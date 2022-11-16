using FileExploreProject.ConfigEnv;
using FileExploreProject.Data;
using FileExploreProject.Interfaces;
using FileExploreProject.Models;
using Microsoft.EntityFrameworkCore;

namespace FileExploreProject.Services
{
    public class IMyFiles : InterfaceFiles<RotDir>
    {
        public string ruta = @"C:\Users\chism\OneDrive\Desktop\MyFiles";

        private DbContextPostgres Dbpostgres;

        public IMyFiles(DbContextPostgres postgres)
        {
            Dbpostgres = postgres;
        }

        public List<RotDir> File()
        {
            var result = Dbpostgres.rotDirs.ToList();
            return result;
        }
    }
}
