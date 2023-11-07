namespace ExerciocioHerancaVeiculoMoto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Instanciação do veículo utilizando atributos da classe Veículo
            Veiculo veiculo01 = new Veiculo() 
            {
                Marca = "Honda", 
                Cor = "Preto" 
            };
            Console.WriteLine(veiculo01.ToString());
            Console.WriteLine();

            //Instanciação do veículo utilizando atributos da classe Moto e que herda atributos de Veiculo
            Moto veiculo02 = new Moto() 
            { 
                Marca = "Yamaha", 
                Cor = "Vermelha", 
                Cilindradas = 1300, 
                Suspensao = "mola média", 
                TipoPneu = "Sem garras" 
            };
            Console.WriteLine(veiculo02.ToString());
            Console.WriteLine();

            //Instanciação do veículo utilizando atributos da classe MotoPasseio e que herda atributos de Moto e Veiculo
            MotoPasseio veiculo03 = new MotoPasseio()
            {
                Marca = "Kawasaki",
                Cor = "Verde",
                Cilindradas = 1200,
                Suspensao = "mola baixa",
                TipoPneu = "Sem garras",
                Bau = "Sem Bau"
            };
            Console.WriteLine(veiculo03.ToString());
            Console.WriteLine();

            //Instanciação do veículo utilizando atributos da classe MotoPasseio e que herda atributos de Moto e Veiculo
            MotoCompeticao veiculo04 = new MotoCompeticao()
            {
                Marca = "Honda",
                Cor = "Amarela",
                Cilindradas = 450,
                Suspensao = "mola alta",
                TipoPneu = "Com garras",
                Carenagem = "Fibra de carbono"
            };
            Console.WriteLine(veiculo04.ToString());
            Console.WriteLine();



            Console.ReadKey();

        }
    }
}