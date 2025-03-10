#include <stdio.h>

int main() {
    int x;

    printf("Введите количество баллов: ");
    scanf("%d", &x);

    if (x < 51) {
        printf("Оценка: 2\n");
    } else if (x <= 70) {
        printf("Оценка: 3\n");
    } else if (x <= 85) {
        printf("Оценка: 4\n");
    } else if (x <= 100) {
        printf("Оценка: 5\n");
    } else {
        printf("Ошибка: баллы должны быть в диапазоне 0-100\n");
    }

    return 0;
}
