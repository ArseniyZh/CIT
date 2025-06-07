#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#define MAX_STR_LEN 20
#define MAX_ELEMENTS 10

// Структура для элемента связанного списка
typedef struct Node {
    char text[MAX_STR_LEN];      // Строка вида "Это ... элемент"
    struct Node* next;           // Указатель на следующий элемент
} Node;

// Функция создания связанного списка с 10 элементами
Node* create_list() {
    Node* head = NULL;
    Node* current = NULL;
    for (int i = 0; i < MAX_ELEMENTS; i++) {
        Node* new_node = (Node*)malloc(sizeof(Node));
        if (!new_node) {
            printf("Ошибка выделения памяти\n");
            exit(1);
        }
        snprintf(new_node->text, MAX_STR_LEN, "Это %d элемент", i + 1);
        new_node->next = NULL;
        if (!head) {
            head = new_node;
            current = new_node;
        } else {
            current->next = new_node;
            current = new_node;
        }
    }
    return head;
}

// Сохранение связанного списка в файл
int save_list_to_file(const char* filename, Node* head) {
    FILE* file = fopen(filename, "wb");
    if (!file) {
        printf("Ошибка открытия файла\n");
        return -1;
    }

    Node* current = head;
    while (current) {
        fwrite(current->text, sizeof(char), MAX_STR_LEN, file);
        current = current->next;
    }

    fclose(file);
    return 0;
}

// Загрузка связанного списка из файла
Node* load_list_from_file(const char* filename) {
    FILE* file = fopen(filename, "rb");
    if (!file) {
        printf("Ошибка открытия файла\n");
        return NULL;
    }

    Node* head = NULL;
    Node* current = NULL;
    char buffer[MAX_STR_LEN];
    while (fread(buffer, sizeof(char), MAX_STR_LEN, file) == MAX_STR_LEN) {
        Node* new_node = (Node*)malloc(sizeof(Node));
        if (!new_node) {
            printf("Ошибка выделения памяти\n");
            exit(1);
        }
        strncpy(new_node->text, buffer, MAX_STR_LEN);
        new_node->next = NULL;
        if (!head) {
            head = new_node;
            current = new_node;
        } else {
            current->next = new_node;
            current = new_node;
        }
    }


    fclose(file);
    return head;
}

// Вывод содержимого связанного списка
void print_list(Node* head) {
    Node* current = head;
    int index = 1;
    printf("Содержимое списка:\n");
    while (current) {
        printf("%d: %s\n", index++, current->text);
        current = current->next;
    }
}

// Удаление последнего элемента (пункт 8)
int delete_last(Node** head) {
    if (!*head) {
        printf("Список пуст\n");
        return -1;
    }

    if (!(*head)->next) {
        free(*head);
        *head = NULL;
        printf("Последний элемент удалён\n");
        return 0;
    }

    Node* current = *head;
    Node* prev = NULL;
    while (current->next) {
        prev = current;
        current = current->next;
    }

    prev->next = NULL;
    free(current);
    printf("Последний элемент удалён\n");
    return 0;
}

// Добавление элемента перед k-ым по порядку (пункт 8)
int insert_before_k(Node** head, int k) {
    if (k < 1) {
        printf("Неверная позиция k: должна быть >= 1\n");
        return -1;
    }

    Node* new_node = (Node*)malloc(sizeof(Node));
    if (!new_node) {
        printf("Ошибка выделения памяти\n");
        exit(1);
    }
    snprintf(new_node->text, MAX_STR_LEN, "Это новый элемент");

    if (k == 1) {
        new_node->next = *head;
        *head = new_node;
    } else {
        Node* current = *head;
        for (int i = 1; i < k - 1 && current; i++) {
            current = current->next;
        }
        if (!current) {
            printf("Позиция k выходит за пределы списка\n");
            free(new_node);
            return -1;
        }
        new_node->next = current->next;
        current->next = new_node;
    }
    printf("Новый элемент добавлен перед %d-м элементом\n", k);
    return 0;
}

// Освобождение памяти, выделенной под список
void free_list(Node* head) {
    Node* current = head;
    while (current) {
        Node* next = current->next;
        free(current);
        current = next;
    }
}

// Главная функция
int main() {
    char filename[] = "FB1.txt";
    Node* head = load_list_from_file(filename);
    if (!head) {
        printf("Файл не найден, создаём новый список\n");
        head = create_list();
        save_list_to_file(filename, head);
    }

    int choice, k;
    do {
        printf("\nМеню:\n");
        printf("1. Вывести содержимое списка\n");
        printf("2. Удалить последний элемент\n");
        printf("3. Добавить элемент перед k-ым по порядку\n");
        printf("0. Выход\n");
        printf("Выберите действие: ");
        scanf("%d", &choice);

        switch (choice) {
            case 1:
                print_list(head);
                break;
            case 2:
                delete_last(&head);
                save_list_to_file(filename, head);
                break;
            case 3:
                printf("Введите позицию k: ");
                scanf("%d", &k);
                insert_before_k(&head, k);
                save_list_to_file(filename, head);
                break;
            case 0:
                printf("Выход\n");
                break;
            default:
                printf("Неверный выбор\n");
        }
    } while (choice != 0);

    free_list(head);
    return 0;
}
