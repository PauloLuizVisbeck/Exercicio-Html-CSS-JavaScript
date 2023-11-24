using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProdutoECategoriaNoBDcomInterface.icrud;
using ProdutoECategoriaNoBDcomInterface.entidades;

namespace ProdutoECategoriaNoBDcomInterface.dao
{
    public class DaoCategoria:ICrud<Categoria>
    {
        //===========================================================================
        // Método para salvar uma categorias no Banco de Dados
        //===========================================================================
        public bool salvar(Categoria categoria)
        {
            //Qdo usamos o using não é preciso fechar a conexão
            using (SqlConnection con = new SqlConnection())
            {
                //Criando comando de conexão com o Banco de Dados
                con.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BD_Estoque;Integrated Security=True;Connect Timeout=30;Encrypt=False;";


                con.Open();
                //Monta o comando DML a ser enviado para o Banco de Dados
                SqlCommand cn = new SqlCommand();
                cn.CommandType = System.Data.CommandType.Text;
                cn.CommandText = "insert into tb_categoria([Descricao]) values (@Descricao)";

                //Envia dados a serem gravados
                cn.Parameters.Add("Descricao", System.Data.SqlDbType.VarChar).Value = categoria.Descricao;


                //Abrir conexão
                cn.Connection = con;

                //Executa a conexão
                return cn.ExecuteNonQuery() > 0;

            }
            //return true;
        }

        //===========================================================================
        // Método para consultar todas as categorias do Banco de Dados
        // Método static = Não precisa instanciar objeto para invocá-lo
        //===========================================================================
        public void consultar()
        {
            using (SqlConnection con = new SqlConnection())
            {
                /*criado conexão com database*/
                con.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BD_Estoque;Integrated Security=True;Connect Timeout=30;Encrypt=False;";


                con.Open();
                /*monta comando DML a ser enviado para o database*/
                SqlCommand cn = new SqlCommand();
                cn.CommandType = CommandType.Text;
                cn.CommandText = "select * from tb_categoria";

                /*abrir a conexaõ*/
                cn.Connection = con;

                /*executa a conexão*/
                SqlDataReader dr;
                dr = cn.ExecuteReader();
                while (dr.Read())
                {
                    Categoria ct = new Categoria();
                    ct.Id = Convert.ToInt32(dr["Id"]);
                    ct.Descricao = Convert.ToString(dr["Descricao"]);


                    Console.WriteLine(ct.ToString());
                }
            }
        }

        //===========================================================================
        // Método para excluir uma categoria no Banco de Dados
        // Método static = Não precisa instanciar objeto para invocá-lo
        //===========================================================================
        public void excluir(int id_excluir)
        {
            using (SqlConnection conexao = new SqlConnection())
            {
                // Cria a conexão com database
                conexao.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BD_Estoque;Integrated Security=True;Connect Timeout=30;Encrypt=False;";

                // Abre a conexão
                conexao.Open();

                // Monta comando DML a ser enviado para o database*/
                SqlCommand cn = new SqlCommand();
                cn.CommandType = CommandType.Text;
                cn.CommandText = "DELETE from tb_categoria where id = @id_excluir";

                /* Método que cria um parâmetro chamado @id_excluir e atribui a ele o valor
                 * da variável id_excluir. Isso significa que, no comando SQL que será
                 * executado (DELETE FROM tb_categoria WHERE id = @id_excluir), o parâmetro
                 * @id_excluir será substituído pelo valor contido na variável id_excluir.
                 * Esse método AddWithValue associa automaticamente o tipo de dado do 
                 * parâmetro ao tipo de dado da variável id_excluir, simplificando a 
                 * configuração do parâmetro. Também vai ajudar a prevenir vulnerabilidades
                 * de segurança, como ataques de injeção de SQL.*/
                cn.Parameters.AddWithValue("@id_excluir", id_excluir);

                /* Informando ao objeto cn, que é do tipo SqlCommand que ele deve utilizar
                 * a conexão para executar o comando SQL.*/
                cn.Connection = conexao;

                /* Executa o comando SQL definido no objeto. Como já configuramos o comando
                 * DELETE e associamos a conexão, esta linha de código executará a exclusão
                 * dos registros da tabela tb_categoria onde o ID é igual ao valor que foi
                 * passado como parâmetro (id_excluir). Essa função ExecuteNonQuery() é usa-
                 * da para executar comandos SQL que não retornam dados, como é o caso de
                 * comandos DELETE, UPDATE ou INSERT. */
                cn.ExecuteNonQuery();
            }
        }

