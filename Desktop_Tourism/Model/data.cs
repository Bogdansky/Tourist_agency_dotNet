namespace Desktop_Tourism.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class data
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public data()
        {
            client_info = new HashSet<client_info>();
            resort = new HashSet<resort>();
        }

        public int id { get; set; }

        [Column("data")]
        [Required]
        public byte[] data1 { get; set; }

        public Guid DocGUID { get; set; }

        [Required]
        [StringLength(260)]
        public string name { get; set; }

        [StringLength(8)]
        public string type { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<client_info> client_info { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<resort> resort { get; set; }
    }
}
