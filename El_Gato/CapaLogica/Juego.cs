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

namespace El_Gato.CapaLogica
{
    public class Juego
    {
        public JugadorBase Jugador1 { get; }
        public JugadorBase Jugador2 { get; }
        public JugadorBase TurnoActual { get; private set; }
        public Tablero Tablero { get; }

        public Juego(JugadorBase j1, JugadorBase j2)
        {
            Jugador1 = j1;
            Jugador2 = j2;
            Tablero = new Tablero();
            TurnoActual = Jugador1;
        }

        public bool JugarTurno(int fila, int col)
        {
            if (Tablero.EstaVacia(fila, col))
            {
                Tablero.Colocar(fila, col, TurnoActual.Simbolo);
                return true;
            }
            return false;
        }

        public void CambiarTurno()
        {
            TurnoActual = (TurnoActual == Jugador1) ? Jugador2 : Jugador1;
        }

        public void Reiniciar()
        {
            Tablero.Reiniciar();
            TurnoActual = Jugador1;
        }

        public bool HayGanador()
        {
            char[,] c = Tablero.Casillas;
            for (int i = 0; i < 3; i++)
            {
                if (c[i, 0] != ' ' && c[i, 0] == c[i, 1] && c[i, 1] == c[i, 2])
                { TurnoActual.Puntos++; return true; }
                if (c[0, i] != ' ' && c[0, i] == c[1, i] && c[1, i] == c[2, i])
                { TurnoActual.Puntos++; return true; }
            }
            if (c[0, 0] != ' ' && c[0, 0] == c[1, 1] && c[1, 1] == c[2, 2])
            { TurnoActual.Puntos++; return true; }
            if (c[0, 2] != ' ' && c[0, 2] == c[1, 1] && c[1, 1] == c[2, 0])
            { TurnoActual.Puntos++; return true; }

            return false;
        }

        public bool EsEmpate()
        {
            if (HayGanador()) return false;
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    if (Tablero.Casillas[i, j] == ' ')
                        return false;

            Jugador1.Puntos++;
            Jugador2.Puntos++;
            return true;
        }
    }
}