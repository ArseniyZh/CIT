#include <stdio.h>
#include <stdlib.h>
#include <time.h>

#define SIZE 5

// Функция для сортировки строки (метод пузырька)
void sort_row(int arr[], int n) {
    for (int i = 0; i < n - 1; i++) {
        for (int j = 0; j < n - i - 1; j++) {
            if (arr[j] > arr[j + 1]) {
                // Обмен элементов
                int temp = arr[j];
                arr[j] = arr[j + 1];
                arr[j + 1] = temp;
            }
        }
    }
}

int main() {
    int A[SIZE][SIZE];

    srand(time(NULL));

    // Заполняем массив случайными числами от 1 до 50
    printf("Исходный массив:\n");
    for (int i = 0; i < SIZE; i++) {
        for (int j = 0; j < SIZE; j++) {
            A[i][j] = rand() % 50 + 1;
            printf("%4d ", A[i][j]);
        }
        printf("\n");
    }

    // Сортируем каждую строку массива
    for (int i = 0; i < SIZE; i++) {
        sort_row(A[i], SIZE);
    }

    // Вывод отсортированного массива
    printf("\nОтсортированный массив:\n");
    for (int i = 0; i < SIZE; i++) {
        for (int j = 0; j < SIZE; j++) {
            printf("%4d ", A[i][j]);
        }
        printf("\n");
    }

    return 0;
}
