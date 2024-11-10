import networkx as nx

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

# Вычисляем минимальный разрез
source, sink = "A", "F"
cut_value, (reachable, non_reachable) = nx.minimum_cut(G, source, sink)

# Выводим результат
print("Емкость минимального разреза:", cut_value)
print("Вершины, достижимые из источника (левая часть разреза):", reachable)
print("Вершины, недостижимые из источника (правая часть разреза):", non_reachable)
