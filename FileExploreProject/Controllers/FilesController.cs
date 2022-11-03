using FileExploreProject.Interfaces;
using FileExploreProject.Models;
using FileExploreProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace FileExploreProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FilesController : Controller
    {
        private InterfaceFiles<ListModels> Files;

        public FilesController(InterfaceFiles<ListModels> files)
        {
            Files = files;
        }

        [HttpGet]
        [Route("{path}")]
        public IActionResult SubArchivos(string path)
        {
            var data = Files.Listar(path);
            return Ok(data);
        }

        [HttpGet]
        public IActionResult Archivos()
        {
            string data = Files.getArchivo();
            return Ok(data);
        }
    }
}
