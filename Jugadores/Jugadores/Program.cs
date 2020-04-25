using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace JuegoDeApuestas
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }

    public class Tablero
    {

        private Jugadores[] jugadores;
        private double pozo;
        private Dados dado01;

        public Tablero()
        {
            this.pozo = 10.000;
            this.dado01 = new Dados();
            this.jugadores = new Jugadores[2];
            this.jugadores[0] = new Jugadores(0);
            this.jugadores[1] = new Jugadores(1);
            

        }
        
        public void iteracion()
        {

            while (this.getPozo() > 0 && jugadores[0].getPlata() > 0  && jugadores[1].getPlata() > 0)
            {
                for (int i = 0; i < 2; i++)
                {
                    Console.WriteLine("Jugador {0} ingrese un numero segun el modo de juego que desea:\n" +
                        "1-conservador\n" +
                        "2-arriesgado\n" +
                        "3-desesperado\n", (i+1));

                }
            }
        }
       



        public double getPozo()
        {
            return this.pozo;
        }
    }

    class Jugadores
    {
        private String modoDeApuesta = "";
        private int apuesta = 0;
        private int montoApuesta = 0;
        private int plata = 100;
        private int numJugador = 0;

        public Jugadores(int numJugador)
        {
            setNumJugadores(numJugador);
        }

        public int getNumJugadores()
        {
            return this.numJugador;
        }
        private void setNumJugadores(int numJugador)
        {
            this.numJugador = numJugador;
        }
        public String getModoDeApuesta()
        {
            return this.modoDeApuesta;
        }
        public void setModoDeApuesta(String modoDeApuesta)
        {
            this.modoDeApuesta = modoDeApuesta;
        }
        public int getApuesta()
        {
            return this.apuesta;
        }
        public void setApuesta(int apuesta)
        {
            this.apuesta = apuesta;
        }
        public int getMontoApuesta()
        {
            return this.apuesta;
        }
        public void setMontoApuesta(int MontoApuesta)
        {
            this.montoApuesta = montoApuesta;
        }
        public int getPlata()
        {
            return this.plata;
        }

    }

    class Dados
    {
        Random r = new Random();
        public int TirarDados(int valor, int cuenta)
        {
            int valorSegundoDado = 0;
            Console.WriteLine("Tirando Dado");
            valor += r.Next(1, 7);
            cuenta += 1;
            if (cuenta < 2)
            {
                return TirarDados(valor, cuenta);


            }
            return valor;
        }
    }

}
