#include <stdio.h>
#include <string.h>

char *my_strncat(char *dest, const char *src, size_t n) {
    char *ptr = dest;

    while (*ptr) {
        ptr++;
    }

    while (n-- && *src) {
        *ptr++ = *src++;
    }

    *ptr = '\0';
    return dest;
}

int main() {
    char dest1[20] = "Hello, ";
    char dest2[20] = "Hello, ";
    char src[] = "world!";

    printf("Конкатенация строк:\n");
    printf("strncat(\"Hello, \", \"world!\", 3) = %s\n", strncat(dest1, src, 3));
    printf("my_strncat(\"Hello, \", \"world!\", 3) = %s\n", my_strncat(dest2, src, 3));

    return 0;
}
