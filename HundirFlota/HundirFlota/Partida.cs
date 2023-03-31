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
        public bool finalizada { get; set; }
        public Tablero tablero {get; set; }
        public int numMovimientos { get; set; }

        // Constructores

        public Partida()
        {
            tablero = new Tablero();
            numMovimientos = 0;
            finalizada= false;
        }

        public Partida (bool _finalizada, int _numMovimientos)
        {
            finalizada = _finalizada;
            numMovimientos= _numMovimientos;
            tablero = new Tablero();

        }

        // Métodos
       
    }
}
