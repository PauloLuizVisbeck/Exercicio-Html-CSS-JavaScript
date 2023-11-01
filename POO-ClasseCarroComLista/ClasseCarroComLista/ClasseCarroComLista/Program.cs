namespace ClasseCarroComLista
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Carro> veiculos = new List<Carro>();
            //Laço while principal que define qual case será executado
            int opcao = 0;
            while (opcao != 6)
            {
                Console.Clear();
                Console.WriteLine("ESCOLHA A OPÇÃO DESEJADA");
                Console.WriteLine("     1 - CADASTRAR CARRO");
                Console.WriteLine("     2 - EXCLUIR CARRO POR PLACA");
                Console.WriteLine("     3 - LISTAR TODOS OS CARROS");
                Console.WriteLine("     4 - LISTAR CARRO PELA PLACA");
                Console.WriteLine("     5 - EDITAR CARRO");
                Console.WriteLine("     6 - SAIR");
                Console.WriteLine();
                Console.Write("OPÇÃO ESCOLHIDA............: ");
                opcao = int.Parse(Console.ReadLine());
                while (opcao < 1 || opcao > 5)
                {
                    Console.WriteLine("Opção inválida!");
                    Console.Write("OPÇÃO ESCOLHIDA............: ");
                    opcao = int.Parse(Console.ReadLine());
                }

                char continuar = 's';                
                switch (opcao)
                {
                    //Case 1 - responsável pelo cadastro de um novo carro
                    case 1:
                        {
                            while (continuar != 'n' && continuar != 'N')
                            {
                                Console.Clear();
                                Console.Write("Informe a placa: ");
                                string placa = Console.ReadLine();
                                Console.Write("Informe a marca: ");
                                string marca = Console.ReadLine();
                                Console.Write("Informe o modelo: ");
                                string modelo = Console.ReadLine();
                                Console.Write("Informe a cor: ");
                                string cor = Console.ReadLine();

                                veiculos.Add(new Carro(placa, marca, modelo, cor));
                                

                                Console.Write("Deseja cadastrar outro carro (S/N)? ");
                                continuar = char.Parse(Console.ReadLine());
                            }
                            break;
                        }
                    //Case 2 - responsável pelo exclusão do carro através da placa
                    case 2:
                        {
                            Console.Clear();
                            Console.Write("Informe a placa do veículo para excluir: ");
                            string placa = Console.ReadLine();                   
                                                        
                            if (placa == null || placa.Length != 7)
                                Console.WriteLine("Numeração de placa invalida!");
                            else
                            {
                                // Procurar o carro com a placa informada na lista
                                Carro carroParaExcluir = veiculos.Find(procurado => procurado.Placa == placa);

                                //"procurado" é uma variável temporária que representa cada elemento da lista veiculos durante a iteração
                                //do método Find. O operador lambda ('=>') permite que você defina essa variável temporária para representar
                                //cada elemento da lista à medida que o método Find percorre os elementos.
                                //"procurado" não precisa ser declarada explicitamente no código, pois é uma variável implícita criada
                                //pela expressão lambda. O compilador C# a reconhece automaticamente e a utiliza para representar cada item
                                //da lista conforme o método Find percorre a lista.

                                //Lista o carro a ser excluido
                                Console.WriteLine();
                                Console.WriteLine($"Veículo: " + carroParaExcluir);
                                // Remove o carro da lista
                                veiculos.Remove(carroParaExcluir);
                                Console.WriteLine("Exclusão realizada com sucesso!");
                                Console.WriteLine();
                                Console.WriteLine();
                                Console.WriteLine("Precione Enter para continuar...");

                            }
                            Console.ReadKey();
                            break;
                        }
                    //Case 3 - responsável por listar todos os carros
                    case 3:
                        {
                            Console.Clear();
                            foreach (Carro car in veiculos)
                            {
                                Console.WriteLine(car.ToString());
                            }
                            Console.WriteLine();
                            Console.WriteLine("Precione Enter para continuar...");
                            Console.ReadKey();
                            break;
                        }
                    //Case 4 - responsável por listar um carros atraves da placa
                    case 4:
                        {
                            Console.Clear();
                            Console.Write("Informe a placa do veículo procurado: ");
                            string placa = Console.ReadLine();                   
                                              
                            if (placa == null || placa.Length != 7)
                                Console.WriteLine("Numeração de placa invalida!");
                            else
                            {
                                // Procurar o carro com a placa informada na lista
                                Carro carroParaLocalizar = veiculos.Find(procurado => procurado.Placa == placa);

                                //"procurado" é uma variável temporária que representa cada elemento da lista veiculos durante a iteração
                                //do método Find. O operador lambda ('=>') permite que você defina essa variável temporária para representar
                                //cada elemento da lista à medida que o método Find percorre os elementos.
                                //"procurado" não precisa ser declarada explicitamente no código, pois é uma variável implícita criada
                                //pela expressão lambda. O compilador C# a reconhece automaticamente e a utiliza para representar cada item
                                //da lista conforme o método Find percorre a lista.

                                //Lista o carro a ser excluido
                                Console.WriteLine();
                                Console.WriteLine($"Veículo: " + carroParaLocalizar);
                                Console.WriteLine();
                                Console.WriteLine();
                                Console.WriteLine("Precione Enter para continuar...");

                            }
                            Console.ReadKey();
                            break;
                        }
                    //Case 5 - responsável por editar um veículo localizado através da placa
                    case 5:
                        {
                            Console.Clear();
                            Console.Write("Informe a placa do veículo a ser alterado: ");
                            string placa = Console.ReadLine();

                            if (placa == null || placa.Length != 7)
                                Console.WriteLine("Numeração de placa invalida!");
                            else
                            {
                                // Procurar o carro com a placa informada na lista
                                Carro carroParaLocalizar = veiculos.Find(procurado => procurado.Placa == placa);
                                Console.Clear();
                                Console.Write("Informe a placa: ");
                                string placa = Console.ReadLine();
                                Console.Write("Informe a marca: ");
                                string marca = Console.ReadLine();
                                Console.Write("Informe o modelo: ");
                                string modelo = Console.ReadLine();
                                Console.Write("Informe a cor: ");
                                string cor = Console.ReadLine();

                                veiculos.Add(new Carro(placa, marca, modelo, cor));


                                Console.Write("Deseja cadastrar outro carro (S/N)? ");
                                continuar = char.Parse(Console.ReadLine());

                                break;
                            }
                        }

                }
            }
        }
    }
}