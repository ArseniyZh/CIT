import sqlite3

from ..connection import DB_NAME


def search_abouts(query=None, start_date=None, end_date=None):
    """
    Ищет отчеты по ID отчета, ID заказа и дате оплаты.
    """
    conn = sqlite3.connect(DB_NAME)
    cursor = conn.cursor()

    sql = """
        SELECT about_id, order_id, price, payment_date
        FROM about
        WHERE 1=1
    """
    params = []

    if query:
        sql += " AND (about_id LIKE ? OR order_id LIKE ?)"
        query_param = f"%{query}%"  # LIKE-поиск
        params.extend([query_param, query_param])

    if start_date:
        sql += " AND payment_date >= ?"
        params.append(start_date)

    if end_date:
        sql += " AND payment_date <= ?"
        params.append(end_date)

    cursor.execute(sql, params)
    rows = cursor.fetchall()
    conn.close()
    return rows


def add_about(order_id, price, payment_date):
    """Добавляет новый отчет в БД."""
    conn = sqlite3.connect(DB_NAME)
    cursor = conn.cursor()
    cursor.execute(
        """
        INSERT INTO about (order_id, price, payment_date) 
        VALUES (?, ?, ?)
    """,
        (order_id, price, payment_date),
    )
    conn.commit()
    conn.close()


def get_all_orders_for_abouts():
    """Возвращает список всех заказов (чтобы выбирать в отчете)."""
    conn = sqlite3.connect(DB_NAME)
    cursor = conn.cursor()
    cursor.execute("SELECT order_id FROM orders")
    rows = cursor.fetchall()
    conn.close()
    return rows  # [(1,), (2,), (3,)]


def get_about_by_id(about_id):
    """Возвращает отчет по ID."""
    conn = sqlite3.connect(DB_NAME)
    cursor = conn.cursor()
    cursor.execute(
        "SELECT about_id, order_id, price, payment_date FROM about WHERE about_id = ?",
        (about_id,),
    )
    about = cursor.fetchone()
    conn.close()
    return about  # Вернёт (about_id, order_id, price, payment_date) или None


def update_about(about_id, price, payment_date):
    """Обновляет данные отчета в БД."""
    conn = sqlite3.connect(DB_NAME)
    cursor = conn.cursor()
    cursor.execute(
        """
        UPDATE about SET price = ?, payment_date = ? WHERE about_id = ?
    """,
        (price, payment_date, about_id),
    )
    conn.commit()
    conn.close()


def delete_about(about_id):
    """Удаляет отчет по ID."""
    conn = sqlite3.connect(DB_NAME)
    cursor = conn.cursor()
    cursor.execute("DELETE FROM about WHERE about_id = ?", (about_id,))
    conn.commit()
    conn.close()
