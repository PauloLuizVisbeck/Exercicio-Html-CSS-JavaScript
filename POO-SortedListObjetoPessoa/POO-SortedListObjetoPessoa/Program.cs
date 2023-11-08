namespace POO_SortedListObjetoPessoa
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Exercício: Criar uma coleção  com chave do tipo string recebendo o nome de uma pessoa e
            //no valor armazenar um objeto do tipo pessoa.

            // Criação de uma SortedList que recebe uma string como Key e um objeto do tipo Pessoa como Value.
            SortedList<string, Pessoa> alunos = new SortedList<string, Pessoa>();

            // Criando objetos Pessoa
            Pessoa p1 = new Pessoa() { Nome = "Paulo", Sobrenome = "Visbeck", Nacionalidade = "Brasileiro", Altura = 1.65, Peso = 70.00 };
            Pessoa p2 = new Pessoa() { Nome = "Michel", Sobrenome = "Puel", Nacionalidade = "Brasileiro", Altura = 1.72, Peso = 85.00 };
            Pessoa p3 = new Pessoa() { Nome = "Karine", Sobrenome = "Souza", Nacionalidade = "Brasileiro", Altura = 1.61, Peso = 63.00 };

            // Adicione os objetos Pessoa à SortedList
            alunos.Add(p1.Nome, p1);
            alunos.Add(p2.Nome, p2);
            alunos.Add(p3.Nome, p3);

            // Exibindo os valores da SortedList
            // A chave (Key) será apenas o atributo Nome do objeto
            // O valor (Value) será todo o objeto
            foreach (var aluno in alunos)
            {
                Console.WriteLine("Chave: " + aluno.Key);
                Console.WriteLine("Valor: " + aluno.Value.ToString());
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}