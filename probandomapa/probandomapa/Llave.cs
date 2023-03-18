using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace probandomapa
{

    public class Llave : IItem
    {
        public void Dibuja()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("K");
        }

        public void Recoge()
        {
            // Aquí iría el código para recoger la llave y salir del mapa
        }
    }
}
