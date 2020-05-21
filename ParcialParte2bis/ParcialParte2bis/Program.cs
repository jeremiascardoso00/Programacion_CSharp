using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;

namespace ParcialParte2bis
{
    class Program
    {
        static void Main(string[] args)
        {

            DateTime Fecha1;
            DateTime Fecha2;

            Console.WriteLine("ingrese el primer instate de tiempo en este formato: \ndia, mes, año \n ");
            Fecha1 = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("ingrese el primer instate de tiempo en este formato: \ndia, mes, año\n ");
            Fecha2 = DateTime.Parse(Console.ReadLine());


            Random randomTest = new Random();


            TimeSpan periodo = Fecha2 - Fecha1;
            TimeSpan periodo2 = Fecha2 - Fecha1;

            Console.WriteLine("Ingrese la cantidad de fechas aleatorias que desea");
            int indice = int.Parse(Console.ReadLine());


            DateTime[] Fechas = new DateTime[indice];
            for (int i=0; i<Fechas.Length; i++)
            {
                
                TimeSpan newSpan = new TimeSpan((randomTest.Next(0, 2020)),(randomTest.Next(0, 30)),(randomTest.Next(0,24)), randomTest.Next(0, 60), randomTest.Next(0,60));
                DateTime newDate = Fecha1 + newSpan;
                if (newDate > Fecha2)
                {

                    i--;

                }
                else
                {

                    Fechas[i] = newDate;

                }
            }
            

            for (int i=0; i < Fechas.Length; i++)
            {
                Console.WriteLine(Fechas[i]);
            }


            Console.WriteLine("Ingrese en cuantos periodos lo quiere separar");
            int periodos = int.Parse(Console.ReadLine());

            int divicion = periodo.Days / periodos;


            Console.WriteLine(divicion);






            for (int i=0; i< periodos; i++)
            {
                
            }
            Console.ReadKey();


            

        }
    }
}
