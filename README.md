# RogueBasin

Juego creado en C#

El jugador (el emoji azul) tiene que recoger las 20 monedas del castillo de Frank

Funcionamiento del juego

Portada / Menú de inicio

-----------------------------------------------

Para la portada del juego he hecho que lea un archivo de texto que contiene un poco
la introducción al juego y las instrucciones de manejo del juego.

-----------------------------------------------

Movimiento del jugador (direcciones, obstáculos, etc..)

El manejo del juego será con las Flechas de dirección, no hay obstáculos ni
mecánicas que no sea moverte.

-----------------------------------------------

Generación del mapa: Algoritmos utilizados

Para generar el mapa se ha usado la función RandomWalk() , esta función genera un
array multidimensional con objetos de la clase muro en todas sus posiciones , el
algoritmo recorre de manera aleatoria a partir de un punto en x y en 4 direcciones y
si la casilla esta dentro de los limites la convierte en suelo y vuelve al punto central y
repite la operación.

-----------------------------------------------

Descripción de la Interfaz del juego
La interfaz del juego es a la izquierda la pantalla donde jugamos y a la derecha un
pequeño menú con tu vida , tus monedas .

-----------------------------------------------

Condiciones de inicio / fin de partida

Iniciamos el proyecto y nos saldrá una introducción , le tendremos que dar a alguna
tecla para poder iniciar la partida
Para que se produzca el final de partida tendremos que coger 20 monedas , o que
nos mate Frank o que muramos por el veneno

-----------------------------------------------

Enemigos / combates (si los hay)

Enemigos si Frank que cuando cogemos mas de 10 monedas aparece otro Frank mas

-----------------------------------------------

Objetos/ítems (si los hay)

Tenemos en el mapa vida , que podemos coger para aumentar nuestra vida en 1
Tenemos veneno que si lo cogemos nos resta 1 en la vida
Tenemos monedas que hay que recoger

-----------------------------------------------

PD: puede que tenga algunos bugs que se iran fixeando :)
