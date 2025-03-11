from PySide6.QtCore import QSize
from PySide6.QtGui import QIcon
from PySide6.QtWidgets import QPushButton


def create_menu_button(text: str, icon_path: str) -> QPushButton:
    button = QPushButton(text)
    button.setIcon(QIcon(icon_path))
    button.setIconSize(QSize(32, 32))
    button.setMinimumHeight(50)

    # Упрощённый стиль без абсолютного позиционирования:
    button.setStyleSheet(
        """
        QPushButton {
            /* Пусть фон/бордюр будут видны для отладки */
            background-color: rgba(255, 255, 255, 0.1);
            border: 1px solid rgba(255, 255, 255, 0.3);

            /* Выравниваем текст слева */
            text-align: left;

            /*
             * Отступ слева заставит текст начинаться правее иконки 
             * (иконка по умолчанию будет тоже “слева” в рамках кнопки).
             */
            padding: 5px;
        }
    """
    )

    return button
