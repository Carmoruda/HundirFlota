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
using System.Text.Json.Serialization;
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
        [JsonInclude]
        public Jugador jugador1 { get; set; }
        /// <summary>
        /// Instancia de la clase Jugador que permite
        /// a un jugador automático participar en la partida.
        /// </summary>
        [JsonInclude]
        public Jugador jugador2 { get; set; }

        //Constructores

        /// <summary>
        /// Constructor vacío de la clase PartidaIndividual. Inicializa
        /// las instancias de la clase Jugador.
        /// </summary>
        public PartidaIndividual() 
        {
            jugador1 = new Jugador();
            jugador2 = new Jugador();
        }

        /// <summary>
        /// Constructor parametrizado de la clase PartidaIndividual.
        /// Inicializa las instancias de la clase Jugador.
        /// </summary>
        /// <param name="_jugador1">
        /// Instancia de Jugador que representa al jugador humano.
        /// </param>
        /// <param name="_jugador2">
        /// Instancia de Jugador que repsenta al jugador automático
        /// </param>
        /// <param name="_nombrePartida">
        /// String que representa el nombre de la partida.
        /// </param>
        public PartidaIndividual(Jugador _jugador1, Jugador _jugador2, string _nombrePartida) : base(false, 0, _nombrePartida)
        {
            jugador1 = _jugador1;
            jugador2 = _jugador2;
        }

        // Métodos

        /// <summary>
        /// Muestra la información correspondiente a cada jugador
        /// de la partida.
        /// </summary>
        /// <returns>
        /// String que muestra el nombre del jugador 1 y del jugador 2.
        /// </returns>
        public override string InformacionJugadores()
        {
            return "\n\t * Jugador 1: " + jugador1.nombre + "\n\t * Jugador 2: " + jugador2.nombre;
        }

        /// <summary>
        /// Controla el inicio de una nueva partida, permitiendo
        /// al jugador 1 (Humano) colocar sus barcos.
        /// </summary>
        public override void NuevaPartida()
        {
            jugador1.NuevaPartida();
        }
    }

}
