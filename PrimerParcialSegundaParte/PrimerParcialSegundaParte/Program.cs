using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PrimerParcialSegundaParte
{
    class Program
    {
        static void Main(string[] args)
        {

            Test test = new Test();
            test.Prueba();
            Console.ReadKey();

        }
    }

    public  class Test
    {

        public void Prueba()
        {
            String respuesta, nombreCliente, apellidoCliente,emailCliente, nombreMascota, tipoMascota, razaMascota;
            int telefonoCliente, codigoMascota;
            bool validez = false;
            do
            {
                
                Console.WriteLine("Desea ingresar un nuevo cliente?\n" +
                    "escriba: si/no");
                respuesta = Console.ReadLine();
                if (respuesta == "si" || respuesta == "SI")
                {
                    validez = true;
                    Console.WriteLine("Ingrese el nombre del cliente:");
                    nombreCliente = Console.ReadLine();

                    Console.WriteLine("Ingrese el apellido del cliente:");
                    apellidoCliente = Console.ReadLine();

                    Console.WriteLine("Ingrese el telefono del cliente:");
                    telefonoCliente = int.Parse(Console.ReadLine());

                    Console.WriteLine("Ingrese el email del cliente:");
                    emailCliente = Console.ReadLine();



                    Cliente cliente1 = new Cliente(nombreCliente, apellidoCliente, telefonoCliente, emailCliente);

                    //cliente1.Mostrar();
                    bool resp = true;
                    String respString;

                    //de esta forma podemos agregar las mascotas que deseemos pero para mostrar el funcionamiento del programa solamente voy a crear 2 mascotas

                    // agregando mascotas, de esta forma un cliente puede agregar todas las mascotas que desee
                    /*do
                    {
                        Console.WriteLine("Ingrese el codigo de la mascota:");
                        codigoMascota = int.Parse(Console.ReadLine());

                        Console.WriteLine("Ingrese el nombre:");
                        nombreMascota = Console.ReadLine();

                        Console.WriteLine("Ingrese el tipo:");
                        tipoMascota = Console.ReadLine();

                        Console.WriteLine("Ingrese la raza:");
                        razaMascota = Console.ReadLine();

                        Mascota mascota1 = new Mascota(codigoMascota, nombreMascota, tipoMascota, razaMascota);
                        cliente1.AgregarMascota(mascota1);

                    //mascota1.Mostrar();
                    
                        Console.WriteLine("Desea agregar otra mascota?\n" +
                            "ingrese: si/no");
                        respString = Console.ReadLine();
                        if (respString == "si" || respString == "SI")
                        {
                            resp = true;
                        }
                        else
                        {
                            resp = false;
                        }
                    } while (resp);*/

                    Mascota perro1 = new Mascota(1, "firulais", "canino", "fox terrier");
                    Mascota perro2 = new Mascota(2, "lasi", "canino", "fox terrier");

                    cliente1.AgregarMascota(perro1);
                    cliente1.AgregarMascota(perro2);

                    //Creamos la atencion que necesitemos
                    Atencion atencion1 = new Extraordinaria( 1, "Revision urgente", "Dolor en el area del estomago del animal", DateTime.Now, 200, "respiracion normal", "parasitos", "aplicacion de antiparasitarios y dieta");
                    Atencion atencion2 = new Ordinaria(2, "Revision sencilla", "Animal con Garrapatas", DateTime.Now,300, "Aplicacion de pipeta" );
                    Atencion atencion3 = new Extraordinaria(3, "Revision urgente", "Pierna Quebrada", DateTime.Now, 500, "Animal alterado por el dolor", "fractura de pierna", "cirujia ");
                    
                    //le agregamos atenciones a la primer mascota
                    cliente1.mascotas[0].AgregarAtencion(atencion2);
                    cliente1.mascotas[1].AgregarAtencion(atencion1);

                    //mostrando los datos de la atencion de cada mascota del cliente
                    cliente1.MostrarMascotas();
 
                }
                else
                {
                    Console.WriteLine("adios");
                    validez = false;

                }
            } while (validez);
            
        }
        
    }

    public class Cliente
    {

        private String nombre;
        private String apellido;
        private long telefono;
        private String email;
        public List<Mascota> mascotas = new List<Mascota>();
        public Cliente(String nombre, String apellido, long telefono, String email)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.telefono = telefono;
            this.email = email;
            
        
        }

        public void AgregarMascota(Mascota mascota)
        {
            this.mascotas.Add(mascota);
        }

        public void MostrarMascotas()
        {
            foreach (Mascota mascotita in mascotas)
            {
                Console.WriteLine($"\nMascota: {mascotita.Nombre}\n" +
                    $"Tipo: {mascotita.Tipo}\n" +
                    $"Raza: {mascotita.Raza}\n" +
                    $"Atencion: ");
                mascotita.MostrarAtencion();
                
            }
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public long Telefono { get => telefono; set => telefono = value; }
        public string Email { get => email; set => email = value; }
        
    }

    public class Mascota
    {
        private long codigoMasc;
        private String nombreMascota;
        private String tipo;
        private String raza;
        private List<Atencion> atenciones = new List<Atencion>();
        public Mascota(long codigoMasc, String nombreM, String tipo, String raza)
        {
            this.codigoMasc = codigoMasc;
            this.nombreMascota = nombreM;
            this.tipo = tipo;
            this.raza = raza;

        }
        public void AgregarAtencion(Atencion atencion)
        {
            this.atenciones.Add(atencion);
        }

        public void MostrarAtencion()
        {
            foreach (Atencion atencion in atenciones)
            {
                Console.WriteLine($"Codigo de atencion: {atencion.Cod_at}\n" +
                    $"Titulo: {atencion.Titulo}\n" +
                    $"Fecha: {atencion.Fecha}\n" +
                    $"Precio: {atencion.Precio}\n" +
                    $"Descripcion: {atencion.Descripcion}\n");
            }
        }

        public long CodigoMasc { get => codigoMasc; set => codigoMasc = value; }
        public string Nombre { get => nombreMascota; set => nombreMascota = value; }
        public string Tipo { get => tipo; set => tipo = value; }
        public string Raza { get => raza; set => raza = value; }
    }

    public abstract class Atencion{
        private int cod_at;
        private String titulo;
        private String descripcion;
        private DateTime fecha;
        private long precio;

        public Atencion(int codigo, String titulo, String descripcion, DateTime fecha, long precio)
        {
            this.cod_at = codigo;
            this.titulo = titulo;
            this.descripcion = descripcion;
            this.fecha = fecha;
            this.precio = precio;
        }

        public int Cod_at { get => cod_at; set => cod_at = value; }
        public string Titulo { get => titulo; set => titulo = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public DateTime Fecha{ get => fecha; set => fecha = value; }
        public long Precio { get => precio; set => precio = value; }
    }

    public class Ordinaria: Atencion
    {
        private String tipo;
        

        public Ordinaria(int codigo, String titulo, String descripcion, DateTime fecha, long precio, String Tipo) : base(codigo, titulo, descripcion, fecha, precio)//ni idea
        {

        }
    }

    public class Extraordinaria : Atencion
    {
        private String signosVitales;
        private String diagnostico;
        private String tratamiento;

        public Extraordinaria(int codigo, String titulo, String descripcion, DateTime fecha, long precio, String signosVitales, String diagnostico, String tratamiento) : base(codigo, titulo, descripcion, fecha, precio)
        {

            this.signosVitales = signosVitales;
            this.diagnostico = diagnostico;
            this.tratamiento = tratamiento;
            
        }

        public string SignosVitales { get => signosVitales; set => signosVitales = value; }
        public string Diagnostico { get => diagnostico; set => diagnostico = value; }
        public string Tratamiento { get => tratamiento; set => tratamiento = value; }
    }




}
