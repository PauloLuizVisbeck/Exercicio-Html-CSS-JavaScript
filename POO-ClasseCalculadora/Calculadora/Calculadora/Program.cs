namespace Calculadora
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Console.Write("Informe um número: ");
            double n1 = double.Parse(Console.ReadLine());
            Console.Write("Informe outro número: ");
            double n2 = double.Parse(Console.ReadLine());

            Calcula x = new Calcula(n1, n2);

            //Console.WriteLine(x.Num1);
            //Console.WriteLine(x.Num2);
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Soma é {0}:", x.Somar());
            Console.WriteLine("Subtração é {0}:", x.Subtrair());
            Console.WriteLine("Multiplicação é {0}:", x.Multiplicar());
            Console.WriteLine("Divisão é {0}:", x.Dividir().ToString("F2"));
            Console.ReadKey();
        }
    }
}