using ProdutoECategoriaNoBD.entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutoECategoriaNoBD.dao
{
    public class DaoProduto
    {
        public bool salvar(Produto produto)
        {
            //Qdo usamos o using não é preciso fechar a conexão
            using (SqlConnection con = new SqlConnection())
            {
                //Criando comando de conexão com o Banco de Dados
                con.ConnectionString = @"Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BD_Estoque;Integrated Security=True;Connect Timeout=30;Encrypt=False;";
                //con.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BD_Estoque;Integrated Security=True;Connect Timeout=30;Encrypt=False;";
                
                con.Open();
                //Monta o comando DML a ser enviado para o Banco de Dados
                SqlCommand cn = new SqlCommand();
                cn.CommandType = System.Data.CommandType.Text;
                cn.CommandText = "insert into tb_produto([Nome],[ValorUnitario],[QtdEstoque],[Id_Categoria] ) values (@Nome,@ValorUnitario,@QtdEstoque,@Id_Categoria)";

                //Envia dados a serem gravados
                cn.Parameters.Add("Nome", System.Data.SqlDbType.VarChar).Value = produto.Nome;
                cn.Parameters.Add("ValorUnitario", System.Data.SqlDbType.Decimal).Value = produto.ValorUnitario;
                cn.Parameters.Add("QtdEstoque", System.Data.SqlDbType.Int).Value = produto.QtdEstoque;
                cn.Parameters.Add("Id_Categoria", System.Data.SqlDbType.Int).Value = produto.Id_Categoria;

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
                con.ConnectionString = @"Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BD_Estoque;Integrated Security=True;Connect Timeout=30;Encrypt=False;";
                con.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BD_Estoque;Integrated Security=True;Connect Timeout=30;Encrypt=False;";
                //con.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BD_Estoque;Integrated Security=True;Connect Timeout=30;Encrypt=False;";

                con.Open();
                /*monta comando DML a ser enviado para o database*/
                SqlCommand cn = new SqlCommand();
                cn.CommandType = CommandType.Text;
                //cn.CommandText = "select * from tb_produto";
                //cn.CommandText = "SELECT p.Id, p.Nome, p.ValorUnitario, p.QtdEstoque, p.Id_Categoria, c.Descricao AS DescricaoCategoria FROM tb_produto p INNER JOIN tb_categoria c ON p.Id_Categoria = c.Id";
                cn.CommandText = "SELECT p.Id, p.Nome, p.ValorUnitario, p.QtdEstoque, p.Id_Categoria, c.Descricao AS DescricaoCategoria FROM tb_produto p INNER JOIN tb_categoria c ON p.Id_Categoria = c.Id";

                /*abrir a conexaõ*/
                cn.Connection = con;

                /*executa a conexão*/
                SqlDataReader dr;
                dr = cn.ExecuteReader();
                while (dr.Read())
                {
                    Produto prod = new Produto();
                    prod.Id = Convert.ToInt32(dr["Id"]);
                    prod.Nome = Convert.ToString(dr["Nome"]);
                    prod.ValorUnitario = Convert.ToDouble(dr["ValorUnitario"]);
                    prod.QtdEstoque = Convert.ToInt32(dr["QtdEstoque"]);
                    prod.Id_Categoria = Convert.ToInt32(dr["Id_Categoria"]);
                    //prod.DescricaoCategoria = Convert.ToString(dr["DescricaoCategoria"]);

                    // Cria um objeto Categoria e atribui ao Produto
                    Categoria categ = new Categoria();                    
                        categ.Id = Convert.ToInt32(dr["Id_Categoria"]);
                        categ.Descricao = Convert.ToString(dr["DescricaoCategoria"]);
                    

                    prod.Cat = categ;
                    Console.WriteLine(prod.ToString());
                }
            }
        }

    }
}
