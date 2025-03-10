#include <stdio.h>
#include <stdlib.h>
#include <time.h>

void fill_array(int *arr, int n) {
    for (int i = 0; i < n; i++) {
        arr[i] = rand() % 100;
    }
}

void double_even_indices(int *arr, int n) {
    for (int i = 0; i < n; i += 2) {
        arr[i] *= 2;
    }
}

void print_array(int *arr, int n) {
    for (int i = 0; i < n; i++) {
        printf("%d ", arr[i]);
    }
    printf("\n");
}

int main() {
    srand(time(NULL));

    int n;
    printf("Введите размер массива: ");
    scanf("%d", &n);

    int *arr = (int *)malloc(n * sizeof(int));
    if (arr == NULL) {
        printf("Ошибка выделения памяти\n");
        return 1;
    }

    fill_array(arr, n);
    
    printf("Исходный массив: ");
    print_array(arr, n);

    double_even_indices(arr, n);

    printf("Измененный массив: ");
    print_array(arr, n);

    free(arr);
    return 0;
}
