using FileExploreProject.Models.SqliteModels;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace FileExploreProject.Data
{
    public class DbContextSqlite : DbContext
    {
        private string _databaseName = "dbSqlite.db";

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite(
                connectionString: "Filename=" + _databaseName,
                options =>
                {
                    options.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
                }
            );
            base.OnConfiguring(options);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsuariosModels>().HasKey(p => new { p.Id });
        }

        public DbSet<UsuariosModels> Usuarios { get; set; }
    }
}
