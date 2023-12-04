using MySql.Data.MySqlClient;

namespace AgendaMVC.Utils
{
    public class Conexao
    {
        //Cria a conexão com o Bando de Dados MySql
        public static MySqlConnection conectar()
        {
            string connString = "Server=localhost;Database=agenda;Uid=root;Pwd=admin";
            MySqlConnection connection = new MySqlConnection(connString);
            return connection;
        }
    }
}
