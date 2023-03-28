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
        public int longitud { get; set; }
        public int[,] coordenada { get; set; }

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
    }
}
