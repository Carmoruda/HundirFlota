/// <summary>
/// 
/// La clase Juego define los atributos y métodos necesarios
/// para el correcto funcionamiento de la gestión de partidas
/// del juego.
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
    internal class Juego
    {

        // Atributos

        /// <summary>
        /// Lista de instancias de Partida que almacena todas las
        /// partidas de un jugador VS otro jugador humano o automático.
        /// </summary>
        public List<Partida> listaPartidas { get; set; }

        /// <summary>
        /// Intacia de la clase Pantalla para controlar la entrada
        /// y salida de datos del usuario.
        /// </summary>
        public Pantalla consola { get; set; }

        // Constructores

        /// <summary>
        /// Constructor vacío de la clase Juego. Inicializa el
        /// atributo consola y la lista de partidas.
        /// </summary>
        public Juego() 
        {
            consola = new Pantalla();
            listaPartidas = new List<Partida>();
        }

        /// <summary>
        /// Constructor parametrizado de la clase Juego. Inicializa
        /// el atributo consola y la lista de barcos.
        /// </summary>
        /// <param name="_listaPartidas">
        /// Lista que representa las partidas del Juego.
        /// </param>
        public Juego(List<Partida> _listaPartidas)
        {
            consola = new Pantalla();
            listaPartidas = _listaPartidas;
        }
    }
}
