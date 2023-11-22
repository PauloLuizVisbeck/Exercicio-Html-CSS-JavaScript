using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutoECategoriaNoBD.entidades
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Descricao { get; set; }

        public Categoria() { }
        public Categoria(string descricao)
        {
            Descricao = descricao;
        }

        /*public string ToString()
        {
            return $"Id_Categoria:{Id} Descrição:{Descricao}";
        }*/
        public override string ToString()
        {
            return $"Id_Categoria:{Id} Descrição:{Descricao}";
        }
    }
}
