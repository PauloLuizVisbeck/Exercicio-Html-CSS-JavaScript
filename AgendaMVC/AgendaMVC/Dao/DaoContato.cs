using System.Data;
using System.Data.SqlClient;
using AgendaMVC.Utils;
using AgendaMVC.Interfaces;
using AgendaMVC.Models;
using MySql.Data.MySqlClient;

namespace AgendaMVC.Dao
{
    public class DaoContato : ICrud<Contato>
    {
        //=============================================================================================
        //Método que altera os contatos no Banco de Dados (Nome do banco = agenda. Criado em MySQL).
        //=============================================================================================
        public bool alterar(Contato t)
        {
            throw new NotImplementedException();
        }

        public Contato consultar(int id)
        {
            throw new NotImplementedException();
        }

        //=============================================================================================
        //Método que consulta os contatos no Banco de Dados (Nome do banco = agenda. Criado em MySQL).
        //=============================================================================================
        public List<Contato> consultar()
        {
            List<Contato> contatos = new List<Contato>();

            MySqlConnection con = Conexao.conectar();
            MySqlCommand command = con.CreateCommand();

            try
            {
                con.Open();
                command.CommandText = "SELECT id, nome, email, telefone FROM contato";
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Contato contato = new Contato();
                        contato.Id = Convert.ToInt32(reader["id"]);
                        contato.Nome = reader["nome"].ToString();
                        contato.Email = reader["email"].ToString();
                        contato.Fone = reader["telefone"].ToString();

                        contatos.Add(contato);
                    }
                }
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }

            return contatos;
            throw new NotImplementedException();
        }

        //=============================================================================================
        //Método que exclui os contatos no Banco de Dados (Nome do banco = agenda. Criado em MySQL).
        //=============================================================================================

        public void excluir(int id)
        {
            MySqlConnection con = Conexao.conectar();
            MySqlCommand command = con.CreateCommand();

            try
            {
                con.Open();
                command.CommandText = "DELETE FROM contato WHERE id = @id";
                command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
                command.ExecuteNonQuery();
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
            //throw new NotImplementedException();
        }

        //==========================================================================================
        //Método que salva o contato no Banco de Dados (Nome do banco = agenda. Criado em MySQL).
        //==========================================================================================
        public bool salvar(Contato contato)
        {
            /* string connString = "Server=localhost;Database=agenda;Uid=root;Pwd=admin";
             MySqlConnection connection = new MySqlConnection(connString);
             MySqlCommand command = connection.CreateCommand();
            */
            MySqlConnection con = Conexao.conectar();
            MySqlCommand command = con.CreateCommand();
            try
            {
                con.Open();
                command.CommandText = "insert into contato(nome, email, telefone)values(@nome,@email,@telefone)";
                command.Parameters.Add("nome", MySqlDbType.VarString).Value = contato.Nome;
                command.Parameters.Add("email", MySqlDbType.VarString).Value = contato.Email;
                command.Parameters.Add("telefone", MySqlDbType.VarString).Value = contato.Fone;
                command.ExecuteNonQuery();
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
            return true;
            //throw new NotImplementedException();
        }


    }
}
