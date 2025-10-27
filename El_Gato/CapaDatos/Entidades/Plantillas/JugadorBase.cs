// ------------------------------------------------------------
// Proyecto: TicTacToe (El Gato)
// Autor: ZORRODEV - 2025
// Tarea: TicTacToe o El Gato CPP
// Materia: Programación Dinámica UAS
// Descripción: Juego clásico de 2 jugadores en consola con colores y hora.
// Fecha: 2025-10-26
// Derechos reservados © ZORRODEV - 2025
// ------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace El_Gato.CapaDatos.Entidades.Plantillas
{
    public abstract class JugadorBase
    {
        public string Nombre { get; set; }
        public char Simbolo { get; set; }
        public int Puntos { get; set; }

        public JugadorBase(string nombre, char simbolo)
        {
            Nombre = nombre;
            Simbolo = simbolo;
            Puntos = 0;
        }

        public abstract (int fila, int col) Jugar(char[,] tablero);
    }
}