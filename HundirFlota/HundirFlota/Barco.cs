/// <summary>
/// 
/// La clase Barco define los atributos necesarios
/// para la creación de cada tipo de barco dentro de 
/// cada jugador.
/// 
/// <autores>LEdSM, OSV y CMU</autores>
/// <version>0.1</version>
/// </summary>

using HundirFlota;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HundirFlota
{
    internal class Barco
    {
        // Atributos

        public int[,] patrullera = new int[2, 2]; // es bidimensional puesto que almaceno 2 numero (coordenadas)
        public int[,] submarino = new int[3,2]; //el primero coincide con la longitud del barco
        public int[,] destructor = new int[4,2];
        public int[,] portaaviones = new int[5,2];
        public Pantalla consola { get; set; }
        public Tablero tablero { get; set; }    



        public Barco() 
        {
            consola= new Pantalla();
            tablero =new Tablero();
            
        }

        public Barco(int[,] patrullera, int[,] submarino, int[,] destructor, int[,] portaaviones, Pantalla consola, Tablero tablero)
        {
            this.patrullera = patrullera;
            this.submarino = submarino;
            this.destructor = destructor;
            this.portaaviones = portaaviones;
            this.consola = consola;
            this.tablero = tablero;
        }

        public void ColocarBarcos()
        {

            string patrullero = "Colocacion barco PATRULLERO";
            consola.ImprimirConsola(patrullero, 0);
            AumentarPosicion(ref patrullera, 2, "| P");

            string subma = "Colocacion barco SUBMARINO";
            consola.ImprimirConsola(subma, 0);
            AumentarPosicion(ref submarino, 3, "| S");

            string destr = "Colocacion barco DESTRUCTOR";
            consola.ImprimirConsola(destr, 0);
            AumentarPosicion(ref destructor, 4, "| D");

            string porta = "Colocacion barco PORTAAVIONES";
            consola.ImprimirConsola(porta, 0);
            AumentarPosicion(ref portaaviones, 5, "| V");

        }


        public void AumentarPosicion(ref int[,] barco, int longitud, string letra) //creo una funcion a la que le paso el barco, su longitud 
        {
            string coordenadaX = "Coordenada X del barco";
            consola.ImprimirConsola(coordenadaX, 0);
            int posicionX = Convert.ToInt32(Console.ReadLine());
            barco[0, 0] = posicionX;
            string coordenadaY = "Coordenada Y del barco";
            consola.ImprimirConsola(coordenadaY, 0);
            int posicionY = Convert.ToInt32(Console.ReadLine());
            barco[0, 1] = posicionY;

            string direccion = "Quieres colocarlo en vertical u horizontal?";
            consola.ImprimirConsola(direccion, 0);
            string decision = Console.ReadLine().ToUpper();

            switch (decision)
            {

                case "VERTICAL":

                    for (int i = 1; i <= longitud; i++) //empiezo en 1 pq la posicion 0 ya la he elegido arriba
                    {
                        barco[i, 0] = posicionX;
                        barco[i, 1]= posicionY + i;
                        tablero.mapa[posicionX,posicionY+i] = letra;
                       
                    }
                    break;

                case "HORIZONTAL":

                    for (int i = 1; i <= longitud; i++)
                    {
                        barco[i, 0] = posicionX + i;
                        barco[i, 1] = posicionY;
                        tablero.mapa[posicionX +i, posicionY] = letra;

                    }
                    break;

            }

        }
    }
}




