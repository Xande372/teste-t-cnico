using Mercado;
using System.Drawing;

class Program
{
    static List<Produto> produtos = new List<Produto>();

    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("--Sistema de Produtos--");
            Console.WriteLine("1 - Cadastrar Produto");
            Console.WriteLine("2 - Listar Produtos");
            Console.WriteLine("3 - Encerrar Programa");
            Console.WriteLine("Digite o número da sua opção: ");

            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    CadastrarProduto();
                    break;
                case "2":
                    ListarProdutos();
                    break;
                case "3":
                    return;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente!");
                    break;
            }
        }
    }

    //Método com o cadastro de proutos.
    static void CadastrarProduto()
    {
        Produto produto = new Produto();

        Console.Clear();
        Console.WriteLine("--Cadastro de Produto--");

        Console.WriteLine("Nome do Produto: ");
        produto.Nome = Console.ReadLine();

        Console.WriteLine("Descrição do Produto: ");
        produto.Descricao = Console.ReadLine();

        //Verificação se o valor é válido.
        Console.WriteLine("Valor do Produto: ");
        produto.Valor = Convert.ToDecimal(Console.ReadLine());

        Console.WriteLine("Disponível para Venda (sim/não): ");
        string disponivel = Console.ReadLine().ToLower();
        produto.DisponivelParaVenda = disponivel == "sim";

        produtos.Add(produto);

        Console.WriteLine("Produto cadastrado com sucesso!");

        //Chama a listagem ao final do cadastro.
        ListarProdutos();
    }

    //Método com a Listagem dos Produtos.
    static void ListarProdutos()
    {
        Console.Clear();
        Console.WriteLine("Listagem de Produtos\n");

        if (produtos.Count == 0)
        {
            Console.WriteLine("Nenhum produto cadastrado.");
        }
        else
        {
            var produtosOrdenados = produtos.OrderBy(p => p.Valor).ToList();

            Console.WriteLine("{0,-30} {1,10} {2,15}", "Nome do Produto", "Valor", "Disponível");
            Console.WriteLine(new string('-', 57));

            foreach (var produto in produtosOrdenados)
            {
                Console.WriteLine("{0,-30} {1,10:C} {2,11}", produto.Nome, produto.Valor, produto.DisponivelParaVenda ? "sim" : "não");
            }
        }

        Console.WriteLine("\n1 - Voltar ao Menu Principal.");
        Console.WriteLine("2 - Cadastrar Novo Produto.");

        string opcao = Console.ReadLine();

        switch (opcao)
        {
            case "1":
                return;
            case "2":
                CadastrarProduto();
                break;
            default:
                Console.WriteLine("Opção inválida.");
                break;
        }
        
    }
}