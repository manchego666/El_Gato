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

namespace El_Gato.CapaLogica
{
    public class Tablero
    {
        public char[,] Casillas { get; private set; }

        public Tablero()
        {
            Casillas = new char[3, 3];
            Reiniciar();
        }

        public void Reiniciar()
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    Casillas[i, j] = ' ';
        }

        public bool EstaVacia(int fila, int col) => Casillas[fila, col] == ' ';
        public void Colocar(int fila, int col, char simbolo) => Casillas[fila, col] = simbolo;
    }
}