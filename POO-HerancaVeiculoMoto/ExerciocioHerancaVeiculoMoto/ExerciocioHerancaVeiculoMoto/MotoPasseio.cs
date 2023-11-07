namespace ExerciocioHerancaVeiculoMoto
{
    internal class MotoPasseio : Moto
    {
        public string Bau { get; set; }

        //Construtores
        public MotoPasseio()
        { }
        public MotoPasseio(string marca, string cor, int cilindrada, string tipoPneu, string suspensao, 
            string bau) : base(marca, cor, cilindrada, tipoPneu, suspensao)
        {
            Bau = bau;
        }

        //Método para escrever
        public string ToString()
        {
            string vemDeMoto = base.ToString();
            return $"{vemDeMoto}, Bau: {Bau}";
        }
    }
}
