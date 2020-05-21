using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_Practico2
{
    class PruebaLibros
    {
        static void Main(string[] args)
        {

            /*Crear una clase PruebaLibros, que realice varias pruebas con las clases creadas. En concreto,
                pruebe a: crear dos libros, añadirlos al conjunto,
                eliminarlos por los dos criterios hasta que el conjunto esté vació, volver a añadir un libro y
                mostrar el contenido final.*/

            Libro libro1 = new Libro("Titulo", "yo", 10, 0);
            Libro libro2 = new Libro("Titulo2", "yo2", 20, 10);
            Libro libro3 = new Libro("las aventuras del emperador", "yo3", 30, 9);

            ConjuntoLibros conjunto = new ConjuntoLibros();
            conjunto.AgregarLibro(libro1);
            conjunto.AgregarLibro(libro2);
            conjunto.Mostrar();

            conjunto.BorrarLibro("Titulo");
            conjunto.Mostrar();

            conjunto.BorrarLibro("Titulo2");
            conjunto.Mostrar();

            conjunto.AgregarLibro(libro3);
            conjunto.Mostrar();
            Console.ReadKey();

        }
    }

    /*
           Practico2:
               Queremos mantener una colección de los libros que hemos ido leyendo, poniéndoles una
               calificación según nos haya gustado más o menos al leerlo. 
               Para ello, crear la clase Libro, cuyos atributos son:
               el titulo, 
               el autor, 
               el número de paginas y 
               la calicación que le damos entre 0 y 10.

               Crear los métodos típicos para poder modicar y obtener los atributos si tienen sentido.


               Posteriormente, crear una clase ConjuntoLibros, 
               que almacena un conjunto de libros (con un array de un tamaño fijo). 
               Se pueden añadir libros que no existan (siempre que haya espacio),
               eliminar libros por título o autor,
               mostrar por pantalla los libros con la mayor y menor calicación dada y, por último, 
               mostrar un contenido de todo el conjunto.

               Crear una clase PruebaLibros, que realice varias pruebas con las clases creadas. En concreto,
               pruebe a: crear dos libros, añadirlos al conjunto,
               eliminarlos por los dos criterios hasta que el conjunto esté vació, volver a añadir un libro y
               mostrar el contenido final.
            */


    public class Libro
    {
        private String Titulo;
        private String Autor;
        private int NumeroDePag;
        private int Calificacion;

        public Libro(String Titulo, String Autor, int NumeroDePag, int Calificacion)
        {
            this.Titulo = Titulo;
            this.Autor = Autor;
            this.NumeroDePag = NumeroDePag;
            if (Calificacion > 10)
            {
                this.Calificacion = 10;
            }else if( Calificacion < 0)
            {
                this.Calificacion = 0;
            }
            else
            {
                this.Calificacion = Calificacion;
            }
            

        }

        public String GetTitulo()
        {
            return this.Titulo;
        }
        public void SetTitulo(String Titulo)
        {
            this.Titulo = Titulo;
        }

        public String GetAutor()
        {
            return this.Autor;
        }

        public void SetAutor(String Autor)
        {
            this.Autor = Autor;
        }

        public int GetNumeroDePag()
        {
            return this.NumeroDePag;
        }
        public void SetNumeroDePag(int NumeroDePag)
        {
            this.NumeroDePag = NumeroDePag;
        }
        public int GetCalificacion()
        {
            return this.Calificacion;
        }

        public void SetCalificacion(int Calificacion)
        {
            if (Calificacion > 10)
            {
                this.Calificacion = 10;
            }
            else if (Calificacion < 0)
            {
                this.Calificacion = 0;
            }
            else
            {
                this.Calificacion = Calificacion;
            }
        }



    }

    public class ConjuntoLibros
    {
        private Libro[] libros = new Libro[10];
        private int indice = 0;

        public ConjuntoLibros( params Libro[] libros )
        {

        }

        public void AgregarLibro(Libro libro)
        {
            if(indice < 10)
            {
                this.libros[indice] = libro;
                indice++;
            }
            else//ACA DEBERIA DE ALGUNA FORMA SABER SI SE BORRO O NO ALGUN LIBRO PARA QUE SEPA QUE LE QUEDA ESPACIO DEA ESTO NO ES UNA BASE DE DATOS, GENERALMENTE PARA ESTE TIPO DE COSAS SE UTILIZAN LISTAS O COLECCIONES, NO ARREGLOS PERO BUENO ESTA BUENO, NO PODER CUMPLIR CON TODA LA FUNCIONALIDAD QUE DEBERIA TENER ESTE PROGRAMA SIN HACER UN HOMENAJE A LO ABSURDO Y AL HARDCODEO PARA QUE FUNCIONE UNA FRACCION DE LO QUE PODRIA SI SE UTILIZARAN LOS ELEMENTOS QUE FUERON HECHOS CON ESE PROPOSITO QUE ES FACILITAR EL TRABAJO DE GENTE COMO YO, LABURANTES, CHAQUEÑOS, GENTE QUE NO ENTIENDE MUCHO DE LA VIDA Y TAMPOCO TIENE GANAS DE ENTENDERLA PQ LA VIDA EN EL CAMPO ES ASI NACES PARA MORIR TRISTE NO COMO TODOS LOS JUDIOS HIJOS DE PUTA QUE VIVEN EN BUENOS AIRES O CORDOBA QUE CONTAMINAN MAS DE LO QUE PRODUCEN Y SE QUEJAN A DOS MANOS DE QUE HACE 45º EN INVIERNO

            {
                Console.WriteLine("no hay mas espacio bolo");
            } 
        }

        public void BorrarLibro(String TituloOAutor)//faltaria un metodo para mover todo el arreglo cuando se borre algun libro
        {
            for (int i = 0; i < indice; i++)
            {
                if (libros[i].GetAutor().Equals(TituloOAutor) || libros[i].GetTitulo().Equals(TituloOAutor))
                {
                    Console.WriteLine($"\n\nlibro numero {i+1} borrado: {libros[i].GetTitulo()}");

                    this.libros[i] = libros[indice-1];
                    Array.Clear(libros, indice, 1);
                    this.indice = indice-1;
                    break;
                }
            }
        }

        public void Mostrar()
        {
            for (int i = 0; i< this.indice; i++)
            {
                Console.WriteLine($"\n\nPosicion numero {i + 1} \nTitulo: {libros[i].GetTitulo()}\n" +
                    $"Autor: {libros[i].GetAutor()} \nNumero de paginas: {libros[i].GetNumeroDePag()}" +
                    $"\nCalificacion: {libros[i].GetCalificacion()}");
            }
        }

        public void MostrarLibro(Libro libro)
        {
            Console.WriteLine($"\n\nTitulo: {libro.GetTitulo()}\n" +
                $"Autor: {libro.GetAutor()} \nNumero de paginas: {libro.GetNumeroDePag()}" +
                $"\nCalificacion: {libro.GetCalificacion()}");
            
        }

        public void MostrarMejorCalif()
        {
            int mayor = -99, menor= 99;
            string titulodemayor="", titulodemenor="";
            for (int i = 0; i < indice; i++)
            {
                if (libros[i].GetCalificacion() > mayor)
                {
                    mayor = libros[i].GetCalificacion();
                    titulodemayor = libros[i].GetTitulo();
                }
                if (libros[i].GetCalificacion() < menor)
                {
                    menor = libros[i].GetCalificacion();
                    titulodemenor = libros[i].GetTitulo();
                }
            }
            Console.WriteLine($"\nMayor calificacion \nTitulo: {titulodemayor} \nCalificacion: {mayor}\n");
            Console.WriteLine($"\nMenor calificacion \nTitulo: {titulodemenor} \nCalificacion: {menor}\n");
        }

    }
}
