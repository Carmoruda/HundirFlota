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

        /// <summary>
        /// String que representa el nombre de la partida.
        /// </summary>
        public string nombrePartida { get; set; }

        // Constructores

        /// <summary>
        /// Constructor vacío de la clase Partida. Inicializa el
        /// atributo de tablero y asigna valores a finalizada, a
        /// numMovimientos y a nombrePartida.
        /// </summary>
        public Partida()
        {
            finalizada = false;
            numMovimientos = 0;
            nombrePartida = "Partida" + DateTime.Now.ToString("dd/MM/yyyy HH:mm tt");
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
        /// <param name="_nombrePartida">
        /// String que representa el nombre de la partida.
        /// </param>
        public Partida (bool _finalizada, int _numMovimientos, string _nombrePartida)
        {
            finalizada = _finalizada;
            numMovimientos= _numMovimientos;
            nombrePartida = _nombrePartida;
        }

        // Métodos
       
    }
}
