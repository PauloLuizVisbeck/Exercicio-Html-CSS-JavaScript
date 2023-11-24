using ProdutoECategoriaNoBDcomInterface.entidades;
using ProdutoECategoriaNoBDcomInterface.icrud;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProdutoECategoriaNoBDcomInterface.icrud
{
    public interface ICrud<T>
    {
        bool salvar(T t);

        void consultar();

        void excluir(int id_excluir);

        void alterar(T t);
    }
}
