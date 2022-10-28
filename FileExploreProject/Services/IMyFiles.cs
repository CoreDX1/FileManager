using FileExploreProject.Interfaces;
using FileExploreProject.Models;
using System.IO;

namespace FileExploreProject.Services
{
    public class IMyFiles : InterfaceFiles<ListModels>
    {
        public List<ListModels> Listar()
        {
            string ruta = @"C:\Users\chism\OneDrive\Desktop\MyFiles";
            return Explorer(ruta);
        }

        public List<ListModels> Explorer(string path)
        {
            List<string> AllContent = new List<string>();

            string[] files = Directory.GetFiles(path);

            foreach (string str in files)
            {
                AllContent.Add(str);
            }

            List<ListModels> dir = new List<ListModels>()
            {
                new ListModels() { Name = "path", Files = AllContent }
            };
            return dir;
        }
    }
}
