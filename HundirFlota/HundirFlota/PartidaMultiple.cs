/// <summary>
/// 
/// La clase PartidaMultiple define los atributos que permiten
/// controlar las partidas del juego con el perfil
/// de un jugador humano contra un jugador humano.
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
    internal class PartidaMultiple : Partida
    {
        // Atributos

        /// <summary>
        /// Instancia de la clase Jugador que permite a un
        /// jugador humano participar en la partida (Jugador 1).
        /// </summary>
        public Jugador jugadorHumano1 { get; set; }

        /// <summary>
        /// Instancia de la clase Jugador que permite a otro 
        /// jugador humano participar en la partida (Jugador 2).
        /// </summary>
        public Jugador jugadorHumano2 { get; set; }

        // Constructores 

        /// <summary>
        /// Constructor vacío de la clase PartidaMultiple. Inicializa
        /// las instancias de la clase Jugador.
        /// </summary>
        public PartidaMultiple() 
        {
            jugadorHumano1 = new Jugador();
            jugadorHumano2 = new Jugador();
        }

        /// <summary>
        /// Constructor parametrizado de la clase PartidaMultiple.
        /// Inicializa las instancias de la clase Jugador.
        /// </summary>
        /// <param name="_jugadorHumano1">
        /// Instancia de Jugador que representa al jugador humano 1.
        /// </param>
        /// <param name="_jugadorHumano2">
        /// Instancia de un Jugador que representa al jugador humano 2.
        /// </param>
        public PartidaMultiple(Jugador _jugadorHumano1, Jugador _jugadorHumano2)
        {
            jugadorHumano1 = _jugadorHumano1;
            jugadorHumano2 = _jugadorHumano2;
        }

        // Métodos
    }
}
