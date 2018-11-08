namespace Desktop_Tourism.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class client_info
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [Required]
        public string surname { get; set; }

        [Required]
        public string name { get; set; }

        public string patronymic { get; set; }

        [Column(TypeName = "date")]
        public DateTime? birthday { get; set; }

        public int? id_photo { get; set; }

        public virtual client client { get; set; }

        public virtual data data { get; set; }
    }
}
