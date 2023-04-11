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

        public List<int> lanzamientoX = new List<int>();
        public List<int> lanzamientoY = new List<int>();
        public Random r = new Random();

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

        /// <summary>
        /// Constructor parametrizado de la clase Jugador.
        /// </summary>
        /// <param name="_nombre"></param>
        /// <param name="_tablero"></param>
        /// <param name="_patrullero"></param>
        /// <param name="_submarino"></param>
        /// <param name="_destructor"></param>
        /// <param name="_portaaviones"></param>
        public Jugador(string _nombre, Tablero _tablero, Barco _patrullero, Barco _submarino, Barco _destructor, Barco _portaaviones)
        {
            nombre = _nombre;
            tablero = _tablero;
            patrullero = _patrullero;
            submarino = _submarino;
            destructor = _destructor;
            portaaviones = _portaaviones;
        }

        // Métodos

        /// <summary>
        /// Permite asignar la orientación y la posición
        /// de los barcos dentro del tablero, además de 
        /// rellenar el tablero con las casillas iniciales.
        /// </summary>
        public void NuevaPartida()
        {
            tablero.RellenarTableroInicial(tablero.mapa, tablero.mapaOponente);
            tablero.RellenarTierra();

            patrullero.NuevoBarco(nombre);
            submarino.NuevoBarco(nombre);
            destructor.NuevoBarco(nombre);
            portaaviones.NuevoBarco(nombre);
        }

        public void Automático()
        {
            bool libre = false;
            int posX = 0;
            int posY = 0;
            do
            {
                posX = r.Next(1, 12);
                posY = r.Next(1, 12);

                Coordenadas coordenada = new Coordenadas();

                coordenada.x[0] = coordenada.x[1] = posX;
                coordenada.y[0] = coordenada.y[1] = posY;

                libre = tablero.BuscarTierra(coordenada);

                for (int i = 0; i< lanzamientoX.Count; i++)
                {
                    if (posX == lanzamientoX[i] && posY == lanzamientoY[i])
                    {
                        libre = true;
                    }
                }
            } while (libre);

            lanzamientoX.Add(posX);
            lanzamientoY.Add(posY);

        }

        public void Atacar(Coordenadas coordenada)
        {

        }
    }
}
