using FileExploreProject.Models.SqliteModels;

namespace FileExploreProject.Interfaces
{
    public interface InterfaceFiles<T>
    {
        public List<T> FilePath(string pathFile);
        public List<T> File();
        public Task<FilesModels> CreateFile(string pathFile, SaveFile files);
        public Task<bool> DeleteFile(string pathFile);
        public Task<bool> UpdateFile(int id, UpdateFiles update);
    }
}
