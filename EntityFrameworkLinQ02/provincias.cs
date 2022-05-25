namespace EntityFrameworkLinQ02
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class provincias
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public provincias()
        {
            distritos = new HashSet<distritos>();
        }

        [Key]
        public int idprovincia { get; set; }

        public int iddepartamento { get; set; }

        [Required]
        [StringLength(50)]
        public string provincia { get; set; }

        public virtual departamentos departamentos { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<distritos> distritos { get; set; }
    }
}
