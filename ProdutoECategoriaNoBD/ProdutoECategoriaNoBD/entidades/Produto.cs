using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutoECategoriaNoBD.entidades
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double ValorUnitario { get; set; }
        public int QtdEstoque { get; set; }
        public int Id_Categoria { get; set; }
        //public string DescricaoCategoria { get; set; }

        //Propriedade utilizando agregação com a classe Categoria
        public Categoria Cat { get; set; }

        public Produto() { }

        public Produto(string nome, double valorUnitario, int qtdEstoque, int id_Categoria)
        {            
            this.Nome = nome;
            this.ValorUnitario = valorUnitario;
            this.QtdEstoque = qtdEstoque;
            this.Id_Categoria = id_Categoria;
        }

        //{Cat.ToString()}

    public string ToString()
        {
            return $"Id_Categ: {Id_Categoria}, Desc_Categ: {Cat.Descricao}, Id_Produto: {Id}, Nome_Produto: {Nome}, Vlr_Unitario: {ValorUnitario}, Qtd_Estoque: {QtdEstoque}";
        }
    }
}
