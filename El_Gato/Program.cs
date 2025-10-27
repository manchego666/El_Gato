// ------------------------------------------------------------
// Proyecto: TicTacToe (El Gato)
// Autor: ZORRODEV - 2025
// Tarea: TicTacToe o El Gato CPP
// Materia: Programaci�n Din�mica UAS
// Descripci�n: Juego cl�sico de 2 jugadores en consola con colores y hora.
// Fecha: 2025-10-26
// Derechos reservados � ZORRODEV - 2025
// ------------------------------------------------------------

namespace El_Gato
{
    internal static class Program
    {
        /// <summary>
        ///  es la clase principal de la aplicaci�n.
        ///  sirve como punto de entrada para iniciar la aplicaci�n.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new frmInicio());
        }
    }
}