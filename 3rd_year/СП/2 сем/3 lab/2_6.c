#include <stdio.h>

int calculate_volume(int length, int width, int height) {
    return length * width * height;
}

int main() {
    int length, width, height;

    printf("Введите длину: ");
    scanf("%d", &length);
    
    printf("Введите ширину: ");
    scanf("%d", &width);
    
    printf("Введите высоту: ");
    scanf("%d", &height);

    int volume = calculate_volume(length, width, height);
    printf("Объем параллелепипеда: %d\n", volume);

    return 0;
}
