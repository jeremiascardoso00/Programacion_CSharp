using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trabajoLab_area
{
    class Program
    {
        /*
        1. Carga de dos matriz en forma manual
        2. Carga de una matriz en forma automática con números aleatorios.
        3. Matriz transpuesta
        4. Traza de una matriz
        5. Determinar si una matriz es del tipo identidad
        6. Matriz diagonal
        7. Multiplicación escalar
        8. Suma de dos matrices
        9. Resta de matrices
        10. Determinar la igualdad de dos matrices
        */

        static void Main(string[] args)
        {

            int opcion = 0, respuesta=0;
            int[,] tab1 = new int[4, 4];
            int[,] tab2 = new int[4, 4];



            do
            {
                Console.WriteLine("Ingrese la opcion que desee realizar:\n" +
                "\n1.Carga de dos matriz en forma manual.\n" +
                "2.Carga de una matriz en forma automática con números aleatorios.\n" +
                "3.Matriz transpuesta.\n" +
                "4.Traza de una matriz.\n" +
                "5.Determinar si una matriz es del tipo identidad.\n" +
                "6.Matriz diagonal.\n" +
                "7.Multiplicación escalar.\n" +
                "8.Suma de dos matrices.\n" +
                "9.Resta de matrices.\n" +
                "10.Determinar la igualdad de dos matrices.\n");
                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        Console.WriteLine("Carga de matriz 1 en forma manual.\n");
                        Cargar(tab1);
                        Mostrar(tab1);
                        Console.WriteLine("\nCarga de matriz 2 en forma manual.\n");
                        Cargar(tab2);
                        Mostrar(tab2);
                        break;
                    case 2:
                        respuesta = 0;
                        do
                        {
                            Console.WriteLine("Carga de una matriz en forma automática con números aleatorios.");
                            Console.WriteLine("Elija cual matriz desea cargar: \n1\n2.\n");
                            respuesta = int.Parse(Console.ReadLine());
                            if (respuesta == 1)
                            {

                                CargarAleatorio(tab1);
                                Mostrar(tab1);
                            }
                            else if (respuesta == 2)
                            {

                                CargarAleatorio(tab2);
                                Mostrar(tab2);
                            }
                        } while (respuesta != 1 && respuesta != 2);
                        break;
                    case 3:
                        respuesta = 0;
                        do
                        {
                            Console.WriteLine("Trasponer una matriz.");
                            Console.WriteLine("Elija cual matriz desea trasponer: \n1\n2.\n");
                            respuesta = int.Parse(Console.ReadLine());
                            if (respuesta == 1)
                            {
                                Trasponer(tab1);
                                
                            }
                            else if (respuesta == 2)
                            {

                                Trasponer(tab2);
                                
                            }
                        } while (respuesta != 1 && respuesta != 2);
                        break;
                    case 4:
                        respuesta = 0;
                        do
                        {
                            Console.WriteLine("Traza de una matriz.");
                            Console.WriteLine("Elija cual matriz desea sacar la traza: \n1\n2.\n");
                            respuesta = int.Parse(Console.ReadLine());
                            if (respuesta == 1)
                            {

                                Traza(tab1);
                                
                            }
                            else if (respuesta == 2)
                            {

                                Traza(tab2);
                                
                            }
                        } while (respuesta != 1 && respuesta != 2);
                        break;
                    case 5:
                        respuesta = 0;
                        do
                        {
                            Console.WriteLine("Determinar si una matriz es del tipo identidad.");
                            Console.WriteLine("Elija cual matriz desea verificar si es identidad: \n1\n2.\n");
                            respuesta = int.Parse(Console.ReadLine());
                            if (respuesta == 1)
                            {
                                Identidad(tab1);

                            }
                            else if (respuesta == 2)
                            {

                                Identidad(tab2);

                            }
                        } while (respuesta != 1 && respuesta != 2);
                        break;
                    case 6:
                        respuesta = 0;
                        do
                        {
                            Console.WriteLine("Matriz diagonal.");
                            Console.WriteLine("Elija cual matriz desea verificar si es diagonal: \n1\n2.\n");
                            respuesta = int.Parse(Console.ReadLine());
                            if (respuesta == 1)
                            {
                                Diagonal(tab1);

                            }
                            else if (respuesta == 2)
                            {

                                Diagonal(tab2);

                            }
                        } while (respuesta != 1 && respuesta != 2);
                        break;
                    case 7:
                        respuesta = 0;
                        do
                        {
                            Console.WriteLine("Multiplicación escalar.");
                            Console.WriteLine("Elija cual matriz desea multiplicar: \n1\n2.\n");
                            respuesta = int.Parse(Console.ReadLine());
                            if (respuesta == 1)
                            {
                                MultiEscalar(tab1);

                            }
                            else if (respuesta == 2)
                            {

                                MultiEscalar(tab2);

                            }
                        } while (respuesta != 1 && respuesta != 2);
                       
                        break;
                    case 8:
                        Console.WriteLine("Suma de dos matrices.");
                        Console.WriteLine("\nsumando matriz 1 con matriz 2");
                        Mostrar(Suma(tab1, tab2));
                        break;
                    case 9:
                        Console.WriteLine("Resta de matrices.");
                        Console.WriteLine("\nrestando matriz 1 con matriz 2");
                        Mostrar(Resta(tab1, tab2));
                        break;
                    case 10:
                        Console.WriteLine("Determinar la igualdad de dos matrices.");
                        Console.WriteLine("\nigualando matriz 1 con matriz 2");
                        Igualacion(tab1, tab2);
                        break;
                }

                Console.WriteLine("desea seguir operando?\nsi=1\nno=0");
                respuesta = int.Parse(Console.ReadLine());
                //Program.Mostrar(tab);
                //Console.WriteLine("El mayor elemento de la matriz es {0} ", Mayor(tab));

                Console.ReadKey();
            } while (respuesta != 0);
            

        }
        static void Cargar(int[,] tab)
        {
            for (int i = 0; i < tab.GetLength(0); i++)
            {
                for (int j = 0; j < tab.GetLength(1); j++)
                {
                    Console.WriteLine("ingrese un valor para colocarselo a la posicion {0} , {1} de la matriz", i,j);
                    tab[i, j] = int.Parse(Console.ReadLine());
                }
            }
        }
        static void CargarAleatorio(int[,] tab)
        {
            Random r = new Random();
            for (int i = 0; i < tab.GetLength(0); i++)
            {
                for (int j = 0; j < tab.GetLength(1); j++)
                {

                    tab[i, j] = r.Next(0, 17);

                }
            }
        }

        static void Mostrar(int[,] tab)
        {
            for (int i = 0; i < tab.GetLength(0); i++)
            {
                for (int j = 0; j < tab.GetLength(1); j++)
                {
                    Console.Write(" " + tab[i,j] );
                }
                Console.WriteLine();
            }
        }

        static void Traza(int[,] tab)
        {
            int aux = 0;
            for (int i = 0; i < tab.GetLength(0); i++)
            {
                for (int j = 0; j < tab.GetLength(1); j++)
                {
                    if (i == j)
                    {
                        aux += tab[i, j];
                    }
                }
                
            }
            Console.WriteLine("La traza de la matriz es igua a: {0}", aux);
        }

        static void Trasponer(int[,] tab)
        {
            int aux = 0, i, j;
            for (i = 0; i < tab.GetLength(0); i++)
            {
                
                for (j = i; j < tab.GetLength(1); j++)
                {
                    aux = tab[i,j];
                    tab[i,j] = tab[j,i];
                    tab[j,i] = aux;
                }

            }
            Mostrar(tab);
        }

        static void Identidad(int[,] tab)
            
        {
            bool comprobacion = false;
            for (int i = 0; i < tab.GetLength(0); i++)
            {
                for (int j = 0; j < tab.GetLength(1); j++)
                {
                    if (i != j)
                    {
                        if(tab[i,j] != 0)
                        {
                            Console.WriteLine("no es una matriz identidad");
                            break;
                        }
                        else
                        {
                            comprobacion = true;
                            
                        }
                    }
                    else
                    {
                        if (tab[i, j] != 1)
                        {
                            Console.WriteLine("no es una matriz identidad");
                            break;
                        }
                        else
                        {
                            comprobacion = true;
                        }
                    }
                }
                
            }
            if (comprobacion)
            {
                Console.WriteLine("La matriz es una matriz identidad");
            }
        }

        static void Diagonal(int[,] tab)
        {
            int aux = tab[0,0];
            bool comprobacion = false;
            for (int i = 0; i < tab.GetLength(0); i++)
            {
                for (int j = 0; j < tab.GetLength(1); j++)
                {
                    if (i != j)
                    {
                        if (tab[i, j] != 0)
                        {
                            Console.WriteLine("no es una matriz diagonal");
                            break;
                        }
                        else
                        {
                            comprobacion = true;

                        }
                    }
                    else
                    {
                        
                        if (tab[i, j] != aux)
                        {
                            Console.WriteLine("no es una matriz identidad");
                            break;
                        }
                        else
                        {
                            comprobacion = true;
                        }
                    }
                }

            }
            if (comprobacion)
            {
                Console.WriteLine("La matriz es una matriz diagonal");
            }
        }

        static void MultiEscalar(int[,] tab)
        {
            Console.WriteLine("ingrese el numero por el que desea hacer la multiplicacion");
            int numero = int.Parse(Console.ReadLine());
            for (int i = 0; i < tab.GetLength(0); i++)
            {
                for (int j = 0; j < tab.GetLength(1); j++)
                {

                    tab[i, j] = tab[i, j] * numero;
                }
            }
            Mostrar(tab);
        }

        static int [,] Suma(int[,] tab1, int[,] tab2)
        {
            if (tab1.GetLength(0) == tab2.GetLength(0) && tab1.GetLength(1) == tab2.GetLength(1))
            {
                int[,] resultado = new int[tab1.GetLength(0), tab1.GetLength(1)];
                for (int i = 0; i < tab1.GetLength(0); i++)
                {
                    for (int j = 0; j < tab1.GetLength(1); j++)
                    {

                           resultado[i, j] = tab1[i, j] + tab2[i,j];
                    }
                }
                return resultado;
            }
            else
            {
                Console.WriteLine("no se pudo realizar la suma debido a que las matrices no concuerdan");
                return null;
            }
            
            
        }

        static int[,] Resta(int[,] tab1, int[,] tab2)
        {
            if (tab1.GetLength(0) == tab2.GetLength(0) && tab1.GetLength(1) == tab2.GetLength(1))
            {
                int[,] resultado = new int[tab1.GetLength(0), tab1.GetLength(1)];
                for (int i = 0; i < tab1.GetLength(0); i++)
                {
                    for (int j = 0; j < tab1.GetLength(1); j++)
                    {

                        resultado[i, j] = tab1[i, j] - tab2[i, j];
                    }
                }
                return resultado;
            }
            else
            {
                Console.WriteLine("no se pudo realizar la resta debido a que las matrices no concuerdan");
                return null;
            }


        }

        static void Igualacion(int[,] tab1, int[,] tab2)
        {
            
            bool comprobacion = false;
            for (int i = 0; i < tab1.GetLength(0); i++)
            {
                for (int j = 0; j < tab1.GetLength(1); j++)
                {
                    if (tab1[i,j] != tab2[i, j])
                    {
                        Console.WriteLine("Las matrices no son iguales");
                        return;
                    }
                    else
                    {
                        comprobacion = true;
                    }
                }

            }
            if (comprobacion)
            {
                Console.WriteLine("Las matrices son iguales");
            }

        }

        static int Mayor(int[,] tab)
        {
            int length = 2, aux = 0;
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if (aux < tab[i, j])
                    {
                        aux = tab[i, j];
                    }

                }

            }
            return aux;

        }

    }
}
