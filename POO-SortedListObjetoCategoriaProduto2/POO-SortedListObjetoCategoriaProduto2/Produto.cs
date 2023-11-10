namespace POO_SortedListObjetoCategoriaProduto2
{
    class Produto
    {
        public int Id { get; set; }
        public string Descricao { get; set; }

        //Propriedade utilizando agregação com a classe Categoria
        public Categoria Cat { get; set; }

        public string ToString()
        {
            return $"{Id} {Descricao} {Cat.ToString()}";
        }
    }
}
