import re

from PySide6.QtWidgets import (
    QHBoxLayout,
    QLabel,
    QLineEdit,
    QMessageBox,
    QPushButton,
    QTableWidget,
    QTableWidgetItem,
    QVBoxLayout,
    QWidget,
    QHeaderView,
)

from database.queries.user_queries import (
    add_user,
    delete_user,
    get_all_users,
    get_user_by_id,
    search_users,
    update_user,
)


def is_valid_car_number(car_number: str) -> bool:
    """
    Проверяет, соответствует ли номер машины формату А111АА111 или А111АА11
    согласно ГОСТу (разрешённые буквы: А, В, Е, К, М, Н, О, Р, С, Т, У, Х).
    """
    pattern = r"^[АВЕКМНОРСТУХ]\d{3}[АВЕКМНОРСТУХ]{2}\d{2,3}$"
    return bool(re.fullmatch(pattern, car_number))


class AddUserWidget(QWidget):
    """
    Виджет для создания нового пользователя.
    """

    def __init__(self, on_user_created, parent=None):
        """
        :param on_user_created: Функция, которая вызывается после успешного создания пользователя
                                (должна заменить экран на список пользователей).
        """
        super().__init__(parent)
        self.on_user_created = on_user_created  # Функция обратного вызова

        layout = QVBoxLayout()
        self.setLayout(layout)

        # Поля ввода
        self.car_number_input = QLineEdit()
        self.car_number_input.setPlaceholderText("Введите номер машины")

        self.car_brand_input = QLineEdit()
        self.car_brand_input.setPlaceholderText("Введите марку машины")

        # Кнопка "Создать"
        self.create_button = QPushButton("Создать")
        self.create_button.clicked.connect(self.on_create_clicked)

        # Добавляем виджеты в макет
        layout.addWidget(QLabel("Номер машины:"))
        layout.addWidget(self.car_number_input)
        layout.addWidget(QLabel("Марка машины:"))
        layout.addWidget(self.car_brand_input)
        layout.addWidget(self.create_button)

    def on_create_clicked(self):
        """Обрабатывает нажатие кнопки 'Создать'."""
        car_number = (
            self.car_number_input.text().strip().upper()
        )  # Приводим к верхнему регистру
        car_brand = self.car_brand_input.text().strip()

        if not car_number or not car_brand:
            QMessageBox.warning(self, "Ошибка", "Все поля должны быть заполнены!")
            return

        # Проверяем, корректен ли номер
        if not is_valid_car_number(car_number):
            QMessageBox.warning(
                self, "Ошибка", "Номер машины не соответствует формату (А111АА111)"
            )
            return

        try:
            add_user(car_number, car_brand)
            QMessageBox.information(self, "Успех", "Пользователь добавлен!")
            self.on_user_created()  # Возвращаемся к списку пользователей
        except Exception as e:
            QMessageBox.critical(
                self, "Ошибка", f"Не удалось добавить пользователя:\n{str(e)}"
            )


class EditUserWidget(QWidget):
    """
    Виджет редактирования пользователя.
    """

    def __init__(self, user_id, on_user_updated, parent=None):
        """
        :param user_id: ID пользователя для редактирования.
        :param on_user_updated: Функция, вызываемая после обновления или удаления.
        """
        super().__init__(parent)
        self.user_id = user_id
        self.on_user_updated = on_user_updated  # Callback для обновления UI

        layout = QVBoxLayout()
        self.setLayout(layout)

        # Получаем текущие данные пользователя
        user = get_user_by_id(user_id)
        if not user:
            QMessageBox.critical(self, "Ошибка", "Пользователь не найден!")
            return

        _, car_number, car_brand = user  # Распаковка данных

        # Поля ввода
        self.car_number_input = QLineEdit(car_number)
        self.car_number_input.setPlaceholderText("Введите номер машины")

        self.car_brand_input = QLineEdit(car_brand)
        self.car_brand_input.setPlaceholderText("Введите марку машины")

        # Кнопки
        self.save_button = QPushButton("Сохранить")
        self.save_button.clicked.connect(self.on_save_clicked)

        self.delete_button = QPushButton("Удалить")
        self.delete_button.clicked.connect(self.on_delete_clicked)

        # Добавляем виджеты
        layout.addWidget(QLabel(f"Редактирование пользователя (ID: {user_id})"))
        layout.addWidget(QLabel("Номер машины:"))
        layout.addWidget(self.car_number_input)
        layout.addWidget(QLabel("Марка машины:"))
        layout.addWidget(self.car_brand_input)
        layout.addWidget(self.save_button)
        layout.addWidget(self.delete_button)

    def on_save_clicked(self):
        """Сохранение изменений."""
        new_car_number = self.car_number_input.text().strip().upper()
        new_car_brand = self.car_brand_input.text().strip()

        if not new_car_number or not new_car_brand:
            QMessageBox.warning(self, "Ошибка", "Все поля должны быть заполнены!")
            return

        if not is_valid_car_number(new_car_number):
            QMessageBox.warning(
                self, "Ошибка", "Номер машины не соответствует формату (А111АА111)"
            )
            return

        update_user(self.user_id, new_car_number, new_car_brand)
        QMessageBox.information(self, "Успех", "Данные обновлены!")
        self.on_user_updated()  # Возвращаемся к списку пользователей

    def on_delete_clicked(self):
        """Удаление пользователя."""
        confirm = QMessageBox.question(
            self,
            "Удаление",
            "Вы уверены, что хотите удалить пользователя?",
            QMessageBox.Yes | QMessageBox.No,
        )
        if confirm == QMessageBox.Yes:
            delete_user(self.user_id)
            QMessageBox.information(self, "Удалено", "Пользователь удалён!")
            self.on_user_updated()  # Возвращаемся к списку


