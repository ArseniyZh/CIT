#include <stdio.h>
#include <stdlib.h>
#define MAX_STR_LEN 100


// Структура для человека
typedef struct {
    char surname[MAX_STR_LEN];    // Фамилия
    char name[MAX_STR_LEN];       // Имя
    int age;                      // Возраст
    char gender;                  // Пол ('M' или 'F')
} Person;


// Общая структура Т (только для людей)
typedef struct {
    Person person;  // Данные человека
} Record;


// Функция создания бинарного файла с данными о людях
int create_file(const char* filename, int N) {
    FILE* file = fopen(filename, "wb");
    if (!file) {
        printf("Ошибка открытия файла\n");
        return -1;
    }


    for (int i = 0; i < N; i++) {
        Record record;
        printf("Введите данные для человека %d:\n", i + 1);
        printf("Фамилия: ");
        scanf("%s", record.person.surname);
        printf("Имя: ");
        scanf("%s", record.person.name);
        printf("Возраст: ");
        scanf("%d", &record.person.age);
        printf("Пол (M/F): ");
        scanf(" %c", &record.person.gender);


        fwrite(&record, sizeof(Record), 1, file);
    }


    fclose(file);
    return 0;
}

// Функция вывода данных о человеке по индексу
void printOutPerson(const char* filename, int index) {
    FILE* file = fopen(filename, "rb");
    int i = 0;
    if (!file) {
        printf("Ошибка открытия файла\n");
        return;
    }
    Record record;
    while (fread(&record, sizeof(Record), 1, file)) {
        i++;
        if (index == i) {
            printf("Фамилия: %s\n", record.person.surname);
            printf("Имя: %s\n", record.person.name);
            printf("Возраст: %d\n", record.person.age);
            printf("Пол: %c\n", record.person.gender);
            fclose(file);
            return;
        }
    }
    printf("Человека с таким индексом нет\n");
    fclose(file);
    return;
}


// Функция подсчёта людей по указанному полу (пункт 3.2)
int count_people_by_gender(const char* filename, char gender) {
    FILE* file = fopen(filename, "rb");
    if (!file) {
        printf("Ошибка открытия файла\n");
        return -1;
    }
    Record record;
    int count = 0;
    while (fread(&record, sizeof(Record), 1, file)) {
        if (record.person.gender == gender) count++;
    }
    fclose(file);
    return count;
}

// Функция подсчёта людей по указанной фамилии (пункт 3.2)
int count_people_by_surname(const char* filename, char surname) {
    FILE* file = fopen(filename, "rb");
    if (!file) {
        printf("Ошибка открытия файла\n");
        return -1;
    }
    Record record;
    int count = 0;
    while (fread(&record, sizeof(Record), 1, file)) {
        if (record.person.surname[0] == surname) count++;
    }
    fclose(file);
    return count;
}

// Функция подсчёта людей по указанному возрасту (пункт 3.2)
int count_people_by_age(const char* filename, char age) {
    FILE* file = fopen(filename, "rb");
    if (!file) {
        printf("Ошибка открытия файла\n");
        return -1;
    }
    Record record;
    int count = 0;
    while (fread(&record, sizeof(Record), 1, file)) {
        if (record.person.age == (int)age) count++;
    }
    fclose(file);
    return count;
}


// Функция изменения пола для n-го человека (пункт 3.2)
int update_person_gender(const char* filename, int n, char new_gender) {
    FILE* file = fopen(filename, "rb+");
    if (!file) {
        printf("Ошибка открытия файла\n");
        return -1;
    }
    Record record;
    fseek(file, (n - 1) * sizeof(Record), SEEK_SET);
    if (fread(&record, sizeof(Record), 1, file) != 1) {
        fclose(file);
        printf("Ошибка: элемент с номером %d не найден\n", n);
        return -1;
    }
    record.person.gender = new_gender;
    fseek(file, (n - 1) * sizeof(Record), SEEK_SET);
    fwrite(&record, sizeof(Record), 1, file);
    fclose(file);
    return 0;
}

