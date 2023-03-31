/// <summary>
/// 
/// La clase Partide define los atributos que permiten
/// controlar las partidas del juego dentro del juego.
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
    internal abstract class Partida
    {
        // Atributos

        /// <summary>
        /// Booleano que reprsenta el estado de la partida
        /// (1 ≡ Finalizada).
        /// </summary>
        public bool finalizada { get; set; }

        /// <summary>
        /// Entero que representa el número de movimientos que 
        /// han sido realizados en la partida.
        /// </summary>
        public int numMovimientos { get; set; }

        // Constructores

        /// <summary>
        /// Constructor vacío de la clase Partida. Inicializa el
        /// atributo de tablero y asigna valores a finalizada y a
        /// numMovimientos.
        /// </summary>
        public Partida()
        {
            finalizada = false;
            tablero = new Tablero();
            numMovimientos = 0;
        }

        /// <summary>
        /// Constructor parametrizado de la clase Partida. Inicializa el
        /// atributo tablro y asigna el valor de finalizada y numMovimientos.
        /// </summary>
        /// <param name="_finalizada">
        /// Booleano que representa si la partida ha sido finalizada.
        /// </param>
        /// <param name="_numMovimientos">
        /// Entero que representa el número de movimientos que han sido
        /// realizados en la partida.
        /// </param>
        public Partida (bool _finalizada, int _numMovimientos)
        {
            finalizada = _finalizada;
            numMovimientos= _numMovimientos;
            tablero = new Tablero();
        }

        // Métodos
       
    }
}
