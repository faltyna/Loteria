//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Loteria
{
    using System;
    using System.Collections.Generic;
    
    public partial class Uczestniks
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Uczestniks()
        {
            this.Nagrodas = new HashSet<Nagrodas>();
        }
    
        public int uczestnikId { get; set; }
        public string imie { get; set; }
        public string nazwisko { get; set; }
        public string pseudonim { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Nagrodas> Nagrodas { get; set; }
    }
}
