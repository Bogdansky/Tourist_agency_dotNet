namespace Desktop_Tourism.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("manager")]
    public partial class manager
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public manager()
        {
            tour = new HashSet<tour>();
        }

        public int id { get; set; }

        [Required]
        public string surname { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        public string patronymic { get; set; }

        [Required]
        [MaxLength(32)]
        public byte[] password { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tour> tour { get; set; }
    }
}
