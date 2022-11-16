using FileExploreProject.Models;
using Microsoft.EntityFrameworkCore;

namespace FileExploreProject.Data
{
    public class DbContextPostgres : DbContext
    {
        public DbContextPostgres(DbContextOptions<DbContextPostgres> options) : base(options) { }

        public DbSet<RotDir> rotDirs { get; set; }
        public DbSet<Usuario> usuarios { get; set; }
        public DbSet<Directoryy> directoryys { get; set; }
        public DbSet<Files> Filesfiles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)  
        {  
            base.OnModelCreating(builder);  
        }  
  
        public override int SaveChanges()  
        {  
            ChangeTracker.DetectChanges();  
            return base.SaveChanges();  
        } 
    }
}
