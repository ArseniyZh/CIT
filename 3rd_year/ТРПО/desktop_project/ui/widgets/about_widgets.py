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

from database.queries.about_queries import (
    add_about,
    delete_about,
    get_about_by_id,
    get_all_orders_for_abouts,
    search_abouts,
    update_about,
)


class AboutsListWidget(QWidget):
    """
    Виджет списка отчетов (таблица about).
    """

    def __init__(self, parent, show_add_about_screen, show_edit_about_screen):
        super().__init__(parent)
        self.show_add_about_screen = show_add_about_screen
        self.show_edit_about_screen = show_edit_about_screen

        layout = QVBoxLayout()
        self.setLayout(layout)

        # --- Верхний блок (поиск по ID/заказу + поиск по датам) ---
        top_layout = QHBoxLayout()

        self.search_field = QLineEdit()
        self.search_field.setPlaceholderText("Поиск по ID отчета или ID заказа...")
        self.search_field.textChanged.connect(self.update_search)

        # Чекбоксы для включения поиска по дате
        self.use_start_date_filter = QCheckBox("Фильтр по дате оплаты от")
        self.use_end_date_filter = QCheckBox("до")

        # Поля выбора дат оплаты (по умолчанию неактивны)
        self.start_date_input = QDateEdit()
        self.start_date_input.setCalendarPopup(True)
        self.start_date_input.setDate(QDate.currentDate())
        self.start_date_input.setEnabled(False)

        self.end_date_input = QDateEdit()
        self.end_date_input.setCalendarPopup(True)
        self.end_date_input.setDate(QDate.currentDate())
        self.end_date_input.setEnabled(False)

        # Обработчики для активации `QDateEdit`
        self.use_start_date_filter.stateChanged.connect(self.toggle_start_date)
        self.use_end_date_filter.stateChanged.connect(self.toggle_end_date)

        # Если пользователь меняет дату, всегда обновляем поиск
        self.start_date_input.dateChanged.connect(self.update_search)
        self.end_date_input.dateChanged.connect(self.update_search)

        # Кнопка "Сбросить поиск"
        self.clear_search_button = QPushButton("Сбросить поиск")
        self.clear_search_button.clicked.connect(self.reset_search)

        # Кнопка "Добавить отчет"
        self.add_about_button = QPushButton("Добавить отчет")
        self.add_about_button.clicked.connect(self.show_add_about_screen)

        top_layout.addWidget(self.search_field)
        top_layout.addWidget(self.use_start_date_filter)
        top_layout.addWidget(self.start_date_input)
        top_layout.addWidget(self.use_end_date_filter)
        top_layout.addWidget(self.end_date_input)
        top_layout.addWidget(self.clear_search_button)
        top_layout.addWidget(self.add_about_button)

        # --- Таблица отчетов ---
        self.table = QTableWidget()
        self.table.setColumnCount(4)
        self.table.setHorizontalHeaderLabels(["ID отчета", "ID заказа", "Цена", "Дата оплаты"])
        self.table.horizontalHeader().setSectionResizeMode(QHeaderView.Stretch)
        self.table.verticalHeader().hide()
        self.table.resizeColumnsToContents()
        self.table.cellDoubleClicked.connect(self.on_about_clicked)

        layout.addLayout(top_layout)
        layout.addWidget(self.table)

        # Загружаем данные
        self.load_abouts()

    def load_abouts(self, query=None, start_date=None, end_date=None):
        """Загружает список отчетов в таблицу с фильтрацией."""
        start_date_str = (
            start_date.toString("yyyy-MM-dd")
            if start_date and self.use_start_date_filter.isChecked()
            else None
        )
        end_date_str = (
            end_date.toString("yyyy-MM-dd")
            if end_date and self.use_end_date_filter.isChecked()
            else None
        )

        reports = search_abouts(query, start_date_str, end_date_str)
        self.table.setRowCount(len(reports))

        for row_idx, (about_id, order_id, price, payment_date) in enumerate(reports):
            self.table.setItem(row_idx, 0, QTableWidgetItem(str(about_id)))
            self.table.setItem(row_idx, 1, QTableWidgetItem(str(order_id)))
            self.table.setItem(row_idx, 2, QTableWidgetItem(f"{price:.2f}"))
            self.table.setItem(row_idx, 3, QTableWidgetItem(payment_date))

        self.table.resizeColumnsToContents()

    def update_search(self):
        """Обновляет список отчетов при изменении фильтров."""
        query = self.search_field.text().strip()
        start_date = (
            self.start_date_input.date() if self.use_start_date_filter.isChecked() else None
        )
        end_date = self.end_date_input.date() if self.use_end_date_filter.isChecked() else None
        self.load_abouts(query, start_date, end_date)

    def reset_search(self):
        """Сбрасывает все фильтры и загружает полный список отчетов."""
        self.search_field.clear()
        self.use_start_date_filter.setChecked(False)
        self.use_end_date_filter.setChecked(False)
        self.start_date_input.setEnabled(False)
        self.end_date_input.setEnabled(False)
        self.load_abouts()

    def toggle_start_date(self):
        """Активация/деактивация `QDateEdit` для даты начала."""
        self.start_date_input.setEnabled(self.use_start_date_filter.isChecked())
        self.update_search()  # Обновляем поиск при любом изменении чекбокса

    def toggle_end_date(self):
        """Активация/деактивация `QDateEdit` для даты окончания."""
        self.end_date_input.setEnabled(self.use_end_date_filter.isChecked())
        self.update_search()  # Обновляем поиск при любом изменении чекбокса

    def on_about_clicked(self, row, column):
        """Открывает редактирование отчета при двойном клике."""
        about_id = int(self.table.item(row, 0).text())
        self.show_edit_about_screen(about_id)
        """Открывает редактирование отчета при двойном клике."""
        about_id = int(self.table.item(row, 0).text())
        self.show_edit_about_screen(about_id)


