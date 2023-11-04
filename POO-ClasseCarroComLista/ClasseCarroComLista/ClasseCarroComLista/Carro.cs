namespace ClasseCarroComLista
{
    internal class Carro
    {
        //Atributos privados
        private string placa;
        private string marca;
        private string modelo;
        private string cor;

        //================================================================================
        //Como abaixo temos mais de um método construtor, dizemos que temos uma sobrecarga
        //================================================================================

        //Construtor Padrão
        public Carro() { }

        //Construtor com todos os parâmetros
        public Carro(string placa, string marca, string modelo, string cor)
        {
            Placa = placa;
            Marca = marca;
            Modelo = modelo;
            Cor = cor;
        }


        //================================================================================
        //Propriedades de acesso aos atributos privados
        //================================================================================

        public string Placa
        {
            get { return placa; }
            set
            {
                if (value.Length < 7 || value.Equals(""))
                {
                    Console.WriteLine("Informação de placa deve ter no mínimo 7 caracteres!");
                    placa = "XXXXXXX";
                }
                else
                    placa = value;
            }
        }

        public string Marca
        {
            get { return marca; }
            set
            {
                if (value.Length < 2)
                    Console.WriteLine("Informação de marca deve ter no mínimo 2 caracteres!");
                else
                    marca = value;
            }
        }

        public string Modelo
        {
            get { return modelo; }
            set
            {
                if (value.Length < 2)
                    Console.WriteLine("Informação de modelo deve ter no mínimo 2 caracteres!");
                else
                    modelo = value;
            }
        }

        public string Cor
        {
            get { return cor; }
            set
            {
                if (value.Length < 3)
                    Console.WriteLine("Informação de cor deve ter no mínimo 3 caracteres!");
                else
                    cor = value;
            }
        }



        // Método usando ToString
        public override string ToString()
        {
            return $"Placa: {Placa}, Marca: {Marca}, Modelo: {Modelo}, Cor: {Cor}";
        }

        // Método de escrita sem o ToString
        public void escrever()
        {
            Console.WriteLine($"Placa: {Placa}, Marca: {Marca}, Modelo: {Modelo}, Cor: {Cor}");
        }
    }
}
