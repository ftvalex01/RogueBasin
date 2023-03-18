using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;

namespace probandomapa
{
    public class Mapa
    {
        public Celda[,] tablero;
        public Random rng;
       
        public int totalMonedas;


        public (int, int) ObtenerPosicionJugador()
        {
            for (int i = 0; i < tablero.GetLength(0); i++)
            {
                for (int j = 0; j < tablero.GetLength(1); j++)
                {
                    if (tablero[i, j].objeto is Jugador)
                    {
                        return (i, j);
                    }
                }
            }
            return (-1, -1); // retorna (-1,-1) si no se encuentra al jugador en el mapa
        }


        public Mapa(int ancho, int alto)
        {
            rng = new Random();
            tablero = new Celda[ancho, alto];
            RandomWalk();
            ColocaComida(1);
            ColocaVeneno(3);
            ColocaMonedasAleatorias(8);
            Salida();

        }


        public void Salida()
        {
            int x, y;
            do
            {
                x = rng.Next(tablero.GetLength(0));
                y = rng.Next(tablero.GetLength(1));
            } while (tablero[x, y] is Muro ||
                     tablero[x, y].objeto is not null ||
                     tablero[x, y].objeto is Veneno ||
                     tablero[x, y].objeto is Comida ||
                     tablero[x, y].objeto is Moneda);
            tablero[x, y] = new Salida();
        }
        public void ColocaComida(int cantidad)
        {

            int x, y;
            for (int i = 0; i < cantidad; i++)
            {
                do
                {
                    x = rng.Next(tablero.GetLength(0));
                    y = rng.Next(tablero.GetLength(1));
                } while (tablero[x, y] is Muro ||
                        tablero[x, y].objeto is not null ||
                        tablero[x, y] is Salida ||
                        tablero[x, y].objeto is Veneno ||
                        tablero[x, y].objeto is Moneda);
                tablero[x, y].objeto = new Comida();
            }
        }
        public void ColocaVeneno(int cantidad)
        {

            int x, y;
            for (int i = 0; i < cantidad; i++)
            {
                do
                {
                    x = rng.Next(tablero.GetLength(0));
                    y = rng.Next(tablero.GetLength(1));
                } while (tablero[x, y] is Muro ||
                        tablero[x, y].objeto is not null ||
                        tablero[x, y] is Salida ||
                        tablero[x, y].objeto is Comida ||
                        tablero[x, y].objeto is Moneda);

                tablero[x, y].objeto = new Veneno();
            }
        }
        public void ColocaMonedasAleatorias(int cantidad)
        {
           
                int x, y;
            for (int i = 0; i < cantidad; i++)
            {
                do
                {
                    x = rng.Next(tablero.GetLength(0));
                    y = rng.Next(tablero.GetLength(1));
                } while (tablero[x, y] is Muro ||
                        tablero[x, y].objeto is not null ||
                        tablero[x, y] is Salida ||
                        tablero[x, y].objeto is Comida ||
                        tablero[x, y].objeto is Veneno);

                Moneda moneda = new Moneda();
                tablero[x, y].objeto = moneda;
               
                totalMonedas++;
            }
        }
        public void RandomWalk()
        {
            /*initialize all map cells to walls.*/
           
          
            for (int i = 0; i < tablero.GetLength(0); i++)
            {
                for (int j = 0; j < tablero.GetLength(1); j++)
                {
                    tablero[i, j] = new Muro();
                   
                }
            }
            int x = tablero.GetLength(0) / 2;
            int y = tablero.GetLength(1) / 2; 
            tablero[x, y] = new Suelo();
            
            int cantidad = (int)(tablero.GetLength(0) * tablero.GetLength(1) * 1);
            int contador = 0;
            int[,] dirs = { { 0, -1 }, { 1, 0 }, { 0, 1 }, { -1, 0 } };

            Random rng = new Random(); 
            while(contador < cantidad)
            {
                int dir = rng.Next(4);
                int newX = x + dirs[dir, 0];
                int newY = y + dirs[dir, 1];
                
                if(newX>=0 && newY>=0 && newX<tablero.GetLength(0) && newY < tablero.GetLength(1))
                {
                    x = newX;
                    y = newY;

                    if (tablero[x,y] is Muro)
                    {
                        tablero[x, y] = new Suelo();
                    }
                }
                else
                {
                    x = tablero.GetLength(0) / 2;
                    y = tablero.GetLength(1) / 2;
                }
                contador++;
            }
        }
       
  
        
        public void Dibuja()
        {
            for (int i = 0; i < tablero.GetLength(0); i++)
            {
                for (int j = 0; j < tablero.GetLength(1); j++)
                {
                    Console.SetCursorPosition(i,j);
                   
                    tablero[i, j].Dibuja();
                }
            }
        }
    }
}






