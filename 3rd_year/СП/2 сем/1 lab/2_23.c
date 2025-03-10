#include <stdio.h>

int main() {
    int n;

    // Ввод n (количество чисел)
    printf("Введите количество чисел: ");
    scanf("%d", &n);

    // Проверяем, что n > 1 (иначе нет смысла проверять последовательность)
    if (n < 2) {
        printf("Последовательность должна содержать хотя бы 2 числа.\n");
        return 1;
    }

    int prev, current;
    int is_increasing = 1; // Флаг: 1 - возрастающая, 0 - нет

    printf("Введите число 1: ");
    scanf("%d", &prev);

    for (int i = 2; i <= n; i++) {
        printf("Введите число %d: ", i);
        scanf("%d", &current);

        if (current <= prev) {
            is_increasing = 0;
        }

        prev = current;
    }

    if (is_increasing) {
        printf("Последовательность является строго возрастающей.\n");
    } else {
        printf("Последовательность не является строго возрастающей.\n");
    }

    return 0;
}
