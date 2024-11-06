def get_unique_elements(N, A):
    unique_elements = []
    for i in range(N):
        is_unique = True
        for j in range(N):
            if i != j and A[i] == A[j]:
                is_unique = False
                break
        if is_unique:
            unique_elements.append(A[i])
    return unique_elements


if __name__ == "__main__":
    N = int(input("Введите количество элементов массива: "))
    A = []
    for _ in range(N):
        num = float(input("Введите элемент массива: "))
        A.append(num)
    unique = get_unique_elements(N, A)
    print("Уникальные элементы массива:", unique)
