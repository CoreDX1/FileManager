using FileExploreProject.Data;
using FileExploreProject.Interfaces;
using FileExploreProject.Models;
using FileExploreProject.Models.SqliteModels;
using Newtonsoft.Json.Linq;

namespace FileExploreProject.Services
{
    public class IMyFiles : InterfaceFiles<ListModels>
    {
        private List<string> AllFiles = new();
        private List<string> AllDirectories = new();
        private List<ListModels> dir = new();
        public string ruta = @"C:\Users\chism\OneDrive\Desktop\MyFiles";

        private DbContextSqlite Dbsqlite;

        public IMyFiles(DbContextSqlite sqlite)
        {
            Dbsqlite = sqlite;
        }

        public List<ListModels> Listar(string pathFile)
        {
            string[] urlArray = pathFile.Split('-');

            foreach (string url in urlArray)
                ruta += $@"\{url}";

            return Explorer(ruta) ? dir : dir;
        }

        public string getArchivo()
        {
            var json = GetDirectory(new DirectoryInfo(ruta)).ToString();
            return json;
        }

        public async Task<string> CreateFiles(string pathFile , FilesModels files)
        {
            string[] urlArray = pathFile.Split('-');

            foreach (string url in urlArray)
                ruta += $@"\{url}";


            if (Directory.Exists(ruta))
            {
                return "Error : Archivo Existe";
            }
            DirectoryInfo di = Directory.CreateDirectory(ruta);

            var data = new FilesModels()
            {
                User = files.User,
                CreateFile = Directory.GetCreationTime(ruta),
                Path = di.FullName,
                NameFile = di.Name
            };

            await Dbsqlite.Files.AddAsync(data);
            await Dbsqlite.SaveChangesAsync();
            return "Se creo el Archivo";
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
                    new ListModels()
                    {
                        Name = new DirectoryInfo(path).Name,
                        Files = AllFiles,
                        Directories = AllDirectories
                    }
                };
                return true;
            }
            else
            {
                dir = new() { new ListModels() { Name = "No exite" } };
                return false;
            }
        }

        public JToken GetDirectory(DirectoryInfo directory)
        {
            return JToken.FromObject(
                new
                {
                    directory = directory
                        .EnumerateDirectories()
                        .ToDictionary(x => x.Name, x => GetDirectory(x)),
                    file = directory.EnumerateFiles().Select(x => x.Name).ToList()
                }
            );
        }
    }
}
