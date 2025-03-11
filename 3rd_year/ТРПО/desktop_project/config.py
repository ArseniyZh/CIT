import os

# Размеры окна
WINDOW_WIDTH = 1280
WINDOW_HEIGHT = 800

# Путь к иконкам
ICONS_PATH = "resources/images"
ICON_USERS = "users.png"
ICON_ORDERS = "orders.png"
ICON_ABOUT = "about.png"

# --- Светлая тема ---
LIGHT_THEME = {
    "WINDOW_COLOR": "#F8F8F6",
    "ALTERNATE_BASE_COLOR": "#ECECE8",
    "TEXT_COLOR": "#333333",
    "BASE_COLOR": "#FFFFFF",
    "HIGHLIGHT_COLOR": "#C2E7D9",
    "HIGHLIGHTED_TEXT_COLOR": "#000000",
}

# --- Тёмная тема ---
DARK_THEME = {}  # Пустой, т.к. тёмная тема сбрасывает все стили

# Путь к файлу сохранения темы
THEME_FILE = "theme.txt"


# Функция для загрузки текущей темы
def load_theme():
    if not os.path.exists(THEME_FILE):
        save_theme(True)  # Если файла нет, создаем с темной темой
        return DARK_THEME

    try:
        with open(THEME_FILE, "r") as f:
            theme = f.read().strip()
            return DARK_THEME if theme == "dark" else LIGHT_THEME
    except Exception:
        return LIGHT_THEME  # На случай ошибки загрузки


# Функция для сохранения текущей темы
def save_theme(is_dark):
    with open(THEME_FILE, "w") as f:
        f.write("dark" if is_dark else "light")


# Загружаем тему при старте приложения
CURRENT_THEME = load_theme()


# Стили для светлой темы
def get_stylesheet(theme):
    if theme == DARK_THEME:
        return ""  # Темная тема → сбрасываем стили

    return """
        QWidget {
            background-color: #F8F8F6;
            color: #333333;
        }
        QLineEdit, QTextEdit {
            background-color: #FFFFFF;
            border: 1px solid #CCCCCC;
        }
        QPushButton {
            background-color: #C2E7D9;
            border-radius: 4px;
            padding: 6px;
        }
        QPushButton:hover {
            background-color: #A8D8C9;
        }
    """
