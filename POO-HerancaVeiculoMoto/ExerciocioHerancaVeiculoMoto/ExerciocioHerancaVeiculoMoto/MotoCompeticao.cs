namespace ExerciocioHerancaVeiculoMoto
{
    internal class MotoCompeticao : Moto
    {       
        public string Carenagem { get; set; }

        //Construtores
        public MotoCompeticao()
        { }
        public MotoCompeticao(string marca, string cor, int cilindrada, string tipoPneu, string suspensao,
            string carenagem) : base(marca, cor, cilindrada, tipoPneu, suspensao)
        {
            Carenagem = carenagem;
        }

        //Método para escrever
        public string ToString()
        {
            string vemDeMoto = base.ToString();
            return $"{vemDeMoto}, Carenagem: {Carenagem}";
        }
    }
}
