using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcialParte2
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime[] arreglo = new DateTime[4];
            int decision = 0;
            int contador = 0;
            arreglo[0] = new DateTime(2020, 05, 08);
            arreglo[1] = new DateTime(2020, 05, 14);
            arreglo[2] = new DateTime(2020, 05, 16);
            arreglo[3] = new DateTime(2020, 05, 20);

            Console.WriteLine("cuenta con {0} fechas", arreglo.Length);
            DateTime fecha1 = new DateTime();
            DateTime fecha2 = new DateTime();
            do
            {
                contador++;
                for (int i = 0; i < arreglo.Length; i++)
                {
                    Console.WriteLine("fecha numero {0}: {1}", (i + 1), arreglo[i]);
                }
                Console.WriteLine("elija la fecha 1, ingrese AÑO, MES, DIA");
                fecha1 = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("elija la fecha 2, ingrese AÑO, MES, DIA");
                fecha1 = DateTime.Parse(Console.ReadLine());
                Periodo(fecha1, fecha2);


                
                Console.WriteLine("desea seguir agregando periodos? SI=1, NO=0");
                decision = int.Parse(Console.ReadLine());

            } while (decision !=0);

            

            
        }
        static void Periodo(DateTime fecha1, DateTime fecha2)
        {
            TimeSpan periodo1 = fecha1 - fecha2;
            periodo1 - fecha1;
            
        }
    }
}
