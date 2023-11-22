using ProdutoECategoriaNoBD.entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutoECategoriaNoBD.dao
{
    public class DaoCategoria
    {
        public bool salvar(Categoria categoria)
        {
            //Qdo usamos o using não é preciso fechar a conexão
            using (SqlConnection con = new SqlConnection())
            {
                //Criando comando de conexão com o Banco de Dados
                con.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BD_Estoque;Integrated Security=True;Connect Timeout=30;Encrypt=False;";
                //con.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BD_Estoque;Integrated Security=True;Connect Timeout=30;Encrypt=False;";
                

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


        public static void consultar()
        {
            using (SqlConnection con = new SqlConnection())
            {
                /*criado conexão com database*/
                con.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BD_Estoque;Integrated Security=True;Connect Timeout=30;Encrypt=False;";
                //con.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BD_Estoque;Integrated Security=True;Connect Timeout=30;Encrypt=False;";
                

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

    }
}
