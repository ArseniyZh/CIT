import time

def binary_search(arr, target):
    comparisons = 0
    swaps = 0  # Перестановок нет в бинарном поиске
    start_time = time.time()

    left, right = 0, len(arr) - 1
    while left <= right:
        mid = (left + right) // 2
        comparisons += 1
        if arr[mid] == target:
            end_time = time.time()
            execution_time = end_time - start_time
            return mid, swaps, comparisons, execution_time
        elif arr[mid] < target:
            left = mid + 1
        else:
            right = mid - 1

    end_time = time.time()
    execution_time = end_time - start_time
    return -1, swaps, comparisons, execution_time

# Тест функции
arr = [1, 3, 5, 7, 9, 11, 13, 15, 17, 19]
target = int(input("Введите элемент для поиска: "))
index, swaps, comparisons, exec_time = binary_search(arr, target)

if index != -1:
    print(f"Элемент найден на индексе {index}.")
else:
    print("Элемент не найден.")
print("Количество перестановок:", swaps)
print("Количество сравнений:", comparisons)
print("Время выполнения:", exec_time, "секунд")
