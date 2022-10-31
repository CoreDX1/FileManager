using System.Net.Http.Headers;

namespace FileExploreProject.Services
{
    public class IUploadImagen
    {
        public bool PostImagen(IFormFile imagen)
        {
            var folderName = Path.Combine("Imagen");
            var pathToSave = Path.Combine(@"C:\Users\chism\OneDrive\Desktop\MyFiles\dir1", folderName);
            if (imagen.Length > 0)
            {
                string? fileName = ContentDispositionHeaderValue
                    .Parse(imagen.ContentDisposition)
                    .FileName.Trim('"');
                string fullPath = Path.Combine(pathToSave, fileName);
                var dbPath = Path.Combine(folderName, fileName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    imagen.CopyTo(stream);
                }
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
