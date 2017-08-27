# Game Space Shooter 

## This game based on Hagamos videojuegos! tutorial on [hagamos videojuegos!](https://youtu.be/tkCupej0j7o?list=PLREdURb87ks3rXXhx2MWERiNTVcG_y_1v)

## Este juego esta basado en Hagamos videojuegos! tutorial en [hagamos videojuegos!](https://youtu.be/tkCupej0j7o?list=PLREdURb87ks3rXXhx2MWERiNTVcG_y_1v)

## This game is based on the Unity3D tutorial [Space Shooter](https://unity3d.com/es/learn/tutorials/projects/space-shooter-tutorial)


# Descripción
Mi idea es desarrollar toda esta serie de tutoriales hasta que tengamos el videojuego acabado, una vez acabado el videojuego, me dispondria a mejorarlo, a quien le apetezca una vez 
acabado ponerse a mejorarlo estare dispuesto a aceptar las posibles mejoras, mientras tanto la idea es ir desarrollando los tutoriales y cuando esten acabados lo pondre todo en la rama
master. 

Cuando el juego este finalizado pienso desarrollar un juego mucho mejor, de codigo libre si acaso lo publicare para Smartphone Android, iOS y ordenadores personales, Windows, Mac OS X y Linux.

Espero que os guste todo el proyecto que voy a ir  realizando con este juego desde que termine los tutoriales hasta que desarrolle un juego completo de naves.

#Description 

My idea is develop every thing serie tutorial, Once the video game is finished, I would be prepared to improve it, whoever wants to do it once
Finished to improve it I will be willing to accept the possible improvements, meanwhile the idea is to develop the tutorials and when they are finished I will put everything in the branch.

When the game is finalized I think I will develop a much better game, free code and maybe I will publish it for android Smartphone, iOS and personal computers, Windows, Mac OS X and Linux.

I hope you like the whole project that I will be doing with this game from the end of the tutorials, I develop videogame complete of ships.

# Notas

## 2. Creando la nave

Un capitulo que simplemente muestra como crear la nave.

## 3. Camara y Luces.

En las propiedades de la camara projection Ortographic para dar un aspecto mas de juego arcade sin pespertivas. 

## 4. Añadiendo el fondo

Explicación de como añadir el fondo a la escena. 

## 5. Moviendo la nave

Añadiendo los scripts para mover la nave por la escena. La velocidad de la nave que se mueve a 1 unidad de movimiento por segundo ahora hay que definir la velocidad. 

## 6. Creando el disparo

Añadiendo el script para que el disparo se instancie y se mueva. Ademas de ponerle la imagen que veremos como disparo. 

## 7. Programando el disparo

Añadiendo el script y ademas terminado de crear el disparo del jugador de la nave. 

## 8. Estableciendo unos limites 

Creando los limites de la escena para todo objeto que se salga de la escena se destruya. 

## 9. Creando un asteroide

Creando un asteroide que vamos a utilizar en nuestro juego.  

## 10. Añadiendo explosiones 

Aqui me he dado cuenta de un error, y es que al objeto Player hay que ponerle la propiedad dentro de Rigidbody en is trigger, para que funcione la colision del objeto contra el asteroide.
Si no, no funcionara y reborara. 

También hay que añadir la explosión del jugador cuando colisiona el asteroide con la nave del jugador. Hay que instanciar los asteroides que los gestionaremos en el siguiente capitulo con el GameController.

## 11. GameController

Aqui hemos creado este objeto GameController para generar los asteorides y gestionar diversos aspectos del videojuego, que se iran viendo conforme se va avanzando en el tutorial, como el marcador.

## 12. Generando asteroides

Aqui generamos los asteorides, y ademas elegimos el tiempo de espera, cuantos asteoides y cada cuanto tiempo apareceran el numero de asteroides como en olas de asteroides.

## 13. Musica y SFX (Efectos de sonido)

Aqui veremos como poner la musica y los efectos de sonido, también como funciona el tema del sonido en Unity3d y programandolo también, según te interese pues asi se hace el añadir sonidos.

## 14. Marcador de puntuación 

Añadiremos puntuacion por cada asteroide que se destruya, el GameController no lo podemos asignar desde la escena a un objeto prefabs ya que el objeto prefabs no existe en toda la escena, solo existe en un momento, 
determinado cuando explota el asteroide o explotanuestra nave. Por tanto no nos dejara nunca asignarselo, lo tendremos que asignar por codigo.

## 15. Gamer Over 

Aparece Game Over y tambien configuramos la tecla R en el metodo GameController.Update() para poder reiniciar la partida en realidad estamos reiniciando la escena. 

## 16. Joystick virtual 

Creamos un Joystick virtual en la pantalla con un boton para jugar a nuestro juego en Smartphone.

 
## 17. Arreglando problemas 

Arreglando ciertos problemas de por donde aparecen los asteroides, y la relacion de aspecto y resoluciones para poder jugar con otras relaciones de aspecto.

## 18. Nuevos asteorides 

Hemos añadido asteroides de distintas clases usando el mismo GameObject solamente cambiando la imagen y hemos hecho que funcione, perfectamente la aparoicion aleatoria de los asteroides.

## 19. Scroll Parallax

Hemos añadido el efecto scroll parallax en el fondo con estrellas usando sistema de particulas.

## 20. Nave enemiga 

Creación de la nave enemiga. 

## 21. Disparo enemigo 

Creación del disparo enemigo, 

## 22. Maniobras evasivas 

Creación de algunas maniobras evasivas. 

Hasta aquí son todos los capitulos desarrollados en el tutorial citado arriba. 

Mi idea es desarrollar a partir de aqui un videojuego con le motor Unity3D mejorando este juego hasta que se pueda decir que tenga la calidad de un juego comercial, como por ejemplo el mitico 1942, o algunos videojuegos de naves de la epoca, todavia se siguen desarrollando videojuegos de naves, asi que si os animais a ayudarme en esta ardua tarea, se agradece. 

Eso si creare otra rama que sera como una rama de desarrollo para no tocar la master y hasta que en la rama de desarrollo no funcione las nuevas funcionaliades añadidas del videojuego no se pondran en la rama master. 

Lo mismo creo otra rama testing una vez desarrolladas las caracteristicas se prueban en la testing pero bueno ya veriamos.

## Versiones Space Shooter

Version 0.1 Alpha SpaceShooter esta seria versión en la que se encuentra el juego. Esta ahora mismo tal cual terminado el tutorial. 


