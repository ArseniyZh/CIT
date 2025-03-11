import os

from PySide6.QtCore import Qt
from PySide6.QtWidgets import (
    QCheckBox,
    QFrame,
    QHBoxLayout,
    QLabel,
    QMainWindow,
    QVBoxLayout,
    QWidget,
)

from config import (
    CURRENT_THEME,
    DARK_THEME,
    ICON_ABOUT,
    ICON_ORDERS,
    ICON_USERS,
    ICONS_PATH,
    LIGHT_THEME,
    WINDOW_HEIGHT,
    WINDOW_WIDTH,
    get_stylesheet,
    save_theme,
)
from ui.widgets.about_widgets import AboutsListWidget, AddAboutWidget, EditAboutWidget
from ui.widgets.order_widgets import AddOrderWidget, EditOrderWidget, OrdersListWidget
from ui.widgets.user_widgets import AddUserWidget, EditUserWidget, UsersListWidget

from .button_factory import create_menu_button


class MainWindow(QMainWindow):
    def __init__(self, app):
        super().__init__()
        self.app = app

        self.setFixedSize(WINDOW_WIDTH, WINDOW_HEIGHT)
        self.setWindowTitle("Административная панель - Главный экран")

        # Главный горизонтальный лейаут
        central_widget = QWidget()
        main_layout = QHBoxLayout()
        central_widget.setLayout(main_layout)

        # --- ЛЕВАЯ ПАНЕЛЬ ---
        left_panel = QWidget()
        left_layout = QVBoxLayout()
        left_layout.setAlignment(Qt.AlignTop)
        left_panel.setLayout(left_layout)

        # Создаём кнопки через фабрику
        icon_users_path = os.path.join(ICONS_PATH, ICON_USERS)
        icon_orders_path = os.path.join(ICONS_PATH, ICON_ORDERS)
        icon_about_path = os.path.join(ICONS_PATH, ICON_ABOUT)

        self.btn_users = create_menu_button("Пользователи", icon_users_path)
        self.btn_orders = create_menu_button("Заказы", icon_orders_path)
        self.btn_about = create_menu_button("Отчет", icon_about_path)

        # Подключаем сигналы
        self.btn_users.clicked.connect(self.on_users_clicked)
        self.btn_orders.clicked.connect(self.on_orders_clicked)
        self.btn_about.clicked.connect(self.on_about_clicked)

        # Добавляем кнопки в layout левой панели
        left_layout.addWidget(self.btn_users)
        left_layout.addWidget(self.btn_orders)
        left_layout.addWidget(self.btn_about)

        # --- ТУМБЛЕР ДЛЯ ТЕМЫ ---
        self.theme_switch = QCheckBox("Тёмная тема")
        self.theme_switch.setChecked(CURRENT_THEME == DARK_THEME)
        self.theme_switch.stateChanged.connect(self.toggle_theme)

        left_layout.addStretch()  # Отодвигаем тумблер вниз
        left_layout.addWidget(self.theme_switch)

        # --- РАЗДЕЛИТЕЛЬ (вертикальная линия) ---
        separator = QFrame()
        separator.setFrameShape(QFrame.VLine)  # вертикальная линия
        separator.setFrameShadow(QFrame.Sunken)  # с тенями, "вдавленная" граница

        # --- ПРАВАЯ ПАНЕЛЬ ---
        # -- Правая панель (запоминаем её Layout, чтобы динамически менять контент)
        self.right_panel = QWidget()
        self.right_layout = QVBoxLayout()
        self.right_layout.setAlignment(Qt.AlignTop)
        self.right_panel.setLayout(self.right_layout)

        # Изначальная заглушка
        self.placeholder_label = QLabel("Выберите опцию в меню")
        self.right_layout.addWidget(self.placeholder_label)

        # --- Добавляем элементы в главный лейаут ---
        main_layout.addWidget(left_panel)
        main_layout.addWidget(separator)  # Добавляем вертикальную линию-разделитель
        main_layout.addWidget(self.right_panel, 1)

        self.setCentralWidget(central_widget)

    #########
    # USERS #
    #########
    def on_users_clicked(self):
        """
        Когда нажали кнопку 'Пользователи' — показываем таблицу юзеров.
        """
        # Удаляем все предыдущие виджеты из right_layout
        self._clear_right_layout()

        # Создаём виджет списка пользователей
        users_widget = UsersListWidget(
            self, self.show_edit_user_screen, self.show_add_user_screen
        )
        # Добавляем его в right_layout
        self.right_layout.addWidget(users_widget)

    def show_users_screen(self):
        """Показывает список пользователей"""
        self._clear_right_layout()
        users_widget = UsersListWidget(
            self, self.show_edit_user_screen, self.show_add_user_screen
        )
        self.right_layout.addWidget(users_widget)

    def show_add_user_screen(self):
        """Показывает экран добавления пользователя"""
        self._clear_right_layout()
        add_user_widget = AddUserWidget(self.show_users_screen)
        self.right_layout.addWidget(add_user_widget)

    def show_edit_user_screen(self, user_id):
        """Показывает экран редактирования пользователя."""
        self._clear_right_layout()
        edit_user_widget = EditUserWidget(user_id, self.show_users_screen)
        self.right_layout.addWidget(edit_user_widget)

    ##########
    # ORDERS #
    ##########
    def on_orders_clicked(self):
        """Открывает список заказов."""
        self._clear_right_layout()
        orders_widget = OrdersListWidget(
            self, self.show_edit_order_screen, self.show_add_order_screen
        )
        self.right_layout.addWidget(orders_widget)

    def show_add_order_screen(self):
        """Показывает экран добавления заказа."""
        self._clear_right_layout()
        add_order_widget = AddOrderWidget(self.show_orders_screen)
        self.right_layout.addWidget(add_order_widget)

    def show_edit_order_screen(self, order_id):
        """Показывает экран редактирования заказа."""
        self._clear_right_layout()
        edit_order_widget = EditOrderWidget(order_id, self.show_orders_screen)
        self.right_layout.addWidget(edit_order_widget)

    def show_orders_screen(self):
        """Показывает список заказов."""
        self._clear_right_layout()
        orders_widget = OrdersListWidget(
            self, self.show_edit_order_screen, self.show_add_order_screen
        )
        self.right_layout.addWidget(orders_widget)

    ##########
    # ABOUTS #
    ##########
    def on_about_clicked(self):
        """Открывает список отчетов."""
        self._clear_right_layout()
        abouts_widget = AboutsListWidget(
            self, self.show_add_about_screen, self.show_edit_about_screen
        )
        self.right_layout.addWidget(abouts_widget)

    def show_add_about_screen(self):
        """Показывает экран добавления отчета."""
        self._clear_right_layout()
        add_about_widget = AddAboutWidget(self.show_about_screen)
        self.right_layout.addWidget(add_about_widget)

    def show_about_screen(self):
        """Показывает список отчетов."""
        self._clear_right_layout()
        about_widget = AboutsListWidget(
            self, self.show_add_about_screen, self.show_edit_about_screen
        )
        self.right_layout.addWidget(about_widget)

    def show_edit_about_screen(self, about_id):
        """Показывает экран редактирования отчета."""
        self._clear_right_layout()
        edit_about_widget = EditAboutWidget(about_id, self.show_about_screen)
        self.right_layout.addWidget(edit_about_widget)

    #########
    # OTHER #
    #########
    def toggle_theme(self):
        """Переключает тему и сохраняет выбор"""
        is_dark = self.theme_switch.isChecked()

        if is_dark:
            self.app.setStyleSheet("")  # Сбрасываем все стили → стандартный вид PySide
        else:
            self.app.setStyleSheet(get_stylesheet(LIGHT_THEME))  # Восстанавливаем стили

        # Сохраняем выбор
        save_theme(is_dark)

    def _clear_right_layout(self):
        """
        Удаляет все виджеты из right_layout, чтобы освободить место под новый контент.
        """
        while self.right_layout.count():
            item = self.right_layout.takeAt(0)
            w = item.widget()
            if w is not None:
                w.deleteLater()  # или w.setParent(None)
