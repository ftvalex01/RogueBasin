using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace probandomapa
{
    public class Muro : Celda
    {
       
        public override void Dibuja()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            if (objeto != null)
            {

                objeto.Dibuja();
            }
            else
            {

            Console.Write("▦");
            }

            
        }

    }
}