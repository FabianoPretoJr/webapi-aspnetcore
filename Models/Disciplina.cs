using System.Collections.Generic;

namespace smartschool.Models
{
    public class Disciplina
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int ProfessorId { get; set; }
        public Professor Professor { get; set; }
        public ICollection<AlunoDisciplina> AlunosDisciplinas { get; set; }
    }
}