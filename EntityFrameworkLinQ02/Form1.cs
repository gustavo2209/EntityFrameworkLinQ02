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
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

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
            using (var db = new ModelPeru02())
            {
                DataTable table = CreaGrilla(new string[] { "Departamentos", "Provincias", "Distritos" });

                var query = from a in db.departamentos
                            join n in db.provincias on a.iddepartamento equals n.iddepartamento
                            join d in db.distritos on n.idprovincia equals d.idprovincia
                            select new
                            {
                                nombre = a.departamento,
                                nota = n.provincia,
                                dis = d.distrito
                            };

                foreach (var fil in query)
                {
                    table.Rows.Add(fil.nombre, fil.nota, fil.dis);
                }

                dataGridView1.DataSource = table;

            }
        }
    }
}
