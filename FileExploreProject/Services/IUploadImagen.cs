using System.Net.Http.Headers;
using FileExploreProject.Interfaces;

namespace FileExploreProject.Services
{
    public class IUploadImagen : InterfaceUploadImagen
    {
        public bool PostImagen(IFormFile imagen, string ruta)
        {
            string[] rutaTranfor = ruta.Split("-");
            string rutaFinal = @"C:\Users\chism\OneDrive\Desktop\MyFiles";
            foreach (string tranfor in rutaTranfor)
            {
                rutaFinal += $@"\{tranfor}";
            }

            var pathToSave = Path.Combine(rutaFinal);
            if (imagen.Length > 0)
            {
                string? fileName = ContentDispositionHeaderValue
                    .Parse(imagen.ContentDisposition)
                    .FileName.Trim('"');
                string fullPath = Path.Combine(pathToSave, fileName);
                //var dbPath = Path.Combine(folderName, fileName);
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
