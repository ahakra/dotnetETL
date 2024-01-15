using Microsoft.EntityFrameworkCore;
using DataSource.Entities;

public class RepositoryContext:DbContext {
   public RepositoryContext(DbContextOptions options) : base(options) { }
    public DbSet<Adapter> Adapters { get; set; }
    public DbSet<Datasource> Datasources { get; set; }

   
}