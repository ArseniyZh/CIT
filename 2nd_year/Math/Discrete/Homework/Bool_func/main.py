from typing import Tuple, List

from sympy import symbols, Symbol
from sympy.logic.boolalg import Or, And
from sympy.logic.boolalg import truth_table

SymbolsListType = List[Symbol]
TruthTableType = List[Tuple[List[int], bool]]


def print_truth_table(expression: str, symbols_list: SymbolsListType, tt: TruthTableType) -> None:
    """
    Функция для вывода таблицы истинности в консоль.
    :param expression: Строка с булевой функцией
    :param symbols_list: Список объектов Symbol, которые используются в булевой функции
    :param tt: Таблица истинности
    :return:
    """
    symbols_list = sorted(list(map(str, symbols_list)))
    print(f"Таблица истинности для F = {expression}")
    print(f"{' || '.join(map(str, symbols_list))} || F")
    for row in tt:
        var = ' || '.join([str(i) for i in row[0]])
        print(f"{var} || {row[1]}")


def generate_truth_table(expression: str) -> Tuple[SymbolsListType, TruthTableType]:
    """
    Функция для генерации Таблицы истинности на основе введенной булевой функции
    :param expression: Строка с булевой функцией
    :return: Кортеж из списка символов и таблцы истинности
    """
    symbols_list = list(set(expression) & set('ABCDEFGHIJKLMNOPQRSTUVWXYZ'))
    _symbols = symbols(symbols_list)
    tt = list(truth_table(expression, _symbols))
    return _symbols, tt


def get_cnf_and_dnf(symbols_list: SymbolsListType, tt: TruthTableType) -> Tuple[str, str]:
    """
    Функция для генерации СДНФ и СКНФ на основе полученной таблицы истинности
    :param symbols_list: Список символов
    :param tt: Таблица истинности
    :return: Кортеж из строк СДНФ и СКНФ
    """
    minterms = [term for term, value in tt if value]
    maxterms = [term for term, value in tt if not value]

    cnf = str(Or(*[And(*(symbol if bit else ~symbol for bit, symbol in zip(term, symbols_list))) for term in minterms]))
    dnf = str(Or(*[And(*(~symbol if bit else symbol for bit, symbol in zip(term, symbols_list))) for term in maxterms]))

    return cnf, dnf


def main():
    """
    Входная точка программы
    """
    expression: str
    expression = input(
        "Введите булеву функцию, используя переменные A, B, C и операторы &, |, ~ (например, A & B | ~C): "
    )

    symbols_list: SymbolsListType
    tt: TruthTableType
    symbols_list, tt = generate_truth_table(expression)

    cnf: str
    dnf: str
    cnf, dnf = get_cnf_and_dnf(symbols_list, tt)

    print()
    print_truth_table(expression, symbols_list, tt)
    print()

    print(f"СКНФ: {cnf}")
    print(f"СДНФ: {dnf}")


if __name__ == "__main__":
    main()
