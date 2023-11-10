namespace POO_SortedListObjetoCategoriaProduto
{
    internal class CategoriaProduto
    {
        public Categoria categ { get; set; } // Uma propriedade que armazena informações da categoria.
        public List<Produto> prod { get; set; } // Uma lista de produtos associada a esta categoria.

        //Construtor que recebe parâmetros
        public CategoriaProduto(Categoria cat)
        {
            categ = cat; // Inicializa a categoria para a instância atual.
            prod = new List<Produto>(); // Inicializa a lista de produtos como vazia.
        }
    }

    internal class Categoria
    {
        public string Id_Cat { get; set; } // Uma propriedade que armazena o ID da categoria.
        public string Descricao_Cat { get; set; } // Uma propriedade que armazena a descrição da categoria.
    }

    internal class Produto
    {
        public string Id_Prod { get; set; } // Uma propriedade que armazena o ID do produto.
        public string Descricao_Prod { get; set; } // Uma propriedade que armazena a descrição do produto.
        public string Marca_Prod { get; set; } // Uma propriedade que armazena a marca do produto.
        public double Preco_Prod { get; set; } // Uma propriedade que armazena o preço do produto.
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            
        }

        
    }
}