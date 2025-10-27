// ------------------------------------------------------------
// Proyecto: TicTacToe (El Gato)
// Autor: ZORRODEV - 2025
// Tarea: TicTacToe o El Gato CPP
// Materia: Programación Dinámica UAS
// Descripción: Juego clásico de 2 jugadores en consola con colores y hora.
// Fecha: 2025-10-26
// Derechos reservados © ZORRODEV - 2025
// ------------------------------------------------------------

using El_Gato.CapaDatos.Entidades;
using El_Gato.CapaLogica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace El_Gato.CapaVisual
{
    public partial class frmJugar : Form
    {
        private Juego partida;
        private JugadorHumano jugador;
        private Bot bot;

        private int tiempoRestante = 10;

        public frmJugar(JugadorHumano j, Bot b)
        {
            InitializeComponent();
            jugador = j ?? throw new ArgumentNullException(nameof(j));
            bot = b ?? throw new ArgumentNullException(nameof(b));
            partida = new Juego(jugador, bot);
        }

        private void frmJugar_Load(object sender, EventArgs e)
        {
            foreach (Control c in tlpGato.Controls)
            {
                if (c is Button btn)
                {
                    string name = btn.Name.Replace("btn", ""); // ej. "00"
                    int fila = int.Parse(name[0].ToString());
                    int col = int.Parse(name[1].ToString());

                    btn.Tag = (fila, col);
                    btn.Text = "";
                    btn.Click += Casilla_Click;
                }
            }
            IniciarTurno();
            ActualizarMarcadores();
        }

        public frmJugar()
        {
            InitializeComponent();
        }



        private void btnSalir_Click(object sender, EventArgs e)
        {
            // Cierra este formulario
            this.Close();
            // Vuelve a mostrar el frmInicio
            frmInicio inicio = new frmInicio();
            inicio.Show();
        }


        // ==================== TIMER ====================
        private void IniciarTurno()
        {
            tiempoRestante = 10;
            lblTiempo.Text = $"Tiempo: {tiempoRestante}";
            timerTurno.Start();
        }

        private void timerTurno_Tick(object sender, EventArgs e)
        {
            tiempoRestante--;
            lblTiempo.Text = $"Tiempo: {tiempoRestante}";

            if (tiempoRestante <= 0)
            {
                timerTurno.Stop();

                if (partida.TurnoActual is JugadorHumano)
                {
                    // Jugada automática si el humano no jugó
                    var jugadaAuto = BuscarPrimeraLibre();
                    if (jugadaAuto != (-1, -1))
                    {
                        partida.JugarTurno(jugadaAuto.Item1, jugadaAuto.Item2);
                        string nombreBoton = $"btn{jugadaAuto.Item1}{jugadaAuto.Item2}";
                        (tlpGato.Controls[nombreBoton] as Button).Text = partida.TurnoActual.Simbolo.ToString();
                    }
                }

                if (VerificarFin()) return;

                partida.CambiarTurno();

                if (partida.TurnoActual is Bot)
                    JuegaBot();
                else
                    IniciarTurno();
            }
        }

        private (int, int) BuscarPrimeraLibre()
        {
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    if (partida.Tablero.Casillas[i, j] == ' ')
                        return (i, j);
            return (-1, -1);
        }

        // ==================== JUGADAS ====================
        private void Casilla_Click(object sender, EventArgs e)
        {
            if (sender is not Button btn || btn.Tag is not ValueTuple<int, int> pos) return;
            var (fila, col) = pos;

            if (!partida.JugarTurno(fila, col)) return;

            btn.Text = partida.TurnoActual.Simbolo.ToString();
            timerTurno.Stop();

            if (VerificarFin()) return;

            partida.CambiarTurno();
            JuegaBot();
        }

        private void JuegaBot()
        {
            var jugadaBot = bot.Jugar(partida.Tablero.Casillas);
            if (jugadaBot.fila != -1)
            {
                partida.JugarTurno(jugadaBot.fila, jugadaBot.col);
                string nombreBoton = $"btn{jugadaBot.fila}{jugadaBot.col}";
                (tlpGato.Controls[nombreBoton] as Button).Text = partida.TurnoActual.Simbolo.ToString();

                if (VerificarFin()) return;

                partida.CambiarTurno();
                IniciarTurno();
            }
        }

        // ==================== UTILIDADES ====================
        private bool VerificarFin()
        {
            if (partida.HayGanador())
            {
                MessageBox.Show($"Ganó {partida.TurnoActual.Nombre}");
                ActualizarMarcadores();
                ReiniciarTablero();
                return true;
            }
            else if (partida.EsEmpate())
            {
                MessageBox.Show("¡Empate!");
                ActualizarMarcadores();
                ReiniciarTablero();
                return true;
            }
            return false;
        }

        private void ReiniciarTablero()
        {
            partida.Reiniciar();
            foreach (Control c in tlpGato.Controls)
                if (c is Button btn) btn.Text = "";
            IniciarTurno();
        }

        private void ActualizarMarcadores()
        {
            lblJugador.Text = $"Jugador: {partida.Jugador1.Puntos}";
            lblBot.Text = $"Bot: {partida.Jugador2.Puntos}";
        }
    }
}

