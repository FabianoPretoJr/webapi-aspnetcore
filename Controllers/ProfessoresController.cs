using Microsoft.AspNetCore.Mvc;
using smartschool.Data;
using smartschool.Models;
using System.Linq;

namespace smartschool.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessoresController : ControllerBase
    {
        private readonly ApplicationDbContext database;
        public ProfessoresController(ApplicationDbContext database)
        {
            this.database = database;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var professores = database.professores.ToList();
            return Ok(professores);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var professor = database.professores.First(p => p.Id == id);
            return Ok(professor);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Professor professor)
        {
            database.professores.Add(professor);
            database.SaveChanges();
            return Ok();
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, [FromBody]Professor professor)
        {
            var pro = database.professores.First(p => p.Id == id);
            pro.Nome = professor.Nome;
            database.SaveChanges();
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Professor professor)
        {
            var pro = database.professores.First(p => p.Id == id);
            pro.Nome = professor.Nome;
            database.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var professor = database.professores.First(p => p.Id == id);
            database.professores.Remove(professor);
            database.SaveChanges();
            return Ok();
        }
    }
}