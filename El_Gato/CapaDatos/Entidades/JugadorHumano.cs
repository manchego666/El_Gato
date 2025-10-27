// ------------------------------------------------------------
// Proyecto: TicTacToe (El Gato)
// Autor: ZORRODEV - 2025
// Tarea: TicTacToe o El Gato CPP
// Materia: Programación Dinámica UAS
// Descripción: Juego clásico de 2 jugadores en consola con colores y hora.
// Fecha: 2025-10-26
// Derechos reservados © ZORRODEV - 2025
// ------------------------------------------------------------

using El_Gato.CapaDatos.Entidades.Plantillas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace El_Gato.CapaDatos.Entidades
{
    public class JugadorHumano : JugadorBase
    {
        public JugadorHumano(string nombre, char simbolo) : base(nombre, simbolo) { }

        public override (int fila, int col) Jugar(char[,] tablero)
        {
            // Aquí no decides nada, la UI manda la jugada
            return (-1, -1);
        }
    }
}
