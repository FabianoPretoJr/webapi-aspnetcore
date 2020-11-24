using Microsoft.AspNetCore.Mvc;

namespace smartschool.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessoresController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Professores: Vania, Clecio, Henrique, Alexandre");
        }
    }
}