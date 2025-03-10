#include <stdio.h>
#include <stdlib.h>
#include <time.h>

void fill_array(int *arr, int n) {
    for (int i = 0; i < n; i++) {
        arr[i] = rand() % 100;
    }
}


int count_unique(int *arr, int n) {
    int unique_count = 0;

    for (int i = 0; i < n; i++) {
        int is_unique = 1;
        for (int j = 0; j < i; j++) {
            if (arr[i] == arr[j]) {
                is_unique = 0;
                break;
            }
        }
        if (is_unique) {
            unique_count++;
        }
    }
    
    return unique_count;
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

    int unique_count = count_unique(arr, n);
    printf("Количество уникальных значений: %d\n", unique_count);

    free(arr);
    return 0;
}
