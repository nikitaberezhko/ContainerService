using Microsoft.EntityFrameworkCore;
using Container = Domain.Container;
using Type = Domain.Type;

namespace Persistence.EntityFramework;

/// <summary>
/// Контекст для работы с EFCore
/// </summary>
public class DataContext : DbContext
{
	public DbSet<Container> Containers { get; set; }
	
	public DataContext(DbContextOptions<DataContext> options) : base(options) { }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => 
		optionsBuilder.UseLazyLoadingProxies();

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Container>().Property(x => x.Id).HasColumnName("id");
		modelBuilder.Entity<Container>().Property(x => x.IsoNumber).HasColumnName("iso_number");
		modelBuilder.Entity<Container>().Property(x => x.TypeId).HasColumnName("type_id");
		modelBuilder.Entity<Container>().Property(x => x.IsEngaged).HasColumnName("is_engaged");
		modelBuilder.Entity<Container>().Property(x => x.EngagedUntil).HasColumnName("engaged_until");
		modelBuilder.Entity<Container>().Property(x => x.IsDeleted).HasColumnName("is_deleted");
		
		modelBuilder.Entity<Type>().Property(x => x.Id).HasColumnName("id");
		modelBuilder.Entity<Type>().Property(x => x.Name).HasColumnName("name");
		modelBuilder.Entity<Type>().Property(x => x.PricePerDay).HasColumnName("price_per_day");
		modelBuilder.Entity<Type>().Property(x => x.IsDeleted).HasColumnName("is_deleted");
	}
}