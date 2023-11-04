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
                while (opcao < 1 || opcao > 6)
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
                                bool encontrado = false;
                                while (encontrado != true)
                                {
                                    //Ao percorrer uma lista usamos o .Count pois não tem o .Length, para varrer até o final
                                    for (int i = 0; i < veiculos.Count; i++)
                                    {
                                        if (veiculos[i].Placa == placa)
                                        {                                            
                                            Console.WriteLine($"Veículo: " + veiculos[i]);
                                            //Método que remove da lista toda aquela posição
                                            veiculos.RemoveAt(i);
                                            Console.WriteLine("Exclusão realizada com sucesso!");
                                            Console.WriteLine();
                                            Console.WriteLine();
                                            Console.WriteLine("Precione Enter para continuar...");
                                            encontrado = true;
                                        }

                                    }
                                }

                                /*
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
                                */

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
                                //============================================================================
                                // Utilização do método .Find (disponível nos elemesntos tipo List)
                                //============================================================================
                                // Procurar o carro com a placa informada, na lista de carros
                                Carro carroParaLocalizar = veiculos.Find(procurado => procurado.Placa == placa);

                                //"procurado" é uma variável temporária que representa cada elemento da lista veiculos durante a iteração
                                //do método Find. O operador lambda ('=>') permite que você defina essa variável temporária para representar
                                //cada elemento da lista à medida que o método Find percorre os elementos.
                                //"procurado" não precisa ser declarada explicitamente no código, pois é uma variável implícita criada
                                //pela expressão lambda. O compilador C# a reconhece automaticamente e a utiliza para representar cada item
                                //da lista conforme o método Find percorre a lista.

                                //Lista o carro localizado através da placa
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
                            Console.Write("Informe a placa do veículo a ser editado: ");
                            string placa = Console.ReadLine();

                            if (placa == null || placa.Length != 7)
                                Console.WriteLine("Numeração de placa invalida!");
                            else
                            {
                                //===============================================================
                                // Chamada do método BuscaCarro
                                //===============================================================
                                // Procurar o carro com a placa informada, na lista de carros
                                Carro carroLocalizado = BuscaCarro(veiculos, placa);
                                if (carroLocalizado == null)
                                {
                                    Console.WriteLine("Não existe veículo com a placa informada!");
                                }
                                else
                                {
                                    int opc = 0;
                                    Console.Clear();
                                    Console.WriteLine("ESCOLHA A OPÇÃO A SER EDITADA:");
                                    Console.WriteLine("     1 - PLACA");
                                    Console.WriteLine("     2 - MARCA");
                                    Console.WriteLine("     3 - MODELO");
                                    Console.WriteLine("     4 - COR");
                                    Console.WriteLine("     5 - CARRO (Altera todas as informações do veículo)");
                                    Console.WriteLine("     6 - MENU ANTERIOR");
                                    Console.WriteLine();
                                    Console.Write("OPÇÃO ESCOLHIDA............: ");
                                    opc = int.Parse(Console.ReadLine());

                                    while (opc < 1 || opc > 6)
                                    {
                                        Console.WriteLine("Opção inválida!");
                                        Console.Write("OPÇÃO ESCOLHIDA............: ");
                                        opc = int.Parse(Console.ReadLine());
                                    }

                                    switch (opc)
                                    {
                                        case 1:
                                            {
                                                Console.WriteLine("Placa atual: {0}", carroLocalizado.Placa);
                                                Console.Write("Nova Placa : ");
                                                carroLocalizado.Placa = Console.ReadLine();
                                                break;
                                            }
                                        case 2:
                                            {
                                                Console.WriteLine("Marca atual: {0}", carroLocalizado.Marca);
                                                Console.Write("Nova Marca : ");
                                                carroLocalizado.Marca = Console.ReadLine();
                                                break;
                                            }
                                        case 3:
                                            {
                                                Console.WriteLine("Modelo atual: {0}", carroLocalizado.Modelo);
                                                Console.Write("Novo Modelo : ");
                                                carroLocalizado.Modelo = Console.ReadLine();
                                                break;
                                            }
                                        case 4:
                                            {
                                                Console.WriteLine("Cor atual: {0}", carroLocalizado.Cor);
                                                Console.Write("Nova Cor : ");
                                                carroLocalizado.Cor = Console.ReadLine();
                                                break;
                                            }
                                        case 5:
                                            {
                                                Console.Write("Você realmente deseja alterar todos os dados deste veículo? (S/N)?: ");
                                                string escolha = Console.ReadLine();
                                                if (escolha == "S" || escolha == "s")
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("Alteração de todos os dados do veículo");
                                                    Console.Write("Informe a nova placa: ");
                                                    carroLocalizado.Placa = Console.ReadLine();
                                                    Console.Write("Informe a nova marca: ");
                                                    carroLocalizado.Marca = Console.ReadLine();
                                                    Console.Write("Informe o novo modelo: ");
                                                    carroLocalizado.Modelo = Console.ReadLine();
                                                    Console.Write("Informe a nova cor: ");
                                                    carroLocalizado.Cor = Console.ReadLine();
                                                    break;
                                                }

                                                break;
                                            }
                                            break;
                                    }

                                }
                            }
                            break;
                        }
                }
            }
            //Método BuscaCarro que realiza a procura de um carro através da placa:
            /*O método BuscaCarro é do tipo Carro, pois vai retornar um objeto desse mesmo tipo, assim como métodos string retornam
             * uma estring, métodos int retornam um int etc. Por ser um método static, não é necessário instanciar um objeto para
             * usá-lo, e como está declarado dentro do program.cs não precisa colocar o nome da classe antes do método quando for
             * utilizá-lo, assim como ocorre no case 5 do switch usado acima, que faz o uso desse método.
             */
            static Carro BuscaCarro(List<Carro> origem, string placa)
            {
                Carro carro = null;
                foreach (Carro car in origem)
                {
                    if (car.Placa.Equals(placa))
                    {
                        carro = car;
                        break;
                    }
                }
                return carro;
            }
        }
    }
}