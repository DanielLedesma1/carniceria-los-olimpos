//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Olimpos.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class clientes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public clientes()
        {
            this.ventas = new HashSet<ventas>();
        }
    
        public int id_cliente { get; set; }
        public Nullable<int> tipodoc_cliente { get; set; }
        public string doc_cliente { get; set; }
        public string nom_cliente { get; set; }
        public string apell_cliente { get; set; }
        public string contacto_cliente { get; set; }
        public string genero_cliente { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ventas> ventas { get; set; }
    }
}
