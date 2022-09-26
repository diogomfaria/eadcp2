using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace checkpoint_2_ead
{
    internal class Gerente: Funcionario
    {
        public Gerente()
        {

        }

        public Gerente(string nome, string matricula, double salario) : base(nome, matricula, salario)
        {

        }

        public double CalcularPagamento(List<Pedido> pedidos)
        {
            double bonus = 0;
            pedidos.ForEach(pedido =>
            {
                bonus += (pedido.Valor * 5) / 100;
            });
            return Salario + bonus;
        }
    }
}
