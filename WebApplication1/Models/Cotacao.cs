namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Cotacao")]
    public partial class Cotacao
    {
        [Key]
        [StringLength(6)]
        public string SIGLA { get; set; }

        [Column(TypeName = "money")]
        public decimal? VALOR { get; set; }
    }
}
