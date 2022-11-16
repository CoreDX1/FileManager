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
        private DbContextPostgres sqlite;

        public UsuariosController(DbContextPostgres sqlite)
        {
            this.sqlite = sqlite;
        }

    }
}