// Функция изменения фамилии для n-го человека (пункт 3.2)
int update_person_surname(const char* filename, int n, char new_surname) {
    FILE* file = fopen(filename, "rb+");
    if (!file) {
        printf("Ошибка открытия файла\n");
        return -1;
    }
    Record record;
    fseek(file, (n - 1) * sizeof(Record), SEEK_SET);
    if (fread(&record, sizeof(Record), 1, file) != 1) {
        fclose(file);
        printf("Ошибка: элемент с номером %d не найден\n", n);
        return -1;
    }
    record.person.surname[0] = new_surname;
    fseek(file, (n - 1) * sizeof(Record), SEEK_SET);
    fwrite(&record, sizeof(Record), 1, file);
    fclose(file);
    return 0;
}

// Функция изменения возраста для n-го человека (пункт 3.2)
int update_person_age(const char* filename, int n, char new_age) {
    FILE* file = fopen(filename, "rb+");
    if (!file) {
        printf("Ошибка открытия файла\n");
        return -1;
    }
    Record record;
    fseek(file, (n - 1) * sizeof(Record), SEEK_SET);
    if (fread(&record, sizeof(Record), 1, file) != 1) {
        fclose(file);
        printf("Ошибка: элемент с номером %d не найден\n", n);
        return -1;
    }
    record.person.age = (int)new_age;
    fseek(file, (n - 1) * sizeof(Record), SEEK_SET);
    fwrite(&record, sizeof(Record), 1, file);
    fclose(file);
    return 0;
}


// Главная функция с меню
int main() {
    char filename[] = "FB.txt";
    int choice, N, n;
    char gender, new_gender;
    char surname, new_surname;
    char age, new_age;

    do {
        printf("\nМеню:\n");
        printf("1. Создать файл с людьми\n");
        printf("2. Вывести человека под номером k\n");

        printf("3. Подсчёт людей по полу\n");
        printf("4. Подсчёт людей по фамилии\n");
        printf("5. Подсчёт людей по возрасту\n");

        printf("6. Изменить пол для n-го человека\n");
        printf("7. Изменить фамилию для n-го человека\n");
        printf("8. Изменить возраст для n-го человека\n");

        printf("0. Выход\n");
        printf("Выберите действие: ");
        scanf("%d", &choice);


        switch (choice) {
            // Создать файл с людьми
            case 1:
                printf("Введите количество людей N: ");
                scanf("%d", &N);
                if (create_file(filename, N) == 0) {
                    printf("Файл успешно создан\n");
                }
                break;
            // Вывести человека под номером k
            case 2:
                printf("Введите номер человека: ");
                scanf("%d", &n);
                printOutPerson(filename, n);
                break;

            // Подсчёт людей по полу
            case 3:
                printf("Введите пол (M/F): ");
                scanf(" %c", &gender);
                int count1 = count_people_by_gender(filename, gender);
                if (count1 >= 0) {
                    printf("Количество людей пола %c: %d\n", gender, count1);
                }
                break;
            // Подсчёт людей по фамилии
            case 4:
                printf("Введите фамилию: ");
                scanf(" %c", &surname);
                int count2 = count_people_by_surname(filename, surname);
                if (count2 >= 0) {
                    printf("Количество людей с фамилией %c: %d\n", surname, count2);
                }
                break;
            // Подсчёт людей по возрасту
            case 5:
                printf("Введите имя: ");
                scanf(" %c", &age);
                int count3 = count_people_by_age(filename, age);
                if (count3 >= 0) {
                    printf("Количество людей возраста %c: %d\n", age, count3);
                }
                break;

            // Изменить пол для n-го человека
            case 6:
                printf("Введите номер человека и новый пол (M/F): ");
                scanf("%d %c", &n, &new_gender);
                if (update_person_gender(filename, n, new_gender) == 0) {
                    printf("Пол для человека %d изменён\n", n);
                }
                break;
            // Изменить фамилию для n-го человека
            case 7:
                printf("Введите номер человека и новую фамилию: ");
                scanf("%d %c", &n, &new_surname);
                if (update_person_surname(filename, n, new_surname) == 0) {
                    printf("Фамилия для человека %d изменена\n", n);
                }
                break;
            // Изменить возраст для n-го человека
            case 8:
                printf("Введите номер человека и новый возраст: ");
                scanf("%d %c", &n, &new_age);
                if (update_person_age(filename, n, new_age) == 0) {
                    printf("Врзраст для человека %d изменён\n", n);
                }
                break;

            case 0:
                printf("Выход\n");
                break;
            default:
                printf("Неверный выбор\n");
        }
    } while (choice != 0);


    return 0;
}
