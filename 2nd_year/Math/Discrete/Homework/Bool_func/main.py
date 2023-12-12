from from_expression import expression_main
from from_truth_table import truth_table_main


def main():
    """
    Входная точка программы
    """

    answer = None
    while answer not in (0, 1):
        answer = int(input(
            "Что вы хотите сделать?\n"
            "0 - Получить СКНФ и СДНФ из булевой функции\n"
            "1 - Получить СКНФ и СДНФ из таблицы истинности\n"
            "10 - Выйти\n"
            "> "
        ))

        if answer == 10:
            break
        elif answer == 0:
            expression_main()
            break
        elif answer == 1:
            truth_table_main()
            break

        print("\nВведите корректный ответ\n")


if __name__ == "__main__":
    main()
