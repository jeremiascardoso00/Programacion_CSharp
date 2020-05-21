using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace POO_Practico1
{

    class PruebaCuentas
    {
        static void Main(string[] args)
        {
            /*
            Practico1:
                Desarrolle una programa orientado a objetos en C#, para gestionar una clase cuenta corriente
                se caracteriza por tener asociado un numero de cuenta y un saldo disponible.

                Además, se puede consultar el saldo disponible en cualquier momento, 
                recibir depósitos y 
                realizar extracciones y pagos.

                Creara además una clase Persona, 
                que se caracteriza por un DNI y un array de cuentas bancarias. 
                La Persona puede tener asociada hasta 3 cuentas bancarias, 

                y debe tener un método que permite añadir cuentas (hasta 3 que es el máximo). 
                También debe contener un método que devuelva si la persona es morosa, 
                ej., si tienen alguna cuenta con saldo negativo.

                
                Crear una clase Prueba Cuentas que instancie un objeto Persona con un dni cualquiera, así
                como dos objetos cuenta, una sin saldo inicial y otra con 700 euros. La persona recibe la
                nomina mensual, por lo que ingresa 1100 euros en la primera cuenta, pero tiene que pagar el
                alquiler de 750 euros con la segunda. Imprimir por pantalla el si la persona es morosa.
                Posteriormente hacer una transferencia de una cuenta a otra y comprobar mostrándolo por
                pantalla que cambia el estado de la persona.        
            */

            Persona persona = new Persona(42404900);

           
            CuentaCorriente cuenta1 = new CuentaCorriente(1,0);
            CuentaCorriente cuenta2 = new CuentaCorriente(2, 700);

            persona.AniadirCuentas(cuenta1);
            persona.AniadirCuentas(cuenta2);




            cuenta1.RecibirDepósitos(1100);
            cuenta1.RealizarPagos(ref cuenta2, 750);

            persona.EsMoroso();
            Console.WriteLine("\nsaldo cuenta 1: " + cuenta1.ConsultarSaldo());
            Console.WriteLine("saldo cuenta 2: " + cuenta2.ConsultarSaldo());
            cuenta1.RecibirDepósitos(cuenta2.RealizarExtracciones(700));

            Console.WriteLine("\n\nDespues de la transferencia... de 700 de cuenta 2 a cuenta 1");
            
            Console.WriteLine("\nsaldo cuenta 1: " + cuenta1.ConsultarSaldo());
            Console.WriteLine("saldo cuenta 2: " + cuenta2.ConsultarSaldo());
            Console.ReadKey();




        }
    }


    class CuentaCorriente
    {
        private int SaldoDisponible;
        private int NumeroDeCuenta;
        public CuentaCorriente(int NumCuenta, int Saldo)
        {
            this.SaldoDisponible = Saldo;
            this.NumeroDeCuenta = NumCuenta;
        }

        public int ConsultarSaldo()
        {
            return this.SaldoDisponible;
        }

        public void RecibirDepósitos(int deposito)
        {
            this.SaldoDisponible += deposito;
        }

        public int RealizarExtracciones(int valor)
        {
            if(valor <= SaldoDisponible)
            {
                SaldoDisponible -= valor;
            }
            else
            {
                Console.WriteLine("No posee el suficiente saldo para realizar esta extraccion");
                valor = 0;
            }
            return valor;
        }

        public void RealizarPagos(ref CuentaCorriente cuenta, int monto) 
        {
            if (SaldoDisponible>= monto)
            {
                this.SaldoDisponible -= monto;
                cuenta.RecibirDepósitos(monto);
            }
            else
            {
                Console.WriteLine("No se cuenta con el suficiente dinero para realizar el pago solicitado");
            }
        }


    }

    class Persona
    {
        private int DNI;
        private CuentaCorriente[] cuenta = new CuentaCorriente[3];
        private int indice = 0;
        public Persona(int DNI)
        {
            this.DNI = DNI;
        }

        public void AniadirCuentas(CuentaCorriente cuenta)
        {
            if (this.indice < 3)
            {
                this.cuenta[indice] = cuenta;
                indice++;
            }
            else
            {
                Console.WriteLine("la persona ya tiene asociadas 3 cuentas");
            }
            
        }

        public void EsMoroso()
        { 
            for (int i = 0; i< indice; i++)
            {
                if (cuenta[i].ConsultarSaldo() < 0)
                {
                    Console.WriteLine($"Esta persona tiene mora de ${cuenta[i].ConsultarSaldo()} en su cuenta numero: {i}");

                }
            }
        }

    }

    

}