using FileExploreProject.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FileExploreProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private DbContextSqlite sqlite;

        public UsuariosController(DbContextSqlite sqlite)
        {
            this.sqlite = sqlite;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await sqlite.Usuarios.ToListAsync();
            return Ok(data);
        }
    }
}
