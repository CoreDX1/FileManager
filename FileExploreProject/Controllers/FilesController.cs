using FileExploreProject.Interfaces;
using FileExploreProject.Models;
using FileExploreProject.Models.SqliteModels;
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
            try
            {
            var data = Files.Listar(path);
            return Ok(data);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public IActionResult Archivos()
        {
            string data = Files.getArchivo();
            return StatusCode(200, data);
        }

        [HttpPost]
        [Route("{path}")]
        public async Task<IActionResult> Create(string path, FilesModels filesModels)
        {
            var data = await Files.CreateFiles(path, filesModels);
            return StatusCode(201, data);
        }

        [HttpDelete]
        [Route("{path}")]
        public IActionResult DeleteFiles(string path)
        {
            Files.DeleteFiles(path);
            return Ok("Se Borro");
        }
    }
}
