using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace interclasse.Models
{
    public partial class apidbContext : DbContext
    {
        public apidbContext()
        {
        }

        public apidbContext(DbContextOptions<apidbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbAtor> TbAtor { get; set; }
        public virtual DbSet<TbDiretor> TbDiretor { get; set; }
        public virtual DbSet<TbFilme> TbFilme { get; set; }
        public virtual DbSet<TbFilmeAtor> TbFilmeAtor { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseMySql("server=localhost;user id=root;password=1234;database=apidb", x => x.ServerVersion("5.7.30-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TbAtor>(entity =>
            {
                entity.HasKey(e => e.IdAtor)
                    .HasName("PRIMARY");

                entity.Property(e => e.NmAtor)
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");
            });

            modelBuilder.Entity<TbDiretor>(entity =>
            {
                entity.HasKey(e => e.IdDiretor)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.IdFilme)
                    .HasName("id_filme");

                entity.Property(e => e.NmDiretor)
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.HasOne(d => d.IdFilmeNavigation)
                    .WithMany(p => p.TbDiretor)
                    .HasForeignKey(d => d.IdFilme)
                    .HasConstraintName("tb_diretor_ibfk_1");
            });

            modelBuilder.Entity<TbFilme>(entity =>
            {
                entity.HasKey(e => e.IdFilme)
                    .HasName("PRIMARY");

                entity.Property(e => e.DsGenero)
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.NmFilme)
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");
            });

            modelBuilder.Entity<TbFilmeAtor>(entity =>
            {
                entity.HasKey(e => e.IdFilmeAtor)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.IdAtor)
                    .HasName("id_ator");

                entity.HasIndex(e => e.IdFilme)
                    .HasName("id_filme");

                entity.Property(e => e.NmPersonagem)
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.HasOne(d => d.IdAtorNavigation)
                    .WithMany(p => p.TbFilmeAtor)
                    .HasForeignKey(d => d.IdAtor)
                    .HasConstraintName("tb_filme_ator_ibfk_2");

                entity.HasOne(d => d.IdFilmeNavigation)
                    .WithMany(p => p.TbFilmeAtor)
                    .HasForeignKey(d => d.IdFilme)
                    .HasConstraintName("tb_filme_ator_ibfk_1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
