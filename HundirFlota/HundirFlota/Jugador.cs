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
        /// Instancia de la clase Barco que representa
        /// un navío de tipo patrullero.
        /// </summary>
        public Barco patrullero { get; set; }

        /// <summary>
        /// Instancia de la clase Barco que representa
        /// un navío de tipo submarino.
        /// </summary>
        public Barco submarino { get; set; }
        
        /// <summary>
        /// Instancia de la clase Barco que representa
        /// un navío de tipo destructor.
        /// </summary>
        public Barco destructor { get; set; }

        /// <summary>
        /// Instancia de la clase Barco que representa
        /// un navío de tipo portaaviones.
        /// </summary>
        public Barco portaaviones { get; set; }

        // Constructores

        /// <summary>
        /// Constructor vacío de la clase Jugador.
        /// </summary>
        public Jugador() 
        {
            tablero = new Tablero();
            patrullero = new Barco(2, "Patrullero", tablero);
            submarino = new Barco(3, "Submarino", tablero);
            destructor = new Barco(4, "Destructor", tablero);
            portaaviones = new Barco(5, "Aviones", tablero);
        }

        /// <summary>
        /// Constructor parametrizado de la clase Jugador. Asigna
        /// el valor del nombre del jugador.
        /// </summary>
        /// <param name="_nombre"></param>
        public Jugador(string _nombre) : this()
        {
            nombre = _nombre;
        }

        // Métodos

        /// <summary>
        /// Permite asignar la orientación y la posición
        /// de los barcos dentro del tablero.
        /// </summary>
        public void NuevaPartida()
        {
            patrullero.NuevoBarco(nombre);
            submarino.NuevoBarco(nombre);
            destructor.NuevoBarco(nombre);
            portaaviones.NuevoBarco(nombre);
        }
    }
}
