using System;
using System.Collections.Generic;

namespace smartschool.Models
{
    public class Professor
    {
        public Professor(){}
        public Professor(int id, int registro, string nome, string Sobrenome)
        {
            this.Id = id;
            this.Registro = Registro;
            this.Nome = nome;
            this.Sobrenome = Sobrenome;
        }

        public int Id { get; set; }
        public int Registro { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Telefone { get; set; }
        public DateTime DataInicio { get; set; } = DateTime.Now;
        public DateTime? DataFim { get; set; } = null;
        public bool Ativo { get; set; } = true;
        public ICollection<Disciplina> Disciplinas { get; set; }
    }
}