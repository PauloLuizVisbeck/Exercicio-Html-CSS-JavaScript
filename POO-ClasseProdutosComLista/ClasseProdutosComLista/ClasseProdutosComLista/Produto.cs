namespace ClasseProdutosComLista
{
    class Produto
    {
        //Auto Propriedade
        public string Codigo { get; set; }

        //Atributos privados (encapsulados)
        private string _descricao;
        private int _estoque;
        private double _valorUnitario;

        //================================================================================
        //Como abaixo temos mais de um método construtor, dizemos que temos uma sobrecarga
        //================================================================================

        //Construtor Padrão
        public Produto()
        { }

        //Construtor que recebe todos os parâmetros
        public Produto(string codigo, string descricao, int estoque, double valorUnitario)
        {
            Codigo = codigo;
            Descricao = descricao;
            Estoque = estoque;
            ValorUnitario = valorUnitario;
        }

        //================================================================================
        //Propriedades de acesso aos atributos privados
        //================================================================================

        //Propriedade de para acessar o atributo _descricao
        public string Descricao
        {
            get { return _descricao; }
            set
            {
                if (value != null && value.Length > 0)
                    _descricao = value;

                //Utilizando um método pronto da classe string. Abaixo, a atribuição "_descricao = value" só ocorre
                //se a string recebida (passada como value) não for nula ou vazia.
                //if (!string.IsNullOrEmpty (value))
                //    _descricao = value;
            }
        }

        //Propriedade de para acessar o atributo _estoque
        public int Estoque
        {
            get { return _estoque; }
            set
            {
                if (value != null && value >= 0)
                    _estoque = value;
            }
        }

        //Propriedade de para acessar o atributo _valorUnitario
        public double ValorUnitario
        {
            get { return _valorUnitario; }
            set
            {
                if (value != null && value > 0)
                    _valorUnitario = value;
            }
        }

        //================================================================================
        //Métodos para a manipulação dos atributos privados
        //================================================================================

        //Método para aplicar acréscimo no valor unitário
        public double AcrescimoPreco(double percentual)
        {
            double novoValorUnitario = ValorUnitario + (ValorUnitario * (percentual / 100));
            //Chamada da Propriedade "ValorUnitario" dentro do Método "novoValorUnitario"
            ValorUnitario = novoValorUnitario;
            return ValorUnitario;
        }

        //Método para aplicar desconto no valor unitário
        public double DescontoPreco(double percentual)
        {
            double novoValorUnitario = ValorUnitario - (ValorUnitario * (percentual / 100));
            ValorUnitario = novoValorUnitario;
            return ValorUnitario;
        }


        //Método ToString para imprimir o objeto
        public override string ToString()
        {
            return $"Codigo: {Codigo}, Descrição: {Descricao}, Estoque: {Estoque}, Valor Unitário: {ValorUnitario.ToString("F2")}";
        }

    }
}
