using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace pruebaGaona
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Periodo> ListaPeriodos;
            List<Periodo> ListaInterseccion;
            Test test = new Test();
            ListaPeriodos = test.CargarListaPeriodos();
            test.Mostrar(ListaPeriodos);

            ListaInterseccion = test.Interseccion(ListaPeriodos);

            Console.WriteLine("las intersecciones son:");
            test.MostrarIntersecciones(ListaInterseccion);

            Console.ReadKey();

        }
    }

    public class Test
    {

        public List<Periodo> CargarListaPeriodos()
        {
            DateTime fecha1;
            DateTime fecha2;
            bool respuesta = true;


            var ListaPeriodos = new List<Periodo> { };

            do
            {

                Console.WriteLine("\nIngrese una fecha de inicio en este formato: dia, mes, año");
                fecha1 = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("\nIngrese una fecha de fin en este formato: dia, mes, año");
                fecha2 = DateTime.Parse(Console.ReadLine());

                if (fecha1 < fecha2)
                {
                    ListaPeriodos.Add(new Periodo(fecha1, fecha2));
                }
                else
                {
                    Console.WriteLine("La fecha de inicio no puede ser mayor que la fecha de fin XD");
                }

                Console.WriteLine("\n\nDesea seguir ingresando periodos? \ningrese SI o NO");
                String resp = Console.ReadLine();
                if (resp.Equals("No") || resp.Equals("no"))
                {
                    respuesta = false;
                }
                else
                {
                    Console.WriteLine("\nEl ingreso de periodos sigue corriendo\n");
                }

            } while (respuesta);

            return ListaPeriodos;
        }
        
            
        public List<Periodo> Interseccion(List<Periodo> ListaPeriodos)
        {

            Periodo auxiliar;
            List<Periodo> NuevaListaPeriodos = new List<Periodo>();
            foreach (var p1 in ListaPeriodos)
            {
                foreach (var p2 in ListaPeriodos)
                {
                    if (!p1.Equals(p2))
                    {
                        auxiliar = Comparar(p1,p2);
                        if (auxiliar != null)
                        {
                            NuevaListaPeriodos.Add(auxiliar);
                        }

                    }
                }
            }

            
            

            return NuevaListaPeriodos;
        }

        public Periodo Comparar(Periodo p1, Periodo p2)
        {
            Periodo InterseccionEntreDosPeriodos;

            if(p1.FechaInicio1 > p2.FechaInicio1 && p1.FechaFin1 < p2.FechaFin1)
            {
                return p1;
            }
            else if (p1.FechaInicio1 < p2.FechaInicio1 && p1.FechaFin1 > p2.FechaFin1)
            {
                return p2;
            }
            else if (p1.FechaInicio1 == p2.FechaInicio1 || p1.FechaFin1 == p2.FechaFin1)
            {
                if(p1.Duracion > p2.Duracion)
                {
                    return p2;
                }
                else if (p1.Duracion < p2.Duracion)
                {
                    return p1;
                }
                else
                {
                    return p1;
                }
            }
            else if (p1.FechaInicio1 > p2.FechaInicio1 && p1.FechaFin1 > p2.FechaFin1)
            {
                return InterseccionEntreDosPeriodos = new Periodo(p1.FechaInicio1, p2.FechaFin1);
            }
            else if (p1.FechaInicio1 < p2.FechaInicio1 && p1.FechaFin1 < p2.FechaFin1)
            {
                return InterseccionEntreDosPeriodos = new Periodo(p2.FechaInicio1, p1.FechaFin1);
            }
            else
            {
                return null;
            } 

        } 

        public void Mostrar(List<Periodo> ListaPeriodos)
        {
            int cont = 1;
            foreach (var periodoEnLista in ListaPeriodos)
            {

                Console.WriteLine($"Periodo numero: {cont}");
                periodoEnLista.MostrarTodo();
                cont++;
            }
        }

        public void MostrarIntersecciones(List<Periodo> ListaPeriodos)
        {
            int cont = 1;
            foreach (var periodoEnLista in ListaPeriodos)
            {

                Console.WriteLine($"Interseccion numero: {cont}");
                periodoEnLista.MostrarTodo();
                cont++;
            }
        }


    }

    /*
     if (p1.FechaInicio1 == p2.FechaInicio1 || p1.FechaFin1 == p2.FechaFin1)//separar en 2 if
                        {
                            TimeSpan intersect = p1.Duracion - p2.Duracion;//esto esta mal pero a lo que voy es que en este caso es facil

                        }
                        else if(p1.FechaInicio1 < p1.FechaInicio1 && p1.FechaFin1 < p2.FechaFin1)
                        {

                        }else if (p1.FechaInicio1 < p1.FechaInicio1 && p1.FechaFin1 > p2.FechaFin1)
                        {

                        }else if (p1.FechaInicio1 > p2.FechaInicio1 && p1.FechaFin1 > p2.FechaFin1)
                        {

                        }
                        else if (p1.FechaInicio1 > p2.FechaInicio1 && p1.FechaFin1 < p2.FechaFin1)
                        {

                        }
         */


    public class Periodo
    {

        private DateTime FechaInicio;
        private DateTime FechaFin;
        private TimeSpan duracion;

        public Periodo(DateTime fechaInicio, DateTime fechaFin)
        {
            this.FechaInicio = fechaInicio;
            this.FechaFin = fechaFin;
            this.duracion = fechaFin - fechaInicio;
        }

        public DateTime FechaInicio1 { get => FechaInicio; set => FechaInicio = value; }
        public DateTime FechaFin1 { get => FechaFin; set => FechaFin = value; }
        public TimeSpan Duracion { get => duracion; set => duracion = value; }

        public void MostrarTodo()
        {
            Console.WriteLine($"Fecha de Inicio del periodo: {this.FechaInicio}\n" +
                $"Fecha de Fin del periodo: {this.FechaFin}\n" +
                $"Periodo: {this.duracion}");
        }

    }
}
