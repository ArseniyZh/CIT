from PySide6.QtCore import QDate
from PySide6.QtWidgets import (
    QCheckBox,
    QComboBox,
    QDateEdit,
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

from database.queries.order_queries import (
    add_order,
    delete_order,
    get_all_users_for_orders,
    get_order_by_id,
    search_orders,
    update_order,
)


class OrdersListWidget(QWidget):
    """
    Виджет списка заказов с поиском по ID, пользователю, дате заезда и выезда.
    """

    def __init__(self, parent, show_edit_order_screen, show_add_order_screen):
        super().__init__(parent)
        self.show_edit_order_screen = show_edit_order_screen

        layout = QVBoxLayout()
        self.setLayout(layout)

        # --- Первая строка: строка поиска ---
        search_layout = QHBoxLayout()
        self.search_field = QLineEdit()
        self.search_field.setPlaceholderText("Поиск по ID заказа или ID пользователя...")
        self.search_field.textChanged.connect(self.update_search)
        search_layout.addWidget(self.search_field)
        layout.addLayout(search_layout)

        # --- Вторая строка: фильтры дат ---
        date_layout = QVBoxLayout()

        # Фильтры по дате заезда
        checkin_layout = QHBoxLayout()
        self.use_checkin_filter = QCheckBox("Дата заезда от")
        self.checkin_date_input = QDateEdit()
        self.checkin_date_input.setCalendarPopup(True)
        self.checkin_date_input.setDate(QDate.currentDate())
        self.checkin_date_input.setEnabled(False)

        self.use_checkin_to_filter = QCheckBox("до")
        self.checkin_to_date_input = QDateEdit()
        self.checkin_to_date_input.setCalendarPopup(True)
        self.checkin_to_date_input.setDate(QDate.currentDate())
        self.checkin_to_date_input.setEnabled(False)

        checkin_layout.addWidget(self.use_checkin_filter)
        checkin_layout.addWidget(self.checkin_date_input)
        checkin_layout.addWidget(self.use_checkin_to_filter)
        checkin_layout.addWidget(self.checkin_to_date_input)

        # Фильтры по дате выезда
        checkout_layout = QHBoxLayout()
        self.use_checkout_filter = QCheckBox("Дата выезда от")
        self.checkout_date_input = QDateEdit()
        self.checkout_date_input.setCalendarPopup(True)
        self.checkout_date_input.setDate(QDate.currentDate())
        self.checkout_date_input.setEnabled(False)

        self.use_checkout_to_filter = QCheckBox("до")
        self.checkout_to_date_input = QDateEdit()
        self.checkout_to_date_input.setCalendarPopup(True)
        self.checkout_to_date_input.setDate(QDate.currentDate())
        self.checkout_to_date_input.setEnabled(False)

        checkout_layout.addWidget(self.use_checkout_filter)
        checkout_layout.addWidget(self.checkout_date_input)
        checkout_layout.addWidget(self.use_checkout_to_filter)
        checkout_layout.addWidget(self.checkout_to_date_input)

        date_layout.addLayout(checkin_layout)
        date_layout.addLayout(checkout_layout)
        layout.addLayout(date_layout)

        # --- Третья строка: кнопки ---
        button_layout = QHBoxLayout()
        self.clear_search_button = QPushButton("Сбросить поиск")
        self.clear_search_button.clicked.connect(self.reset_search)

        self.add_order_button = QPushButton("Добавить заказ")
        self.add_order_button.clicked.connect(show_add_order_screen)

        button_layout.addWidget(self.clear_search_button)
        button_layout.addWidget(self.add_order_button)
        layout.addLayout(button_layout)

        # --- Таблица заказов ---
        self.table = QTableWidget()
        self.table.setColumnCount(4)
        self.table.setHorizontalHeaderLabels(
            ["ID заказа", "ID пользователя", "Дата заезда", "Дата выезда"]
        )
        self.table.horizontalHeader().setSectionResizeMode(QHeaderView.Stretch)
        self.table.verticalHeader().hide()
        self.table.cellDoubleClicked.connect(self.on_order_clicked)

        layout.addWidget(self.table)

        # Обработчики для активации `QDateEdit`
        self.use_checkin_filter.stateChanged.connect(self.toggle_checkin_date)
        self.use_checkin_to_filter.stateChanged.connect(self.toggle_checkin_to_date)
        self.use_checkout_filter.stateChanged.connect(self.toggle_checkout_date)
        self.use_checkout_to_filter.stateChanged.connect(self.toggle_checkout_to_date)

        # Если пользователь меняет дату, всегда обновляем поиск
        self.checkin_date_input.dateChanged.connect(self.update_search)
        self.checkin_to_date_input.dateChanged.connect(self.update_search)
        self.checkout_date_input.dateChanged.connect(self.update_search)
        self.checkout_to_date_input.dateChanged.connect(self.update_search)

        # Загружаем данные
        self.load_orders()

    def load_orders(
        self,
        query=None,
        checkin_date=None,
        checkin_to_date=None,
        checkout_date=None,
        checkout_to_date=None,
    ):
        """Загружает список заказов в таблицу с фильтрацией."""
        checkin_date_str = (
            checkin_date.toString("yyyy-MM-dd")
            if checkin_date and self.use_checkin_filter.isChecked()
            else None
        )
        checkin_to_date_str = (
            checkin_to_date.toString("yyyy-MM-dd")
            if checkin_to_date and self.use_checkin_to_filter.isChecked()
            else None
        )
        checkout_date_str = (
            checkout_date.toString("yyyy-MM-dd")
            if checkout_date and self.use_checkout_filter.isChecked()
            else None
        )
        checkout_to_date_str = (
            checkout_to_date.toString("yyyy-MM-dd")
            if checkout_to_date and self.use_checkout_to_filter.isChecked()
            else None
        )

        orders = search_orders(
            query,
            checkin_date_str,
            checkin_to_date_str,
            checkout_date_str,
            checkout_to_date_str,
        )
        self.table.setRowCount(len(orders))

        for row_idx, (order_id, user_id, checkin_date, checkout_date) in enumerate(orders):
            self.table.setItem(row_idx, 0, QTableWidgetItem(str(order_id)))
            self.table.setItem(row_idx, 1, QTableWidgetItem(str(user_id)))
            self.table.setItem(row_idx, 2, QTableWidgetItem(checkin_date))
            self.table.setItem(row_idx, 3, QTableWidgetItem(checkout_date))

        self.table.resizeColumnsToContents()

    def update_search(self):
        """Обновляет список заказов при изменении фильтров."""
        query = self.search_field.text().strip()
        checkin_date = (
            self.checkin_date_input.date() if self.use_checkin_filter.isChecked() else None
        )
        checkin_to_date = (
            self.checkin_to_date_input.date()
            if self.use_checkin_to_filter.isChecked()
            else None
        )
        checkout_date = (
            self.checkout_date_input.date() if self.use_checkout_filter.isChecked() else None
        )
        checkout_to_date = (
            self.checkout_to_date_input.date()
            if self.use_checkout_to_filter.isChecked()
            else None
        )
        self.load_orders(query, checkin_date, checkin_to_date, checkout_date, checkout_to_date)

    def reset_search(self):
        """Сбрасывает все фильтры и загружает полный список заказов."""
        self.search_field.clear()
        self.use_checkin_filter.setChecked(False)
        self.use_checkin_to_filter.setChecked(False)
        self.use_checkout_filter.setChecked(False)
        self.use_checkout_to_filter.setChecked(False)
        self.checkin_date_input.setEnabled(False)
        self.checkin_to_date_input.setEnabled(False)
        self.checkout_date_input.setEnabled(False)
        self.checkout_to_date_input.setEnabled(False)
        self.load_orders()

    def toggle_checkin_date(self):
        """Активация/деактивация `QDateEdit` для даты заезда от."""
        self.checkin_date_input.setEnabled(self.use_checkin_filter.isChecked())
        self.update_search()

    def toggle_checkin_to_date(self):
        """Активация/деактивация `QDateEdit` для даты заезда до."""
        self.checkin_to_date_input.setEnabled(self.use_checkin_to_filter.isChecked())
        self.update_search()

    def toggle_checkout_date(self):
        """Активация/деактивация `QDateEdit` для даты выезда от."""
        self.checkout_date_input.setEnabled(self.use_checkout_filter.isChecked())
        self.update_search()

    def toggle_checkout_to_date(self):
        """Активация/деактивация `QDateEdit` для даты выезда до."""
        self.checkout_to_date_input.setEnabled(self.use_checkout_to_filter.isChecked())
        self.update_search()

    def on_order_clicked(self, row, column):
        """Открывает редактирование заказа при двойном клике."""
        order_id = int(self.table.item(row, 0).text())
        self.show_edit_order_screen(order_id)


class AddOrderWidget(QWidget):
    """
    Виджет для добавления нового заказа.
    """

    def __init__(self, on_order_created, parent=None):
        """
        :param on_order_created: Функция, вызываемая после успешного создания заказа.
        """
        super().__init__(parent)
        self.on_order_created = on_order_created  # Callback-функция

        layout = QVBoxLayout()
        self.setLayout(layout)

        # Получаем список пользователей
        self.users = get_all_users_for_orders()
        self.user_dropdown = QComboBox()
        for user_id, car_number in self.users:
            self.user_dropdown.addItem(f"{car_number} (ID: {user_id})", user_id)

        # Дата заезда
        self.checkin_date_input = QDateEdit()
        self.checkin_date_input.setCalendarPopup(True)
        self.checkin_date_input.setDate(QDate.currentDate())

        # Дата выезда
        self.checkout_date_input = QDateEdit()
        self.checkout_date_input.setCalendarPopup(True)
        self.checkout_date_input.setDate(QDate.currentDate())

        # Кнопка "Создать"
        self.create_button = QPushButton("Создать")
        self.create_button.clicked.connect(self.on_create_clicked)

        # Добавляем виджеты
        layout.addWidget(QLabel("Выберите пользователя:"))
        layout.addWidget(self.user_dropdown)
        layout.addWidget(QLabel("Дата заезда:"))
        layout.addWidget(self.checkin_date_input)
        layout.addWidget(QLabel("Дата выезда:"))
        layout.addWidget(self.checkout_date_input)
        layout.addWidget(self.create_button)

    def on_create_clicked(self):
        """Обрабатывает нажатие кнопки 'Создать'."""
        user_id = self.user_dropdown.currentData()
        checkin_date = self.checkin_date_input.date().toString("yyyy-MM-dd")
        checkout_date = self.checkout_date_input.date().toString("yyyy-MM-dd")

        if checkin_date > checkout_date:
            QMessageBox.warning(self, "Ошибка", "Дата выезда должна быть позже даты заезда!")
            return

        try:
            add_order(user_id, checkin_date, checkout_date)
            QMessageBox.information(self, "Успех", "Заказ добавлен!")
            self.on_order_created()  # Возвращаемся к списку заказов
        except Exception as e:
            QMessageBox.critical(self, "Ошибка", f"Не удалось добавить заказ:\n{str(e)}")


class EditOrderWidget(QWidget):
    """
    Виджет редактирования заказа.
    """

    def __init__(self, order_id, on_order_updated, parent=None):
        """
        :param order_id: ID заказа для редактирования.
        :param on_order_updated: Функция, вызываемая после обновления или удаления заказа.
        """
        super().__init__(parent)
        self.order_id = order_id
        self.on_order_updated = on_order_updated  # Callback для возврата к списку заказов

        layout = QVBoxLayout()
        self.setLayout(layout)

        # Получаем данные заказа
        order = get_order_by_id(order_id)
        if not order:
            QMessageBox.critical(self, "Ошибка", "Заказ не найден!")
            return

        _, user_id, checkin_date, checkout_date = order  # Распаковываем данные

        # Заголовок с ID пользователя
        layout.addWidget(
            QLabel(f"Редактирование заказа (ID: {order_id}, Пользователь: {user_id})")
        )

        # Поля для редактирования дат
        self.checkin_date_input = QDateEdit()
        self.checkin_date_input.setCalendarPopup(True)
        self.checkin_date_input.setDate(QDate.fromString(checkin_date, "yyyy-MM-dd"))

        self.checkout_date_input = QDateEdit()
        self.checkout_date_input.setCalendarPopup(True)
        self.checkout_date_input.setDate(QDate.fromString(checkout_date, "yyyy-MM-dd"))

        # Кнопки "Сохранить
        self.save_button = QPushButton("Сохранить")
        self.save_button.clicked.connect(self.on_save_clicked)

        self.delete_button = QPushButton("Удалить")
        self.delete_button.clicked.connect(self.on_delete_clicked)

        # Добавляем виджеты в макет
        layout.addWidget(QLabel("Дата заезда:"))
        layout.addWidget(self.checkin_date_input)
        layout.addWidget(QLabel("Дата выезда:"))
        layout.addWidget(self.checkout_date_input)
        layout.addWidget(self.save_button)
        layout.addWidget(self.delete_button)

    def on_save_clicked(self):
        """Сохранение изменений."""
        checkin_date = self.checkin_date_input.date().toString("yyyy-MM-dd")
        checkout_date = self.checkout_date_input.date().toString("yyyy-MM-dd")

        if checkin_date > checkout_date:
            QMessageBox.warning(self, "Ошибка", "Дата выезда должна быть позже даты заезда!")
            return

        update_order(self.order_id, checkin_date, checkout_date)
        QMessageBox.information(self, "Успех", "Данные заказа обновлены!")
        self.on_order_updated()  # Возвращаемся к списку заказов

    def on_delete_clicked(self):
        """Удаление заказа."""
        confirm = QMessageBox.question(
            self,
            "Удаление",
            "Вы уверены, что хотите удалить заказ?",
            QMessageBox.Yes | QMessageBox.No,
        )
        if confirm == QMessageBox.Yes:
            delete_order(self.order_id)
            QMessageBox.information(self, "Удалено", "Заказ удалён!")
            self.on_order_updated()  # Возвращаемся к списку заказов
