#include <stdio.h>

void find_bounds(float num, int *lower, int *upper) {
    *lower = (int)num;
    *upper = *lower + 1;
}

int main() {
    float num;
    int lower, upper;

    printf("Введите вещественное число: ");
    scanf("%f", &num);

    find_bounds(num, &lower, &upper);

    printf("Число находится между %d и %d\n", lower, upper);

    return 0;
}
