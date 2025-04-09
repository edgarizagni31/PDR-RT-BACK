using Microsoft.EntityFrameworkCore;
using EmployeeApi.Domain.Entities;


namespace EmployeeApi.Infrastructure.Data
{
  public class EmployeeDbContext : DbContext
  {
    public DbSet<AFP> Afps { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Job> Jobs { get; set; }
    public DbSet<Employee> Employees { get; set; }

    public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options)
    {
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.Entity<Employee>(entity =>
      {
        entity.HasKey(e => e.Id);

        entity.HasOne(e => e.Job)
          .WithMany(j => j.Employees)
          .HasForeignKey(e => e.JobId)
          .OnDelete(DeleteBehavior.Restrict);

        entity.HasOne(e => e.Afp)
          .WithMany(a => a.Employees)
          .HasForeignKey(e => e.AfpId)
          .OnDelete(DeleteBehavior.Restrict);

        entity.Property(e => e.ContractDate).HasColumnType("datetime2");

        entity.Property(e => e.BirthDate).HasColumnType("datetime2");

        entity.Property(e => e.Salary).HasColumnType("decimal(10,2)");

        entity.Property(e => e.Status).HasDefaultValue(1);

        entity.Property(e => e.FirstName).IsRequired();

        entity.Property(e => e.LastName).IsRequired();


        entity.ToTable("Employees", tb => tb.HasTrigger("Salary_Update"));
        entity.ToTable("Employees", tb => tb.HasTrigger("Insert_Employee"));
        entity.ToTable("Employees", tb => tb.HasTrigger("Update_Employee"));
        entity.ToTable("Employees", tb => tb.HasTrigger("Delete_Employee"));
  

      });



      modelBuilder.Entity<Job>(entity =>
      {
        entity.HasKey(j => j.Id);

        entity.Property(j => j.Name).IsRequired();

        entity.HasOne(j => j.Deparment)
          .WithMany(d => d.Jobs)
          .HasForeignKey(j => j.DeparmentId)
          .OnDelete(DeleteBehavior.Restrict);
      });

      modelBuilder.Entity<Department>(entity =>
      {
        entity.HasKey(d => d.Id);

        entity.Property(d => d.Name).IsRequired();
      });

      modelBuilder.Entity<AFP>(entity =>
      {
        entity.HasKey(a => a.Id);

        entity.Property(a => a.Name).IsRequired();
      });

      modelBuilder.Entity<SalaryHistory>(entity =>
      {
        entity.HasKey(sh => sh.Id);

        entity.HasOne(sh => sh.Employee)
          .WithMany(e => e.SalaryHistories)
          .HasForeignKey(sh => sh.EmployeeId)
          .OnDelete(DeleteBehavior.Restrict);

        entity.Property(sh => sh.OldSalary).HasColumnType("decimal(10,2)");

        entity.Property(sh => sh.NewSalary).HasColumnType("decimal(10,2)");

        entity.Property(sh => sh.UpdatedAt).HasColumnType("datetime2").HasDefaultValueSql("GETDATE()");
      });

      modelBuilder.Entity<Audit>(entity =>
      {
        entity.HasKey(a => a.Id);

        entity.Property(a => a.Timestamp).HasColumnType("datetime2").HasDefaultValueSql("GETDATE()");

        entity.Property(a => a.OldValue).HasMaxLength(int.MaxValue);

        entity.Property(a => a.NewValue).HasMaxLength(int.MaxValue);
      });
    }
  }
}
