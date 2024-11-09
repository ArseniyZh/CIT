import time

def merge_sort(arr):
    comparisons = 0
    swaps = 0
    start_time = time.time()

    def merge(left, right):
        nonlocal comparisons, swaps
        result = []
        i = j = 0

        # Слияние двух отсортированных частей
        while i < len(left) and j < len(right):
            comparisons += 1
            if left[i] < right[j]:
                result.append(left[i])
                i += 1
            else:
                result.append(right[j])
                j += 1
                swaps += 1

        # Добавление оставшихся элементов
        result.extend(left[i:])
        result.extend(right[j:])
        return result

    def sort(arr):
        if len(arr) <= 1:
            return arr
        mid = len(arr) // 2
        left = sort(arr[:mid])
        right = sort(arr[mid:])
        return merge(left, right)

    sorted_arr = sort(arr)
    end_time = time.time()
    execution_time = end_time - start_time
    return sorted_arr, swaps, comparisons, execution_time

# Тест функции
arr = [38, 27, 43, 3, 9, 82, 10]
sorted_arr, swaps, comparisons, exec_time = merge_sort(arr)

print("Отсортированный массив:", sorted_arr)
print("Количество перестановок:", swaps)
print("Количество сравнений:", comparisons)
print("Время выполнения:", exec_time, "секунд")
