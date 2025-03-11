import sqlite3

from ..connection import DB_NAME


def search_orders(
    query=None,
    checkin_date_from=None,
    checkin_date_to=None,
    checkout_date_from=None,
    checkout_date_to=None,
):
    """
    Ищет заказы по ID заказа, ID пользователя, дате заезда и дате выезда.
    Поддерживает поиск по диапазону дат.
    """
    conn = sqlite3.connect(DB_NAME)
    cursor = conn.cursor()

    sql = """
        SELECT order_id, user_id, checkin_date, checkout_date
        FROM orders
        WHERE 1=1
    """
    params = []

    if query:
        sql += " AND (order_id LIKE ? OR user_id LIKE ?)"
        query_param = f"%{query}%"
        params.extend([query_param, query_param])

    # Фильтрация по дате заезда
    if checkin_date_from and checkin_date_to:
        sql += " AND checkin_date BETWEEN ? AND ?"
        params.extend([checkin_date_from, checkin_date_to])
    elif checkin_date_from:
        sql += " AND checkin_date >= ?"
        params.append(checkin_date_from)
    elif checkin_date_to:
        sql += " AND checkin_date <= ?"
        params.append(checkin_date_to)

    # Фильтрация по дате выезда
    if checkout_date_from and checkout_date_to:
        sql += " AND checkout_date BETWEEN ? AND ?"
        params.extend([checkout_date_from, checkout_date_to])
    elif checkout_date_from:
        sql += " AND checkout_date >= ?"
        params.append(checkout_date_from)
    elif checkout_date_to:
        sql += " AND checkout_date <= ?"
        params.append(checkout_date_to)

    cursor.execute(sql, params)
    rows = cursor.fetchall()
    conn.close()
    return rows


def add_order(user_id, checkin_date, checkout_date):
    """Добавляет новый заказ в БД."""
    conn = sqlite3.connect(DB_NAME)
    cursor = conn.cursor()
    cursor.execute(
        """
        INSERT INTO orders (user_id, checkin_date, checkout_date) 
        VALUES (?, ?, ?)
    """,
        (user_id, checkin_date, checkout_date),
    )
    conn.commit()
    conn.close()


def get_all_users_for_orders():
    """Возвращает список всех пользователей (для выбора в заказе)."""
    conn = sqlite3.connect(DB_NAME)
    cursor = conn.cursor()
    cursor.execute("SELECT user_id, car_number FROM users")
    rows = cursor.fetchall()
    conn.close()
    return rows  # [(1, 'А123ВЕ777'), (2, 'О999ХТ99')]


def get_order_by_id(order_id):
    """Возвращает заказ по ID."""
    conn = sqlite3.connect(DB_NAME)
    cursor = conn.cursor()
    cursor.execute(
        "SELECT order_id, user_id, checkin_date, checkout_date FROM orders WHERE order_id = ?",
        (order_id,),
    )
    order = cursor.fetchone()
    conn.close()
    return order  # Вернёт (order_id, user_id, checkin_date, checkout_date) или None


def update_order(order_id, checkin_date, checkout_date):
    """Обновляет данные заказа в БД."""
    conn = sqlite3.connect(DB_NAME)
    cursor = conn.cursor()
    cursor.execute(
        """
        UPDATE orders SET checkin_date = ?, checkout_date = ? WHERE order_id = ?
    """,
        (checkin_date, checkout_date, order_id),
    )
    conn.commit()
    conn.close()


def delete_order(order_id):
    """Удаляет заказ по ID."""
    conn = sqlite3.connect(DB_NAME)
    cursor = conn.cursor()
    cursor.execute("DELETE FROM orders WHERE order_id = ?", (order_id,))
    conn.commit()
    conn.close()
