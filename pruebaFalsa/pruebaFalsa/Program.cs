using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace pruebaFalsa
{
    class Program
    {
        static void Main(string[] args)
        {

            /*int[] arr = { 1, 4, 5 };
            System.Console.WriteLine("En Main, antes de llamar al metodo, primer elemento: " +
                "{0}", arr[0]);
            Change(ref arr,out int a);
            System.Console.WriteLine("En Main, despues de llamar al metodo, primer elemento:" +
                "{0}", arr[0]);
            System.Console.WriteLine("En Main, despues de llamar al metodo, primer elemento:" +
                "{0}", arr.Length);

            if (true ^ false)
            {
                System.Console.WriteLine("OR exclusivo");
            }
            Console.ReadKey();*/



            /*
             Ejercicio - Calendario
             Realice una clase utilitaria de manejo de tiempo y fechas que tenga al menos:
             ObtenerDiasCalendario() obtiene los días entre dos fechas
             ObtenerDiasLaborables() obtiene los días laborables entre dos fechas
             SumarDiasLaborables() obtiene una fecha sumando una cantidad de días a una fecha inicial
             Tenga en cuenta fines de semanas y feriados.
             Puede guardar los feriados en un arreglo.
            */

            //descomentar segun se use

            //Utilitaria util = new Utilitaria();

            //util.ObtenerDiasCalendario();

            //util.ObtenerDiasLaborables();

            //util.SumarDiasLaborables();

            int a = 0, contador = 1;
            int[] pArray= new int[1];

            while (contador<5)
            {

                if (pArray.Length == 1)
                {
                    Console.WriteLine("ingrese un numero para agregar al arreglo");
                    a = int.Parse(Console.ReadLine());
                    pArray[0] = a;

                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("ingrese un numero para agregar al arreglo");
                    a = int.Parse(Console.ReadLine());
                    Redefinir(out pArray, a, contador);

                    Console.ReadKey();
                }
                contador++;
            }
            for(int i=0; i < pArray.Length; i++)
            {
                Console.WriteLine(pArray[i]);
            }
            Console.WriteLine(pArray.Length);
            Console.ReadKey();
        }

        static void Redefinir(out int[] pArray, int a, int contador )
        {

            Array.Resize<int>(ref pArray, pArray.Length+1);
            
            pArray[contador] = a;
        }

        /*static void Change (ref int[] pArray, out int a)
        {
            pArray[0] = 888;//esto afecta al de afuera
            a = 42;
            pArray = new int[5] {-3,-1,-2,-3,-4 };//esto no afecta al de afuera
            System.Console.WriteLine("En Change," +
                "primer elemento: {0}", pArray[0]);
        }*/
    }
    public class Utilitaria
    {
        public void ObtenerDiasCalendario()
        {
            String dateString1, dateString2;
            System.Console.WriteLine("ingrese la primera fecha con este formato:" +
                "AÑO, MES, DIA\n " +
                "0000, 00, 00");
            dateString1 = System.Console.ReadLine();

            System.Console.WriteLine("\ningrese la segunda fecha con este formato:" +
                "AÑO, MES, DIA\n " +
                "0000, 00, 00");
            dateString2 = System.Console.ReadLine();


            DateTime date1 = DateTime.Parse(dateString1);
            DateTime date2 = DateTime.Parse(dateString2);
            System.Console.WriteLine(date1.ToShortDateString());
            System.Console.WriteLine(date2.ToShortDateString());

            TimeSpan intervalo = date1 - date2;

            System.Console.WriteLine("Cantidad de dias entre las dos fechas" + Math.Abs(intervalo.TotalDays));

            //mostrar las fechas usando addDays
            if (intervalo.TotalDays < 0)
            {
                //date1 es de donde debo comenzar a mostrar los dias
                for (int i = 1; i < Math.Abs(intervalo.TotalDays) + 1; i++)
                {
                    System.Console.WriteLine(date1.AddDays(i).ToShortDateString());
                }
            }
            else if (intervalo.TotalDays > 0)
            {
                //date2 es de donde debo comenzar a mostrar los dias
                for (int i = 1; i < Math.Abs(intervalo.TotalDays) + 1; i++)
                {
                    System.Console.WriteLine(date2.AddDays(i).ToShortDateString());
                }
            }
            System.Console.ReadKey();
        }

        public void ObtenerDiasLaborables()
        {
            String dateString1, dateString2;
            System.Console.WriteLine("ingrese la primera fecha con este formato:" +
                "AÑO, MES, DIA\n " +
                "0000, 00, 00");
            dateString1 = System.Console.ReadLine();

            System.Console.WriteLine("\ningrese la segunda fecha con este formato:" +
                "AÑO, MES, DIA\n " +
                "0000, 00, 00");
            dateString2 = System.Console.ReadLine();

            DateTime date1 = DateTime.Parse(dateString1);
            DateTime date2 = DateTime.Parse(dateString2);
            System.Console.WriteLine(date1.ToShortDateString());
            System.Console.WriteLine(date2.ToShortDateString());
            //se puede hacer esto...
            //date1.DayOfWeek != DayOfWeek.Saturday

            TimeSpan intervalo = date1 - date2;

            System.Console.WriteLine("\nCantidad de dias entre las dos fechas: " + Math.Abs(intervalo.TotalDays) + "\n");

            //mostrar las fechas usando addDays
            if (intervalo.TotalDays < 0)
            {
                //date1 es de donde debo comenzar a mostrar los dias
                for (int i = 1; i < Math.Abs(intervalo.TotalDays); i++)
                {
                    if (DiaLaboral(date1.AddDays(i)))
                    {
                        System.Console.WriteLine(date1.AddDays(i).ToShortDateString());
                    }
                }
            }
            else if (intervalo.TotalDays > 0)
            {
                //date2 es de donde debo comenzar a mostrar los dias
                for (int i = 1; i < Math.Abs(intervalo.TotalDays); i++)
                {
                    if (DiaLaboral(date2.AddDays(i)))
                    {
                        System.Console.WriteLine(date2.AddDays(i).ToShortDateString());
                    }
                }
            }
            System.Console.ReadKey();
        }

        public void SumarDiasLaborables()
        {
            int suma = 0, contador = 0, i = 1;
            String dateString1;
            System.Console.WriteLine("ingrese la primera fecha con este formato:" +
                "AÑO, MES, DIA\n " +
                "0000, 00, 00");
            dateString1 = System.Console.ReadLine();

            DateTime date1 = DateTime.Parse(dateString1);
            System.Console.WriteLine(date1.ToShortDateString());

            System.Console.WriteLine("Ingrese los dias laborales que desea sumar(?");
            suma = int.Parse(Console.ReadLine());

            //mostrar las fechas usando addDays

            //date1 es de donde debo comenzar a mostrar los dias
            while (contador < 5)
            {
                if (DiaLaboral(date1.AddDays(i)))
                {
                    System.Console.WriteLine(date1.AddDays(i).ToShortDateString());
                    contador++;
                }
                i++;
            }
            System.Console.ReadKey();
        }

        public static bool DiaLaboral(DateTime date)
        {
            DateTime[] feria2 = new DateTime[]
{
                new DateTime(2008, 04, 1),
                new DateTime(2020, 05, 9),
                new DateTime(2020, 05, 20)

            };


            if (date.DayOfWeek.Equals(DayOfWeek.Saturday) || date.DayOfWeek.Equals(DayOfWeek.Sunday))
            {
                return false;
            }
            else
            {

                for (int i = 0; i < feria2.Length; i++)
                {
                    if (date.Equals(feria2[i]))
                    {
                        return false;
                    }

                }
                return true;
            }



        }
    }
}
