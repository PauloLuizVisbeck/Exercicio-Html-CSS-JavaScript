namespace ClasseCarro
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Carro carro01 = new Carro();
            carro01.Placa = "MLO3922";
            carro01.Marca = "Ford";
            carro01.Modelo = "EcoSport";
            carro01.Cor = "Branco";
            //Invocando o método ToString definido dentro da classe carro
            Console.WriteLine(carro01.ToString());
            Console.WriteLine();

            Carro carro02 = new Carro() { Placa = "MGX1156", Marca = "Fiat", Modelo = "Pulse", Cor = "Vermelho" };
            //Acessando outro método de escrita dos atributos
            carro02.escrever();
            Console.WriteLine();

            //Instanciando o objeto e já passando parâmetros
            Carro carro03 = new Carro("PLS1207", "Honda", "Civic", "Preto");
            //Acessando outro método de escrita dos atributos
            carro03.escrever();
            Console.WriteLine();
            Console.ReadKey();

            
        }
    }
}