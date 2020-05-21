using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estructuraDeDecisionEnCsharp
{
    class Program
    {
        static void Main(string[] args)
        {

            string texto = "";
            ConsoleKeyInfo c;
            Console.WriteLine("Ingrese texto");

            texto = Console.ReadLine();
            

            if (texto != "")
            {
                Console.WriteLine("elija una de las 3 opciones:" +
                    "1-Texto en mayúscula/n" +
                    "2-Texto en minúscula/n" +
                    "3-Texto Original/n");
                c=Console.ReadKey();
                if (c.KeyChar == 1)
                {
                    Console.WriteLine(texto.ToUpper());
                }else if (c.KeyChar == 2)
                {
                    Console.WriteLine(texto.ToLower());

                }
                else if (c.KeyChar == 3)
                {
                    Console.WriteLine(texto);
                }
            }
            else
            {
                Console.WriteLine("no ingreso ningun texto");
            }
           

           


            
        }
    }
}
