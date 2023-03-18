using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace probandomapa
{
    public class Agua : Celda
    {
 
      public override void Dibuja()
        {
            
                //agua
                Console.ForegroundColor = ConsoleColor.Blue;
            if (objeto != null)
            {

                objeto.Dibuja();
            }
            else
            {

            Console.Write("~");
            }
            
            
        }
    }
}