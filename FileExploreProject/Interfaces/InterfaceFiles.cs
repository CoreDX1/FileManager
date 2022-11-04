using FileExploreProject.Models.SqliteModels;

namespace FileExploreProject.Interfaces
{
    public interface InterfaceFiles<T>
    {
        public List<T> Listar(string pathFile);
        public string getArchivo();
        public Task<FilesModels> CreateFiles(string pathFile, FilesModels files);
        public Task<string> DeleteFiles(string pathFile);
    }
}
