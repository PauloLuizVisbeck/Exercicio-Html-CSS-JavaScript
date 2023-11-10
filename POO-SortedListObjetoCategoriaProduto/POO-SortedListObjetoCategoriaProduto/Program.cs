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
            // Criando uma SortedList que associa uma descrição de categoria a um objeto CategoriaProduto
            SortedList<string, CategoriaProduto> ligarCategComProduto = new SortedList<string, CategoriaProduto>();

            // Criando instâncias de categorias
            Categoria categoria1 = new Categoria { Id_Cat = "A001", Descricao_Cat = "Graos" };
            Categoria categoria2 = new Categoria { Id_Cat = "A002", Descricao_Cat = "Farinhas" };
            Categoria categoria3 = new Categoria { Id_Cat = "A003", Descricao_Cat = "Limpeza" };
            Categoria categoria4 = new Categoria { Id_Cat = "A004", Descricao_Cat = "Bazar" };

            //Ciando instancias de produto
            Produto produto1 = new Produto { Id_Prod = "1", Descricao_Prod = "Arroz", Marca_Prod = "Urbano", Preco_Prod = 4.75 };
            Produto produto2 = new Produto { Id_Prod = "2", Descricao_Prod = "Feijão", Marca_Prod = "Dalfovo", Preco_Prod = 9.80 };
            Produto produto3 = new Produto { Id_Prod = "1", Descricao_Prod = "Farinha Trigo", Marca_Prod = "Nordeste", Preco_Prod = 7.50 };
            Produto produto4 = new Produto { Id_Prod = "2", Descricao_Prod = "Farinha Mandioca", Marca_Prod = "Zuke", Preco_Prod = 4.95 };
            Produto produto5 = new Produto { Id_Prod = "1", Descricao_Prod = "Sabonete", Marca_Prod = "Francis", Preco_Prod = 3.90 };
            Produto produto6 = new Produto { Id_Prod = "2", Descricao_Prod = "Shampoo", Marca_Prod = "Seda", Preco_Prod = 11.90 };
            Produto produto7 = new Produto { Id_Prod = "3", Descricao_Prod = "Papel Higienico", Marca_Prod = "Neve", Preco_Prod = 48.90 };
            Produto produto8 = new Produto { Id_Prod = "1", Descricao_Prod = "Panela", Marca_Prod = "Tramontina", Preco_Prod = 79.00 };

            // Adicionando produtos a categorias através do método AdicionarProdutoACategoria
            AdicionarProdutoACategoria(categoria1, produto1, ligarCategComProduto);
            AdicionarProdutoACategoria(categoria1, produto2, ligarCategComProduto);
            AdicionarProdutoACategoria(categoria2, produto3, ligarCategComProduto);
            AdicionarProdutoACategoria(categoria2, produto4, ligarCategComProduto);
            AdicionarProdutoACategoria(categoria3, produto5, ligarCategComProduto);
            AdicionarProdutoACategoria(categoria3, produto6, ligarCategComProduto);
            AdicionarProdutoACategoria(categoria3, produto7, ligarCategComProduto);
            AdicionarProdutoACategoria(categoria4, produto8, ligarCategComProduto);

            //==================================================================================================================================================================
            //Outra forma de adicionar produtos a categorias:
            //AdicionarProdutoACategoria(categoria1, new Produto { Id_Prod = "3", Descricao_Prod = "Produto3", Marca_Prod = "Marca3", Preco_Prod = 30.0 }, categoriasProdutos);
            //==================================================================================================================================================================

            // Listando os produtos por categoria através do método ListarProdutos
            ListarProdutos(ligarCategComProduto);
        }

        //Método AdicionarProdutoACategoria. Explicação dos parâmetros:
        //Categoria categoria: Este é o objeto de categoria que se deseja associar ao produto.
        //Produto produto: Este é o objeto de produto que você deseja adicionar à categoria.
        //SortedList<string, CategoriaProduto> categoriasProdutos: Esta é uma estrutura de dados SortedList que
        //mantém o mapeamento entre categorias e objetos CategoriaProduto.
        //string categoriaKey: Este é o índice de SortedListonde a categoria deve ser armazenada.
        static void AdicionarProdutoACategoria(Categoria categoria, Produto produto, SortedList<string, CategoriaProduto> ligarCategComProduto)
        {
            // Verifica se a categoria já existe na SortedList
            if (!ligarCategComProduto.ContainsKey(categoria.Id_Cat))
            {
                // Se não existir, cria uma nova entrada para a categoria
                ligarCategComProduto.Add(categoria.Id_Cat, new CategoriaProduto(categoria));
            }

            // Adiciona o produto à lista de produtos da categoria, porém não permite produtos repetidos (com o mesmo Id_Prod)
            if (!ligarCategComProduto[categoria.Id_Cat].prod.Any(p => p.Id_Prod == produto.Id_Prod))
            {
                ligarCategComProduto[categoria.Id_Cat].prod.Add(produto);
            }

        }

        static void ListarProdutos(SortedList<string, CategoriaProduto> ligarCategComProduto)
        {
            // Percorre as categorias e seus produtos
            foreach (var ligCatProd in ligarCategComProduto.Values)
            {
                foreach (var produto in ligCatProd.prod)
                {
                    // Exibe os detalhes da categoria e do produto
                    Console.WriteLine($"{ligCatProd.categ.Id_Cat}, {ligCatProd.categ.Descricao_Cat}, {produto.Id_Prod}, {produto.Descricao_Prod}, {produto.Marca_Prod}, R$ {produto.Preco_Prod.ToString("F2")}");
                }
            }
        }


    }
}