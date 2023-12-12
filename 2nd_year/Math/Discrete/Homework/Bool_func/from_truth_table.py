from typing import List

funcType = List[int]
truthTableType = List[List[str]]
lettersType = List[str]


def create_truth_table(count_pair: int, func: funcType) -> truthTableType:
    """
    Функция для создания таблицы истинности

    :param count_pair: Количество переменных
    :param func: Вектор функции
    :return: Таблица истинности
    """
    truth_table = [
        list(format(i, "b").zfill(count_pair)) + [func[i]]
        for i in range(2 ** count_pair)
    ]
    return truth_table


def print_table(letters: lettersType, truth_table: truthTableType, func: funcType) -> None:
    """
    Функция для вывода таблицы истинности в консоль

    :param letters: Список переменных
    :param truth_table: Таблица истинности
    :param func: Вектор функции
    :return:
    """
    print(f"Таблица истинности для вектора функции = {''.join(map(str, func))}")
    print(" || ".join(letters))
    for i in range(len(truth_table)):
        print(" || ".join(map(str, truth_table[i])))

    return


def create_sknf(truth_table: truthTableType, count_par: int, letters: lettersType) -> lettersType:
    """
    Функция для создания СКНФ

    :param truth_table: Таблица истинности
    :param count_par: Количество переменных
    :param letters: Список переменных
    :return: Список из символов СКНФ
    """
    sknf = []
    for i in range(len(truth_table)):
        temp = list()
        sknf.append(temp)
        if int(truth_table[i][-1]) == 0:
            for j in range(count_par):
                if int(truth_table[i][j]) == 0:
                    sknf[i].append(letters[j])
                else:
                    a = "~" + letters[j]
                    sknf[i].append(a)
    return [elem for elem in sknf if elem]


def create_sdnf(truth_table: truthTableType, count_par: int, letters: lettersType) -> lettersType:
    """
    Функция для создания СДНФ

    :param truth_table: Таблица истинности
    :param count_par: Количество переменных
    :param letters: Список переменных
    :return: Список из символов СДНФ
    """
    sdnf = []
    for i in range(len(truth_table)):
        temp = list()
        sdnf.append(temp)
        if int(truth_table[i][-1]) == 1:
            for j in range(count_par):
                if int(truth_table[i][j]) == 1:
                    sdnf[i].append(letters[j])
                else:
                    a = "~" + letters[j]
                    sdnf[i].append(a)
    return [elem for elem in sdnf if elem]


def get_sdnf(sdnf: lettersType) -> str:
    """
    Функция для форматирования СДНФ

    :param sdnf: Список символов СДНФ
    :return: Готовая строка СДНФ
    """
    result = []
    for i in range(len(sdnf)):
        temp = " | ".join(sdnf[i])
        temp = "(" + temp + ")"
        result.append(temp)
    return " & ".join(result)


def get_sknf(sknf: lettersType) -> str:
    """
    Функция для форматирования СКНФ

    :param sknf: Список символов СКНФ
    :return: Готовая строка СКНФ
    """
    result = []
    for i in range(len(sknf)):
        temp = " & ".join(sknf[i])
        temp = "(" + temp + ")"
        result.append(temp)
    return " | ".join(result)


def truth_table_main():
    """
    Входная точка программы
    """
    count_par = int(input("Введите количество переменных: "))

    func = []

    while len(func) != 2 ** count_par:
        func = [int(i) for i in input(f"Введите вектор функции "
                                      f"(должно быть {2 ** count_par} значений, например, 10101011): ")]

    letters = list("ABCDEGHIJKLMNOPQRSTUVWXYZ")
    letters1 = letters[:count_par] + ["F"]

    truth_table = create_truth_table(count_par, func)
    sknf = create_sknf(truth_table, count_par, letters)
    sdnf = create_sdnf(truth_table, count_par, letters)

    result_sdnf = get_sdnf(sdnf)
    result_sknf = get_sknf(sknf)

    print()
    print_table(letters1, truth_table, func)
    print()
    print(f"СКНФ: {result_sknf}")
    print(f"СДНФ: {result_sdnf}")


if __name__ == "__main__":
    truth_table_main()
