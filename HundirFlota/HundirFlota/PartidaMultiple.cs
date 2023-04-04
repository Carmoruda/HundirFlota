﻿/// <summary>
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
        /// <param name="_nombrePartida">
        /// String que representa el nombre de la partida.
        /// </param>
        public PartidaMultiple(Jugador _jugadorHumano1, Jugador _jugadorHumano2, string _nombrePartida) : base(false, 0, _nombrePartida)
        {
            jugadorHumano1 = _jugadorHumano1;
            jugadorHumano2 = _jugadorHumano2;
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
            return "\n\t * Jugador 1: " + jugadorHumano1.nombre + "\n\t * Jugador 2: " + jugadorHumano2.nombre;
        }
    }
}
