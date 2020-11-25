using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using smartschool.Data;
using smartschool.Models;
using Microsoft.EntityFrameworkCore;

namespace smartschool.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunosController : ControllerBase
    {
        public readonly IRepository repo;

        public AlunosController(IRepository repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var alunos = repo.GetAllAlunos(true);
            return Ok(alunos);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var aluno = repo.GetAlunoById(id, false);
                if (aluno == null)
                {
                    Response.StatusCode = 400;
                    return new ObjectResult("");
                }
                return Ok(aluno);
            }
            catch (Exception)
            {
                Response.StatusCode = 400;
                return new ObjectResult("");
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody]Aluno aluno)
        {
            repo.Add(aluno);
            if (repo.SaveChanges())
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Aluno aluno)
        {
            var alu = repo.GetAlunoById(id, false);
            if (alu == null) return BadRequest();
            
            repo.Update(aluno);
            if (repo.SaveChanges())
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, [FromBody]Aluno aluno)
        {
            var alu = repo.GetAlunoById(id, false);
            if (alu == null) return BadRequest();
            
            repo.Update(aluno);
            if (repo.SaveChanges())
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var aluno = repo.GetAlunoById(id, false);
            if (aluno == null) return BadRequest();

            repo.Delete(aluno);
            if (repo.SaveChanges())
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}