class UsersListWidget(QWidget):
    """
    Виджет для списка пользователей с поиском и кнопкой "Добавить пользователя".
    """

    def __init__(self, parent, show_edit_user_screen, show_add_user_screen):
        """
        :param show_edit_user_screen: Функция для перехода на экран редактирования.
        :param show_add_user_screen: Функция для перехода на экран добавления.
        """
        super().__init__(parent)
        self.show_edit_user_screen = show_edit_user_screen
        self.show_add_user_screen = show_add_user_screen

        # Основной вертикальный лейаут (вся страница)
        layout = QVBoxLayout()
        self.setLayout(layout)

        # --- ГОРИЗОНТАЛЬНЫЙ ЛЕЙАУТ (поиск + кнопка "Добавить пользователя") ---
        top_layout = QHBoxLayout()

        # Поле поиска
        self.search_field = QLineEdit()
        self.search_field.setPlaceholderText("Поиск по ID, номеру машины или марке...")
        self.search_field.textChanged.connect(self.on_search_text_changed)

        # Кнопка "Добавить пользователя"
        self.add_user_button = QPushButton("Добавить пользователя")
        self.add_user_button.clicked.connect(self.on_add_user_clicked)  # Пока просто print

        # Добавляем в горизонтальный лейаут
        top_layout.addWidget(self.search_field)
        top_layout.addWidget(self.add_user_button)

        # Таблица пользователей
        self.table = QTableWidget()
        self.table.setColumnCount(3)
        self.table.setHorizontalHeaderLabels(["ID", "Номер машины", "Марка машины"])
        self.table.horizontalHeader().setSectionResizeMode(QHeaderView.Stretch)
        self.table.verticalHeader().hide()
        self.table.cellDoubleClicked.connect(self.on_user_clicked)

        # Добавляем всё в основной лейаут
        layout.addLayout(top_layout)  # Сначала поиск + кнопка
        layout.addWidget(self.table)  # Затем таблица

        # Загружаем данные
        self.load_users()

    def load_users(self, query=None):
        """Загружает данные в таблицу, либо все, либо по поиску."""
        users = search_users(query) if query else get_all_users()

        self.table.setRowCount(len(users))
        for row_idx, (user_id, car_number, car_brand) in enumerate(users):
            self.table.setItem(row_idx, 0, QTableWidgetItem(str(user_id)))
            self.table.setItem(row_idx, 1, QTableWidgetItem(str(car_number)))
            self.table.setItem(row_idx, 2, QTableWidgetItem(str(car_brand)))

        self.table.resizeColumnsToContents()

    def on_user_clicked(self, row, column):
        """Открывает редактирование пользователя при клике."""
        user_id = int(self.table.item(row, 0).text())
        self.show_edit_user_screen(user_id)

    def on_search_text_changed(self):
        """Обновляет список при вводе в поле поиска."""
        query = self.search_field.text().strip()
        self.load_users(query)

    def on_add_user_clicked(self):
        """Открывает экран создания пользователя"""
        self.show_add_user_screen()
