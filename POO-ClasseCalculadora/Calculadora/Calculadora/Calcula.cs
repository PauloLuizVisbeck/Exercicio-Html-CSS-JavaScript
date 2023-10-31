namespace Calculadora
{
    internal class Calcula
    {
        private double num1;
        private double num2;

        //Construtor padrão (se tiver apenas ele de construtor, não precisa implementá-lo)
        public Calcula() { }

        //Construtor com dois parâmetros
        public Calcula(double num1, double num2)
        {
            this.num1 = num1;
            this.num2 = num2;
        }

        //Propriedade para leitura e escrita no atributo privado num1
        public double Num1
        {
            get { return num1; }
            set
            {
                if (value <= 0)
                    Console.WriteLine("Informe um valor maior que zero!");
                else
                    num1 = value;
            }
        }

        //Propriedade para leitura e escrita no atributo privado num2
        public double Num2
        {
            get { return num2; }
            set
            {
                if (value <= 0)
                    Console.WriteLine("Informe um valor maior que zero!");
                else
                    num2 = value;
            }
        }
        //Metodo para realizar a soma
        public double Somar()
        {
            return num1 + num2;
        }

        //Metodo para realizar a subtração
        public double Subtrair()
        {
            return num1 - num2;
        }

        //Metodo para realizar a multiplicação
        public double Multiplicar()
        {
            return num1 * num2;
        }

        //Metodo para realizar a divisão
        public double Dividir()
        {
            return num1 / num2;
        }
    }
}
