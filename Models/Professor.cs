using System.Collections.Generic;

namespace smartschool.Models
{
    public class Professor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public ICollection<Disciplina> Disciplinas { get; set; }
    }
}