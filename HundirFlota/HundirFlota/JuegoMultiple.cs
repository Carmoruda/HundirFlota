/// <summary>
/// 
/// La clase JuegoMultiple define los atributos que permiten
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
    internal class JuegoMultiple : Partida
    {
        //Atributos

        /// <summary>
        /// Primer Jugador humano iniciado por composición de 
        /// la clase Jugador.
        /// </summary>
        public Jugador jugadorHumano1 { get; set; }
        /// <summary>
        /// Segundo jugador humano iniciado por comopsición de 
        /// la clase Jugador.
        /// </summary>
        public Jugador jugadorHumano2 { get; set; }

        //Constructores 
        /// <summary>
        /// Constructor vacío de la clase JuegoMúltiple 
        /// </summary>
        public JuegoMultiple() { }

        /// <summary>
        /// Constructor parametrizado de la clase JuegoMúltiple.
        /// </summary>
        /// <param name="jugadorHumano1"></param>
        /// <param name="jugadorHumano2"></param>
        public JuegoMultiple(Jugador jugadorHumano1, Jugador jugadorHumano2)
        {
            this.jugadorHumano1 = jugadorHumano1;
            this.jugadorHumano2 = jugadorHumano2;
        }
    }
}
