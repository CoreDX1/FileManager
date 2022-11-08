using FileExploreProject.Models.SqliteModels;

namespace FileExploreProject.Interfaces
{
    public interface InterfaceFiles<T>
    {
        public T FilePath(string pathFile);
        public T File();
        public Task<FilesModels> CreateFile(string pathFile, FilesModels files);
        public Task<string> DeleteFile(string pathFile);
        public Task<string> UpdateFile(int id, UpdateFiles update);
    }
}
