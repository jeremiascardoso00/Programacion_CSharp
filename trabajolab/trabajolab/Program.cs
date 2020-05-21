using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trabajoprog
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Objetivo: Comprender el uso básico de estructuras repetitivas.
            Ejercicio:
            Calcular la media y la desviación estándar de un conjunto de 10 personas.
            Tome por teclado la altura en cm de cada persona y cárguela en un arreglo.
            Presente los resultados obtenidos.
            Muestre que alturas se encuentran por encima de la media y por debajo de ella.
            Muestre que alturas se encuentran dentro del rango definido por la desviación estándar.*/

            int[] personas = new int[10];

            

            float media = 0;
            double desv = 0;

            for (int i = 0; i < personas.Length; i++)
            {
                Console.WriteLine("ingrese la altura de la persona " + (i + 1) + " en cm");
                personas[i] = Convert.ToInt32(Console.ReadLine());
                media += personas[i];
            }
            media = media / personas.Length;

            /*
            Paso 1: calcular la media.
            Paso 2: calcular el cuadrado de la distancia a la media para cada dato.
            Paso 3: sumar los valores que resultaron del paso 2.
            Paso 4: dividir entre el número de datos.
            Paso 5: sacar la raíz cuadrada.*/

            for (int i = 0; i < personas.Length; i++)
            {

                desv += Math.Pow((personas[i] - media), 2);
            }
            desv = desv / personas.Length;




            Console.WriteLine("la media de altura de las personas es: " + media);
            Console.WriteLine("la desviacion estandar de altura de las personas es la raiz cuadrada de: " + desv);
            desv = Math.Sqrt(desv);
            Console.WriteLine("\nes decir: " + desv);


            for (int i = 0; i < personas.Length; i++)
            {

                if (personas[i] > media)
                {

                    Console.WriteLine(personas[i] + " - se encuentra arriba de la media");

                }
                else if (personas[i] < media)
                {
                    Console.WriteLine(personas[i] + " - se encuentra debajo de la media");
                }
            }

            for (int i = 0; i < personas.Length; i++)
            {

                if (personas[i] > (media + desv) || personas[i] < (media - desv))
                {
                    Console.WriteLine(personas[i] + " - no se encuentra dentro del rango definido por la desviación estándar");
                }
                else
                {
                    Console.WriteLine(personas[i] + " - se encuentra dentro del rango definido por la desviación estándar ");
                }
            }

            Console.ReadKey();
        }
    }
}
