namespace FileExploreProject.Models
{
    public class ListModels
    {
        public string Name { get; set; } = string.Empty;
        public List<string> Files { get; set; } = new List<string>();
        public List<string> Directories { get; set; } = new List<string>();
    }
}
