using FileExploreProject.Interfaces;
using FileExploreProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace FileExploreProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FilesController : Controller
    {
        private InterfaceFiles<RotDir> Files;

        public FilesController(InterfaceFiles<RotDir> files)
        {
            Files = files;
        }

        [HttpGet]
        public IActionResult Archivos()
        {
            var data = Files.File();
            return StatusCode(200, data);
        }
    }
}
