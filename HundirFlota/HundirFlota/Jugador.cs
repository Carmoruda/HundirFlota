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
    [Serializable]
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

        /// <summary>
        /// Instancia de la clase Pantalla para controlar la entrada
        /// y salida de datos del usuario.
        /// </summary>
        public Pantalla consola { get; set; }

        /// <summary>
        /// Lista de enteros que representa las coordenadas X
        /// de los lanzamientos.
        /// </summary>
        public List<int> lanzamientoX { get; set; }

        /// <summary>
        /// Lista de enteros que representa las coordenadas Y
        /// de los lanzamientos.
        /// </summary>
        public List<int> lanzamientoY { get; set; }


        // Constructores

        /// <summary>
        /// Constructor vacío de la clase Jugador.
        /// </summary>
        public Jugador() 
        {
            tablero = new Tablero();
            consola = new Pantalla();
            patrullero = new Barco(2, "Patrullero", tablero);
            submarino = new Barco(3, "Submarino", tablero);
            destructor = new Barco(4, "Destructor", tablero);
            portaaviones = new Barco(5, "Aviones", tablero);
            lanzamientoX = new List<int>();
            lanzamientoY = new List<int>();
        }

        /// <summary>
        /// Constructor parametrizado de la clase Jugador. Asigna
        /// el valor del nombre del jugador.
        /// </summary>
        /// <param name="_nombre">
        /// String que representa el nombre del jugador.
        /// </param>
        public Jugador(string _nombre) : this()
        {
            nombre = _nombre;
        }

        /// <summary>
        /// Constructor parametrizado de la clase Jugador. Asigna
        /// el valor de todos los atributos.
        /// </summary>
        /// <param name="_nombre">
        /// String que representa el nombre del jugador.
        /// </param>
        /// <param name="_tablero">
        /// Instancia de la clase Tablero que permite el control
        /// del tablero de la partida.
        /// </param>
        /// <param name="_patrullero">
        /// Instancia de la clase Barco que representa
        /// un navío de tipo patrullero.
        /// </param>
        /// <param name="_submarino">
        /// Instancia de la clase Barco que representa
        /// un navío de tipo submarino.
        /// </param>
        /// <param name="_destructor">
        /// Instancia de la clase Barco que representa
        /// un navío de tipo destructor.
        /// </param>
        /// <param name="_portaaviones">
        /// Instancia de la clase Barco que representa
        /// un navío de tipo portaaviones.
        /// </param>
        /// <param name="_consola">
        /// Instancia de la clase Tablero que permite el control
        /// del tablero de la partida.
        /// </param>
        /// <param name="_lanzamientosX">
        /// Lista de enteros que representa las coordenadas X
        /// de los lanzamientos.
        /// </param>
        /// <param name="_lanzamientosY">
        /// Lista de enteros que representa las coordenadas Y
        /// de los lanzamientos.
        /// </param>
        public Jugador(string _nombre, Tablero _tablero, Barco _patrullero, Barco _submarino, Barco _destructor, Barco _portaaviones, Pantalla _consola, List<int> _lanzamientosX, List<int> _lanzamientosY)
        {
            nombre = _nombre;
            tablero = _tablero;
            patrullero = _patrullero;
            submarino = _submarino;
            destructor = _destructor;
            portaaviones = _portaaviones;
            consola = _consola;
            lanzamientoX = _lanzamientosX;
            lanzamientoY = _lanzamientosY;
        }

        // Métodos

        /// <summary>
        /// Permite asignar la orientación y la posición
        /// de los barcos dentro del tablero, además de 
        /// rellenar el tablero con las casillas iniciales.
        /// </summary>
        /// <param name="modo">
        /// String que representa tipo de modo de juego de la partida.
        /// </param>
        public void NuevaPartida(string modo)
        {
            tablero.RellenarTableroInicial(tablero.mapa, tablero.mapaOponente);
            tablero.RellenarTierra();

            patrullero.NuevoBarco(nombre, modo);
            submarino.NuevoBarco(nombre, modo);
            destructor.NuevoBarco(nombre, modo);
            portaaviones.NuevoBarco(nombre, modo);
        }

       

        /// <summary>
        /// Permite controlar las acciones de atacar del jugador
        /// humano.
        /// </summary>
        public Coordenadas Atacar(string modo)
        {
            string[] opciones = { "\n\t* Coordenada X: ", "\t* Coordenada Y: "};
            Coordenadas coordenadasAtacar = new Coordenadas();
            coordenadasAtacar.ControlIntroducirCoordenadas(1, 1, consola, tablero, opciones, "ATACAR", true, modo, nombre);

            return coordenadasAtacar;
        }

        /// <summary>
        /// Permite controlar el estado de los barcos.
        /// </summary>
        /// <param name="coordenadas">
        /// Instancia de la clase coordenadas que representa las 
        /// coordenadas a las que se ataca.
        /// </param>
        /// <param name="tableroOponente">
        /// Intancia de la clase Tablero que representa el tablero
        /// de ataque del jugador adversario.
        /// </param>
        public void EstadoBarcos(Coordenadas coordenadas, Tablero tableroOponente)
        {
            patrullero.EstadoHundido(lanzamientoX, lanzamientoY, coordenadas, tableroOponente);
            submarino.EstadoHundido(lanzamientoX, lanzamientoY, coordenadas, tableroOponente);
            destructor.EstadoHundido(lanzamientoX, lanzamientoY, coordenadas, tableroOponente);
            portaaviones.EstadoHundido(lanzamientoX, lanzamientoY, coordenadas, tableroOponente);

            lanzamientoX.Add(coordenadas.x[0]); // Añadir a la lista de lanzamientos de ataque las coordenas.
            lanzamientoY.Add(coordenadas.y[0]); // Añadir a la lista de lanzamientos de ataque las coordenas.
        }
    }
}
