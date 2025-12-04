using GestAproAspNet.Models;
using Microsoft.EntityFrameworkCore;

namespace GestAproAspNet.Data
{
    public class GesApproviDbContext : DbContext
    {
        public GesApproviDbContext(DbContextOptions<GesApproviDbContext> options)
            : base(options)
        {
        }

        public DbSet<Fournisseur> Fournisseurs { get; set; } = null!;
        public DbSet<Article> Articles { get; set; } = null!;
        public DbSet<Approvi> Approvis { get; set; } = null!;
        public DbSet<TransactionApproArticle> TransactionsApproArticle { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
            modelBuilder.Entity<Fournisseur>(entity =>
            {
                entity.ToTable("fournisseurs");

                entity.HasKey(f => f.Id);

                entity.Property(f => f.Nom)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(f => f.Telephone)
                      .HasMaxLength(30);

                entity.Property(f => f.Email)
                      .HasMaxLength(100);
            });

            
            modelBuilder.Entity<Article>(entity =>
            {
                entity.ToTable("articles");

                entity.HasKey(a => a.Id);

                entity.Property(a => a.Libelle)
                      .IsRequired()
                      .HasMaxLength(150);

                entity.Property(a => a.Code)
                      .HasMaxLength(50);
            });

            
            modelBuilder.Entity<Approvi>(entity =>
            {
                entity.ToTable("approvis");

                entity.HasKey(a => a.Id);

                entity.Property(a => a.Reference)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.Property(a => a.DateApprovi)
                      .IsRequired();

                entity.Property(a => a.TotalAmount)
                      .HasColumnType("decimal(18,2)");

                entity.Property(a => a.Observations)
                      .HasMaxLength(500);

                
                entity.HasOne(a => a.Fournisseur)
                      .WithMany(f => f.Approvis)
                      .HasForeignKey(a => a.FournisseurId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            
            modelBuilder.Entity<TransactionApproArticle>(entity =>
            {
                entity.ToTable("transactions_appro_article");

                entity.HasKey(t => t.Id);

                entity.Property(t => t.PrixUnitaire)
                      .HasColumnType("decimal(18,2)");

                entity.Property(t => t.Montant)
                      .HasColumnType("decimal(18,2)");

                
                entity.HasOne(t => t.Article)
                      .WithMany(a => a.Transactions)
                      .HasForeignKey(t => t.ArticleId)
                      .OnDelete(DeleteBehavior.Restrict);

                
                entity.HasOne(t => t.Approvi)
                      .WithMany(a => a.Transactions)
                      .HasForeignKey(t => t.ApproviId)
                      .OnDelete(DeleteBehavior.Cascade);
            });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
            if (!optionsBuilder.IsConfigured)
            {
                
            }
        }
    }
}
