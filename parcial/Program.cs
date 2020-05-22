using System;
using System.Reflection;

namespace parcial
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime desde = new DateTime(0001, 01, 01, 00, 00, 00, 0000000);
            DateTime hasta = new DateTime(2020, 05, 14, 21, 38, 56, 0000000);

            Console.WriteLine("¿Cuantos intervalos de tiempo desea generar?");
            int cantidadInstantes = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese cantidad de periodos de rango de distribucion que desea:");
            int rangoDistribucion = int.Parse(Console.ReadLine());

            TimeSpan cantidadDias = hasta - desde;
            TimeSpan aux = cantidadDias / rangoDistribucion;
            int cantidadDiasIntervalso = aux.Days;
            Console.WriteLine(cantidadDiasIntervalso);

            DateTime[] arr = new DateTime[cantidadInstantes];
            DateTime[] intervalos = new DateTime[rangoDistribucion];
            
            //for(int i=0; i< arr.Length; i+=)


            Random random = new Random();
            int rango = ((TimeSpan)(hasta - desde)).Days;
            for(int i=0; i < arr.Length; i++)
            {
                arr[i] = desde.AddDays(random.Next(rango));
            }
            Console.WriteLine("Instantes de tiempo generados:");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
        }
    }
}
