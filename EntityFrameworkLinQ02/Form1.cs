using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityFrameworkLinQ02
{
    public partial class Form1 : Form
    {
        private int offset; // desplazamiento
        private int pagesize;
        private int totalfils;

        public Form1()
        {
            InitializeComponent();
            offset = 0;
            pagesize = 20;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Inicio();
            PintaGrilla();
        }

        private void PintaGrilla()
        {
            using (var db = new ModelPeru02())
            {
                DataTable table = CreaGrilla(new string[] { "Departamentos", "Provincias", "Distritos" });

                var query = (from dist in db.distritos
                             orderby dist.provincias.departamentos.departamento,
                             dist.provincias.provincia
                             select dist).Skip(offset).Take(pagesize);
                            
                foreach (var fil in query)
                {
                    table.Rows.Add(fil.provincias.departamentos.departamento, fil.provincias.provincia, fil.distrito);
                }

                dataGridView1.DataSource = table;

                dataGridView1.DataSource = table;
                label1.Text = pagesize + " filas a partir del registro " + offset;
            }
        }

        private void Inicio()
        {
            using (var db = new ModelPeru02())
            {
                var query = (from d in db.distritos select d).ToList();
                totalfils = query.Count;
                label2.Text = "Cantidad de registros: " + totalfils;
            }
        }

        private DataTable CreaGrilla(string[] titulos)
        {
            DataTable tabla = new DataTable();

            foreach (string t in titulos)
            {
                tabla.Columns.Add(t, System.Type.GetType("System.String"));
            }
            return tabla;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            offset = 0;
            PintaGrilla();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            offset -= 20;

            if (offset < 0)
            {
                offset += 20;
                MessageBox.Show("No hay más páginas a la izquierda");
            }
            else
            {
                PintaGrilla();
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            offset += 20;

            if (offset > totalfils)
            {
                offset -= 20;
                MessageBox.Show("No hay más páginas a la derecha");
            }
            else
            {
                PintaGrilla();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            offset = totalfils % pagesize == 0 ? 
                    totalfils - pagesize : 
                    totalfils - totalfils % pagesize;
            PintaGrilla();
        }
    }
}
