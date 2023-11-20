using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcessandoBD.entidades;

namespace AcessandoBD.dao
{
    public class DaoLocais
    {
        public bool salvar(Locais locais)
        {
            //Qdo usamos o using não é preciso fechar a conexão
            using (SqlConnection con = new SqlConnection())
            {
                //Criando comando de conexão com o Banco de Dados
                con.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=bd_agenda;Integrated Security=True;Connect Timeout=30;Encrypt=False;";
                con.Open();
                //Monta o comando DML a ser enviado para o Banco de Dados
                SqlCommand cn = new SqlCommand();
                cn.CommandType = System.Data.CommandType.Text;
                cn.CommandText = "insert into locais([nome],[rua],[numero],[cidade],[uf]) values (@nome,@rua,@numero,@cidade,@uf)";

                //Envia dados a serem gravados
                cn.Parameters.Add("nome", System.Data.SqlDbType.VarChar).Value = locais.Nome;
                cn.Parameters.Add("rua", System.Data.SqlDbType.VarChar).Value = locais.Rua;
                cn.Parameters.Add("numero", System.Data.SqlDbType.VarChar).Value = locais.Numero;
                cn.Parameters.Add("cidade", System.Data.SqlDbType.VarChar).Value = locais.Cidade;
                cn.Parameters.Add("uf", System.Data.SqlDbType.VarChar).Value = locais.Uf;

                //Abrir conexão
                cn.Connection = con;

                //Executa a conexão
                return cn.ExecuteNonQuery() > 0;

            }
            return true;
        }
    }
}

