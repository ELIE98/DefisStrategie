using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DefisStrategie.Models
{
    public partial class moviesContext : DbContext
    {
        public moviesContext()
        {
        }

        public moviesContext(DbContextOptions<moviesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Auteurs> Auteurs { get; set; }
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Films> Films { get; set; }
        public virtual DbSet<Locations> Locations { get; set; }
        public virtual DbSet<Utilisateurs> Utilisateurs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("Host=5.182.33.229;port=5430;Database=movies;Username=postgres;Password=postgres");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Auteurs>(entity =>
            {
                entity.ToTable("auteurs");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Code)
                    .HasColumnName("code")
                    .HasMaxLength(50);

                entity.Property(e => e.DateCreation).HasColumnName("date_creation");

                entity.Property(e => e.DateModification).HasColumnName("date_modification");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.EstActif)
                    .HasColumnName("est_actif")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.Libelle)
                    .HasColumnName("libelle")
                    .HasMaxLength(220);

                entity.Property(e => e.ModifierPar)
                    .HasColumnName("modifier_par")
                    .HasMaxLength(30);

                entity.Property(e => e.Userid)
                    .HasColumnName("userid")
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Categories>(entity =>
            {
                entity.ToTable("categories");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Code)
                    .HasColumnName("code")
                    .HasMaxLength(50);

                entity.Property(e => e.DateCreation).HasColumnName("date_creation");

                entity.Property(e => e.DateModification).HasColumnName("date_modification");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.EstActif)
                    .HasColumnName("est_actif")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.Libelle)
                    .HasColumnName("libelle")
                    .HasMaxLength(220);

                entity.Property(e => e.ModifierPar)
                    .HasColumnName("modifier_par")
                    .HasMaxLength(30);

                entity.Property(e => e.Userid)
                    .HasColumnName("userid")
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Films>(entity =>
            {
                entity.ToTable("films");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AuteurId).HasColumnName("auteur_id");

                entity.Property(e => e.CategorieId).HasColumnName("categorie_id");

                entity.Property(e => e.Code)
                    .HasColumnName("code")
                    .HasMaxLength(50);

                entity.Property(e => e.DateCreation).HasColumnName("date_creation");

                entity.Property(e => e.DateModification).HasColumnName("date_modification");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Duree).HasColumnName("duree");

                entity.Property(e => e.EstActif)
                    .HasColumnName("est_actif")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.EstDisponible)
                    .HasColumnName("est_disponible")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.ModifierPar)
                    .HasColumnName("modifier_par")
                    .HasMaxLength(30);

                entity.Property(e => e.Titre)
                    .HasColumnName("titre")
                    .HasMaxLength(220);

                entity.Property(e => e.Userid)
                    .HasColumnName("userid")
                    .HasMaxLength(30);

                entity.HasOne(d => d.Auteur)
                    .WithMany(p => p.Films)
                    .HasForeignKey(d => d.AuteurId)
                    .HasConstraintName("films_auteur_id_fkey");

                entity.HasOne(d => d.Categorie)
                    .WithMany(p => p.Films)
                    .HasForeignKey(d => d.CategorieId)
                    .HasConstraintName("films_categorie_id_fkey");
            });

            modelBuilder.Entity<Locations>(entity =>
            {
                entity.ToTable("locations");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.DateCreation).HasColumnName("date_creation");

                entity.Property(e => e.DateDebut).HasColumnName("date_debut");

                entity.Property(e => e.DateFin).HasColumnName("date_fin");

                entity.Property(e => e.DateModification).HasColumnName("date_modification");

                entity.Property(e => e.EstActif)
                    .HasColumnName("est_actif")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.FilmId).HasColumnName("film_id");

                entity.Property(e => e.ModifierPar)
                    .HasColumnName("modifier_par")
                    .HasMaxLength(30);

                entity.Property(e => e.Userid)
                    .HasColumnName("userid")
                    .HasMaxLength(30);

                entity.Property(e => e.UtilisateurId).HasColumnName("utilisateur_id");

                entity.HasOne(d => d.Film)
                    .WithMany(p => p.Locations)
                    .HasForeignKey(d => d.FilmId)
                    .HasConstraintName("locations_film_id_fkey");

                entity.HasOne(d => d.Utilisateur)
                    .WithMany(p => p.Locations)
                    .HasForeignKey(d => d.UtilisateurId)
                    .HasConstraintName("locations_utilisateur_id_fkey");
            });

            modelBuilder.Entity<Utilisateurs>(entity =>
            {
                entity.ToTable("utilisateurs");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.AdresseGeographique).HasColumnName("adresse_geographique");

                entity.Property(e => e.DateCreation).HasColumnName("date_creation");

                entity.Property(e => e.DateModification).HasColumnName("date_modification");

                entity.Property(e => e.EstActif)
                    .HasColumnName("est_actif")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.ModifierPar)
                    .HasColumnName("modifier_par")
                    .HasMaxLength(30);

                entity.Property(e => e.Nom)
                    .HasColumnName("nom")
                    .HasMaxLength(200);

                entity.Property(e => e.Prenoms)
                    .HasColumnName("prenoms")
                    .HasMaxLength(255);

                entity.Property(e => e.Telephone)
                    .HasColumnName("telephone")
                    .HasMaxLength(50);

                entity.Property(e => e.Userid)
                    .HasColumnName("userid")
                    .HasMaxLength(30);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
