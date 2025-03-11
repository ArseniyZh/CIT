import sys

from PySide6.QtWidgets import QApplication

from config import CURRENT_THEME, get_stylesheet
from ui.main_window import MainWindow


def main():
    app = QApplication(sys.argv)

    # Устанавливаем глобальные стили
    app.setStyleSheet(get_stylesheet(CURRENT_THEME))

    # Передаём `app` в `MainWindow`
    window = MainWindow(app)
    window.show()

    sys.exit(app.exec())


if __name__ == "__main__":
    main()
