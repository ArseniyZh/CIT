import time

def swap_values(a, b):
    comparisons = 0  # Нет сравнений
    swaps = 1  # Одно возвращение значений в обратном порядке
    start_time = time.time()
    
    result = (b, a)
    
    end_time = time.time()
    execution_time = end_time - start_time
    
    return result, swaps, comparisons, execution_time

# Тест функции
x = int(input("Введите первое число: "))
y = int(input("Введите второе число: "))
(result_x, result_y), swaps, comparisons, exec_time = swap_values(x, y)

print("После обмена:")
print("Первое число:", result_x)
print("Второе число:", result_y)
print("Количество перестановок:", swaps)
print("Количество сравнений:", comparisons)
print("Время выполнения:", exec_time, "секунд")
