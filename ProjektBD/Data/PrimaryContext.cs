using Microsoft.EntityFrameworkCore;
using ProjektBD.Data.Entities;

namespace ProjektBD.Data
{
	public class PrimaryContext : DbContext
	{
		public PrimaryContext(DbContextOptions options) : base(options)
		{
		}
		public PrimaryContext() : base()
		{
		}

		public DbSet<Employee> Emplyees { get; set; }
		public DbSet<Book> Books { get; set; }
		public DbSet<Reader> Readers { get; set; }
		public DbSet<Rental> Rentals { get; set; }
		public DbSet<Fee> Fees { get; set; }

		/*protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			
			modelBuilder.Entity<Worker>()
				.HasOne(s => s.Department)
				.WithMany(c => c.Workers)
				.HasForeignKey(s => s.DepartmentId);

            modelBuilder.Entity<Worker>()
                .HasOne(s => s.Project)
                .WithMany(c => c.Workers)
                .HasForeignKey(s => s.ProjectId);
        }*/
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source=primary.db");
    }
}
