using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoPracticoCifradoCesar
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Instrucciones
            Utilizando el tipo string y/o char elabore un programa de consola que descifre un texto cifrado según el algoritmo César.
            Consideraciones:

            Se tomará el texto cifrado por consola
            Se tomará la clave de cifrado por consola
            Los únicos caracteres que se podrán cifrar son los siguientes aábcdeéfghiíjklmnñoópqrstuúüvwxyz
            Todos los demás aparecerán sin cifrar
            ‌
            Como prueba el texto que deben descifrar es
            fcyb ry pbabpüzüragb ehr yyruñ qrfqr qragéb rf ry jréqñqréb pbabpüzüragb --- clave 13
            ‌
            y la clave es un número primo de dos cifras que podrás encontrar en el enlace adjunto!!

          
            ‌
            Suban las solución completa a su carpeta de Drive
             */

            

            String codigo, codigoDescifrado;
            int clave;
            CifradoCesar cifradoCesar;
            Console.WriteLine("Ingrese el codigo que desea descifrar.\n" +
                "\nTenga en cuenta que los unicos caracteres que se podran descifrar son los siguientes:\n" +
                "aábcdeéfghiíjklmnñoópqrstuúüvwxyz");
            codigo = Console.ReadLine();

            //ingresar 13
            Console.WriteLine("Ingrese la clave");
            clave = int.Parse(Console.ReadLine());
            
            cifradoCesar = new CifradoCesar(clave);
            
            //pruebo el codigo de ejemplo del profe
            codigoDescifrado = cifradoCesar.Descifrar("fcyb ry pbabpüzüragb ehr yyruñ qrfqr qragéb rf ry jréqñqréb pbabpüzüragb");
            Console.WriteLine(codigoDescifrado);
        }
    }

    public class CifradoCesar
    {

        private String codigoSinDescifrar;
        private String codigoDescifrado;
        private int clave;

        //creo arreglo de alfabeto
        private char[] alfabeto = new char[] { 'a', 'b' , 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'ñ', 'o' ,'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'};
        
        //creo un arreglo de caracteres del codigo a descifrar
        private char[] arregloCodigo;
        
        //creo un arreglo de caracteres de los caracteres que se pueden descifrar, que parece que al final no voy a usar un pedo pq comparo los String con indices nomas
        private char[] arregloCaracteres = new char[] { 'a','á','b','c','d','e','é','f','g','h','i','í','j','k','l','m','n','ñ','o','ó','p','q','r','s','t','u','ú','ü','v','w','x','y','z' };

        //creo un String con los caracteres que se pueden descifrar
        private String caracteres = "aábcdeéfghiíjklmnñoópqrstuúüvwxyz";



        public CifradoCesar(int clave)
        {
            this.clave = clave;
        }

        public String Descifrar(String codigo)
        {
            //creo una nueva variale para ir acumulando los caracteres descifrados
            String respuesta = "";

            //creo un entero para la comparacion de caracteres
            int compareResult = 0;

            //transformo el String a un arreglo de char para recorrerlo
            this.arregloCodigo = codigo.ToCharArray();

            //recorro el codigo recibido con un for y voy comparando las posiciones con las del arreglo de caracteres permitidos
            for (int i = 0; i < arregloCodigo.Length; i++)
            {

                //se puede hacer esto o se puede poner un if con todo esto "aábcdeéfghiíjklmnñoópqrstuúüvwxyz"

                for (int j = 0; j < caracteres.Length; j++)
                {
                    compareResult = String.Compare((codigo[i].ToString()), (this.caracteres[j].ToString()), StringComparison.OrdinalIgnoreCase);//comprobar si funciona xd
                    if (compareResult == 0)
                    {
                        //hago un metodo fuera de este para comparar pq aca es un desca
                        respuesta += Comparar(codigo[i]);//no se si asi se acumula(? esto devuelve el caracter que corresponde
                    }
                    else//si la comparacion de los dos indices traspasa2 a String es distinta de 0 significa que son distintos caracteres directamente, no que sean mayusculas o minus
                    {
                        //no se descifra el codigo y se le agrega a la variable respuesta el caracter asi nomas
                        //ir acumulando en respuesta los caracteres de codigo[i] que caigan en este else
                    }

                }

            }
            return respuesta;
        }

        private String Comparar(char caracterAComparar)
        {
            //bueno aca esta el tema pq pensaba comparar con el alfabeto y asi comoque darle un valor a caracterAComparar para sumarle la clave
            //pensaba en sumar la clave y meter un if por si se superaban los ciclos del for que regrese todo al 0 y siga avanzando con lo que le queda para llegar al valor de la clave
            //si tengo 27 letras en el abecedario y resulta que encuentro la coincidencia en el indice 20 y tengo que sumar 13 entonces cuando llegue al 27 el indice pero a la suma le siguen faltando
            // 6 se empieza de vuelta el for y se avanza hasta esos 6
            for (int i= 0; i < alfabeto.Length; i++)
            {
                //XD
            }
            return "";
        }
    }

}
