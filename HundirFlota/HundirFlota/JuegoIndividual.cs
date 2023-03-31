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
        /// Constructor vacío de la clase JuegoIndividual. Inicializa
        /// las instancias de la clase Jugador.
        /// </summary>
        public JuegoIndividual() 
        {
            jugadorHumano = new Jugador();
            jugadorAuto = new Jugador();
        }

        /// <summary>
        /// Constructor parametrizado de la clase JuegoIndividual.
        /// Inicializa las instancias de la clase Jugador.
        /// </summary>
        /// <param name="jugadorHumano">
        /// Instancia de Jugador que representa al jugador Humano.
        /// </param>
        /// <param name="jugadorAuto">
        /// Instancia de Jguador que repsenta al jugador automático
        /// </param>
        public JuegoIndividual(Jugador _jugadorHumano, Jugador _jugadorAuto)
        {
            jugadorHumano = _jugadorHumano;
            jugadorAuto = _jugadorAuto;
        }

        // Métodos
    }

}
