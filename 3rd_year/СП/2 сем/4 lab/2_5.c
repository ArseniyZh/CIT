#include <stdio.h>
#include <string.h>

void remove_bracket_content(char *str) {
    int write_index = 0;
    int inside_brackets = 0;

    for (int i = 0; str[i] != '\0'; i++) {
        if (str[i] == '(') {
            inside_brackets++;
        } else if (str[i] == ')') {
            if (inside_brackets > 0) {
                inside_brackets--;
            }
        } else if (inside_brackets == 0) {
            str[write_index++] = str[i];
        }
    }

    str[write_index] = '\0';
}

int main() {
    char str[256];

    printf("Введите строку: ");
    fgets(str, sizeof(str), stdin);

    remove_bracket_content(str);

    printf("Результат: %s\n", str);

    return 0;
}
