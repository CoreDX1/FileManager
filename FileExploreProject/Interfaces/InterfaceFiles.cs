using FileExploreProject.Models.SqliteModels;

namespace FileExploreProject.Interfaces
{
    public interface InterfaceFiles<T>
    {
        public List<T> Listar(string pathFile);
        public string getArchivo();
        public Task<string> CreateFiles(string path, FilesModels files);
    }
}
