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
    
    public partial class Jogadores
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Jogadores()
        {
            this.Escalacoes = new HashSet<Escalacoes>();
        }
    
        public int ID { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Nacionalidade { get; set; }
        public System.DateTime DataNascimento { get; set; }
        public int IDTime { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Escalacoes> Escalacoes { get; set; }
        public virtual Times Times { get; set; }
    }
}