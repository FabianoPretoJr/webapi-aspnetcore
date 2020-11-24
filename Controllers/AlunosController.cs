using Microsoft.AspNetCore.Mvc;

namespace smartschool.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunosController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Alunos: Fabiano, Gustavo, Karine, Isabela");
        }
    }
}