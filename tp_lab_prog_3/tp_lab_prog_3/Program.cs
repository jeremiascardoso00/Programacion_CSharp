using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp_lab_prog_3
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Dejo un par de ejercicios para que trabajen en casa ya les iré subiendo mas para que se diviertan.
            Transformar en código el siguiente pseudocódigo, relativo a determinar la naturaleza par o impar de un número.
            Pseudocódigo aludido:


            2.  Mostrar “Introduzca un número” : Pedir Num
            3.  Res = Num mod 2
            4.  Si Res = 0 Entonces
            Mostrar “El número es par”
            SiNo
            Mostrar “El número es impar”
                 FinSi
            5.  Fin

            Desarrollar una aplicacion en c# para que dado un número de 
            entrada calcule su correspondiente tabla de multiplicar
            */

            Console.WriteLine("Introduzca un número");
            int res = Convert.ToInt32(Console.ReadLine()) % 2;
            if (res == 0)
            {
                Console.WriteLine("El numero es par");
            }
            else
            {
                Conosole.WriteLine("El numero es impar");

            }
            Console.ReadKey();

            Console.WriteLine("aplicacion que genera tablas de multiplicar");

            Console.WriteLine("Ingrese un numero");
            
            resp = Console.ReadLine();

            for (int i=0; i<10; i++)
            {
                Console.WriteLine(resp + " * " + i + " = " + (resp * i));
            }
            Console.ReadKey();
        }
    }
}
