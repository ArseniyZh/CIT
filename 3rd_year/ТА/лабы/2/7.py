import time

def generate_permutations(arr):
    permutations = []
    comparisons = 0
    swaps = 0  # Счетчик для перестановок
    start_time = time.time()
    
    def backtrack(start):
        nonlocal swaps, comparisons
        comparisons += 1  # Увеличение счетчика на каждый вызов
        if start == len(arr):
            permutations.append(arr[:])
            return
        for i in range(start, len(arr)):
            arr[start], arr[i] = arr[i], arr[start]  # Перестановка
            swaps += 1
            backtrack(start + 1)
            arr[start], arr[i] = arr[i], arr[start]  # Отмена перестановки

    backtrack(0)
    
    end_time = time.time()
    execution_time = end_time - start_time
    return permutations, swaps, comparisons, execution_time

# Тест функции
arr = [1, 2, 3]
permutations, swaps, comparisons, exec_time = generate_permutations(arr)

print("Все перестановки множества:", permutations)
print("Количество перестановок:", swaps)
print("Количество сравнений:", comparisons)
print("Время выполнения:", exec_time, "секунд")
