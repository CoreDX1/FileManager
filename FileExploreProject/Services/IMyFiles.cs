using FileExploreProject.ConfigEnv;
using FileExploreProject.Data;
using FileExploreProject.Interfaces;
using FileExploreProject.Models;
using FileExploreProject.Models.SqliteModels;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System.Xml.Serialization;

namespace FileExploreProject.Services
{
    public class IMyFiles : InterfaceFiles<ListModels>
    {
        private List<string> AllFiles = new();
        private List<string> AllDirectories = new();
        private ListModels dir = new();
        public string ruta = @"C:\Users\chism\OneDrive\Desktop\MyFiles";
        public DotEnv Dot = new();

        private DbContextSqlite Dbsqlite;

        public IMyFiles(DbContextSqlite sqlite)
        {
            Dbsqlite = sqlite;
        }

        public ListModels FilePath(string pathFile)
        {
            PathRoot(pathFile);
            var result = Explorer(ruta) ? dir : dir;
            return result;
        }

        public ListModels File()
        {
            var result = Explorer(ruta) ? dir : dir;
            return result;
        }

        public async Task<FilesModels> CreateFile(string pathFile, FilesModels files)
        {
            PathRoot(pathFile);
            if (Directory.Exists(ruta))
            {
                return new FilesModels() { Path = "El archivo Existe"};
            }

            DirectoryInfo di = Directory.CreateDirectory(ruta);

            var data = new FilesModels()
            {
                User = files.User,
                CreateFile = Directory.GetCreationTime(ruta),
                UpdateFile = Directory.GetCreationTime(ruta),
                Path = di.FullName,
                NameFile = di.Name
            };

            await Dbsqlite.Files.AddAsync(data);
            await Dbsqlite.SaveChangesAsync();
            return data;
        }

        public async Task<string> UpdateFile(int id , UpdateFiles update)
        {
            if (Directory.Exists(ruta))
            {
                var data = await Dbsqlite.Files.FindAsync(id);

                string file = @$"{ruta}\{data.NameFile}";
                string newFile = $@"{ruta}\{update.newName}";
                Directory.Move(file, newFile);
                if(data != null)
                {
                    data.NameFile = update.newName;
                    data.Path = newFile;
                    data.UpdateFile = DateTime.Now;

                    await Dbsqlite.SaveChangesAsync();
                }
                return "Nombre Cambiado";
            }
            return "Error";
        }

        public async Task<string> DeleteFile(string pathFile)
        {
            PathRoot(pathFile);
            if (Directory.Exists(ruta))
            {
                Directory.Delete(ruta);

                var context = new DbContextSqlite();
                var query = from s in context.Files where s.Path == ruta select s;

                var data = query.FirstOrDefault();

                if (data != null)
                {
                    Dbsqlite.Remove(data);
                    await Dbsqlite.SaveChangesAsync();
                }
                return "Directorio Borrado";
            }

            return "Directorio No existe";
        }

        public bool Explorer(string path)
        {
            if (Directory.Exists(path))
            {
                string[] files = Directory.GetFiles(path);
                string[] dirs = Directory.GetDirectories(path);

                foreach (string str in files)
                {
                    AllFiles.Add(new FileInfo(str).Name);
                }
                foreach (string srt in dirs)
                {
                    AllDirectories.Add(new DirectoryInfo(srt).Name);
                }

                dir = new()
                {
                    Name = new DirectoryInfo(path).Name,
                    Files = AllFiles,
                    Directories = AllDirectories
                };
                return true;
            }
            else
            {
                dir = new() { Name = "No exite" };
                return false;
            }
        }

        public JToken GetDirectory(DirectoryInfo directory)
        {
            var text = JToken.FromObject(
                new
                {
                    directory = directory
                        .EnumerateDirectories()
                        .ToDictionary(x => x.Name, x => GetDirectory(x)),
                    file = directory.EnumerateFiles().Select(x => x.Name).ToList()
                }
            );
            return text;
        }

        public string PathRoot(string root)
        {
            string[] urlArray = root.Split('-');

            foreach (string url in urlArray)
                ruta += $@"\{url}";
            return ruta;
        }
    }
}
