namespace E_projektService3
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Franvaro")]
    public partial class Franvaro
    {
        [Key]
        public int ReferensID { get; set; }

        [StringLength(50)]
        public string fNamn { get; set; }

        [StringLength(50)]
        public string eNamn { get; set; }

        [StringLength(120)]
        public string Adress { get; set; }

        public int? Telefonnummer { get; set; }

        [Column("E-post")]
        [StringLength(100)]
        public string E_post { get; set; }

        public int AnstallningsID { get; set; }

        [StringLength(150)]
        public string FranvaroOrsak { get; set; }

        [StringLength(50)]
        public string Tid { get; set; }

        [StringLength(50)]
        public string Datum { get; set; }

        [StringLength(50)]
        public string Status { get; set; }
    }
}
