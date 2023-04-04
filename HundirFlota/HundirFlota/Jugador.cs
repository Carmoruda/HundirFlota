/// <summary>
/// 
/// La clase Jugador define los atributos necesarios
/// para la identificación de los jugadores y el
/// el control del tablero.
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
    internal class Jugador
    {
        // Atributos

        /// <summary>
        /// String que representa el nombre del jugador.
        /// </summary>
        public string nombre { get; set; }

        /// <summary>
        /// Instancia de la clase Tablero que permite el control
        /// del tablero de la partida.
        /// </summary>
        public Tablero tablero { get; set; }

        /// <summary>
        /// Barco tipo patrullero iniciado  por composición
        /// de la clase barco.
        /// </summary>
        public Barco patrullero { get; set; }
        /// <summary>
        /// Barco tipo submarino iniciado por composición
        /// de la clase barco.
        /// </summary>
        public Barco submarino { get; set; }
        /// <summary>
        /// Barco tipo destructor iniciadopor composición
        /// de la clase barco.
        /// </summary>
        public Barco destructor { get; set; }
        /// <summary>
        /// Barco tipo portaaviones iniciadopor composición
        /// de la clase barco.
        /// </summary>
        public Barco portaaviones { get; set; }

        // Constructores

        /// <summary>
        /// Constructor vacío de la clase Jugador.
        /// </summary>
        public Jugador() 
        {
            tablero = new Tablero();
            patrullero = new Barco();
            submarino = new Barco();
            destructor = new Barco();
            portaaviones = new Barco();
        }

        /// <summary>
        /// Constructor parametrizado 1 de la clase jugador
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="tablero"></param>
        /// <param name="patrullero"></param>
        /// <param name="submarino"></param>
        /// <param name="destructor"></param>
        /// <param name="portaaviones"></param>
        public Jugador(string nombre, Tablero tablero, Barco patrullero, Barco submarino, Barco destructor, Barco portaaviones)
        {
            this.nombre = nombre;
            this.tablero = tablero;
            this.patrullero = patrullero;
            this.submarino = submarino;
            this.destructor = destructor;
            this.portaaviones = portaaviones;
        }

        public Jugador(string _nombre) : base()
        {
            nombre = _nombre;
        }

    }
}
