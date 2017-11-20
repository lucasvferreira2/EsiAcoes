namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Usuario")]
    public partial class Usuario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Usuario()
        {
            Ativo_Monitorados = new HashSet<Ativo_Monitorados>();
            Ativo_Obtidos = new HashSet<Ativo_Obtidos>();
        }

        public int ID { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(10)]
        public string Senha { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ativo_Monitorados> Ativo_Monitorados { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ativo_Obtidos> Ativo_Obtidos { get; set; }
    }
}
