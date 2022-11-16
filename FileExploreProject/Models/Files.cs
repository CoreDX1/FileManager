namespace FileExploreProject.Models
{
    public class Files
    {
        public int id { get; set; }
        public string name { get; set; }
        public string folderpath { get; set; }
        public string datecreated { get; set; }
        public string datemodified { get; set; }
        public int id_dir { get; set; }
    }
}