        //===========================================================================
        // Método para alterar uma categorias no Banco de Dados
        // Método static = Não precisa instanciar objeto para invocá-lo
        //===========================================================================
        public void alterar(Categoria ctg)
        {
            using (SqlConnection conexao = new SqlConnection())
            {
                // Cria a conexão com database
                conexao.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BD_Estoque;Integrated Security=True;Connect Timeout=30;Encrypt=False;";

                // Abre a conexão
                conexao.Open();

                // Monta comando DML a ser enviado para o database*/
                SqlCommand cn = new SqlCommand();
                cn.CommandType = CommandType.Text;
                cn.CommandText = "UPDATE tb_categoria SET Descricao = @Descricao WHERE Id = @Id;";


                cn.Parameters.Add("@Id", System.Data.SqlDbType.VarChar).Value = ctg.Id;
                cn.Parameters.Add("@Descricao", System.Data.SqlDbType.NVarChar).Value = ctg.Descricao;


                /* Informando ao objeto cn, que é do tipo SqlCommand que ele deve utilizar
                 * a conexão para executar o comando SQL.*/
                cn.Connection = conexao;

                /* Executa o comando SQL definido no objeto. Como já configuramos o comando
                 * DELETE e associamos a conexão, esta linha de código executará a exclusão
                 * dos registros da tabela tb_categoria onde o ID é igual ao valor que foi
                 * passado como parâmetro (id_excluir). Essa função ExecuteNonQuery() é usa-
                 * da para executar comandos SQL que não retornam dados, como é o caso de
                 * comandos DELETE, UPDATE ou INSERT. */
                cn.ExecuteNonQuery();
            }
        }

        //===========================================================================
        // Método para resetar todo o Banco de Dados tb_categoria
        // Método static = Não precisa instanciar objeto para invocá-lo
        //===========================================================================
        public static void resetar_tb_categoria()
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BD_Estoque;Integrated Security=True;Connect Timeout=30;Encrypt=False;";

            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                // Abre a conexão com o banco de dados
                conexao.Open();

                /* Inicia uma transação no banco de dados usando o objeto SqlTransaction 
                 * associado à conexão "conexao". Uma transação permite agrupar diversas
                 * operações em uma única unidade lógica de trabalho, garantindo que todas
                 * sejam realizadas com sucesso ou revertidas se ocorrer algum erro.*/
                SqlTransaction transaction = conexao.BeginTransaction();

                /* Inicia um bloco try para tratamento de abordagens e cria um novo objeto 
                 * SqlCommand associado à conexão "conexao" dentro da transação transaction.*/
                try
                {
                    SqlCommand cmd = conexao.CreateCommand();
                    cmd.Transaction = transaction;

                    /* Define o texto do comando SQL para excluir todos os dados da tabela 
                     * tb_produtoe executar esse comando utilizando o método ExecuteNonQuery().
                     * Isso resulta na remoção de todos os registros da tabela.*/
                    cmd.CommandText = "DELETE FROM tb_categoria;";
                    cmd.ExecuteNonQuery();

                    /* Define que o índice da tabele deve iniciar a partir do zero, ou seja,
                     * o indice iniciará em 1. */
                    cmd.CommandText = "DBCC CHECKIDENT ('tb_categoria', RESEED, 0);";
                    cmd.ExecuteNonQuery();

                    /* Se todas as operações dentro do bloco tryforem bem-sucedidas, a 
                     * transação é concluída ( Commit), ou que efetivam as mudanças no banco 
                     * de dados. A conexão com o banco de dados é fechada após o Commit.*/
                    transaction.Commit();
                }
                /* Se ocorrer alguma exceção durante as operações dentro do bloco try, a 
                 * transação é revertida ( Rollback). O código dentro do bloco catché acionado
                 * para lidar com a exceção, fechando a conexão com o banco de dados após a 
                 * reversão da transação.*/
                catch (Exception ex)
                {
                    // Reverte a transação em caso de erro
                    transaction.Rollback();
                    // Fecha a conexao com o Banco
                    conexao.Close();
                }
            }

        }
    }
}
