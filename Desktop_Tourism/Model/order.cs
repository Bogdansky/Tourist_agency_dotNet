namespace Desktop_Tourism.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("order")]
    public partial class order
    {
        public int id { get; set; }

        public int? id_client { get; set; }

        public int? id_tour { get; set; }

        public double cost { get; set; }

        [Column(TypeName = "date")]
        public DateTime date_of_sale { get; set; }

        [Column(TypeName = "date")]
        public DateTime date_of_start { get; set; }

        public int? id_adobe { get; set; }

        public virtual adobe adobe { get; set; }

        public virtual client client { get; set; }

        public virtual tour tour { get; set; }
    }
}
