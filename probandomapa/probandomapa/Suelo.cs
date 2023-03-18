using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace probandomapa
{
    public class Suelo : Celda
    {
     
        public override void Dibuja()
        {

            Console.ForegroundColor = ConsoleColor.White;
            if (objeto != null)
            {

                objeto.Dibuja();
            }
            else
            {
                Console.Write(".");

            }
          
        }
        
    }
}