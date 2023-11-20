using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcessandoBD.entidades
{
    public class Locais
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }

        public Locais() { }
        public Locais (int id, string nome, string rua, string numero,  string cidade, string uf)
        {
            Id = id;
            Nome = nome;
            Rua = rua;
            Numero = numero;
            Cidade = cidade;
            Uf = uf;
        }
    }
}
