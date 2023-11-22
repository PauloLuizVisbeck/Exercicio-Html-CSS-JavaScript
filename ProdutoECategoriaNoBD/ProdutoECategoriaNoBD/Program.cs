using ProdutoECategoriaNoBD.dao;
using ProdutoECategoriaNoBD.entidades;

namespace ProdutoECategoriaNoBD
{
    public class Program
    {
        static void Main(string[] args)
        {
            int opcao = 0;
            while (opcao != 5)
            {
                //Menu de opções
                Console.Clear();
                Console.WriteLine("Escolha a opção desejada:");
                Console.WriteLine("01................Cadastrar Categorias");
                Console.WriteLine("02................Consultar Categorias");
                Console.WriteLine("03................Cadastrar Produtos");
                Console.WriteLine("04................Consultar Produtos");
                Console.WriteLine("05................Sair");
                Console.WriteLine();
                Console.WriteLine();
                Console.Write("Opção escolhida: ");

                //Repete enquanto não houver a escolha de uma opção válida
                opcao = int.Parse(Console.ReadLine());
                while (opcao < 0 || opcao > 5)
                {
                    Console.WriteLine("Opção inválida...Escolha uma das opções acima!");
                    opcao = int.Parse(Console.ReadLine());
                }

                //Chamada dos métodos conforme escolha do usuário
                switch (opcao)
                {
                    case 1:
                        {
                            Console.Clear();
                            Console.Write("Informe a descrição da categoria: ");
                            string desc = Console.ReadLine();
                            Categoria ctg = new Categoria();
                            ctg.Descricao = desc;
                            DaoCategoria daoCategoria = new DaoCategoria();
                            if (daoCategoria.salvar(ctg))
                            {
                                Console.WriteLine();
                                Console.WriteLine();
                                Console.WriteLine("Categoria salva com sucesso!");
                                Console.WriteLine("Pressione Enter para continuar...");
                                Console.ReadKey();
                            }
                            break;
                        }
                    case 2:
                        {
                            Console.Clear();
                            Console.WriteLine("Lista de Categorias:");
                            DaoCategoria.consultar();
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine("Pressione Enter para continuar...");
                            Console.ReadKey();
                            break;
                        }
                    case 3:
                        {
                            Console.Clear();
                            Console.Write("Informe o nome do Produto: ");
                            string nome = Console.ReadLine();
                            Console.Write("Informe o valor do Produto: ");
                            double valor = double.Parse(Console.ReadLine());
                            Console.Write("Informe a quantidade em estoque do Produto: ");
                            int qtd = int.Parse(Console.ReadLine());
                            Console.Write("Informe a categoria do Produto: ");
                            int cat = int.Parse(Console.ReadLine());

                            Produto produto = new Produto(nome, valor, qtd, cat);
                            DaoProduto daoProduto = new DaoProduto();
                            if (daoProduto.salvar(produto))
                            {
                                Console.WriteLine();
                                Console.WriteLine();
                                Console.WriteLine("Produto salvo com sucesso!");
                                Console.WriteLine("Pressione Enter para continuar...");
                                Console.ReadKey();
                            }
                            break;
                        }
                    case 4:
                        {
                            Console.Clear();
                            Console.WriteLine("Lista de Categorias:");
                            DaoProduto.consultar();
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine("Pressione Enter para continuar...");
                            Console.ReadKey();
                            break;
                        }
                }

            }


            /*
            //Inserindo categorias no Banco de Dados
            Categoria ctg = new Categoria();
            ctg.Descricao = "Graos";
            DaoCategoria daoCategoria = new DaoCategoria();            
            if(daoCategoria.salvar(ctg))
            {
              Console.WriteLine("Categoria salva com sucesso!");
            }
            */

            //DaoCategoria.consultar();

            /*
            //Inserindo produtos no Banco de Dados            
            Produto produto = new Produto("Toalha", 12.50, 100, 1003);
            DaoProduto daoProduto = new DaoProduto();
            if (daoProduto.salvar(produto))
            {
                Console.WriteLine("Produto salvo com sucesso!");
            }
            */

            //DaoProduto.consultar();

        }
    }
}
