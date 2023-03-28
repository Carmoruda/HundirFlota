/// <summary>
/// 
/// La clase Tablero define los atributos necesarios 
/// para el control de los tableros de los jugadores
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
    internal class Tablero
    {
        public int[,] mapa = new int[12, 12];
        public List<int> zonasTierra = new List<int>();
        public Pantalla consola { get; set; }

        public Tablero()
        {
            consola = new Pantalla();
            zonasTierra = new List<int>();
            mapa = new int[12, 12];
        }

        //CONST PARAMETRIZADO??

        //METODOS 

        public void pintar()
        {
            consola.PintarTablero(mapa, 0, 0);

        }
    }
}
