//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Kursovaya
{
    using System;
    using System.Collections.Generic;
    
    public partial class tasks
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tasks()
        {
            this.reports = new HashSet<reports>();
        }
    
        public int ID { get; set; }
        public string taskname { get; set; }
        public string description { get; set; }
        public System.DateTime date { get; set; }
        public int empID { get; set; }
        public Nullable<bool> expired { get; set; }
        public Nullable<bool> verification { get; set; }
    
        public virtual emp emp { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<reports> reports { get; set; }
    }
}
