namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Ativo_Obtidos
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Usuario_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(6)]
        public string Sigla { get; set; }

        public int Quantidade { get; set; }

        [Column(TypeName = "date")]
        public DateTime Data { get; set; }

        [Column(TypeName = "money")]
        public decimal Preco { get; set; }

        public bool Operacao { get; set; }

        public virtual Cotacao Cotacao { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
