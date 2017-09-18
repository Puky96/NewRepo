using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TestAzure.DBModels
{
    public partial class eComplaintsCTX : DbContext
    {
        public virtual DbSet<Area> Area { get; set; }
        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<Brand> Brand { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Equipment> Equipment { get; set; }
        public virtual DbSet<Investigator2Department> Investigator2Department { get; set; }
        public virtual DbSet<LineCoordinator> LineCoordinator { get; set; }
        public virtual DbSet<Qcategory> Qcategory { get; set; }
        public virtual DbSet<Question> Question { get; set; }
        public virtual DbSet<Questions2Reports> Questions2Reports { get; set; }
        public virtual DbSet<Report> Report { get; set; }
        public virtual DbSet<ReportApproval> ReportApproval { get; set; }
        public virtual DbSet<Supplier> Supplier { get; set; }
        public virtual DbSet<Tracking> Tracking { get; set; }
        public virtual DbSet<Zone> Zone { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Data Source=PF0SEPEM-X7\SQLEXPRESS;Initial Catalog=eComplaints;Integrated Security=False;User ID=sa;Password=Parola00;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Area>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Area)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Area_Department");
            });

            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.HasIndex(e => e.UserId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.FullName).HasMaxLength(50);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });
            });

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Equipment>(entity =>
            {
                entity.Property(e => e.Name).IsRequired();

                entity.HasOne(d => d.Zone)
                    .WithMany(p => p.Equipment)
                    .HasForeignKey(d => d.ZoneId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Equipment_Zone");
            });

            modelBuilder.Entity<Investigator2Department>(entity =>
            {
                entity.Property(e => e.InvestigatorId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Investigator2Department)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK_Investigator2Department_Department");

                entity.HasOne(d => d.Investigator)
                    .WithMany(p => p.Investigator2Department)
                    .HasForeignKey(d => d.InvestigatorId)
                    .HasConstraintName("FK_Investigator2Department_Users");
            });

            modelBuilder.Entity<LineCoordinator>(entity =>
            {
                entity.Property(e => e.LineCoordinatorName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Area)
                    .WithMany(p => p.LineCoordinator)
                    .HasForeignKey(d => d.AreaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LineCoordinator_Area");
            });

            modelBuilder.Entity<Qcategory>(entity =>
            {
                entity.ToTable("QCategory");

                entity.Property(e => e.Name).IsRequired();

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Qcategory)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_QCategory_Department");
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.Property(e => e.Question1)
                    .IsRequired()
                    .HasColumnName("Question");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Question)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Questions_QCategory");
            });

            modelBuilder.Entity<Questions2Reports>(entity =>
            {
                entity.HasOne(d => d.Question)
                    .WithMany(p => p.Questions2Reports)
                    .HasForeignKey(d => d.QuestionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Questions2Reports_Question");

                entity.HasOne(d => d.Report)
                    .WithMany(p => p.Questions2Reports)
                    .HasForeignKey(d => d.ReportId)
                    .HasConstraintName("FK_Questions2Reports_Report");
            });

            modelBuilder.Entity<Report>(entity =>
            {
                entity.Property(e => e.BatchNo).HasMaxLength(50);

                entity.Property(e => e.BatchSap)
                    .HasColumnName("BatchSAP")
                    .HasMaxLength(50);

                entity.Property(e => e.DateHour).HasColumnType("datetime");

                entity.Property(e => e.EtiqueteImagePath).IsRequired();

                entity.Property(e => e.Gcas)
                    .IsRequired()
                    .HasColumnName("GCAS")
                    .HasMaxLength(50);

                entity.Property(e => e.IdentitifcationNumber)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ImagePath).IsRequired();

                entity.Property(e => e.LineCoordinator)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Originator)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Po)
                    .IsRequired()
                    .HasColumnName("PO")
                    .HasMaxLength(50);

                entity.Property(e => e.VendorBatch).HasMaxLength(50);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Report)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Report_Department");

                entity.HasOne(d => d.PhenomenaCategoryNavigation)
                    .WithMany(p => p.Report)
                    .HasForeignKey(d => d.PhenomenaCategory)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Report_QCategory");
            });

            modelBuilder.Entity<ReportApproval>(entity =>
            {
                entity.Property(e => e.ApprovalDate).HasColumnType("datetime");

                entity.Property(e => e.Reason).IsRequired();

                entity.HasOne(d => d.Report)
                    .WithMany(p => p.ReportApproval)
                    .HasForeignKey(d => d.ReportId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReportApproval_Report");
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Supplier)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Supplier_Department");
            });

            modelBuilder.Entity<Tracking>(entity =>
            {
                entity.Property(e => e.BlockedMaterialDecision).HasMaxLength(50);

                entity.Property(e => e.BrandSize)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ClaimedDt).HasColumnName("ClaimedDT");

                entity.Property(e => e.ClaimedOfStops).HasColumnName("Claimed#OfStops");

                entity.Property(e => e.ConfirmedDt).HasColumnName("ConfirmedDT");

                entity.Property(e => e.ConfirmedOfStops).HasColumnName("Confirmed#OfStops");

                entity.Property(e => e.DueDate).HasColumnType("datetime");

                entity.Property(e => e.Issue).IsRequired();

                entity.Property(e => e.LotProductionDate).HasColumnType("datetime");

                entity.Property(e => e.Owner)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Report)
                    .WithMany(p => p.Tracking)
                    .HasForeignKey(d => d.ReportId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tracking_Report");

                entity.HasOne(d => d.SupplierNavigation)
                    .WithMany(p => p.Tracking)
                    .HasForeignKey(d => d.Supplier)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tracking_Supplier");
            });

            modelBuilder.Entity<Zone>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Area)
                    .WithMany(p => p.Zone)
                    .HasForeignKey(d => d.AreaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Zone_Area");
            });
        }
    }
}
