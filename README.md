# Práctica 2 - Hundir la flota

## Descripción del juego

Batalla Naval es un juego de estrategia para dos jugadores desarrollado por la empresa Milton Bradley Company en 1931 para jugar mediante una tabla en papel, pero ha evolucionado hasta convertirse en un juego digital disponible en todas las plataformas.

El juego está formado por un tablero doble por jugador que representa diferentes zonas del océano. El primer tablero representa la visión del jugador donde se encuentran colocados sus barcos y los disparos realizados por el oponente; mientras que el segundo tablero representa los disparos realizados por el jugador, así como los barcos localizados del oponente. Una vez desplegados los mapas, los dos jugadores juegan por turnos realizando disparos hasta que uno de los jugadores hunda todos los barcos del oponente.

## Estructura de la práctica

Crear una aplicación de consola que reproduce el juego de Hundir la Flota en dos modalidades:

1. Jugador humano vs jugador humano.
2. Jugador humano vs jugador automático.

Para el desarrollo de la aplicación se deberá ofrecer una interfaz que ofrezca las siguientes funcionalidades:

- **Cargar partida**: Mostrar las diferentes partidas que han sido guardadas y no han finalizado.

  - El jugador podrá seleccionar una de ellas para continuar jugando.

- **Juego individual**: Nueva partida desde cero (tipo juego de 1 jugador).

- **Juego múltiple**: Nueva partida desde cero (tipo juego de 2 jugadores).

- **Rankings partida**: Mostrar todas las partidas que han finalizado en victoria (al menos de 1 de los jugadores). Mostrar:

  - Nombre jugador.
  - Número de moviemiento.
  - Ganador.

- **Salir**: Finalizar la aplicación de forma ordenada.

## ¿Cómo se juega?

Consite en un conjunto de turnos hasta la derrota de uno de los jugadores o finalización de la partida. Fases de juego:

- **Fase de configuración**: Inicio de la partida.

  - Introducción de los nombres de los jugadores.
  - Localización de los barcos.

  - 1 jugador:

    - Nombre para el jugador automático.
    - Localización barcos de forma aleatoria.

  - Detección de coordenada erronea (pidiendo que la introduzca de nuevo).

![Diagrama de flujo](https://ufv-es.instructure.com/courses/26481/files/3181119/preview)

- **Fase de juego**: Turnos entre los jugadores.

  - Jugadores humanos:
    - Mostrar el mapa dual como ayuda a la selección del disparo a realizar sobre el mapa del oponente.
    - El disparo denerá ser válido (límites del mapa).

- **Fase de finalización**: Fin de la partida.

  - Opciones:

    1. Victoria de un jugador tras hundir el último barco del otro.
    2. Abandono de un jugador previo a la realización de un disparo (Los jugadores deberán poder finalizar la partida antes de realizar su disparo)

  - Guardar info en un fichero de datos:

    1. Victoria para la visualización del ranking.
    2. Abandono para continuar la partida en el futuro.

  - Juego automático: Jugador 2 = Jugador automático.

## Estrucura del mapa

- Mapa modelado con una cuadrícula de tamaño N.

  - Cuadrícula compuesta por casillas:
    - Zonas de tierra (no se pueden colocar barcos).
    - Zonas de océano (se pueden colocar barcos).

- Tipos de barcos (modelados como entidades independientes):
  - Patrullera (2x1 casillas).
  - Submarino (3x1 casillas).
  - Destructor (4x1 casillas).
  - Portaaviones (5x1 casillas).

## Consideraciones

- **Estructura mapas**: A elección del alumno (puede ser estático o generado aleatoriamente).

- **Tamaño mapa**: 12x12.

- **Introducción de datos**: Los datos son correctos (no es necesario comprobar los datos a excepción de las coordenadas y disparos).

- **Coordenadas barcos**: No pueden encontrarse fuera de los límites, sobre una zona de tierra o sobre otro barco.

  - Coordenada incorrecta: Se deberá volver a introducir la coordenada.

- **Ficheros**: Se deben crear 2:

  1. Almacenamiento ranking.
  2. Almacenamiento partidas sin finalizar.

  - Si se incluyen nuevos tipos de ficheros, su estructura y objetivo deberán ser descritos.

## Memoria

- [x] Portada.
- [x] Índice de cotenidos.
- [x] Introducción (descripción resumida del trabajo realizado y nombre miembros).
- [ ] Descripción trabajo:
  - [x] Descripción clases y decisiones de diseño.
  - [x] Incluir un diagrama de clases (incluye todas las clases y las relaciones existentes).
- [x] Problemas encontrados (describir problemas encontrados a lo largo de la práctica).
- [x] Conclusiones (Indicando la valoración del trabajo realizado).

## Normas entrega

- Grupos de 3 personas.
- No se permite la utilización de sistemas de generación de código.
- Documentación en archivo .pdf
- Solución en archivo .zip (.cs, .sln y el .pdf).
- Se valorarán los comentarios en el código.
- Se valorará el código estructuraado y limpio.
- **Obligatorio**:
  - [x] Abstracción.
  - [x] Encapsulación.
  - [x] Herencia.
  - [x] Polimorfismo.
  - [x] Uso de buenas prácticas.
