#include <stdio.h>
#include <stdlib.h>
#include <time.h>

#define SIZE 30 // Размер массива

// Функция сравнения для qsort
int compare(const void *a, const void *b) {
    return (*(int *)a - *(int *)b);
}

int main() {
    int A[SIZE];
    int has_duplicates = 0;

    srand(time(NULL));

    printf("Массив A: ");
    for (int i = 0; i < SIZE; i++) {
        A[i] = rand() % 100 + 1;
        printf("%d ", A[i]);
    }
    printf("\n");

    // Сортируем массив
    qsort(A, SIZE, sizeof(int), compare);

    // Проверяем на повторы
    for (int i = 0; i < SIZE - 1; i++) {
        if (A[i] == A[i + 1]) {
            has_duplicates = 1;
            break;
        }
    }

    if (has_duplicates) {
        printf("В массиве есть повторяющиеся элементы.\n");
    } else {
        printf("В массиве нет повторяющихся элементов.\n");
    }

    return 0;
}
