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
        public JugadorHumano jugadorHumano { get; set; }
        /// <summary>
        /// Instancia de la clase Jugador que permite
        /// a un jugador automático participar en la partida.
        /// </summary>
        [JsonInclude]
        public JugadorHumano jugadorAuto { get; set; }

        //Constructores

        /// <summary>
        /// Constructor vacío de la clase PartidaIndividual. Inicializa
        /// las instancias de la clase Jugador.
        /// </summary>
        public PartidaIndividual() 
        {
            jugadorHumano = new JugadorHumano();
            jugadorAuto = new JugadorHumano();
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
        public PartidaIndividual(JugadorHumano _jugadorHumano, JugadorHumano _jugadorAuto, string _nombrePartida) : base(false, 0, _nombrePartida)
        {
            jugadorHumano = _jugadorHumano;
            jugadorAuto = _jugadorAuto;
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
            return "\n\t * Jugador 1: " + jugadorHumano.nombre + "\n\t * Jugador 2: " + jugadorAuto.nombre;
        }

        /// <summary>
        /// Controla el inicio de una nueva partida, permitiendo
        /// al jugador 1 (Humano) colocar sus barcos.
        /// </summary>
        public override void NuevaPartida()
        {
            jugadorHumano.NuevaPartida();
        }
    }

}
