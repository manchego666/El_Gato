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
    public class Bot : JugadorBase
    {
        private Random rnd = new Random();

        public Bot(string nombre, char simbolo) : base(nombre, simbolo) { }

        public override (int fila, int col) Jugar(char[,] tablero)
        {
            // Lógica automática del bot
            List<(int, int)> vacias = new();
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    if (tablero[i, j] == ' ')
                        vacias.Add((i, j));

            return vacias.Count > 0 ? vacias[rnd.Next(vacias.Count)] : (-1, -1);
        }
    }
}   