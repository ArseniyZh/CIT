import math
import time

def find_gcd_of_array(arr):
    comparisons = 0
    swaps = 0  # Перестановок нет, так как мы только вычисляем НОД
    start_time = time.time()

    gcd = arr[0]
    for num in arr[1:]:
        gcd = math.gcd(gcd, num)
        comparisons += 1  # Сравнение для каждого элемента массива

    end_time = time.time()
    execution_time = end_time - start_time
    return gcd, swaps, comparisons, execution_time

# Тест функции
arr = [48, 72, 108, 36]
gcd, swaps, comparisons, exec_time = find_gcd_of_array(arr)

print("Наибольший общий делитель всех элементов массива:", gcd)
print("Количество перестановок:", swaps)
print("Количество сравнений:", comparisons)
print("Время выполнения:", exec_time, "секунд")
