using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolimosrfismoEInyeccionDeDependencias2
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Realice una aplicación para el calculo de perímetros en figuras planas haciendo uso de sus formulas
            y conociendo que para las figuras siguientes basta con dos dimensiones para poder hallarlo.
            */

            /*Test t = new Test();

            Console.WriteLine("<<<<<<<<<<<<<<<<<Probamos Triagnulo>>>>>>>>>>>>>>>>>");
            Triangulo triangulo = new Triangulo(2, 4);
            t.probarInyeccion(triangulo);
            Console.WriteLine("<<<<<<<<<<<<<<<<<Probamos Cuadrado>>>>>>>>>>>>>>>");
            t.probarInyeccion(new Cuadrado(10));
            Console.Read();*/

            //este es el mismo ejercicio solo que en este caso no voy a realizar la  inyeccion de dependencia sino que muestro el area de las figuras mediante herencia
            Area[] i = new Area[3];

            i[0] = new Cuadrado(10);
            i[0].CalcularArea();
            i[1] = new Triangulo(2, 4);
            i[1].CalcularArea();
            i[2] = new Rombo(10, 5);
            i[2].CalcularArea();
            Console.Read();
        }
    }

    class Test
    {
        Area i;
        public void probarInyeccion(Area m)
        {
            this.i = m;
            this.i.CalcularArea();
        }
    }
    interface Area
    {
        void CalcularArea();
    }

    public class Cuadrado : Area
    {
        private int Lado = 0;

        public Cuadrado(int Lado)
        {
            this.Lado = Lado;
        }

        public void CalcularArea()
        {
            double resultado = 0;
            resultado = Math.Pow(this.Lado, 2);
            Console.WriteLine("area del cuadrado: " + resultado);
        }
    }

    public class Rectangulo : Area
    {
        private int Base = 0;
        private int Altura = 0;

        public Rectangulo(int Base, int Altura)
        {
            this.Base = Base;
            this.Altura = Altura;
        }

        public void CalcularArea()
        {
            double resultado = 0;
            resultado = this.Base * this.Altura;
            Console.WriteLine("area del rectangulo: " + resultado);
        }
    }

    public class Paralelogramo : Area
    {
        private int Base = 0;
        private int Altura = 0;

        public Paralelogramo(int Base, int Altura)
        {
            this.Base = Base;
            this.Altura = Altura;
        }

        public void CalcularArea()
        {
            double resultado = 0;
            resultado = this.Base * this.Altura;
            Console.WriteLine("area del paralelogramo: " + resultado);
        }
    }


    public class Rombo : Area
    {
        private int D = 0;
        private int d = 0;

        public Rombo(int D, int d)
        {
            this.D = D;
            this.d = d;
        }

        public void CalcularArea()
        {
            double resultado = 0;
            resultado = ((this.D * this.d) / 2);
            Console.WriteLine("area del rombo: " + resultado);
        }
    }

    public class Triangulo : Area
    {
        private int Base = 0;
        private int Altura = 0;

        public Triangulo(int Base, int Altura)
        {
            this.Base = Base;
            this.Altura = Altura;
        }

        public void CalcularArea()
        {
            double resultado = 0;
            resultado = ((this.Base * this.Altura) / 2);
            Console.WriteLine("area del triangulo: " + resultado);
        }
    }

    static class Constants
    {
        public const double Pi = 3.14159;
    }

    public class Circulo : Area
    {
        private int Radio = 0;


        public Circulo(int radio)
        {
            this.Radio = radio;
        }

        public void CalcularArea()
        {
            double resultado = 0;
            resultado = Math.Pow((Constants.Pi * this.Radio), 2);
            Console.WriteLine("area del ciruclo: " + resultado);
        }
    }
}
