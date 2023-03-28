/// <summary>
/// 
/// La clase JuegoIndividual define los atributos que permiten
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
    internal class JuegoIndividual : Partida
    {
        //Atributos
        /// <summary>
        /// Jugador humano iniciado por composición de 
        /// la clase Jugador
        /// </summary>
        public Jugador jugadorHumano { get; set; }
        /// <summary>
        /// Jugador automático iniciado por composición de
        /// la clase Jugaor.
        /// </summary>
        public Jugador jugadorAuto { get; set; }

        //Constructores
        /// <summary>
        /// Constructor parametrizado de la clase JuegoInividual
        /// </summary>
        public JuegoIndividual() { }

        /// <summary>
        /// Constructor parametrizado de la clase JuegoIndividual
        /// </summary>
        /// <param name="jugadorHumano"></param>
        /// <param name="jugadorAuto"></param>
        public JuegoIndividual(Jugador jugadorHumano, Jugador jugadorAuto)
        {
            this.jugadorHumano = jugadorHumano;
            this.jugadorAuto = jugadorAuto;
        }
    }

}
