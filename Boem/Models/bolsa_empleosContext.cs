using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Boem.Models
{
    public partial class bolsa_empleosContext : DbContext
    {
        public bolsa_empleosContext()
        {
        }

        public bolsa_empleosContext(DbContextOptions<bolsa_empleosContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<JobPosting> JobPosting { get; set; }
        public virtual DbSet<JobType> JobType { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserTypes> UserTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(base.Database.GetDbConnection());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("category");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasColumnName("category_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<JobPosting>(entity =>
            {
                entity.ToTable("job_posting");

                entity.Property(e => e.JobPostingId).HasColumnName("job_posting_id");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.Company)
                    .IsRequired()
                    .HasColumnName("company")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreationDate)
                    .HasColumnName("creation_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.JobType).HasColumnName("job_type");

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasColumnName("location")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Logo)
                    .HasColumnName("logo")
                    .HasColumnType("image");

                entity.Property(e => e.PersonalId).HasColumnName("personal_id");

                entity.Property(e => e.Position)
                    .IsRequired()
                    .HasColumnName("position")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Url)
                    .HasColumnName("url")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.JobPosting)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_job_posting_category");

                entity.HasOne(d => d.JobTypeNavigation)
                    .WithMany(p => p.JobPosting)
                    .HasForeignKey(d => d.JobType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_job_posting_job_type");

                entity.HasOne(d => d.Personal)
                    .WithMany(p => p.JobPosting)
                    .HasForeignKey(d => d.PersonalId)
                    .HasConstraintName("FK_job_posting_user");
            });

            modelBuilder.Entity<JobType>(entity =>
            {
                entity.ToTable("job_type");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.PersonalId);

                entity.ToTable("user");

                entity.Property(e => e.PersonalId).HasColumnName("personal_id");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.UserNavigation)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_user_user_types");
            });

            modelBuilder.Entity<UserTypes>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("user_types");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.UserType)
                    .IsRequired()
                    .HasColumnName("user_type")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
