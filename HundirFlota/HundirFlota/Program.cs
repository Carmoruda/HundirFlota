using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HundirFlota
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Juego miJuego = new Juego();
            //Tablero tablero = new Tablero(); //nome lo borreis :)
            //tablero.Pintar();
            //Console.ReadKey();
            miJuego.Menu();
        }
    }
}
