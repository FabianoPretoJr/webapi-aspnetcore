using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using smartschool.Data;
using smartschool.Models;

namespace smartschool.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunosController : ControllerBase
    {
        private readonly ApplicationDbContext database;
        public AlunosController(ApplicationDbContext database)
        {
            this.database = database;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var alunos = database.alunos.ToList();
            return Ok(alunos);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var aluno = database.alunos.First(a => a.Id == id);
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
            database.alunos.Add(aluno);
            database.SaveChanges();
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Aluno aluno)
        {
            var alu = database.alunos.First(a => a.Id == id);
            alu.Nome = aluno.Nome;
            alu.Sobrenome = aluno.Sobrenome;
            alu.Telefone = aluno.Telefone;
            database.SaveChanges();
            return Ok();
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, [FromBody]Aluno aluno)
        {
            var alu = database.alunos.First(a => a.Id == id);
            alu.Nome = aluno.Nome;
            alu.Sobrenome = aluno.Sobrenome;
            alu.Telefone = aluno.Telefone;
            database.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var aluno = database.alunos.First(a => a.Id == id);
            database.Remove(aluno);
            database.SaveChanges();
            return Ok();
        }
    }
}