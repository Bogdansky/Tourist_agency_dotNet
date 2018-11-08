namespace Desktop_Tourism.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("resort")]
    public partial class resort
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public resort()
        {
            tour = new HashSet<tour>();
        }

        public int id { get; set; }

        [Required]
        public string name { get; set; }

        public int? id_country { get; set; }

        public int? id_video { get; set; }

        public virtual country country { get; set; }

        public virtual data data { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tour> tour { get; set; }
    }
}
