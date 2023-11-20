using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcessandoBD.entidades;

namespace AcessandoBD.dao
{
    public class DaoContatos
    {
        public bool salvar (Contato contato)
        {
            //Qdo usamos o using não é preciso fechar a conexão
            using(SqlConnection con = new SqlConnection())
            {
                //Criando comando de conexão com o Banco de Dados
                con.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=bd_agenda;Integrated Security=True;Connect Timeout=30;Encrypt=False;";
                con.Open();
                //Monta o comando DML a ser enviado para o Banco de Dados
                SqlCommand cn = new SqlCommand();
                cn.CommandType = System.Data.CommandType.Text;
                cn.CommandText = "insert into contatos([nome],[email],[telefone]) values (@nome,@email,@telefone)";

                //Envia dados a serem gravados
                cn.Parameters.Add("nome", System.Data.SqlDbType.VarChar).Value = contato.Nome;
                cn.Parameters.Add("email", System.Data.SqlDbType.VarChar).Value = contato.Email;
                cn.Parameters.Add("telefone", System.Data.SqlDbType.VarChar).Value = contato.Telefone;

                //Abrir conexão
                cn.Connection = con;

                //Executa a conexão
                return cn.ExecuteNonQuery() > 0;
                
            }
            return true;
        }

        
        public void consultar()
        {
            using (SqlConnection con = new SqlConnection())
            {
                /*criado conexão com database*/
                con.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=bd_agenda;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                con.Open();
                /*monta comando DML a ser enviado para o database*/
                SqlCommand cn = new SqlCommand();
                cn.CommandType = CommandType.Text;
                cn.CommandText = "select * from contatos";

                /*abrir a conexaõ*/
                cn.Connection = con;

                /*executa a conexão*/
                SqlDataReader dr;
                dr = cn.ExecuteReader();
                while (dr.Read())
                {
                    Contato ct = new Contato();
                    ct.Id = Convert.ToInt32(dr["id"]);
                    ct.Nome = Convert.ToString(dr["nome"]);
                    ct.Email = Convert.ToString(dr["email"]);
                    ct.Telefone = Convert.ToString(dr["telefone"]);
                    Console.WriteLine(ct.ToString());
                }
            }
        }

    }
}
