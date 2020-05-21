using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimerExamenParcialDeLaboratorio_III
{
    class Program
    {
        static void Main(string[] args)
        {
            Test test = new Test();

            test.testear();

        }
    }
    public class Test
    {
        public void testear()
        {
            //creamos un cliente
            Cliente cliente1 = new Cliente("carlitos", "juanez", 3624683897, "hola12345@gmail.com");

            //creamos 2 carritos que van a estar vinculados al cliente
            Carrito carrito1 = new Carrito(100, cliente1);
            Carrito carrito2 = new Carrito(200, cliente1);

            //creamos 4 articulos
            Articulo articulo1 = new Perecedero("mayonesa", "aderesos", 50, 100, new DateTime(10 / 06 / 20));
            Articulo articulo2 = new Perecedero("salsa cesar", "salsas", 50, 200, new DateTime(10 / 07 / 20));
            Articulo articulo3 = new Articulo("escoba", "limpieza", 50, 200000);
            Articulo articulo4 = new Articulo("rueda", "automotor", 900, 2);

            //cargamos carrito 1
            carrito1.AgregarArticulo(articulo1);
            carrito1.AgregarArticulo(articulo2);

            //borramos el articulo que queramos del carrito 1
            carrito1.BorrarConArgumentosArticulo(articulo1);



            //cargamos carrito 2
            carrito2.AgregarArticulo(articulo3);
            carrito2.AgregarArticulo(articulo4);

            //agregamos los carritos
            cliente1.AgregarCarrito(carrito1);
            cliente1.AgregarCarrito(carrito2);

            //mostrar los articulos elementos del primer articulo del primer carrito
            cliente1.Carritos[0].Articulos[0].MostrarElementosArticulos();

            //mostrar los elementos del carrito 1
            carrito1.MostrarElementosCarrito();

            //borramos el carrito que queramos
            cliente1.BorrarConArgumentosCarrito(carrito2);

          

            Console.ReadKey();
        }
        
    }

    public class Cliente
    {
        private String nombre;
        private String apellido;
        private uint telefono;
        private String e_mail;
        private Carrito[] carritos = new Carrito[1];
        private Carrito[] copiaCarritos;
        private int tamañoCarrito;
        private bool resp = false;


        public Cliente(String nombre, String apellido, uint telefono, String email)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.telefono = telefono;
            this.e_mail = email;
            this.tamañoCarrito = 0;
            
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public uint Telefono { get => telefono; set => telefono = value; }
        public string E_mail { get => e_mail; set => e_mail = value; }
        public Carrito[] Carritos { get => carritos; set => carritos = value; }

        public void AgregarCarrito(Carrito carrito)
        {
            if (resp)
            {
                copiaCarritos = carritos;

                
                //Console.WriteLine(copiaCarritos[0].GetPrecioTotal());//esto me demuestra que copiaCarritos efectivamente es una copia identica de carritos

                this.carritos = new Carrito[carritos.Length +1];//aca tengo la duda si el .lenght me tira un espacio mas o el mismo
                
                for (int i = 0; i < copiaCarritos.Length; i++)
                {
                    carritos[i] = copiaCarritos[i];
                }

                this.carritos[carritos.Length-1] = carrito; //aca lo mismo probemos dijo el ciego

                tamañoCarrito++;
                Console.WriteLine($"\nel nuevo tamaño del arreglo carritos es: {carritos.Length}");
                Console.WriteLine("se agrego el carrito numero {0}", tamañoCarrito);

                Console.WriteLine("precio total del carrito numero {0}: {1}", tamañoCarrito, carritos[carritos.Length-1].GetPrecioTotal());

            }
            else
            {
                carritos[0] = carrito;
                Console.WriteLine($"el nuevo tamaño del arreglo carritos es: {carritos.Length}\n\n");
                resp = true;
                tamañoCarrito = 1;
            }
            
        }

        /*public void BorrarCarritoSinArgumentos()
        {

            Console.WriteLine("Elija el carrito que desea borrar:\n");
            for (int i = 0; i < carritos.Length; i++)
            {
                Console.WriteLine($"\nCarrito numero {i}: ");
                carritos[i].MostrarElementosCarrito();
            }
            int respuesta = int.Parse(Console.ReadLine());

            Console.WriteLine("Carrito numero {0} borrado.",respuesta);
            this.carritos[respuesta] = carritos[carritos.Length-1];//pruebo si es lenght y no lenght-1
            Array.Clear(carritos, (carritos.Length-1), 1);

            this.tamañoCarrito--;


            Console.WriteLine("Los carritos quedaron de la siguiente forma:\n");
            for (int i = 0; i < tamañoCarrito; i++)
            {
                Console.WriteLine($"\nCarrito numero {i}: ");
                carritos[i].MostrarElementosCarrito();
            }

        }*/

        public void BorrarConArgumentosCarrito(Carrito carrito)
        {
            for (int i=0; i < carritos.Length; i++)
            {
                if (carritos[i] == carrito)
                {
                    Console.WriteLine("Carrito numero {0} borrado.", i);
                    this.carritos[i] = carritos[carritos.Length - 1];
                    Array.Clear(carritos, (carritos.Length - 1), 1);

                    this.tamañoCarrito--;
                }
            }
        }

    }

    public class Carrito
    {
        private Articulo[] articulos = new Articulo[1];
        private int precio_total = 0;
        private Articulo[] copiaArticulos;
        private int tamañoArticulos;
        private Cliente cliente;
        
        private bool resp = false;

        public int Precio_total { get => precio_total; set => precio_total = value; }
        public Cliente Cliente { get => cliente; set => cliente = value; }
        public Articulo[] Articulos { get => articulos; set => articulos = value; }

        public Carrito(int precio_total,Cliente cliente)
        {
            this.precio_total = precio_total;
            this.cliente = cliente;
            
        }

        public void AgregarArticulo(Articulo articulo)
        {
            if (resp)
            {
                copiaArticulos = articulos;

                this.articulos = new Articulo[articulos.Length + 1];

                for (int i = 0; i < copiaArticulos.Length; i++)
                {
                    articulos[i] = copiaArticulos[i];
                }

                this.articulos[articulos.Length - 1] = articulo;

                tamañoArticulos++;
                Console.WriteLine($"\nel nuevo tamaño del arreglo articulos es: {articulos.Length}");
                Console.WriteLine("se agrego el articulo numero {0}", tamañoArticulos);

                Console.WriteLine("Elementos del articulo numero {0}: \n", tamañoArticulos);
                articulo.MostrarElementosArticulos();

            }
            else
            {
                articulos[0] = articulo;
                Console.WriteLine($"el nuevo tamaño del arreglo carritos es: {articulos.Length}\n\n");
                resp = true;
                tamañoArticulos = 1;
            }

        }

        /*public void BorrarArticuloSinArgumentos()//esto funcionaba pero me di cuenta de que pedia que le mandemos con argumento asi que lo dejo comentado
        {

            Console.WriteLine("Elija el articulo que desea borrar:\n");
            for (int i = 0; i < articulos.Length; i++)
            {
                Console.WriteLine($"\nArticulo numero numero {i}: ");
                articulos[i].MostrarElementosArticulos();
            }
            int respuesta = int.Parse(Console.ReadLine());

            Console.WriteLine("Articulo numero {0} borrado.", respuesta);
            this.articulos[respuesta] = articulos[articulos.Length - 1];
            Array.Clear(articulos, (articulos.Length - 1), 1);

            this.tamañoArticulos--;


            Console.WriteLine("Los articulos quedaron de la siguiente forma:\n");
            for (int i = 0; i < tamañoArticulos; i++)
            {
                Console.WriteLine($"\nArticulo numero {i}: ");
                articulos[i].MostrarElementosArticulos();
            }

        }*/

        public void BorrarConArgumentosArticulo(Articulo articulo)
        {
            for (int i = 0; i < articulos.Length; i++)
            {
                if (articulos[i] == articulo)
                {
                    Console.WriteLine("Articulo numero {0} borrado.", i);
                    this.articulos[i] = articulos[articulos.Length - 1];
                    Array.Clear(articulos, (articulos.Length - 1), 1);

                    this.tamañoArticulos--;
                }
            }
        }

        public void MostrarElementosCarrito()
        {
            for (int i = 0; i < articulos.Length; i++)
            {
                if (tamañoArticulos !=0)
                {
                    if (articulos[i] != null)
                    {
                        Console.WriteLine($"\nArticulo numero {i}: \n");
                        articulos[i].MostrarElementosArticulos();
                    }
                    else
                    {
                        Console.WriteLine("no hay articulos en el carrito {0}", i);
                    }
                    
                }
                else
                {
                    Console.WriteLine("todavia no hay articulos en el carrito {0}", i);
                }
                

            }
            Console.WriteLine($"\nPrecio total: {this.precio_total}\n");
        }


        public int GetPrecioTotal()
        {
            return this.precio_total;
        }
    }

    public class Articulo
    {
        private String nombre;
        private String categoria;
        private int precio;
        private int stock;

        public Articulo(String nombre, String categoria, int precio, int stock)
        {
            this.nombre = nombre;
            this.categoria = categoria;
            this.precio = precio;
            this.stock = stock;
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public string Categoria { get => categoria; set => categoria = value; }
        public int Precio { get => precio; set => precio = value; }
        public int Stock { get => stock; set => stock = value; }

        public void MostrarElementosArticulos()
        {
            Console.WriteLine($"Nombre: {this.nombre}\n" +
                $"Categoria: {this.categoria}\n" +
                $"Precio: {this.precio}\n" +
                $"Stock disponible: {this.stock}\n");
        }
    }

    public class Perecedero: Articulo
    {
        private DateTime vencimiento;

        public Perecedero(String nombre, String categoria, int precio, int stock, DateTime vencimiento): base (nombre, categoria, precio, stock)
        {
            this.vencimiento = vencimiento;
        }

        public DateTime Vencimiento { get => vencimiento; set => vencimiento = value; }
    }





}
