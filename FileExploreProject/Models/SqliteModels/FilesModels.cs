using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FileExploreProject.Models.SqliteModels
{
    [Table("Files")]
    public class FilesModels
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string NameFile { get; set; } = string.Empty;
        public string User { get; set; } = string.Empty;
        public string Path { get; set; } = string.Empty;
        public DateTime CreateFile { get; set; }
        public DateTime UpdateFile { get; set; }
    }
}
