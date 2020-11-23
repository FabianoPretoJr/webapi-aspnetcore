using System.Collections.Generic;

namespace smartschool.Models
{
    public class Aluno
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Telefone { get; set; }
        public ICollection<AlunoDisciplina> AlunosDisciplinas { get; set; }
    }
}