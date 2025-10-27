// ------------------------------------------------------------
// Proyecto: TicTacToe (El Gato)
// Autor: ZORRODEV - 2025
// Tarea: TicTacToe o El Gato CPP
// Materia: Programaci�n Din�mica UAS
// Descripci�n: Juego cl�sico de 2 jugadores en consola con colores y hora.
// Fecha: 2025-10-26
// Derechos reservados � ZORRODEV - 2025
// ------------------------------------------------------------

using El_Gato.CapaDatos.Entidades;
using El_Gato.CapaVisual;
using System.Media;

namespace El_Gato
{
    public partial class frmInicio : Form
    {
        private SoundPlayer musicaFondo;
        public frmInicio()
        {
            InitializeComponent();
            musicaFondo = new SoundPlayer(Properties.Resources.DiaLluvioso);
            musicaFondo.PlayLooping(); // se repite sin parar
        }
        //=========================== Eventos de los botones ===========================
        private void btnJugarCPP_Click(object sender, EventArgs e) // Bot�n para jugar la versi�n en C++
        {
            try
            {
                System.Diagnostics.Process.Start("elGato.exe");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al iniciar el juego en C++: " + ex.Message);
            }
        }
        private void btnJugarBot_Click(object sender, EventArgs e) // Bot�n para jugar contra el Bot en c#
        {
            // Crear jugadores
            var jugador = new JugadorHumano("Jugador", 'X');
            var bot = new Bot("Bot", 'O');

            // Crear la partida visual
            frmJugar jugar = new frmJugar(jugador, bot);

            // Ocultar frmInicio mientras se juega
            this.Hide();
            jugar.ShowDialog();
            this.Show();


        }
        private void btnJugarOnline_Click(object sender, EventArgs e) // Bot�n para jugar en l�nea
        {
            MessageBox.Show("Modo Online en desarrollo...");
        }

        private void btnSource_Click(object sender, EventArgs e) // Bot�n para abrir el repositorio de GitHub
        {
            System.Diagnostics.Process.Start("https://github.com/manchego666");
        }

        private void btnSalir_Click(object sender, EventArgs e) // Bot�n para salir de la aplicaci�n
        {
            Application.Exit();
            musicaFondo.Stop();
            Application.Exit();
        }

    }
}
