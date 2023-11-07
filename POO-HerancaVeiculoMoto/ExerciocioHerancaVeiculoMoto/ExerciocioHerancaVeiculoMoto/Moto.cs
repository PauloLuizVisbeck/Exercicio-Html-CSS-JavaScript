namespace ExerciocioHerancaVeiculoMoto
{
    internal class Moto : Veiculo
    {
        public int Cilindradas { get; set; }
        public string TipoPneu { get; set; }
        public string Suspensao { get; set; }

        //Construtores
        public Moto()
        { }
        public Moto(string marca, string cor, int cilindrada, string tipoPneu, string suspensao ):base(marca, cor)
        {
            Cilindradas = cilindrada;
            TipoPneu = tipoPneu;
            Suspensao = suspensao;
        }

        //Método para escrever
        public string ToString()
        {
            string vemDeVeiculo = base.ToString();
            return $"{vemDeVeiculo}, Cilindrada: {Cilindradas},  Tipo de Pneu: {TipoPneu}, Suspensão: {Suspensao}";
        }

        //A linha do return poderia ser escrito sem a necessidade de criar a variável:
        //return $"{base.ToString()}, Cilindrada: {Cilindradas},  Tipo de Pneu: {TipoPneu}, Suspensão: {Suspensao}";
    }
}
