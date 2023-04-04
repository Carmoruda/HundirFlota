/// <summary>
/// 
/// La clase PartidaIndividual define los atributos que permiten
/// controlar las partidas del juego con el perfil
/// de un jugador humano contra un jugador automático.
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
    internal class PartidaIndividual : Partida
    {
        //Atributos

        /// <summary>
        /// Instancia de la clase Jugador que permite
        /// a un jugador humano participar en la partida.
        /// </summary>
        public Jugador jugadorHumano { get; set; }
        /// <summary>
        /// Instancia de la clase Jugador que permite
        /// a un jugador automático participar en la partida.
        /// </summary>
        public Jugador jugadorAuto { get; set; }

        //Constructores

        /// <summary>
        /// Constructor vacío de la clase PartidaIndividual. Inicializa
        /// las instancias de la clase Jugador.
        /// </summary>
        public PartidaIndividual() 
        {
            jugadorHumano = new Jugador();
            jugadorAuto = new Jugador();
        }

        /// <summary>
        /// Constructor parametrizado de la clase PartidaIndividual.
        /// Inicializa las instancias de la clase Jugador.
        /// </summary>
        /// <param name="_jugadorHumano">
        /// Instancia de Jugador que representa al jugador humano.
        /// </param>
        /// <param name="_jugadorAuto">
        /// Instancia de Jugador que repsenta al jugador automático
        /// </param>
        /// <param name="_nombrePartida">
        /// String que representa el nombre de la partida.
        /// </param>
        public PartidaIndividual(Jugador _jugadorHumano, Jugador _jugadorAuto, string _nombrePartida) : base(false, 0, _nombrePartida)
        {
            jugadorHumano = _jugadorHumano;
            jugadorAuto = _jugadorAuto;
        }

        // Métodos
    }

}
