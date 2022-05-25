namespace EntityFrameworkLinQ02
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class distritos
    {
        [Key]
        public int iddistrito { get; set; }

        public int idprovincia { get; set; }

        [Required]
        [StringLength(50)]
        public string distrito { get; set; }

        public virtual provincias provincias { get; set; }
    }
}
