import time

# Алгоритм Кнута-Морриса-Пратта (КМП)
def knuth_morris_pratt(text, pattern):
    def build_partial_match_table(pattern):
        table = [0] * len(pattern)
        j = 0
        for i in range(1, len(pattern)):
            if pattern[i] == pattern[j]:
                j += 1
                table[i] = j
            else:
                if j > 0:
                    j = table[j - 1]
                    i -= 1
                else:
                    table[i] = 0
        return table

    table = build_partial_match_table(pattern)
    occurrences = []
    m, i = 0, 0

    while m + i < len(text):
        if pattern[i] == text[m + i]:
            if i == len(pattern) - 1:
                occurrences.append(m)
                m = m + i - table[i]
                i = table[i] if i > 0 else 0
            else:
                i += 1
        else:
            if table[i] > 0:
                m = m + i - table[i]
                i = table[i]
            else:
                m += 1
                i = 0

    return occurrences

# Алгоритм Бойера-Мура-Хорспула
def boyer_moore_horspool(text, pattern):
    shift_table = {ch: len(pattern) for ch in set(text)}
    for j in range(len(pattern) - 1):
        shift_table[pattern[j]] = len(pattern) - 1 - j

    occurrences = []
    i = 0

    while i <= len(text) - len(pattern):
        matched = True
        for j in range(len(pattern) - 1, -1, -1):
            if text[i + j] != pattern[j]:
                i += shift_table.get(text[i + len(pattern) - 1], len(pattern))
                matched = False
                break
        if matched:
            occurrences.append(i)
            i += len(pattern)

    return occurrences

# Функция для подсчета вхождений и времени выполнения
def search_and_count(file_path, word, search_method):
    with open(file_path, 'r', encoding='utf-8') as file:
        text = file.read()

    start_time = time.time()
    occurrences = search_method(text, word)
    end_time = time.time()
    execution_time = end_time - start_time

    print(f"Найдено вхождений: {len(occurrences)}")
    print(f"Индексы вхождений: {occurrences}")
    print(f"Время выполнения: {execution_time:.6f} секунд")
    return execution_time

# Основная программа
if __name__ == "__main__":
    file_path = "text.txt"
    word = input("Введите слово для поиска: ")

    print("\nПоиск с помощью алгоритма Кнута-Морриса-Пратта (КМП):")
    kmp_time = search_and_count(file_path, word, knuth_morris_pratt)

    print("\nПоиск с помощью алгоритма Бойера-Мура-Хорспула:")
    bmh_time = search_and_count(file_path, word, boyer_moore_horspool)

    # Сравнение времени выполнения
    if kmp_time < bmh_time:
        print("\nАлгоритм Кнута-Морриса-Пратта быстрее.")
    else:
        print("\nАлгоритм Бойера-Мура-Хорспула быстрее.")
