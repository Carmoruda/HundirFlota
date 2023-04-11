/// <summary>
/// 
/// La clase Coordenadas define los atributos y métodos necesarios
/// para el correcto funcionamiento de las coordenadas de los barcos.
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
    [Serializable]
    internal class Coordenadas
    {
        // Atributos

        /// <summary>
        /// Array de enteros que representa la coordenada en 
        /// el eje X del barco.
        /// </summary>
        public int[] x {  get; set; }

        /// <summary>
        /// Array de enteros que representa la coordenada en 
        /// el eje Y del barco.
        /// </summary>
        public int[] y { get; set; }

        // Constructores

        /// <summary>
        /// Constructor vacío de la clase jugador.
        /// </summary>
        public Coordenadas() 
        {
            x = new int[2];
            y = new int[2];
        }

        /// <summary>
        /// Constructor parametrizado de la clase Coordenadas. Asigna
        /// los valor de las coordenas x e y del barco.
        /// </summary>
        /// <param name="_x">
        /// Array de enteros que representa la coordenada X del barco.
        /// </param>
        /// <param name="_y">
        /// Array de enteros que representa la coordenada Y del barco.
        /// </param>
        public Coordenadas(int[] _x, int[] _y)
        {
            x = _x;
            y = _y;
        }

        // Métodos
    }
}
