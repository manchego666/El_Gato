// ------------------------------------------------------------
// Proyecto: TicTacToe (El Gato)
// Autor: ZORRODEV - 2025
// Tarea: TicTacToe o El Gato CPP
// Materia: Programación Dinámica UAS
// Descripción: Juego clásico de 2 jugadores en consola con colores, hora y modo vs CPU.
// Fecha: 2025-10-27
// Derechos reservados © ZORRODEV - 2025
// ------------------------------------------------------------
#include <iostream>
#include <array>
#include <string>
#include <chrono>
#include <ctime>
#include <limits>

using namespace std;

// Tamaño del tablero
constexpr int N = 3;

// ANSI colores
#define RESET   "\033[0m"
#define RED     "\033[31m"
#define GREEN   "\033[32m"
#define YELLOW  "\033[33m"
#define CYAN    "\033[36m"

// Tipos y constantes
using Tablero = array<array<char, N>, N>;
constexpr char VACIO = ' ';
constexpr char J1 = 'X';
constexpr char J2 = 'O';

// Inicializa el tablero
void inicializar(Tablero& t) {
    for (int i = 0; i < N; ++i)
        for (int j = 0; j < N; ++j)
            t[i][j] = VACIO;
}

// Muestra el tablero
void mostrar(const Tablero& t) {
    cout << "\n   0   1   2\n";
    for (int i = 0; i < N; ++i) {
        cout << " " << i << " ";
        for (int j = 0; j < N; ++j) {
            if (t[i][j] == J1)
                cout << RED << t[i][j] << RESET;
            else if (t[i][j] == J2)
                cout << GREEN << t[i][j] << RESET;
            else
                cout << t[i][j];
            if (j < N - 1) cout << " | ";
        }
        cout << "\n";
        if (i < N - 1) cout << "  -----------\n";
    }
    cout << "\n";
}

// Hora actual (versión segura con ctime_s)
void mostrarHoraActual() {
    auto ahora = chrono::system_clock::now();
    time_t tiempo = chrono::system_clock::to_time_t(ahora);
    char buffer[26]; // tamaño estándar para ctime_s
    ctime_s(buffer, sizeof(buffer), &tiempo);
    cout << CYAN << "Hora actual: " << buffer << RESET;
}

// Validación de jugada
bool jugadaValida(const Tablero& t, int fila, int col) {
    if (fila < 0 || fila >= N || col < 0 || col >= N) return false;
    return t[fila][col] == VACIO;
}

// Aplicar jugada
void aplicarJugada(Tablero& t, int fila, int col, char jugador) {
    t[fila][col] = jugador;
}

// Verificar ganador
char verificarGanador(const Tablero& t) {
    for (int i = 0; i < N; ++i)
        if (t[i][0] != VACIO && t[i][0] == t[i][1] && t[i][1] == t[i][2])
            return t[i][0];
    for (int j = 0; j < N; ++j)
        if (t[0][j] != VACIO && t[0][j] == t[1][j] && t[1][j] == t[2][j])
            return t[0][j];
    if (t[0][0] != VACIO && t[0][0] == t[1][1] && t[1][1] == t[2][2])
        return t[0][0];
    if (t[0][2] != VACIO && t[0][2] == t[1][1] && t[1][1] == t[2][0])
        return t[0][2];
    return VACIO;
}

// Verificar empate
bool esEmpate(const Tablero& t) {
    for (int i = 0; i < N; ++i)
        for (int j = 0; j < N; ++j)
            if (t[i][j] == VACIO) return false;
    return true;
}

// Alternar jugador
char alternar(char jugador) {
    return (jugador == J1) ? J2 : J1;
}

// Menú principal
int menuPrincipal() {
    cout << CYAN << "=== Tic Tac Toe ===" << RESET << "\n";
    cout << "1. Jugar (2 jugadores)\n";
    cout << "2. Jugar vs CPU\n";
    cout << "3. Salir\n";
    cout << "Seleccione una opcion: ";
    int op;
    cin >> op;
    return op;
}

// Juego 2 jugadores
void jugar() {
    Tablero t;
    inicializar(t);
    char jugador = J1;

    while (true) {
        mostrar(t);
        cout << "Turno de jugador " << jugador << " (fila col): ";
        int fila, col;
        cin >> fila >> col;

        if (!cin) {
            cin.clear();
            cin.ignore(numeric_limits<streamsize>::max(), '\n');
            cout << YELLOW << "Entrada invalida. Intente de nuevo.\n" << RESET;
            continue;
        }

        if (!jugadaValida(t, fila, col)) {
            cout << YELLOW << "Jugada invalida. Intente de nuevo.\n" << RESET;
            continue;
        }

        aplicarJugada(t, fila, col, jugador);

        char ganador = verificarGanador(t);
        if (ganador != VACIO) {
            mostrar(t);
            cout << GREEN << "Ganador: jugador " << ganador << "!\n" << RESET;
            break;
        }

        if (esEmpate(t)) {
            mostrar(t);
            cout << YELLOW << "Empate.\n" << RESET;
            break;
        }

        jugador = alternar(jugador);
    }
}

// Juego vs CPU
void jugarVsCPU() {
    Tablero t;
    inicializar(t);
    char jugador = J1;

    while (true) {
        mostrar(t);
        if (jugador == J1) {
            cout << "Tu turno (fila col): ";
            int fila, col;
            cin >> fila >> col;

            if (!cin) {
                cin.clear();
                cin.ignore(numeric_limits<streamsize>::max(), '\n');
                cout << YELLOW << "Entrada invalida.\n" << RESET;
                continue;
            }

            if (!jugadaValida(t, fila, col)) {
                cout << YELLOW << "Jugada invalida.\n" << RESET;
                continue;
            }

            aplicarJugada(t, fila, col, jugador);
        }
        else {
            // CPU: primera celda vacía
            for (int i = 0; i < N; ++i) {
                for (int j = 0; j < N; ++j) {
                    if (t[i][j] == VACIO) {
                        aplicarJugada(t, i, j, jugador);
                        cout << "CPU juega en (" << i << ", " << j << ")\n";
                        goto hecho;
                    }
                }
            }
        hecho:;
        }

        char ganador = verificarGanador(t);
        if (ganador != VACIO) {
            mostrar(t);
            cout << GREEN << "Ganador: jugador " << ganador << "!\n" << RESET;
            break;
        }

        if (esEmpate(t)) {
            mostrar(t);
            cout << YELLOW << "Empate.\n" << RESET;
            break;
        }

        jugador = alternar(jugador);
    }
}

// Main
int main() {
    while (true) {
        mostrarHoraActual();
        int op = menuPrincipal();
        if (op == 1) {
            jugar();
        }
        else if (op == 2) {
            jugarVsCPU();
        }
        else if (op == 3) {
            cout << "Saliendo...\n";
            break;
        }
        else {
            cout << YELLOW << "Opcion invalida.\n" << RESET;
        }

        cout << "\n¿Desea jugar de nuevo? (s/n): ";
        char r;
        cin >> r;
        if (r == 's' || r == 'S') continue;
        else {
            cout << "Fin del juego.\n";
            break;
        }
    }
    return 0;
}