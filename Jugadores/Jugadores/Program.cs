using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace JuegoDeApuestas
{
    class Program
    {
        static void Main(string[] args)
        {

            /*
            Instructions
            Objetivo: implementar varias clases y sus asociaciones. Usar propiedades, enumeraciones o constantes donde se necesite
            ‌
            Modifique el juego anterior
            -Dos jugadores, Dos dados y Apuestas
            -Tres modos de apuesta {conservador -1/2, arriesgado -2/5, desesperado -4/15}
            -Cada jugador cuenta con $100 iniciales y un pozo de $10000.
            -El juego termina cuando el pozo o el saldo de algún jugador llega a cero.
            -Hasta 5 clases

            Ejemplo:
            Pozo empieza con 10000, el jugador 1 $100 y el jugador 2 $100
            Jugador 1 apuesta $10 (conservador) al nro 6
            Jugador 2 apuesta $20 (arriesgado) al nro 10
            Se corrobora que haya suficiente dinero en el pozo para pagar en el caso que gane la apuesta más elevada y que cada jugador pueda pagar lo apostado si pierde
            ‌
            Una posibilidad
            Se arrojan los dados y se obtiene 11
            Ambos pierden el jugador 1 se queda con $90, el jugador 2 se queda con $60
            El pozo acumula 10050
            ‌
            Otra posibilidad
            Se arrojan los dados y se obtiene 10
            Ambos pierden el jugador 1 se queda con $90, el jugador 2 se queda con $200 (100 + 5*20)
            El pozo acumula 10000 + 10 -100 = 9910
             */

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
                    int monto = 0;
                    int modo = 0;
                    int apuesta = 0;
                    int resp = 0;
                    do
                    {
                    Console.WriteLine("Jugador {0} ingrese un numero segun el modo de juego que desea:\n" +
                        "1-conservador\n" +
                        "2-arriesgado\n" +
                        "3-desesperado\n", (i+1));
                    modo = Convert.ToInt16(Console.ReadLine());
                    
                    
                        switch (modo)
                        {

                            case 1:
                                jugadores[i].setModoDeApuesta("Conservador");
                                resp = 0;
                                break;
                            case 2:
                                jugadores[i].setModoDeApuesta("Arriesgado");
                                resp = 0;
                                break;
                            case 3:
                                jugadores[i].setModoDeApuesta("Desesperado");
                                resp = 0;
                                break;
                            default:
                                Console.WriteLine("opcion ingresada invalida");
                                resp = 1;
                                break;
                        }
                    } while (resp==1);
                    do
                    {
                    Console.WriteLine("Jugador {0} ingrese un monto que desee apostar\n", (i + 1));
                    monto = Convert.ToInt16(Console.ReadLine());
                    
                        if (monto <= jugadores[i].getPlata())
                        {
                            jugadores[i].setMontoApuesta(monto);
                            resp = 0;
                        }
                        else
                        {
                            Console.WriteLine("no cuenta con esa cifra, usted cuenta con ${0}", jugadores[i].getPlata());
                            resp = 1;
                        }
                    } while (resp == 1);

                    do
                    {
                        Console.WriteLine("Jugador {0} ingrese un numero entre el 1 y el 12 al que desee apostar\n", (i + 1));
                        apuesta = Convert.ToInt16(Console.ReadLine());

                        if (apuesta > 0 && apuesta < 13)
                        {
                            jugadores[i].setApuesta(apuesta);
                            resp = 0;
                        }
                        else
                        {
                            Console.WriteLine("Numero fuera de rango");
                            resp = 1;
                        }
                    } while (resp == 1);

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
