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
            var data = Files.FilePath(path);
            return Ok(data);
        }

        [HttpGet]
        public IActionResult Archivos()
        {
            var data = Files.File();
            return StatusCode(200, data);
        }

        [HttpPost]
        [Route("{path}")]
        public async Task<IActionResult> Create(string path, SaveFile filesModels)
        {
            var data = await Files.CreateFile(path, filesModels);
            return StatusCode(201, data);
        }

        [HttpDelete]
        [Route("{path}")]
        public IActionResult DeleteFiles(string path)
        {
            var data = Files.DeleteFile(path);
            if (data != null)
            {
                return Ok("Se Borro");
            }
            else
            {
                return BadRequest("Error Al Borrar");
            }
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateFile(int id, UpdateFiles name)
        {
            bool data = await Files.UpdateFile(id, name);
            if (data)
            {
                return Ok("Actualizado");
            }
            else
            {
                return BadRequest("Error");
            }
        }
    }
}
