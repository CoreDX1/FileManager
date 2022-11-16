using FileExploreProject.Data;
using FileExploreProject.Models.SqliteModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FileExploreProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private DbContextPostgres sqlite;

        public UsuariosController(DbContextPostgres sqlite)
        {
            this.sqlite = sqlite;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await sqlite.Usuarios.ToListAsync();
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> PostUsuarios(UsuariosModels usuarios)
        {
            UsuariosModels data = new UsuariosModels()
            {
                Name = usuarios.Name,
                Age = usuarios.Age,
            };

            await sqlite.AddAsync(data);
            await sqlite.SaveChangesAsync();
            return Ok(data);
        }
    }
}
