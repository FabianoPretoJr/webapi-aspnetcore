using Microsoft.AspNetCore.Mvc;
using smartschool.Data;
using smartschool.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace smartschool.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessoresController : ControllerBase
    {
        public readonly IRepository repo;

        public ProfessoresController(IRepository repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var professores = repo.GetAllProfessores(true);
            return Ok(professores);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var professor = repo.GetAlunoById(id, false);
            if (professor == null)
            {
                Response.StatusCode = 400;
                return new ObjectResult("");
            }
            return Ok(professor);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Professor professor)
        {
            repo.Add(professor);
            if (repo.SaveChanges())
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, [FromBody]Professor professor)
        {
            var pro = repo.GetProfessorById(id, false);
            if (pro == null) return BadRequest();
            
            repo.Update(professor);
            if (repo.SaveChanges())
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Professor professor)
        {
            var pro = repo.GetProfessorById(id, false);
            if (pro == null) return BadRequest();
            
            repo.Update(professor);
            if (repo.SaveChanges())
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var professor = repo.GetProfessorById(id, false);
            if (professor == null) return BadRequest();

            repo.Delete(professor);
            if (repo.SaveChanges())
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}