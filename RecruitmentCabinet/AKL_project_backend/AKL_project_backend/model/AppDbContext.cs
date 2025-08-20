using AKL_project_backend.model;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AKL_project_backend.model
{
    
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }
        public DbSet<Recruteur> Recruteur { get; set; }
        public DbSet<Reclamation> Reclamation { get; set; }
        public DbSet<Offre> offre{ get; set; }
        public DbSet<Langues> langue { get; set; }
        public DbSet<Formations> Formations { get; set; }
        public DbSet<ExperienceProf> Experienceprof { get; set; }
        public DbSet<CV> CV { get; set; }
        public DbSet<Condidat> condidat { get; set; }
        public DbSet<Competences> competences { get; set; }
        public DbSet<Atelier>  Atelier { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<PermisConduit> Permis { get; set; }



        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Définir le nom des tables pour chaque entité
            modelBuilder.Entity<Recruteur>().ToTable("Recruteurs");
            modelBuilder.Entity<Reclamation>().ToTable("Reclamations");
            modelBuilder.Entity<Offre>().ToTable("Offres");
            modelBuilder.Entity<Langues>().ToTable("Langues");
            modelBuilder.Entity<Formations>().ToTable("Formations");
            modelBuilder.Entity<ExperienceProf>().ToTable("ExperiencesProfessionnelles");
            modelBuilder.Entity<CV>().ToTable("CVs");
            modelBuilder.Entity<Condidat>().ToTable("Condidats");
            modelBuilder.Entity<Competences>().ToTable("Competences");
            modelBuilder.Entity<Atelier>().ToTable("Ateliers");
            modelBuilder.Entity<Admin>().ToTable("Admins");
            modelBuilder.Entity<PermisConduit>().ToTable("Permis");


            // Relation One-to-One entre Condidat et CV
            modelBuilder.Entity<Condidat>()
                .HasOne(c => c.Cv)  // Propriété de navigation dans Condidat
                .WithOne(cv => cv.condidat)  // Propriété de navigation dans CV
                .HasForeignKey<CV>(cv => cv.condidatId);  // Clé étrangère dans CV

            // Relation One-to-Many entre Recruteur et Offre
            modelBuilder.Entity<Recruteur>()
                .HasMany(r => r.offres)  // Propriété de navigation dans Recruteur
                .WithOne(o => o.RECRUTEUR)  // Propriété de navigation dans Offre
                .HasForeignKey(o => o.RECRUTEURID);  // Clé étrangère dans Offre

            // Relations One-to-Many entre CV et Formations, Competences, Langues, ExperienceProf
            modelBuilder.Entity<CV>()
                .HasMany(cv => cv.Formations)  // Propriété de navigation dans CV
                .WithOne(f => f.CV)  // Propriété de navigation dans Formations
                .HasForeignKey(f => f.CvId);  // Clé étrangère dans Formations

            modelBuilder.Entity<CV>()
                .HasMany(cv => cv.competences)  // Propriété de navigation dans CV
                .WithOne(c => c.CV)  // Propriété de navigation dans Competences
                .HasForeignKey(c => c.CvId);  // Clé étrangère dans Competences

            modelBuilder.Entity<CV>()
                .HasMany(cv => cv.Langues)  // Propriété de navigation dans CV
                .WithOne(l => l.CV)  // Propriété de navigation dans Langues
                .HasForeignKey(l => l.CvId);  // Clé étrangère dans Langues

            modelBuilder.Entity<CV>()
                .HasMany(cv => cv.ExperienceProfs)  // Propriété de navigation dans CV
                .WithOne(e => e.CV)  // Propriété de navigation dans ExperienceProf
                .HasForeignKey(e => e.CvId);  // Clé étrangère dans ExperienceProf

        modelBuilder.Entity<CV>()
                .HasMany(cv => cv.PermisConduit)  // Propriété de navigation dans CV
                .WithOne(e => e.CV)  // Propriété de navigation dans ExperienceProf
                .HasForeignKey(e => e.CvId);  // Clé étrangère dans ExperienceProf
    }


}
    }

