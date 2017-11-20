namespace WebApplication1.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model13")
        {
        }

        public virtual DbSet<Ativo_Monitorados> Ativo_Monitorados { get; set; }
        public virtual DbSet<Ativo_Obtidos> Ativo_Obtidos { get; set; }
        public virtual DbSet<Cotacao> Cotacao { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ativo_Monitorados>()
                .Property(e => e.Sigla)
                .IsUnicode(false);

            modelBuilder.Entity<Ativo_Obtidos>()
                .Property(e => e.Sigla)
                .IsUnicode(false);

            modelBuilder.Entity<Ativo_Obtidos>()
                .Property(e => e.Preco)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Cotacao>()
                .Property(e => e.SIGLA)
                .IsUnicode(false);

            modelBuilder.Entity<Cotacao>()
                .Property(e => e.VALOR)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Senha)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Ativo_Monitorados)
                .WithRequired(e => e.Usuario)
                .HasForeignKey(e => e.Usuario_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Ativo_Obtidos)
                .WithRequired(e => e.Usuario)
                .HasForeignKey(e => e.Usuario_ID)
                .WillCascadeOnDelete(false);
        }
    }
}
