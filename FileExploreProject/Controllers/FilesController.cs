using FileExploreProject.Interfaces;
using FileExploreProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace FileExploreProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FilesController : Controller
    {
        private InterfaceFiles Files;
        public FilesController(InterfaceFiles files)
        {
            Files = files;
        }

        [HttpGet]
        public IActionResult Archivos()
        {
            var data = Files.Listar();
            return Ok(data);
        }
    }
}
