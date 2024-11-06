def smallest_in_longest_positive_sequence(N, A):
    max_length = 0
    min_element = None
    current_length = 0
    current_min = None

    for num in A:
        if num > 0:
            current_length += 1
            if current_min is None or num < current_min:
                current_min = num
        else:
            if current_length > max_length:
                max_length = current_length
                min_element = current_min
            elif current_length == max_length and current_min is not None:
                if min_element is None or current_min < min_element:
                    min_element = current_min
            current_length = 0
            current_min = None

    # Проверка после цикла, если массив заканчивается положительной последовательностью
    if current_length > max_length:
        min_element = current_min
    elif current_length == max_length and current_min is not None:
        if min_element is None or current_min < min_element:
            min_element = current_min

    return min_element



if __name__ == "__main__":
    N = int(input("Введите количество элементов массива: "))
    A = []
    for _ in range(N):
        num = int(input("Введите элемент массива: "))
        A.append(num)
    result = smallest_in_longest_positive_sequence(N, A)
    if result is not None:
        print("Наименьший элемент в наиболее длинной непрерывной последовательности положительных значений:", result)
    else:
        print("В массиве нет положительных элементов.")
