import time

def generate_subsets(arr):
    subsets = []
    comparisons = 0
    swaps = 0  # Перестановок нет в генерации подмножеств
    start_time = time.time()
    
    def backtrack(start, path):
        nonlocal comparisons
        comparisons += 1  # Счетчик для каждой итерации рекурсии
        subsets.append(path)
        for i in range(start, len(arr)):
            backtrack(i + 1, path + [arr[i]])

    backtrack(0, [])
    
    end_time = time.time()
    execution_time = end_time - start_time
    return subsets, swaps, comparisons, execution_time

# Тест функции
arr = [1, 2, 3]
subsets, swaps, comparisons, exec_time = generate_subsets(arr)

print("Все подмножества множества:", subsets)
print("Количество перестановок:", swaps)
print("Количество сравнений:", comparisons)
print("Время выполнения:", exec_time, "секунд")
