#include <stdio.h>

int max_of_four(int a, int b, int c, int d) {
    int max = a;

    if (b > max) {
        max = b;
    }
    if (c > max) {
        max = c;
    }
    if (d > max) {
        max = d;
    }

    return max;
}

int main() {
    int a, b, c, d;

    printf("Введите четыре целых числа: ");
    scanf("%d %d %d %d", &a, &b, &c, &d);

    int max_value = max_of_four(a, b, c, d);
    printf("Наибольшее число: %d\n", max_value);

    return 0;
}
