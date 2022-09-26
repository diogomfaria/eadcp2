using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using checkpoint_2_ead_enum;

namespace checkpoint_2_ead
{
    internal class Pedido
    {
        public DateTime DataPedido { get; set; }
        public StatusPedido Status { get; set; }
        public List<ItemPedido> Itens { get; set; }
        public double Valor { get; set; }
        public Funcionario Funcionario { get; set; }
        public void AddItem(ItemPedido item)
        {
            if (Itens == null)
            {
                Itens = new List<ItemPedido>();
            }

            Itens.Add(item);
        }

        public override string ToString()
        {
            return $"{DataPedido} | {Valor} | {Status} | {Funcionario}";
        }
    }
}
