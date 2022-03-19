using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using DoNotBuyThisApp.Data.Models;

#nullable disable

namespace DoNotBuyThisApp.Data
{
    public partial class ProjectContext : DbContext
    {
        public ProjectContext()
        {
        }

        public ProjectContext(DbContextOptions<ProjectContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Constant> Constants { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeeSalary> EmployeeSalaries { get; set; }
        public virtual DbSet<Salary> Salaries { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;User=sa;Password=Admin0099;Database=Project");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Constant>(entity =>
            {
                entity.ToTable("Constant");

                entity.HasIndex(e => e.Name, "UQ__Constant__737584F6286606C2")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.LiteralValue)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.HasIndex(e => new { e.FirstName, e.LastName }, "U_Name")
                    .IsUnique();

                entity.Property(e => e.BonusGrossSalary)
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Deductions)
                    .HasColumnType("money")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GrossSalary).HasColumnType("money");

                entity.Property(e => e.JobTitle)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PayRise).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<EmployeeSalary>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("EmployeeSalaries");

                entity.Property(e => e.BonusGrossSalary).HasColumnType("money");

                entity.Property(e => e.CAS)
                    .HasColumnType("money")
                    .HasColumnName("CAS");

                entity.Property(e => e.CASS)
                    .HasColumnType("money")
                    .HasColumnName("CASS");

                entity.Property(e => e.Deductions).HasColumnType("money");

                entity.Property(e => e.EmitedAt).HasColumnType("date");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ForMonth).HasColumnType("date");

                entity.Property(e => e.GrossSalary).HasColumnType("money");

                entity.Property(e => e.JobTitle)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NetSalary).HasColumnType("money");

                entity.Property(e => e.Tax).HasColumnType("money");

                entity.Property(e => e.TotalGrossSalary).HasColumnType("money");

                entity.Property(e => e.TotalTaxableSalary).HasColumnType("money");
            });

            modelBuilder.Entity<Salary>(entity =>
            {
                entity.ToTable("Salary");

                entity.HasIndex(e => new { e.EmployeeId, e.ForMonth }, "U_EmployeeMonth")
                    .IsUnique();

                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Cas)
                    .HasColumnType("money")
                    .HasColumnName("CAS");

                entity.Property(e => e.Cass)
                    .HasColumnType("money")
                    .HasColumnName("CASS");

                entity.Property(e => e.EmitedAt)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ForMonth).HasColumnType("date");

                entity.Property(e => e.NetSalary).HasColumnType("money");

                entity.Property(e => e.Tax).HasColumnType("money");

                entity.Property(e => e.TotalGrossSalary).HasColumnType("money");

                entity.Property(e => e.TotalTaxableSalary).HasColumnType("money");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Salaries)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Salary__Employee__2F10007B");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
