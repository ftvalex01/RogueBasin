using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace probandomapa
{
    public class Salida : Celda
    {


        public override void Dibuja()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            if (objeto != null)
            {

                objeto.Dibuja();
            }
            else
            {

            Console.Write('╬');
            }
          
        }
    }
}