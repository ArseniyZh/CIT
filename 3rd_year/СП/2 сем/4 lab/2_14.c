#include <stdio.h>
#include <string.h>

void remove_spaces(char *str) {
    int write_index = 0;
    
    for (int i = 0; str[i] != '\0'; i++) {
        if (str[i] != ' ') {
            str[write_index++] = str[i];
        }
    }
    
    str[write_index] = '\0';
}

int main() {
    char str[256];

    printf("Введите строку: ");
    fgets(str, sizeof(str), stdin);

    remove_spaces(str);

    printf("Результат: %s\n", str);

    return 0;
}
