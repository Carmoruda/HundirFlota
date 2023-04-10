using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HundirFlota
{
    internal class JugadorHumano : Jugador
    {

        public JugadorHumano () : base ()
        {

        }

        public JugadorHumano(string _nombre) : base()
        {
            nombre = _nombre;
        }
    }
}
