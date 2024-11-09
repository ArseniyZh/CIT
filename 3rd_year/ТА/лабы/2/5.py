import time

def find_max_in_each_row(matrix):
    comparisons = 0
    swaps = 0  # Перестановок нет, так как мы только ищем максимальные значения
    start_time = time.time()

    max_in_rows = []
    for row in matrix:
        max_in_row = row[0]
        for num in row[1:]:
            comparisons += 1
            if num > max_in_row:
                max_in_row = num

        max_in_rows.append(max_in_row)

    end_time = time.time()
    execution_time = end_time - start_time
    return max_in_rows, swaps, comparisons, execution_time

# Тест функции
matrix = [
    [3, 8, 1, 4],
    [6, 2, 9, 5],
    [7, 3, 4, 2],
    [5, 8, 6, 7]
]

max_in_rows, swaps, comparisons, exec_time = find_max_in_each_row(matrix)

print("Максимальные элементы в каждой строке:", max_in_rows)
print("Количество перестановок:", swaps)
print("Количество сравнений:", comparisons)
print("Время выполнения:", exec_time, "секунд")
