//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Luiskart.Compartido.Modelos
{
    using System;
    using System.Collections.Generic;
    
    public partial class Anime
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Anime()
        {
            this.Personajes = new HashSet<Personaje>();
        }
    
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int GeneroId { get; set; }
        public System.DateTime FechaEstreno { get; set; }
        public byte[] Portada { get; set; }
    
        public virtual Genero Genero { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Personaje> Personajes { get; set; }
    }
}
