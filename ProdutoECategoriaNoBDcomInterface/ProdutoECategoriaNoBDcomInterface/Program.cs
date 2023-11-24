using ProdutoECategoriaNoBDcomInterface.dao;
using ProdutoECategoriaNoBDcomInterface.entidades;

namespace ProdutoECategoriaNoBDcomInterface
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int opcao = 0;
            while (opcao != 10)
            {
                //Menu de opções
                Console.Clear();
                Console.WriteLine("          Escolha a opção desejada:");
                Console.WriteLine();
                Console.WriteLine("=============== CATEGORIAS ===============");
                Console.WriteLine("|01................Cadastrar Categorias   |");
                Console.WriteLine("|02................Listar Categorias      |");
                Console.WriteLine("|03................Excluir Categoria      |");
                Console.WriteLine("|04................Alterar Categoria      |");
                Console.WriteLine("================ PRODUTOS ================");
                Console.WriteLine("|05................Cadastrar Produtos     |");
                Console.WriteLine("|06................Listar Produtos        |");
                Console.WriteLine("|07................Excluir Produto        |");
                Console.WriteLine("|08................Alterar Produto        |");
                Console.WriteLine("==========================================");
                Console.WriteLine("|09................Modo Administrador     |");
                Console.WriteLine("|10................Sair                   |");
                Console.WriteLine("==========================================");
                Console.WriteLine();
                Console.WriteLine();
                Console.Write("Opção escolhida: ");

                //Repete enquanto não houver a escolha de uma opção válida
                opcao = int.Parse(Console.ReadLine());
                while (opcao < 0 || opcao > 10)
                {
                    Console.WriteLine("Opção inválida...Escolha uma das opções acima!");
                    Console.Write("Opção escolhida: ");
                    opcao = int.Parse(Console.ReadLine());
                }

                //Chamada dos métodos conforme escolha do usuário
                switch (opcao)
                {
                    // Cadastrar Categorias
                    case 1:
                        {
                            Console.Clear();
                            Console.Write("Informe a descrição da categoria: ");
                            string desc = Console.ReadLine();
                            Categoria ctg = new Categoria();
                            ctg.Descricao = desc;
                            //Chamada do método da classe DaoCategoria
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
                    // Listar Categorias
                    case 2:
                        {
                            Console.Clear();
                            Console.WriteLine("Lista de Categorias:");
                            //Chamada do método da classe DaoCategoria
                            DaoCategoria cat = new DaoCategoria();
                            cat.consultar();
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine("Pressione Enter para continuar...");
                            Console.ReadKey();
                            break;
                        }
                    // Excluir Categoria
                    case 3:
                        {
                            Console.Clear();
                            Console.Write("Informe o Id da categoria a ser excluida (0 = desistir): ");
                            int id_excluir = int.Parse(Console.ReadLine());
                            if (id_excluir > 0)
                            {
                                //Chamada do método da classe DaoCategoria
                                DaoCategoria cat = new DaoCategoria();
                                cat.excluir(id_excluir);
                                Console.WriteLine();
                                Console.WriteLine();
                                Console.WriteLine("Exclusão realizada com sucesso!");
                                Console.ReadKey();
                            }
                            break;
                        }
                    //Alterar Categoria
                    case 4:
                        {
                            Console.Clear();
                            Console.Write("Informe o Id da categoria a ser alterada (0 = desistir): ");
                            int id_alterar = int.Parse(Console.ReadLine());
                            if (id_alterar > 0)
                            {
                                Console.Write("Informe o novo nome da categoria: ");
                                string nome_alterar = Console.ReadLine();

                                //Atribuindo valores ao objeto sem uso do construtor
                                Categoria categoria = new Categoria();
                                {
                                    categoria.Id = id_alterar;
                                    categoria.Descricao = nome_alterar;
                                }
                                //Chamada do método da classe DaoCategoria
                                DaoCategoria cat = new DaoCategoria();
                                cat.alterar(categoria);
                                Console.WriteLine();
                                Console.WriteLine();
                                Console.WriteLine("Alteração realizada com sucesso!");
                            }
                            Console.WriteLine("Pressione Enter para continuar...");
                            Console.ReadKey();
                            break;
                        }
                    // Cadastrar Produtos
                    case 5:
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

                            //Atribuindo valores ao objeto usando o construtor
                            Produto produto = new Produto(nome, valor, qtd, cat);
                            //Chamada do método da classe DaoProduto
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
                    // Listar Produtos
                    case 6:
                        {
                            Console.Clear();
                            Console.WriteLine("Lista de Produtos:");
                            //Chamada do método da classe DaoProduto
                            DaoProduto produto = new DaoProduto();
                            produto.consultar();
                            Console.WriteLine();
                            Console.WriteLine();
                            Console.WriteLine("Pressione Enter para continuar...");
                            Console.ReadKey();
                            break;
                        }
                    // Excluir Produto
                    case 7:
                        {
                            Console.Clear();
                            Console.Write("Informe o Id do produto a ser excluido (0 = desistir): ");
                            int id_excluir = int.Parse(Console.ReadLine());
                            if (id_excluir > 0)
                            {
                                //Chamada do método da classe DaoProduto
                                DaoProduto produto = new DaoProduto();
                                produto.excluir(id_excluir);
                                Console.WriteLine();
                                Console.WriteLine();
                                Console.WriteLine("Exclusão realizada com sucesso!");
                                Console.ReadKey();
                            }
                            break;
                        }
                    //Alterar Produto
                    case 8:
                        {
                            Console.Clear();
                            Console.Write("Informe o Id do produto a ser alterado (0 = desistir): ");
                            int id_alterar = int.Parse(Console.ReadLine());
                            if (id_alterar > 0)
                            {
                                Console.Write("Informe o novo nome do produto: ");
                                string nome_alterar = Console.ReadLine();
                                Console.Write("Informe o novo valor do produto: ");
                                double valor_alterar = double.Parse(Console.ReadLine());
                                Console.Write("Informe o novo estoque do produto: ");
                                int estoque_alterar = int.Parse(Console.ReadLine());
                                Console.Write("Informe a nova categoria do produto: ");
                                int categoria_alterar = int.Parse(Console.ReadLine());

                                //Atribuindo valores ao objeto sem uso do construtor
                                Produto produto = new Produto();
                                {
                                    produto.Id = id_alterar;
                                    produto.Nome = nome_alterar;
                                    produto.ValorUnitario = valor_alterar;
                                    produto.QtdEstoque = estoque_alterar;
                                    produto.Id_Categoria = categoria_alterar;
                                }
                                //Chamada do método da classe DaoCategoria
                                DaoProduto prod = new DaoProduto();
                                prod.alterar(produto);
                                Console.WriteLine();
                                Console.WriteLine();
                                Console.WriteLine("Alteração realizada com sucesso!");
                            }
                            Console.WriteLine("Pressione Enter para continuar...");
                            Console.ReadKey();
                            break;
                        }
                    //Alterar Produto
                    case 9:
                        {
                            Console.Clear();
                            Console.WriteLine("ATENÇÃO: ESSE MODO PERMITE RESERTAR OS BANCOS DE DADOS!");
                            Console.WriteLine("ATENÇÃO: ESSA AÇÃO É PERMANENTE!");
                            Console.WriteLine();
                            Console.Write("Deseja prosseguir (S/N)? :");
                            char escolha = char.Parse(Console.ReadLine().ToLower());
                            if (escolha == 's')
                            {
                                Console.WriteLine("Informe a tabela a ser resetada:");
                                Console.WriteLine("01....................Categoria");
                                Console.WriteLine("02....................Produto");
                                Console.WriteLine("03....................Sair");
                                Console.WriteLine();
                                Console.Write("Opção escolhida: ");
                                int opcao2 = int.Parse(Console.ReadLine());
                                while (opcao2 < 0 || opcao2 > 3)
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("Opção inválida...Escolha uma das opções acima!");
                                    Console.Write("Opção escolhida: ");
                                    opcao2 = int.Parse(Console.ReadLine());
                                }

                                switch (opcao2)
                                {
                                    case 1:
                                        {
                                            DaoCategoria.resetar_tb_categoria();
                                            Console.WriteLine();
                                            Console.WriteLine();
                                            Console.WriteLine("Tabela tb_categoria RESETADA!");
                                            break;

                                        }
                                    case 2:
                                        {
                                            DaoProduto.resetar_tb_produto();
                                            Console.WriteLine();
                                            Console.WriteLine();
                                            Console.WriteLine("Tabela tb_produto RESETADA!");
                                            break;
                                        }
                                }


                            }
                            Console.WriteLine("Pressione Enter para continuar...");
                            Console.ReadKey();
                            break;
                        }

                }

            }
        }
    }
}
