using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_Practico3
{
    public class Jerarquía
    {
        public static void Main(String[] args)
        {

            List<Figura> figuras = new List<Figura>();
            figuras.Add(new Circulo(10)); // Radio=10
            figuras.Add(new Cuadrado(10)); // Lado=10
            figuras.Add(new Triangulo(10, 5)); // Base=10,
            //Altura = 5;
            foreach (Figura f in figuras)
            {
                f.Area();
            }
            Console.ReadKey();
            
                
        }
    }
    public abstract class Figura
    {
        public abstract void Area();
    }
    static class Constants
    {
        public const double Pi = 3.14159;
        
    }


    public class Circulo: Figura
    {
        private int radio = 0;
        public Circulo(int radio)
        {
            this.radio = radio;
        }

        public override void Area()
        {
            double resultado = 0;
            resultado = Math.Pow((Constants.Pi * this.radio),2);
            Console.WriteLine("El area del circulo es: {0}", resultado);
        }
    }

    public class Cuadrado : Figura
    {
        private int Lado = 0;
        public Cuadrado(int Lado)
        {
            this.Lado = Lado;
        }


        public override void Area()
        {
            double resultado = Math.Pow(this.Lado, 2);
            Console.WriteLine("El area del cuadrado es: {0}", resultado);
        }
    }

    public class Triangulo : Figura
    {
        private int Base = 0;
        private int Altura = 0;
        public Triangulo(int Base, int Altura)
        {
            this.Base = Base;
            this.Altura = Altura;
        }

        public override void Area()
        {
            double resultado = (this.Base * this.Altura) / 2;
            Console.WriteLine("El area del triangulo es: {0}",resultado);

        }
    }

    

}
