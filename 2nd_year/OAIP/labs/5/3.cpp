#include <iostream>
#include <cstdlib>
#include <ctime>

using namespace std;

double generateRandomNumber() {
    return (rand() % 21) - 10;
}

void reflectMatrix(double** matrix, int rows, int cols) {
    for (int i = 0; i < rows; ++i) {
        for (int j = 0; j < cols / 2; ++j) {
            double temp = matrix[i][j];
            matrix[i][j] = matrix[i][cols - 1 - j];
            matrix[i][cols - 1 - j] = temp;
        }
    }
}

void printMatrix(double** matrix, int rows, int cols) {
    for (int i = 0; i < rows; ++i) {
        for (int j = 0; j < cols; ++j) {
            cout << matrix[i][j] << "\t";
        }
        cout << endl;
    }
}

int main() {
    srand(static_cast<unsigned>(time(0)));

    int rows, cols;

    cout << "Enter the number of rows: ";
    cin >> rows;

    cout << "Enter the number of columns: ";
    cin >> cols;

    double** matrix = new double*[rows];
    for (int i = 0; i < rows; ++i) {
        matrix[i] = new double[cols];
    }

    for (int i = 0; i < rows; ++i) {
        for (int j = 0; j < cols; ++j) {
            matrix[i][j] = generateRandomNumber();
        }
    }

    cout << "\nOriginal Matrix:\n";
    printMatrix(matrix, rows, cols);

    reflectMatrix(matrix, rows, cols);

    cout << "\nReflected Matrix:\n";
    printMatrix(matrix, rows, cols);

    for (int i = 0; i < rows; ++i) {
        delete[] matrix[i];
    }
    delete[] matrix;

    return 0;
}
