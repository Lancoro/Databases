using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace LehaLab3_1
{
    public partial class SiteContext : DbContext
    {
        public SiteContext()
        {
        }

        public SiteContext(DbContextOptions<SiteContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cabinet> Cabinets { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Leader> Leaders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Site;Username=postgres;Password=qwerty");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Russian_Russia.1251");

            modelBuilder.Entity<Cabinet>(entity =>
            {
                entity.ToTable("Cabinet");

                entity.HasIndex(e => e.CourseId, "fki_course_id");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.CourseId).HasColumnName("course_id");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Cabinets)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("course_id");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Cabinet)
                    .HasForeignKey<Cabinet>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("id");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("Client");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Email)
                    .HasColumnType("character varying")
                    .HasColumnName("email");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.ToTable("Company");

                entity.HasIndex(e => e.LeaderId, "fki_leader_id");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.CompanyCountry)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("company_country");

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("company_name");

                entity.Property(e => e.LeaderId).HasColumnName("leader_id");

                entity.HasOne(d => d.Leader)
                    .WithMany(p => p.Companies)
                    .HasForeignKey(d => d.LeaderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("leader_id");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("Course");

                entity.HasIndex(e => e.CompanyId, "fki_company_id");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.CompanyId).HasColumnName("company_id");

                entity.Property(e => e.CourseName)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("course_name");

                entity.Property(e => e.Language)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("language");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("company_id");
            });

            modelBuilder.Entity<Leader>(entity =>
            {
                entity.ToTable("Leader");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
