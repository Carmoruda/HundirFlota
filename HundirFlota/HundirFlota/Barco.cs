/// <summary>
/// 
/// La clase Barco define los atributos necesarios
/// para la creación de cada tipo de barco dentro de 
/// cada jugador.
/// 
/// <autores>LEdSM, OSV y CMU</autores>
/// <version>0.1</version>
/// </summary>

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

        public int[,] patrullera = new int[2,2]; // es bidimensional puesto que almaceno 2 numero (coordenadas)
        public int[,] submarino = new int[3,2]; //el primero coincide con la longitud del barco
        public int[,] destructuctor = new int[4,2];
        public int[,] portaaviones = new int[5,2];
        public Pantalla consola { get; set; }



        public Barco() 
        {
            consola= new Pantalla();
            
        }

        public Barco(int longitud, int[,] coordenada)
        {

        }

        public void ColocarBarcos()
        {
            string coordenadaX = "Coordenada X del barco";
            consola.ImprimirConsola(coordenadaX, 0);
            int posicionX = Convert.ToInt32(Console.ReadLine());
            patrullera[0, 0] = posicionX;
            string coordenadaY = "Coordenada Y del barco";
            consola.ImprimirConsola(coordenadaY, 0);
            int posicionY = Convert.ToInt32(Console.ReadLine());
            patrullera[0, 1] = posicionY;
            AumentarPosicion(patrullera, 2, 2, posicionX, posicionY);





            //creo una funcion a la que le paso el barco, su longitud y si quiero que incremente izqda o dcha

        }


        public void AumentarPosicion(Array barco, int longitud, int coordenada, int posicionX, int posicionY) 
        
        {
            string direccion = "Quieres colocarlo en vertical u horizontal?";
            consola.ImprimirConsola(direccion, 0);
            string decision = Console.ReadLine().ToUpper();

            switch (decision)
            {
                case "Vertical":
                    break;

            }

        }
    }
}