class AddAboutWidget(QWidget):
    """
    Виджет для добавления нового отчета (about).
    """

    def __init__(self, on_about_created, parent=None):
        """
        :param on_about_created: Функция, вызываемая после успешного создания отчета.
        """
        super().__init__(parent)
        self.on_about_created = on_about_created  # Callback-функция

        layout = QVBoxLayout()
        self.setLayout(layout)

        # Получаем список заказов
        self.orders = get_all_orders_for_abouts()
        self.order_dropdown = QComboBox()
        for (order_id,) in self.orders:
            self.order_dropdown.addItem(f"Заказ ID: {order_id}", order_id)

        # Поле для ввода суммы
        self.price_input = QLineEdit()
        self.price_input.setPlaceholderText("Введите сумму оплаты")

        # Дата оплаты
        self.payment_date_input = QDateEdit()
        self.payment_date_input.setCalendarPopup(True)
        self.payment_date_input.setDate(QDate.currentDate())

        # Кнопка "Создать"
        self.create_button = QPushButton("Создать")
        self.create_button.clicked.connect(self.on_create_clicked)

        # Добавляем виджеты
        layout.addWidget(QLabel("Выберите заказ:"))
        layout.addWidget(self.order_dropdown)
        layout.addWidget(QLabel("Сумма оплаты:"))
        layout.addWidget(self.price_input)
        layout.addWidget(QLabel("Дата оплаты:"))
        layout.addWidget(self.payment_date_input)
        layout.addWidget(self.create_button)

    def on_create_clicked(self):
        """Обрабатывает нажатие кнопки 'Создать'."""
        order_id = self.order_dropdown.currentData()
        price = self.price_input.text().strip()
        payment_date = self.payment_date_input.date().toString("yyyy-MM-dd")

        if not price:
            QMessageBox.warning(self, "Ошибка", "Введите сумму оплаты!")
            return

        try:
            price = float(price)
            if price <= 0:
                raise ValueError
        except ValueError:
            QMessageBox.warning(
                self, "Ошибка", "Сумма оплаты должна быть положительным числом!"
            )
            return

        try:
            add_about(order_id, price, payment_date)
            QMessageBox.information(self, "Успех", "Отчет добавлен!")
            self.on_about_created()  # Возвращаемся к списку отчетов
        except Exception as e:
            QMessageBox.critical(self, "Ошибка", f"Не удалось добавить отчет:\n{str(e)}")


class EditAboutWidget(QWidget):
    """
    Виджет редактирования отчета (about).
    """

    def __init__(self, about_id, on_about_updated, parent=None):
        """
        :param about_id: ID отчета для редактирования.
        :param on_about_updated: Функция, вызываемая после обновления или удаления отчета.
        """
        super().__init__(parent)
        self.about_id = about_id
        self.on_about_updated = on_about_updated  # Callback для возврата к списку отчетов

        layout = QVBoxLayout()
        self.setLayout(layout)

        # Получаем данные отчета
        about = get_about_by_id(about_id)
        if not about:
            QMessageBox.critical(self, "Ошибка", "Отчет не найден!")
            return

        _, order_id, price, payment_date = about  # Распаковываем данные

        # Заголовок с ID заказа
        layout.addWidget(QLabel(f"Редактирование отчета (ID: {about_id}, Заказ: {order_id})"))

        # Поле для редактирования суммы оплаты
        self.price_input = QLineEdit(str(price))
        self.price_input.setPlaceholderText("Введите сумму оплаты")

        # Поле для редактирования даты оплаты
        self.payment_date_input = QDateEdit()
        self.payment_date_input.setCalendarPopup(True)
        self.payment_date_input.setDate(QDate.fromString(payment_date, "yyyy-MM-dd"))

        # Кнопки "Сохранить" и "Удалить"
        self.save_button = QPushButton("Сохранить")
        self.save_button.clicked.connect(self.on_save_clicked)

        self.delete_button = QPushButton("Удалить")
        self.delete_button.clicked.connect(self.on_delete_clicked)

        # Добавляем виджеты
        layout.addWidget(QLabel("Сумма оплаты:"))
        layout.addWidget(self.price_input)
        layout.addWidget(QLabel("Дата оплаты:"))
        layout.addWidget(self.payment_date_input)
        layout.addWidget(self.save_button)
        layout.addWidget(self.delete_button)

    def on_save_clicked(self):
        """Сохранение изменений."""
        price = self.price_input.text().strip()
        payment_date = self.payment_date_input.date().toString("yyyy-MM-dd")

        if not price:
            QMessageBox.warning(self, "Ошибка", "Введите сумму оплаты!")
            return

        try:
            price = float(price)
            if price <= 0:
                raise ValueError
        except ValueError:
            QMessageBox.warning(
                self, "Ошибка", "Сумма оплаты должна быть положительным числом!"
            )
            return

        update_about(self.about_id, price, payment_date)
        QMessageBox.information(self, "Успех", "Данные отчета обновлены!")
        self.on_about_updated()  # Возвращаемся к списку отчетов

    def on_delete_clicked(self):
        """Удаление отчета."""
        confirm = QMessageBox.question(
            self,
            "Удаление",
            "Вы уверены, что хотите удалить отчет?",
            QMessageBox.Yes | QMessageBox.No,
        )
        if confirm == QMessageBox.Yes:
            delete_about(self.about_id)
            QMessageBox.information(self, "Удалено", "Отчет удалён!")
            self.on_about_updated()  # Возвращаемся к списку отчетов
