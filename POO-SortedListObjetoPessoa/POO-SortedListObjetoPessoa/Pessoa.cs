namespace POO_SortedListObjetoPessoa
{

    internal class Pessoa
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Nacionalidade { get; set; }
        public double Altura { get; set; }
        public double Peso { get; set; }

        public string ToString()
        {
            return $"{Nome}, {Sobrenome}, {Nacionalidade}, {Altura}, {Peso}";
        }
    }

}

