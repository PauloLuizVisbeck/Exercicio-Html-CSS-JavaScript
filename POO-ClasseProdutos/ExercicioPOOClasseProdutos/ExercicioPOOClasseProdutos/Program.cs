namespace ExercicioPOOClasseProdutos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Cadastro de Produtos");
            Console.Write("Informe o código do produto: ");
            string codigo = Console.ReadLine();
            Console.Write("Informe a descrição do produto: ");
            string descricao = Console.ReadLine();
            Console.Write("Informe o estoque do produto: ");
            int estoque = int.Parse(Console.ReadLine());
            Console.Write("Informe o valor unitário do produto: ");
            double valorUnitario = double.Parse(Console.ReadLine());

            //Setando valores no objeto através das Propriedades
            Produto produto = new Produto();
            produto.Codigo = codigo;
            produto.Descricao = descricao;
            produto.Estoque = estoque;
            produto.ValorUnitario = valorUnitario;

            //Escrevendo o objeto através do método ToString
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(produto.ToString());

            Console.WriteLine();
            Console.WriteLine();
            Console.Write("Inforne o percentual de aumento: ");
            double percentual = double.Parse(Console.ReadLine());

            //Utilizando o método AcrescimoPreço dentro da própria escrita
            Console.WriteLine("Novo preço do produto com aumento: {0}", produto.AcrescimoPreco(percentual).ToString("F2"));

            Console.WriteLine();
            Console.WriteLine();
            Console.Write("Inforne o percentual de desconto: ");
            percentual = double.Parse(Console.ReadLine());

            Console.WriteLine("Novo preço do produto com desconto: {0}", produto.DescontoPreco(percentual).ToString("F2"));
            Console.ReadKey();
        }
    }
}