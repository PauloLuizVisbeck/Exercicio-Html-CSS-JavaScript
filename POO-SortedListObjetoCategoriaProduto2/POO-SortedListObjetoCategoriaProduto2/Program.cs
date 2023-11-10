namespace POO_SortedListObjetoCategoriaProduto2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Instanciando objetos do tipo Categoria
            Categoria cereal = new Categoria() { Id = 1, Descricao = "Cereal" };
            Categoria frutas = new Categoria() { Id = 2, Descricao = "Frutas" };
            Categoria frios = new Categoria() { Id = 3, Descricao = "Frios" };

            //Instanciando objetos do tipo Produto
            Produto milho = new Produto() { Id = 1, Descricao = "Milho", Cat = cereal };
            Produto arroz = new Produto() { Id = 2, Descricao = "Arroz", Cat = cereal };
            Produto laranja = new Produto() { Id = 3, Descricao = "Laranja", Cat = frutas };

            //Escrevendo um objeto através do método implementado dentro da classe
            Console.WriteLine(milho.ToString());


            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            //Criando uma SortedList chamada listaProdutos, cujo value é uma List de objetos do tipo Produto
            SortedList<string, List<Produto>> listaProdutos = new SortedList<string, List<Produto>>();

            //Criando uma List chamada listaCereal, que é uma é uma lista de objetos do tipo Produto
            List<Produto> listaCereal = new List<Produto>();

            //Adicionando objetos do tipo Produto, na lista listaCereal
            listaCereal.Add(milho);
            listaCereal.Add(arroz);

            //Adicionando a key (cereal.Descricao) e o value (listaCereal) na SortedList listaProdutos
            listaProdutos.Add(cereal.Descricao, listaCereal);

            //Criando uma List chamada listaFrutas, que é uma é uma lista de objetos do tipo Produto
            List<Produto> listaFrutas = new List<Produto>();

            //Adicionando objetos do tipo Produto, na lista listaFrutas
            listaFrutas.Add(laranja);

            //Adicionando a key (frutas.Descricao) e o value (listaFrutas) na SortedList listaProdutos
            listaProdutos.Add(frutas.Descricao, listaFrutas);

            //Criando uma List chamada listaFrios, que é uma é uma lista de objetos do tipo Produto
            List<Produto> listaFrios = new List<Produto>();

            //=========================================================================
            //Instanciando um objeto no momento em que o mesmo é atribuido a uma lista:
            //=========================================================================
            //Adicionando objetos do tipo Produto, na lista listaFrios
            listaFrios.Add(new Produto() { Id = 4, Descricao = "Queijo", Cat = frios });

            listaProdutos.Add(frios.Descricao, listaFrios);

            
            //Varrendo a listaProdutos e mostrando cada categoria e suas listas relacionadas:
            foreach (var item in listaProdutos)
            {
                Console.WriteLine(item.Key);
                List<Produto> lista = listaProdutos[item.Key];

                foreach (Produto prod in lista)
                {
                    Console.WriteLine(prod.ToString());
                }
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}