import sqlite3

from ..connection import DB_NAME


def get_all_users():
    """Возвращает список всех пользователей из таблицы 'users'."""
    conn = sqlite3.connect(DB_NAME)
    cursor = conn.cursor()

    cursor.execute("SELECT user_id, car_number, car_brand FROM users")
    rows = cursor.fetchall()
    conn.close()

    # rows будет списком кортежей [(1, 12345, 'Toyota'), (2, 67890, 'BMW'), ...]
    return rows


def search_users(query):
    """
    Ищет пользователей по user_id, car_number или car_brand.
    Поддерживает частичное совпадение.
    """
    conn = sqlite3.connect(DB_NAME)
    cursor = conn.cursor()

    query = f"%{query}%"  # Добавляем LIKE-дикий символ для поиска в середине строки
    cursor.execute(
        """
        SELECT user_id, car_number, car_brand
        FROM users
        WHERE user_id LIKE ? OR car_number LIKE ? OR car_brand LIKE ?
    """,
        (query, query, query),
    )

    rows = cursor.fetchall()
    conn.close()
    return rows


def add_user(car_number, car_brand):
    """
    Добавляет нового пользователя в БД.
    """
    conn = sqlite3.connect(DB_NAME)
    cursor = conn.cursor()

    try:
        cursor.execute(
            """
            INSERT INTO users (car_number, car_brand) VALUES (?, ?)
        """,
            (car_number, car_brand),
        )
        conn.commit()
    except sqlite3.IntegrityError:
        print("Ошибка: Такой номер машины уже существует!")
    finally:
        conn.close()


def get_user_by_id(user_id):
    """Возвращает пользователя по его ID."""
    conn = sqlite3.connect(DB_NAME)
    cursor = conn.cursor()
    cursor.execute(
        "SELECT user_id, car_number, car_brand FROM users WHERE user_id = ?", (user_id,)
    )
    user = cursor.fetchone()
    conn.close()
    return user  # Вернёт (id, car_number, car_brand) или None


def update_user(user_id, new_car_number, new_car_brand):
    """Обновляет данные пользователя в БД."""
    conn = sqlite3.connect(DB_NAME)
    cursor = conn.cursor()
    cursor.execute(
        """
        UPDATE users SET car_number = ?, car_brand = ? WHERE user_id = ?
    """,
        (new_car_number, new_car_brand, user_id),
    )
    conn.commit()
    conn.close()


def delete_user(user_id):
    """Удаляет пользователя по ID."""
    conn = sqlite3.connect(DB_NAME)
    cursor = conn.cursor()
    cursor.execute("DELETE FROM users WHERE user_id = ?", (user_id,))
    conn.commit()
    conn.close()
