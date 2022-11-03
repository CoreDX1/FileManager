namespace FileExploreProject.Interfaces
{
    public interface InterfaceFiles<T>
    {
        public List<T> Listar(string pathFile);
        public string getArchivo();
    }
}
