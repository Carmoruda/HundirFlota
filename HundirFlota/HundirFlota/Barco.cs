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

        public int longitud { get; set; }
        public int[,] coordenada { get; set; }
        public int[,] patrullera = new int[2,2]; // es bidimensional puesto que almaceno 2 numero (coordenadas)
        public int[,] submarino = new int[3,2]; //el primero es la longitud del barco
        public int[,] destructuctor = new int[4,2];
        public int[,] portaaviones = new int[5,2];



        public Barco() 
        {
            longitud = 0;
            coordenada = new int[1,1];

            
        }

        public Barco(int longitud, int[,] coordenada)
        {
            this.longitud = longitud;
            this.coordenada = coordenada;
        }

        public void ColocarBarcos()
        {

        }
    }
}
