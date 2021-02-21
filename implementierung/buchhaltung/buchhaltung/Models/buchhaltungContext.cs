using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Shell.Models
{
    public partial class buchhaltungContext : DbContext
    {
        public buchhaltungContext()
        {
        }

        public buchhaltungContext(DbContextOptions<buchhaltungContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Arbeitszeiten> Arbeitszeiten { get; set; }
        public virtual DbSet<Einkauf> Einkauf { get; set; }
        public virtual DbSet<Fixkosten> Fixkosten { get; set; }
        public virtual DbSet<Personal> Personal { get; set; }
        public virtual DbSet<Steuersaetze> Steuersaetze { get; set; }
        public virtual DbSet<Verkauf> Verkauf { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=buchhaltung;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Arbeitszeiten>(entity =>
            {
                entity.HasKey(e => e.IdArbeitszeit)
                    .HasName("PK__Arbeitsz__9EAD877530DC3D93");

                entity.ToTable("Arbeitszeiten");

                entity.Property(e => e.IdArbeitszeit).HasColumnName("ID_Arbeitszeit");

                entity.Property(e => e.Arbeitsstunden).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Datum).HasColumnType("date");

                entity.Property(e => e.IdPersonal).HasColumnName("ID_Personal");

                entity.HasOne(d => d.IdPersonalNavigation)
                    .WithMany(p => p.Arbeitszeitens)
                    .HasForeignKey(d => d.IdPersonal)
                    .HasConstraintName("fk_Personal");
            });

            modelBuilder.Entity<Einkauf>(entity =>
            {
                entity.HasKey(e => e.IdEinkauf)
                    .HasName("PK__Einkauf__874D12AA59D200D5");

                entity.ToTable("Einkauf");

                entity.Property(e => e.IdEinkauf).HasColumnName("ID_Einkauf");

                entity.Property(e => e.BetragNetto)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("Betrag_Netto");

                entity.Property(e => e.Datum).HasColumnType("date");

                entity.Property(e => e.IdSteuersatz).HasColumnName("ID_Steuersatz");

                entity.HasOne(d => d.IdSteuersatzNavigation)
                    .WithMany(p => p.Einkaufs)
                    .HasForeignKey(d => d.IdSteuersatz)
                    .HasConstraintName("fk_SteuersatzEinkauf");
            });

            modelBuilder.Entity<Fixkosten>(entity =>
            {
                entity.HasKey(e => e.IdFixkosten)
                    .HasName("PK__Fixkoste__F15483F9BE51EE09");

                entity.ToTable("Fixkosten");

                entity.Property(e => e.IdFixkosten).HasColumnName("ID_Fixkosten");

                entity.Property(e => e.Betrag).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Bezeichnung).HasMaxLength(50);

                entity.Property(e => e.Datum).HasColumnType("date");
            });

            modelBuilder.Entity<Personal>(entity =>
            {
                entity.HasKey(e => e.IdPersonal)
                    .HasName("PK__Personal__11995ADDFB01ACE5");

                entity.ToTable("Personal");

                entity.Property(e => e.IdPersonal).HasColumnName("ID_Personal");

                entity.Property(e => e.Nachname).HasMaxLength(50);

                entity.Property(e => e.Stundenlohn).HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<Steuersaetze>(entity =>
            {
                entity.HasKey(e => e.IdSteuersatz)
                    .HasName("PK__Steuersa__68EB16F87714C4AD");

                entity.ToTable("Steuersaetze");

                entity.Property(e => e.IdSteuersatz).HasColumnName("ID_Steuersatz");

                entity.Property(e => e.Bezeichnung).HasMaxLength(100);

                entity.Property(e => e.Steuersatz).HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<Verkauf>(entity =>
            {
                entity.HasKey(e => e.IdVerkauf)
                    .HasName("PK__Verkauf__079B1AC20F4B3A43");

                entity.ToTable("Verkauf");

                entity.Property(e => e.IdVerkauf).HasColumnName("ID_Verkauf");

                entity.Property(e => e.BetragNetto)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("Betrag_Netto");

                entity.Property(e => e.Datum).HasColumnType("date");

                entity.Property(e => e.IdSteuersatz).HasColumnName("ID_Steuersatz");

                entity.HasOne(d => d.IdSteuersatzNavigation)
                    .WithMany(p => p.Verkaufs)
                    .HasForeignKey(d => d.IdSteuersatz)
                    .HasConstraintName("fk_SteuersatzVerkauf");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
