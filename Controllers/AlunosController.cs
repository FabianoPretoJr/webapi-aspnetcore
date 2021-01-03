using System;
using Microsoft.AspNetCore.Mvc;
using smartschool.Data;
using smartschool.Models;
using AutoMapper;
using System.Collections.Generic;
using smartschool.DTO;
using System.Threading.Tasks;
using smartschool.helpers;

namespace smartschool.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunosController : ControllerBase
    {
        public readonly IRepository repo;
        public IMapper Mapper { get; }

        public AlunosController(IRepository repo, IMapper mapper)
        {
            this.repo = repo;
            this.Mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]PageParams pageParams)
        {
            var alunos = await repo.GetAllAlunosAsync(pageParams, true);
            var alunosResult = Mapper.Map<IEnumerable<AlunoDTO>>(alunos);

            Response.AddPagination(alunos.CurrentPages, alunos.PageSize, alunos.TotalCount, alunos.TotalPages);

            return Ok(alunosResult);
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

                var alunoDTO = Mapper.Map<AlunoDTO>(aluno);

                return Ok(alunoDTO);
            }
            catch (Exception)
            {
                Response.StatusCode = 400;
                return new ObjectResult("");
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody]AlunoRegistrarDTO model)
        {
            var aluno = Mapper.Map<Aluno>(model);

            repo.Add(aluno);
            if (repo.SaveChanges())
            {
                return Created($"/api/alunos/{model.Id}", Mapper.Map<AlunoDTO>(aluno));
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]AlunoRegistrarDTO model)
        {
            var aluno = repo.GetAlunoById(id, false);
            if (aluno == null) return BadRequest();

            Mapper.Map(model, aluno);
            
            repo.Update(aluno);
            if (repo.SaveChanges())
            {
                return Created($"/api/alunos/{model.Id}", Mapper.Map<AlunoDTO>(aluno));
            }
            return BadRequest();
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, [FromBody]AlunoRegistrarDTO model)
        {
            var aluno = repo.GetAlunoById(id, false);
            if (aluno == null) return BadRequest();

            Mapper.Map(model, aluno);
            
            repo.Update(aluno);
            if (repo.SaveChanges())
            {
                return Created($"/api/alunos/{model.Id}", Mapper.Map<AlunoDTO>(aluno));
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