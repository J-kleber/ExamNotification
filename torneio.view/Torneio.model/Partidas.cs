//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Torneio.model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Partidas
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Partidas()
        {
            this.Escalacoes = new HashSet<Escalacoes>();
        }
    
        public int ID { get; set; }
        public int IDTorneio { get; set; }
        public int IDTime1 { get; set; }
        public int IDTime2 { get; set; }
        public int Rodada { get; set; }
        public int PlacarTime1 { get; set; }
        public int PlacarTime2 { get; set; }
        public System.DateTime DataHora { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Escalacoes> Escalacoes { get; set; }
        public virtual Times Times { get; set; }
        public virtual Times Times1 { get; set; }
        public virtual Torneios Torneios { get; set; }
    }
}