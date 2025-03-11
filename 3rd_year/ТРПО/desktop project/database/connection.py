import os
import sqlite3

DB_NAME = "admin_panel.db"


def init_db():
    """
    Проверяет, существует ли файл БД.
    Если нет – создаёт его и все необходимые таблицы.
    Если таблицы пустые, заполняет их моковыми данными.
    """
    is_new_db = not os.path.exists(DB_NAME)

    conn = sqlite3.connect(DB_NAME)
    cursor = conn.cursor()

    # Создание таблиц
    cursor.execute(
        """
        CREATE TABLE IF NOT EXISTS users (
            user_id INTEGER PRIMARY KEY AUTOINCREMENT,
            car_number TEXT UNIQUE NOT NULL,
            car_brand TEXT
        )
        """
    )

    cursor.execute(
        """
        CREATE TABLE IF NOT EXISTS orders (
            order_id INTEGER PRIMARY KEY AUTOINCREMENT,
            user_id INTEGER,
            checkin_date TEXT,
            checkout_date TEXT,
            FOREIGN KEY (user_id) REFERENCES users(user_id)
        )
        """
    )

    cursor.execute(
        """
        CREATE TABLE IF NOT EXISTS about (
            about_id INTEGER PRIMARY KEY AUTOINCREMENT,
            order_id INTEGER,
            price REAL,
            payment_date TEXT,
            FOREIGN KEY (order_id) REFERENCES orders(order_id)
        )
        """
    )

    conn.commit()

    if is_new_db:
        print("База данных не найдена. Создаём новую и заполняем тестовыми данными...")

        # Добавляем пользователей
        cursor.executemany(
            """
            INSERT INTO users (car_number, car_brand)
            VALUES (?, ?)
            """,
            [
                ("А123ВЕ77", "Toyota"),
                ("М456ОР99", "BMW"),
                ("С789КТ55", "Mercedes"),
            ],
        )

        # Получаем ID добавленных пользователей
        cursor.execute("SELECT user_id FROM users")
        user_ids = [row[0] for row in cursor.fetchall()]

        # Добавляем заказы
        orders_data = [
            (user_ids[0], "2024-06-10", "2024-06-15"),
            (user_ids[1], "2024-06-20", "2024-06-25"),
            (user_ids[2], "2024-07-01", "2024-07-05"),
        ]
        cursor.executemany(
            """
            INSERT INTO orders (user_id, checkin_date, checkout_date)
            VALUES (?, ?, ?)
            """,
            orders_data,
        )

        # Получаем ID добавленных заказов
        cursor.execute("SELECT order_id FROM orders")
        order_ids = [row[0] for row in cursor.fetchall()]

        # Добавляем отчёты
        about_data = [
            (order_ids[0], 5000.00, "2024-06-15"),
            (order_ids[1], 7000.00, "2024-06-25"),
            (order_ids[2], 9000.00, "2024-07-05"),
        ]
        cursor.executemany(
            """
            INSERT INTO about (order_id, price, payment_date)
            VALUES (?, ?, ?)
            """,
            about_data,
        )

        conn.commit()
        print("База данных успешно создана и заполнена тестовыми данными.")

    else:
        print("База данных уже существует – ничего создавать не нужно.")

    conn.close()
