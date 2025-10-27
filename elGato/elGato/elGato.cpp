// ------------------------------------------------------------
// Proyecto: TicTacToe (El Gato)
// Autor: ZORRODEV - 2025
// Tarea: TicTacToe o El Gato CPP
// Materia: Programación Dinámica UAS
// Descripción: Juego clásico de 2 jugadores en consola con colores y hora.
// Fecha: 2025-10-26
// Derechos reservados © ZORRODEV - 2025
// ------------------------------------------------------------
#include <iostream>
#include <array>
#include <string>

using namespace std;

// Tamaño del tablero (3x3)
constexpr int N = 3;

// Tipos y constantes
using Tablero = array<array<char, N>, N>;
constexpr char VACIO = ' ';
constexpr char J1 = 'X';
constexpr char J2 = 'O';

// Inicializa el tablero con espacios vacíos
void inicializar(Tablero& t) {
    for (int i = 0; i < N; ++i)
        for (int j = 0; j < N; ++j)
            t[i][j] = VACIO;
}

// Muestra el tablero con formato
void mostrar(const Tablero& t) {
    cout << "\n   0   1   2\n";
    for (int i = 0; i < N; ++i) {
        cout << " " << i << " ";
        for (int j = 0; j < N; ++j) {
            cout << t[i][j];
            if (j < N - 1) cout << " | ";
        }
        cout << "\n";
        if (i < N - 1) cout << "  -----------\n";
    }
    cout << "\n";
}

// Verifica si una jugada es válida (dentro de rango y celda vacía)
bool jugadaValida(const Tablero& t, int fila, int col) {
    if (fila < 0 || fila >= N || col < 0 || col >= N) return false;
    return t[fila][col] == VACIO;
}

// Aplica la jugada al tablero
void aplicarJugada(Tablero& t, int fila, int col, char jugador) {
    t[fila][col] = jugador;
}

// Verifica si hay un ganador y devuelve el símbolo ganador, o ' ' si no hay
char verificarGanador(const Tablero& t) {
    // Filas
    for (int i = 0; i < N; ++i) {
        if (t[i][0] != VACIO && t[i][0] == t[i][1] && t[i][1] == t[i][2])
            return t[i][0];
    }
    // Columnas
    for (int j = 0; j < N; ++j) {
        if (t[0][j] != VACIO && t[0][j] == t[1][j] && t[1][j] == t[2][j])
            return t[0][j];
    }
    // Diagonal principal
    if (t[0][0] != VACIO && t[0][0] == t[1][1] && t[1][1] == t[2][2])
        return t[0][0];
    // Diagonal secundaria
    if (t[0][2] != VACIO && t[0][2] == t[1][1] && t[1][1] == t[2][0])
        return t[0][2];

    return VACIO;
}

// Verifica si el tablero está lleno (empate)
bool esEmpate(const Tablero& t) {
    for (int i = 0; i < N; ++i)
        for (int j = 0; j < N; ++j)
            if (t[i][j] == VACIO) return false;
    return true;
}

// Alterna el jugador actual
char alternar(char jugador) {
    return (jugador == J1) ? J2 : J1;
}

// Muestra el menú principal y devuelve opción (1 jugar, 2 salir)
int menuPrincipal() {
    cout << "=== Tic Tac Toe ===\n";
    cout << "1. Jugar (2 jugadores)\n";
    cout << "2. Salir\n";
    cout << "Seleccione una opcion: ";
    int op;
    cin >> op;
    return op;
}

// Juego principal de dos jugadores
void jugar() {
    Tablero t;
    inicializar(t);
    char jugador = J1;

    while (true) {
        mostrar(t);
        cout << "Turno de jugador " << jugador << " (fila col): ";
        int fila, col;
        cin >> fila >> col;

        if (!cin) { // manejo básico de entrada inválida
            cin.clear();
            cin.ignore(numeric_limits<streamsize>::max(), '\n');
            cout << "Entrada invalida. Intente de nuevo.\n";
            continue;
        }

        if (!jugadaValida(t, fila, col)) {
            cout << "Jugada invalida. Intente de nuevo.\n";
            continue;
        }

        aplicarJugada(t, fila, col, jugador);

        char ganador = verificarGanador(t);
        if (ganador != VACIO) {
            mostrar(t);
            cout << "Ganador: jugador " << ganador << "!\n";
            break;
        }

        if (esEmpate(t)) {
            mostrar(t);
            cout << "Empate.\n";
            break;
        }

        jugador = alternar(jugador);
    }
}

int main() {
    while (true) {
        int op = menuPrincipal();
        if (op == 1) {
            jugar();
            cout << "\n¿Desea jugar de nuevo? (s/n): ";
            char r;
            cin >> r;
            if (r == 's' || r == 'S') {
                // reinicio implícito: la función jugar crea y reinicia el tablero
                continue;
            }
            else {
                cout << "Fin del juego.\n";
                break;
            }
        }
        else if (op == 2) {
            cout << "Saliendo...\n";
            break;
        }
        else {
            cout << "Opcion invalida.\n";
        }
    }
    return 0;
}