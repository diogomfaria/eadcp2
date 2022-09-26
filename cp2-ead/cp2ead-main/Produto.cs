using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace checkpoint_2_ead
{
    internal class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Valor { get; set; }

        public override string ToString()
        {
            return $"{Id} | {Nome} | {Valor}";
        }
    }
}
