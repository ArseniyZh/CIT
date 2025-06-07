#include <stdio.h>


int power(int a, int b) {
    int result = 1;
    for (int i = 0; i < b; i++) {
        result *= a;
    }
    return result;
}


int multiply(int a, int b) {
    return a * b;
}


int remainder(int a, int b) {
    if (b == 0) {
        printf("Ошибка: деление на ноль!\n");
        return 0;
    }
    return a % b;
}


int is_multiple(int a, int b) {
    if (b == 0) {
        printf("Ошибка: деление на ноль!\n");
        return 0;
    }
    return (a % b == 0) ? 1 : 0; // 1 - кратно, 0 - не кратно
}


int calculate(int a, int b, int (*func)(int, int)) {
    return func(a, b);
}


int main() {
    int a, b, choice;
    int (*operations[4])(int, int) = {power, multiply, remainder, is_multiple};


    do {
        printf("\nМеню:\n");
        printf("1. Возведение a в степень b\n");
        printf("2. Произведение a и b\n");
        printf("3. Остаток от деления a на b\n");
        printf("4. Проверка кратности a и b\n");
        printf("0. Выход\n");
        printf("Выберите действие (0-4): ");
        scanf("%d", &choice);


        if (choice >= 1 && choice <= 4) {
            printf("Введите a: ");
            scanf("%d", &a);
            printf("Введите b: ");
            scanf("%d", &b);


            int result = calculate(a, b, operations[choice - 1]);
            
            switch (choice) {
                case 1:
                    printf("%d в степени %d = %d\n", a, b, result);
                    break;
                case 2:
                    printf("%d * %d = %d\n", a, b, result);
                    break;
                case 3:
                    if (b != 0) {
                        printf("%d %% %d = %d\n", a, b, result);
                    }
                    break;
                case 4:
                    if (b != 0) {
                        printf("%d %s кратно %d\n", a, result ? "является" : "не является", b);
                    }
                    break;
            }
        } else if (choice != 0) {
            printf("Неверный выбор! Введите число от 0 до 4.\n");
        }
    } while (choice != 0);


    printf("Программа завершена.\n");
    return 0;
}