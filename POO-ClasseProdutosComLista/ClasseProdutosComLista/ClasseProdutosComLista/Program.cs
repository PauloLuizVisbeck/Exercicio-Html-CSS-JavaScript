namespace ClasseProdutosComLista
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Instanciação de um objeto chamado produtos, que é do tipo Lista de Produto
            List<Produto> produtos = new List<Produto>();   
            int opcao = 0;
            while (opcao != 6)
            {
                Console.Clear();
                Console.WriteLine("ESCOLHA A OPÇÃO DESEJADA");
                Console.WriteLine("     1 - CADASTRAR PRODUTO");
                Console.WriteLine("     2 - LISTAR UM PRODUTO");
                Console.WriteLine("     3 - LISTAR TODOS OS PRODUTOS");
                Console.WriteLine("     4 - ACRESCER PREÇO DO PRODUTO");
                Console.WriteLine("     5 - DESCONTO PREÇO DO PRODUTO");
                Console.WriteLine("     6 - SAIR");
                Console.WriteLine();
                Console.Write("OPÇÃO ESCOLHIDA............: ");
                opcao = int.Parse(Console.ReadLine());

                //Verifica se opção escolhioda é válida de acordo com o Menu
                while (opcao < 1 || opcao > 6)
                {
                    Console.WriteLine("Opção inválida!");
                    Console.Write("OPÇÃO ESCOLHIDA............: ");
                    opcao = int.Parse(Console.ReadLine());
                }

                char continuar = 'S';
                switch (opcao)
                {
                    //Rotina responsável por cadastrar produtos
                    case 1:
                        {
                            while (continuar != 'N')
                            {
                                Console.Clear();
                                Console.Write("Informe o código do produto: ");
                                string codigo = Console.ReadLine();
                                Console.Write("Informe a descrição do produto: ");
                                string descricao = Console.ReadLine();
                                Console.Write("Informe o estoque do produto: ");
                                int estoque = int.Parse(Console.ReadLine());
                                Console.Write("Informe o valor unitário do produto: ");
                                double valorUnitario = double.Parse(Console.ReadLine());

                                //Setando valores lidos no objeto produto
                                produtos.Add(new Produto(codigo, descricao, estoque, valorUnitario));

                                Console.WriteLine();
                                Console.Write("Deseja cadastrar outro produto (S/N)? ");
                                continuar = char.Parse(Console.ReadLine().ToUpper());
                            }                    
                            break;
                        }
                    //Rotina responsável por listar um produto
                    case 2:
                        {
                            Console.Clear();
                            Console.Write("Informe o código do produto: ");
                            string codigo = Console.ReadLine();

                            if (codigo == null || codigo.Length < 1)
                                Console.WriteLine("Código invalido!");
                            else
                            {
                                //============================================================================
                                // Utilização do método .Find (disponível nos elemesntos tipo List)
                                //============================================================================
                                // Procurar o produto com o código informado, na lista de produtos
                                Produto localizaProduto = produtos.Find(procurado => procurado.Codigo == codigo);

                                //"procurado" é uma variável temporária que representa cada elemento da lista produtos durante a iteração
                                //do método Find. O operador lambda ('=>') permite que você defina essa variável temporária para representar
                                //cada elemento da lista à medida que o método Find percorre os elementos.
                                //"procurado" não precisa ser declarada explicitamente no código, pois é uma variável implícita criada
                                //pela expressão lambda. O compilador C# a reconhece automaticamente e a utiliza para representar cada item
                                //da lista conforme o método Find percorre a lista.

                                //Lista o produto localizado através do código
                                Console.WriteLine();
                                Console.WriteLine($"Produto: " + localizaProduto);
                                Console.WriteLine();
                                Console.WriteLine();
                                Console.WriteLine("Precione Enter para continuar...");

                            }
                            Console.ReadKey();
                            break;
                        }
                    //Rotina responsável por listar todos os produtos
                    case 3:
                        {
                            Console.Clear();
                            foreach (Produto prod in produtos)
                            {
                                Console.WriteLine(prod.ToString());
                            }
                            Console.WriteLine();
                            Console.WriteLine("Precione Enter para continuar...");
                            Console.ReadKey();
                            break;
                        }
                    //Rotina responsável por acrescer preço do produto
                    case 4:
                        {
                            Console.Clear();
                            Console.Write("Informe o código do produto a receber aumento: ");
                            string codigo = Console.ReadLine();

                            if (codigo == null || codigo.Length < 1)
                                Console.WriteLine("Código invalido!");
                            else
                            {
                                //===============================================================
                                // Chamada do método BuscaProduto
                                //===============================================================
                                // Procurar o produto com o código informado, na lista de produtos
                                Produto produtoLocalizado = BuscaProduto(produtos, codigo);
                                if (produtoLocalizado == null)
                                {
                                    Console.WriteLine("Não existe produto com o código informado!");
                                }
                                else
                                {
                                    Console.Write("Informe o percentual de aumento: ");
                                    double percent = double.Parse(Console.ReadLine());
                                    Console.WriteLine();
                                    Console.WriteLine("Preço Atual:");
                                    Console.WriteLine(produtoLocalizado.ToString());
                                    //Chamada do método AcrescimoPreco da classe Produto
                                    produtoLocalizado.AcrescimoPreco(percent);
                                    Console.WriteLine();
                                    Console.WriteLine("Novo Preço:");
                                    Console.WriteLine(produtoLocalizado.ToString());
                                    Console.WriteLine();
                                    Console.WriteLine("Precione Enter para continuar...");
                                    Console.ReadKey();
                                }                                
                            }
                            break;
                        }
                    //Rotina responsável por conceder desconto de preço ao produto
                    case 5:
                        {
                            Console.Clear();
                            Console.Write("Informe o código do produto a receber desconto: ");
                            string codigo = Console.ReadLine();

                            if (codigo == null || codigo.Length < 1)
                                Console.WriteLine("Código invalido!");
                            else
                            {
                                //===============================================================
                                // Chamada do método BuscaProduto
                                //===============================================================
                                // Procurar o produto com o código informado, na lista de produtos
                                Produto produtoLocalizado = BuscaProduto(produtos, codigo);
                                if (produtoLocalizado == null)
                                {
                                    Console.WriteLine("Não existe produto com o código informado!");
                                }
                                else
                                {
                                    Console.Write("Informe o percentual de desconto: ");
                                    double percent = double.Parse(Console.ReadLine());
                                    Console.WriteLine();
                                    Console.WriteLine("Preço Atual:");
                                    Console.WriteLine(produtoLocalizado.ToString());
                                    //Chamada do método DescontoPreco da classe Produto
                                    produtoLocalizado.DescontoPreco(percent);
                                    Console.WriteLine();
                                    Console.WriteLine("Novo Preço:");
                                    Console.WriteLine(produtoLocalizado.ToString());
                                    Console.WriteLine();
                                    Console.WriteLine("Precione Enter para continuar...");
                                    Console.ReadKey();
                                }
                            }
                            break;
                        }
                }
            }
        }
        //Método BuscaProduto que realiza a procura de um produto através do código:
        /*O método BuscaProduto é do tipo Produto, pois vai retornar um objeto desse mesmo tipo, assim como métodos string retornam
         * uma estring, métodos int retornam um int etc. Por ser um método static, não é necessário instanciar um objeto para
         * usá-lo, e como está declarado dentro do program.cs não precisa colocar o nome da classe antes do método quando for
         * utilizá-lo, assim como ocorre no case 4 do switch usado acima, que faz o uso desse método.
         */
        static Produto BuscaProduto(List<Produto> origem, string codigo)
        {
            Produto produto = null;
            foreach (Produto product in origem)
            {
                if (product.Codigo.Equals(codigo))
                {
                    produto = product;
                    break;
                }
            }
            return produto;
        }
    }
}