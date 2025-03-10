#include <stdio.h>

int main() {
    int n;

    printf("Введите число от 1 до 10: ");
    scanf("%d", &n);

    if (n < 1 || n > 10) {
        printf("Ошибка: число должно быть в диапазоне от 1 до 10\n");
        return 1;
    }

    printf("Буквы, коды которых кратны %d:\n", n);

    for (char ch = 'A'; ch <= 'Z'; ch++) {
        if (ch % n == 0) {
            printf("%c (код: %d)\n", ch, ch);
        }
    }

    for (char ch = 'a'; ch <= 'z'; ch++) {
        if (ch % n == 0) {
            printf("%c (код: %d)\n", ch, ch);
        }
    }

    return 0;
}
