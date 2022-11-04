using FileExploreProject.Models.SqliteModels;

namespace FileExploreProject.Interfaces
{
    public interface InterfaceFiles<T>
    {
        public List<T> FilePath(string pathFile);
        public string File();
        public Task<FilesModels> CreateFile(string pathFile, FilesModels files);
        public Task<string> DeleteFile(string pathFile);
        public string UpdateFile(string pathFile);
    }
}
