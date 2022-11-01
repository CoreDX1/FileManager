using FileExploreProject.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace FileExploreProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        private IUploadImagen uploadM = new IUploadImagen();

        [HttpPost, DisableRequestSizeLimit]
        [Route("{path}")]
        public IActionResult Upload(string path)
        {
            try
            {
                var file = Request.Form.Files[0];
                if (uploadM.PostImagen(file, path))
                {
                    return Ok("Exito");
                }
                else
                {
                    return BadRequest("falla");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internet server error: {ex}");
            }
        }
    }
}
