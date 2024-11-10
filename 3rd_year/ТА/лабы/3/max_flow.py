import networkx as nx
from collections import deque

# Создаем направленный граф
G = nx.DiGraph()

# Определяем ребра и их пропускные способности
edges = [
    ("A", "B", 8),
    ("A", "C", 6),
    ("B", "D", 5),
    ("B", "E", 7),
    ("C", "E", 4),
    ("C", "D", 3),
    ("D", "F", 9),
    ("E", "F", 5)
]

# Добавляем ребра с их пропускными способностями в граф
for u, v, capacity in edges:
    G.add_edge(u, v, capacity=capacity)

# Копируем граф для остаточной сети
residual_graph = G.copy()

# Функция для поиска увеличивающего пути с использованием BFS
def bfs_find_path(graph, source, sink):
    parent = {source: None}
    queue = deque([source])
    while queue:
        u = queue.popleft()
        for v in graph.successors(u):
            if v not in parent and graph[u][v]["capacity"] > 0:  # Путь найден
                parent[v] = u
                if v == sink:
                    path = []
                    while v is not None:
                        path.append(v)
                        v = parent[v]
                    return path[::-1]  # Возвращаем путь в прямом порядке
                queue.append(v)
    return None  # Если пути нет

# Функция для вывода состояния ребер
def print_edge_capacities(graph):
    print("Состояние ребер:")
    for u, v, data in graph.edges(data=True):
        print(f"{u} → {v}: {data['capacity']}")

# Алгоритм нахождения максимального потока с пошаговым выводом состояния
source, sink = "A", "F"
max_flow = 0
step = 1

while True:
    path = bfs_find_path(residual_graph, source, sink)
    if path is None:
        break  # Завершаем цикл, если пути нет

    # Определяем минимальную пропускную способность на пути
    path_flow = min(residual_graph[u][v]["capacity"] for u, v in zip(path, path[1:]))
    max_flow += path_flow

    # Обновляем остаточные пропускные способности на найденном пути
    for u, v in zip(path, path[1:]):
        residual_graph[u][v]["capacity"] -= path_flow
        if residual_graph.has_edge(v, u):
            residual_graph[v][u]["capacity"] += path_flow
        else:
            residual_graph.add_edge(v, u, capacity=path_flow)

    # Вывод состояния графа после текущего шага
    print(f"\nШаг {step}:")
    print(f"Найденный путь: {' → '.join(path)} с потоком {path_flow}")
    print_edge_capacities(residual_graph)
    
    step += 1

print(f"\nМаксимальный поток: {max_flow}")
