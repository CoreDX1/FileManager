using FileExploreProject.Interfaces;
using FileExploreProject.Models;
using System.IO;

namespace FileExploreProject.Services
{
    public class IMyFiles : InterfaceFiles<ListModels>
    {
        private List<string> AllFiles = new();
        private List<string> AllDirectories = new();
        private List<ListModels> dir = new();

        public List<ListModels> Listar(string pathFile)
        {
            string[] urlArray = pathFile.Split('-');
            string ruta = @"C:\Users\chism\OneDrive\Desktop\MyFiles";

            foreach (string url in urlArray)
                ruta += $@"\{url}";

            if (Explorer(ruta))
                return dir;
            else
                return dir;
        }

        public List<ListModels> getArchivo()
        {
            string ruta = @"C:\Users\chism\OneDrive\Desktop\MyFiles";
            if (Explorer(ruta))
                return dir;
            else
                return dir;
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
    }
}
