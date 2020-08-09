using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Test.Models
{
    public partial class BazaDiplomskiContext : DbContext
    {
        public BazaDiplomskiContext()
        {
        }

        public BazaDiplomskiContext(DbContextOptions<BazaDiplomskiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Grad> Grad { get; set; }
        public virtual DbSet<Igra> Igra { get; set; }
        public virtual DbSet<Igrac> Igrac { get; set; }
        public virtual DbSet<Karta> Karta { get; set; }
        public virtual DbSet<Kupuje> Kupuje { get; set; }
        public virtual DbSet<LicnaNagrada> LicnaNagrada { get; set; }
        public virtual DbSet<Nagrada> Nagrada { get; set; }
        public virtual DbSet<Navijac> Navijac { get; set; }
        public virtual DbSet<Odrzava> Odrzava { get; set; }
        public virtual DbSet<Posecuje> Posecuje { get; set; }
        public virtual DbSet<Stadion> Stadion { get; set; }
        public virtual DbSet<Sudija> Sudija { get; set; }
        public virtual DbSet<Tim> Tim { get; set; }
        public virtual DbSet<TimskaNagrada> TimskaNagrada { get; set; }
        public virtual DbSet<Utakmica> Utakmica { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost;Database=BazaDiplomski;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Grad>(entity =>
            {
                entity.Property(e => e.GradId)
                    .HasColumnName("GradID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Drzava)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Ime)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Igra>(entity =>
            {
                entity.HasKey(e => new { e.TimTimId, e.UtakmicaUtakmicaId })
                    .HasName("IgraPK");

                entity.Property(e => e.TimTimId).HasColumnName("Tim_TimID");

                entity.Property(e => e.UtakmicaUtakmicaId).HasColumnName("Utakmica_UtakmicaID");

                entity.Property(e => e.SudijaSudijaId).HasColumnName("Sudija_SudijaID");

                entity.HasOne(d => d.SudijaSudija)
                    .WithMany(p => p.Igra)
                    .HasForeignKey(d => d.SudijaSudijaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Igra_Sudija_FK");

                entity.HasOne(d => d.TimTim)
                    .WithMany(p => p.Igra)
                    .HasForeignKey(d => d.TimTimId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Igra_Tim_FK");

                entity.HasOne(d => d.UtakmicaUtakmica)
                    .WithMany(p => p.Igra)
                    .HasForeignKey(d => d.UtakmicaUtakmicaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Igra_Utakmica_FK");
            });

            modelBuilder.Entity<Igrac>(entity =>
            {
                entity.Property(e => e.IgracId)
                    .HasColumnName("IgracID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Ime)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Prezime)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TimTimId).HasColumnName("Tim_TimId");

                entity.HasOne(d => d.TimTim)
                    .WithMany(p => p.Igrac)
                    .HasForeignKey(d => d.TimTimId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Igrac_Tim_FK");
            });

            modelBuilder.Entity<Karta>(entity =>
            {
                entity.Property(e => e.KartaId)
                    .HasColumnName("KartaID")
                    .ValueGeneratedNever();

                entity.Property(e => e.OdrzavaStadionId).HasColumnName("Odrzava_StadionID");

                entity.Property(e => e.OdrzavaUtakmicaId).HasColumnName("Odrzava_UtakmicaID");

                entity.HasOne(d => d.Odrzava)
                    .WithMany(p => p.Karta)
                    .HasForeignKey(d => new { d.OdrzavaUtakmicaId, d.OdrzavaStadionId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Karta_Odrzava_FK");
            });

            modelBuilder.Entity<Kupuje>(entity =>
            {
                entity.HasKey(e => new { e.KartaKartaId, e.NavijacNavijacId })
                    .HasName("Kupuje_PK");

                entity.Property(e => e.KartaKartaId).HasColumnName("Karta_KartaID");

                entity.Property(e => e.NavijacNavijacId).HasColumnName("Navijac_NavijacID");

                entity.HasOne(d => d.KartaKarta)
                    .WithMany(p => p.Kupuje)
                    .HasForeignKey(d => d.KartaKartaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Kupuje_Karta_FK");

                entity.HasOne(d => d.NavijacNavijac)
                    .WithMany(p => p.Kupuje)
                    .HasForeignKey(d => d.NavijacNavijacId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Kupuje_Navijac_FK");
            });

            modelBuilder.Entity<LicnaNagrada>(entity =>
            {
                entity.HasKey(e => e.NagradaId)
                    .HasName("LicnaNagrada_PK");

                entity.Property(e => e.NagradaId)
                    .HasColumnName("NagradaID")
                    .ValueGeneratedNever();

                entity.Property(e => e.IgracIgracId).HasColumnName("Igrac_IgracID");

                entity.Property(e => e.VrstaNagrade)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.IgracIgrac)
                    .WithMany(p => p.LicnaNagrada)
                    .HasForeignKey(d => d.IgracIgracId)
                    .HasConstraintName("LicnaNagrada_Igrac_FK");

                entity.HasOne(d => d.Nagrada)
                    .WithOne(p => p.LicnaNagrada)
                    .HasForeignKey<LicnaNagrada>(d => d.NagradaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("LicnaNagrada_Nagrada_FK");
            });

            modelBuilder.Entity<Nagrada>(entity =>
            {
                entity.Property(e => e.NagradaId)
                    .HasColumnName("NagradaID")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<Navijac>(entity =>
            {
                entity.Property(e => e.NavijacId)
                    .HasColumnName("NavijacID")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<Odrzava>(entity =>
            {
                entity.HasKey(e => new { e.UtakmicaUtakmicaId, e.StadionStadionId })
                    .HasName("Odrzava_PK");

                entity.Property(e => e.UtakmicaUtakmicaId).HasColumnName("Utakmica_UtakmicaID");

                entity.Property(e => e.StadionStadionId).HasColumnName("Stadion_StadionID");

                entity.HasOne(d => d.StadionStadion)
                    .WithMany(p => p.Odrzava)
                    .HasForeignKey(d => d.StadionStadionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Odrzava_Stadion_FK");

                entity.HasOne(d => d.UtakmicaUtakmica)
                    .WithMany(p => p.Odrzava)
                    .HasForeignKey(d => d.UtakmicaUtakmicaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Odrzava_Utakmica_FK");
            });

            modelBuilder.Entity<Posecuje>(entity =>
            {
                entity.HasKey(e => new { e.KupujeKartaKartaId, e.KupujeNavijacNavijacId, e.OdrzavaUtakmicaId, e.OdrzavaStadionId })
                    .HasName("Posecuje_PKJ");

                entity.Property(e => e.KupujeKartaKartaId).HasColumnName("Kupuje_Karta_KartaID");

                entity.Property(e => e.KupujeNavijacNavijacId).HasColumnName("Kupuje_Navijac_NavijacID");

                entity.Property(e => e.OdrzavaUtakmicaId).HasColumnName("Odrzava_UtakmicaID");

                entity.Property(e => e.OdrzavaStadionId).HasColumnName("Odrzava_StadionID");

                entity.HasOne(d => d.Kupuje)
                    .WithMany(p => p.Posecuje)
                    .HasForeignKey(d => new { d.KupujeKartaKartaId, d.KupujeNavijacNavijacId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Posecuje_Kupuje_FK");

                entity.HasOne(d => d.Odrzava)
                    .WithMany(p => p.Posecuje)
                    .HasForeignKey(d => new { d.OdrzavaUtakmicaId, d.OdrzavaStadionId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Posecuje_Odrzava_FK");
            });

            modelBuilder.Entity<Stadion>(entity =>
            {
                entity.Property(e => e.StadionId)
                    .HasColumnName("StadionID")
                    .ValueGeneratedNever();

                entity.Property(e => e.GradGradId).HasColumnName("Grad_GradID");

                entity.Property(e => e.Ime)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.GradGrad)
                    .WithMany(p => p.Stadion)
                    .HasForeignKey(d => d.GradGradId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Stadion_Grad_FK");
            });

            modelBuilder.Entity<Sudija>(entity =>
            {
                entity.ToTable("sudija");

                entity.Property(e => e.SudijaId)
                    .HasColumnName("SudijaID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Ime)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Prezime)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tim>(entity =>
            {
                entity.Property(e => e.TimId)
                    .HasColumnName("TimID")
                    .ValueGeneratedNever();

                entity.Property(e => e.GradGradId).HasColumnName("Grad_GradId");

                entity.Property(e => e.Ime)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.GradGrad)
                    .WithMany(p => p.Tim)
                    .HasForeignKey(d => d.GradGradId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Tim_Grad_FK");
            });

            modelBuilder.Entity<TimskaNagrada>(entity =>
            {
                entity.HasKey(e => e.NagradaId)
                    .HasName("Timska_Nagrada_PK");

                entity.Property(e => e.NagradaId)
                    .HasColumnName("NagradaID")
                    .ValueGeneratedNever();

                entity.Property(e => e.TimTimId).HasColumnName("Tim_TimID");

                entity.Property(e => e.TipNagrade)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.Nagrada)
                    .WithOne(p => p.TimskaNagrada)
                    .HasForeignKey<TimskaNagrada>(d => d.NagradaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("TimskaNagrada_Nagrada_FK");

                entity.HasOne(d => d.TimTim)
                    .WithMany(p => p.TimskaNagrada)
                    .HasForeignKey(d => d.TimTimId)
                    .HasConstraintName("TimskaNagrada_Tim_FK");
            });

            modelBuilder.Entity<Utakmica>(entity =>
            {
                entity.Property(e => e.UtakmicaId)
                    .HasColumnName("UtakmicaID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Datum).HasColumnType("date");

                entity.Property(e => e.FazaTakmicenja)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Odigrana)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
