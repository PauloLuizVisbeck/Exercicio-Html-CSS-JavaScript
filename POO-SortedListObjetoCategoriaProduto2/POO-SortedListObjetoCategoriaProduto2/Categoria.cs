namespace POO_SortedListObjetoCategoriaProduto2
{
    class Categoria
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string ToString()
        {
            return $"Id_Cat:{Id} Desc_Cat:{Descricao} ";
        }
    }
}
