using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace checkpoint_2_ead
{
    internal class Funcionario
    {
        public string Nome { get; set; }
        public string Matricula { get; set; }
        public double Salario { get; set; }

        public Funcionario()
        {

        }

        public Funcionario(string nome, string matricula, double salario)
        {
            Nome = nome;
            Matricula = matricula;
            Salario = salario;
        }

        public override string ToString()
        {
            return $"{Nome} | {Matricula} | {Salario}";
        }
    }
}
