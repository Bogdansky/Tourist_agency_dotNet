namespace Desktop_Tourism.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tour")]
    public partial class tour
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tour()
        {
            order = new HashSet<order>();
        }

        public int id { get; set; }

        [Required]
        public string name { get; set; }

        public int duration { get; set; }

        public int? id_resort { get; set; }

        public int? id_manager { get; set; }

        public virtual manager manager { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<order> order { get; set; }

        public virtual resort resort { get; set; }
    }
}
