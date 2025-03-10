#include <stdio.h>
#include <string.h>

int my_strcmp(const char *s1, const char *s2) {
    while (*s1 && (*s1 == *s2)) {
        s1++;
        s2++;
    }
    return *(unsigned char *)s1 - *(unsigned char *)s2;
}

int main() {
    char str1[] = "hello";
    char str2[] = "hello";
    char str3[] = "world";

    printf("Сравнение строк:\n");
    printf("strcmp(\"hello\", \"hello\") = %d\n", strcmp(str1, str2));
    printf("my_strcmp(\"hello\", \"hello\") = %d\n", my_strcmp(str1, str2));

    printf("\n");

    printf("strcmp(\"hello\", \"world\") = %d\n", strcmp(str1, str3));
    printf("my_strcmp(\"hello\", \"world\") = %d\n", my_strcmp(str1, str3));

    printf("\n");

    printf("strcmp(\"world\", \"hello\") = %d\n", strcmp(str3, str1));
    printf("my_strcmp(\"world\", \"hello\") = %d\n", my_strcmp(str3, str1));

    return 0;
}
