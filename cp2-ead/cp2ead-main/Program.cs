using checkpoint_2_ead;
using checkpoint_2_ead_enum;

int opcao = 0;

List<Produto> produtos = new List<Produto>();
List<Vendedor> vendedores = new List<Vendedor>();
List<Gerente> gerentes = new List<Gerente>();
List<Pedido> pedidos = new List<Pedido>();
List<Funcionario> funcionarios = new List<Funcionario>();

do
{
    Console.WriteLine("1 - Cadastrar Produto");
    Console.WriteLine("2 - Cadastrar Funcionário");
    Console.WriteLine("3 - Efetuar Venda");
    Console.WriteLine("4 - Listar Produtos");
    Console.WriteLine("5 - Listar Funcionários");
    Console.WriteLine("6 - Listar Pedidos");
    Console.WriteLine("7 - Calcular Pagamento de Funcionário");
    Console.WriteLine("8 - Sair");
    Console.Write("Opcao: ");

    opcao = int.Parse(Console.ReadLine());

    Console.Clear();

    switch (opcao)
    {
        case 1:
            Console.WriteLine("Cadastrar Produto");
            Produto produto = new Produto();

            Console.Write("Id: ");
            produto.Id = int.Parse(Console.ReadLine());

            Console.Write("Nome: ");
            produto.Nome = Console.ReadLine();

            Console.Write("Valor: ");
            produto.Valor = double.Parse(Console.ReadLine());

            produtos.Add(produto);
            break;

        case 2:
            Console.WriteLine("Cadastrar Cliente");
            string tipoFuncionario;

            Console.Write("Qual é o tipo de funcionário? (V)endedor ou (G)erente: ");
            tipoFuncionario = Console.ReadLine();
            if(tipoFuncionario == "V" || tipoFuncionario == "v")
            {
                Vendedor vendedor = new Vendedor();

                Console.Write("Nome: ");
                vendedor.Nome = Console.ReadLine();

                Console.Write("Matricula: ");
                vendedor.Matricula = Console.ReadLine();

                Console.Write("Salario: ");
                vendedor.Salario = double.Parse(Console.ReadLine());

                vendedores.Add(vendedor);
                funcionarios.Add(vendedor);
            }
            else if(tipoFuncionario == "G" || tipoFuncionario == "g")
            {
                Gerente gerente = new Gerente();

                Console.Write("Nome: ");
                gerente.Nome = Console.ReadLine();

                Console.Write("Matricula: ");
                gerente.Matricula = Console.ReadLine();

                Console.Write("Salario: ");
                gerente.Salario = double.Parse(Console.ReadLine());

                gerentes.Add(gerente);
                funcionarios.Add(gerente);
               
            }
            break;
        case 3:
            Console.WriteLine("Cadastrar Pedido");
            Pedido pedido = new Pedido();

            Console.Write("Informe a quantidade de itens do pedido: ");
            int qtdItens = int.Parse(Console.ReadLine());

            for (int i = 0; i < qtdItens; i++)
            {
                ItemPedido item = new ItemPedido();

                Console.Write($"Id do Produto {i + 1}: ");
                int idProduto = int.Parse(Console.ReadLine());

                item.Produto = produtos.Find(produto => produto.Id == idProduto);
                item.Valor = item.Produto.Valor;

                Console.Write($"Quantidade do Produto {i + 1}: ");
                item.Quantidade = int.Parse(Console.ReadLine());

                Console.WriteLine($"Valor : {item.SubTotal()}");

                pedido.AddItem(item);
            }
            string matriculaFuncionario;
            Console.Write("Informe matrícula do funcionário: ");
            matriculaFuncionario = Console.ReadLine();
            pedido.Funcionario = funcionarios.Find(funcionario => funcionario.Matricula == matriculaFuncionario);

            pedido.DataPedido = DateTime.Now;
            pedido.Status = StatusPedido.Processando;
            double soma = 0;

            pedido.Itens.ForEach(item =>
            {
                soma += item.SubTotal();
            });
            pedido.Valor = soma;

            pedidos.Add(pedido);

            break;

        case 4:
            Console.WriteLine("Listar Produtos");

            produtos.ForEach(produto =>
            {
                Console.WriteLine(produto);
            });

            break;

        case 5:
            Console.WriteLine("Listar Funcionarios");

            funcionarios.ForEach(funcionario =>
            {
                Console.WriteLine(funcionario);
            });

            break;

        case 6:
            Console.WriteLine("Listar Pedidos");

            pedidos.ForEach(pedido =>
            {
                Console.WriteLine(pedido);
            });

            break;

        case 7:
            Console.WriteLine("Calcular Pagamento de Funcionário");
            gerentes.ForEach(gerente =>
            {
                Console.WriteLine($"{gerente.Nome} | pagamento: {gerente.CalcularPagamento(pedidos)}");
            });
            vendedores.ForEach(vendedor =>
            {
                List<Pedido> pedidosVendedor = new List<Pedido>();
                pedidos.ForEach(pedido =>
                {
                    if (pedido.Funcionario.Matricula == vendedor.Matricula)
                    {
                        pedidosVendedor.Add(pedido);
                    }
                });
                Console.WriteLine($"{vendedor.Nome} | pagamento: {vendedor.CalcularPagamento(pedidosVendedor)}");
            });
            break;
    }

    Console.ReadKey();
    Console.Clear();
} while (opcao != 8);