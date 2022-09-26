using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace checkpoint_2_ead
{
    internal class ItemPedido
    {
        public int Quantidade { get; set; }
        public double Valor { get; set; }
        public Produto Produto { get; set; }

        public double SubTotal()
        {
            return Valor * Quantidade;
        }

        public override string ToString()
        {
            return $"{Quantidade} | {Valor} | {Produto}";
        }
    }
}
