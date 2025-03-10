#include <stdio.h>
#include <stdlib.h>
#include <time.h>

#define SIZE 10 // Размер массива

int main() {
    int X[SIZE]; // Массив из 10 элементов
    int count = 0; // Счетчик чисел в диапазоне [25, 50]

    srand(time(NULL));

    printf("Массив X: ");
    for (int i = 0; i < SIZE; i++) {
        X[i] = rand() % 100 + 1;
        printf("%d ", X[i]);

        // Проверяем, входит ли число в диапазон [25, 50]
        if (X[i] >= 25 && X[i] <= 50) {
            count++;
        }
    }
    printf("\n");

    printf("Количество элементов в диапазоне [25, 50]: %d\n", count);
    return 0;
}
