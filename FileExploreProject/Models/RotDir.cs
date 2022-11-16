using System.ComponentModel.DataAnnotations.Schema;

namespace FileExploreProject.Models
{
    [Table("rootdirectoy")]
    public class RotDir
    {
        public int id { get; set; }
        public string nameroot { get; set; }
        public string createdate { get; set; }
    }
}
