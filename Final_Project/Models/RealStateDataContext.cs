using Microsoft.EntityFrameworkCore;

namespace Final_Project.Models
{
    public class RealStateDataContext : DbContext
    {
        public DbSet<Property> Properties { get; set; }
        public DbSet<PropertyType> PropertyTypes { get; set; }
        public DbSet<PropertyStatus> PropertyStatuses { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Client> Clients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=RealStateDataContext;Trusted_Connection=True;TrustServerCertificate=true;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Remove pluralizing table names
            modelBuilder.Entity<Property>().ToTable("Property");
            modelBuilder.Entity<PropertyType>().ToTable("PropertyType");
            modelBuilder.Entity<PropertyStatus>().ToTable("PropertyStatus");
            modelBuilder.Entity<Employee>().ToTable("Employee");
            modelBuilder.Entity<Contract>().ToTable("Contract");
            modelBuilder.Entity<Client>().ToTable("Client");

            // Configure relationships and constraints using Fluent API
            modelBuilder.Entity<Property>()
                .HasOne(p => p.PropertyType)
                .WithMany()
                .HasForeignKey(p => p.PropertyTypeId);

            modelBuilder.Entity<Property>()
                .HasOne(p => p.PropertyStatus)
                .WithMany()
                .HasForeignKey(p => p.PropertyStatusId);

            modelBuilder.Entity<Property>()
                .HasOne(p => p.Employee)
                .WithMany()
                .HasForeignKey(p => p.EmployeeId);

            modelBuilder.Entity<Contract>()
                .HasOne(c => c.Property)
                .WithMany()
                .HasForeignKey(c => c.PropertyId);

            modelBuilder.Entity<Contract>()
                .HasOne(c => c.Employee)
                .WithMany()
                .HasForeignKey(c => c.EmployeeId);

            modelBuilder.Entity<Contract>()
                .HasOne(c => c.Client)
                .WithMany()
                .HasForeignKey(c => c.ClientId);
        }
    }
}
