namespace ExerciocioHerancaVeiculoMoto
{
    internal class Veiculo
    {
        public string Marca { get; set; }
        public string Cor { get; set; }

        //Construtores
        public Veiculo()
        { }
        public Veiculo (string marca, string cor)
        {
            Marca = marca;
            Cor = cor;
        }

        //Método para escrever
        public string ToString()
        {
            return $"Marca:{Marca}  Cor:{Cor} ";
        }
    }
}
