using Microsoft.Data.Sqlite;
using System.IO;

namespace agency.Data;

public static class Database
{
    private static readonly string _dbPath = "agency.db";

    public static SqliteConnection GetConnection()
    {
        if (!File.Exists(_dbPath))
        {
            CreateDatabase();
        }

        return new SqliteConnection($"Data Source={_dbPath}");
    }

    private static void CreateDatabase()
    {
        using var connection = new SqliteConnection($"Data Source={_dbPath}");
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText =
        @"
        -- Агенты
        CREATE TABLE Agents (
            Id INTEGER PRIMARY KEY,
            LastName TEXT NOT NULL,
            FirstName TEXT NOT NULL,
            MiddleName TEXT,
            Password TEXT NOT NULL,
            CommissionRate REAL NOT NULL
        );

        -- Клиенты
        CREATE TABLE Clients (
            Id INTEGER PRIMARY KEY,
            LastName TEXT NOT NULL,
            FirstName TEXT NOT NULL,
            MiddleName TEXT,
            Password TEXT NOT NULL,
            Phone TEXT NOT NULL,
            Email TEXT
        );

        -- Адреса объектов
        CREATE TABLE Addresses (
            Id INTEGER PRIMARY KEY,
            City TEXT NOT NULL,
            Street TEXT NOT NULL,
            House TEXT NOT NULL,
            Building TEXT
        );

        -- Квартиры
        CREATE TABLE Apartments (
            Id INTEGER PRIMARY KEY,
            Area REAL NOT NULL,
            Rooms INTEGER NOT NULL,
            Floor INTEGER NOT NULL
        );

        -- Районы
        CREATE TABLE Districts (
            Id INTEGER PRIMARY KEY,
            Name TEXT NOT NULL,
            Area TEXT NOT NULL
        );

        -- Дома
        CREATE TABLE Houses (
            Id INTEGER PRIMARY KEY,
            Floors INTEGER NOT NULL,
            Area REAL NOT NULL
        );

        -- Земельные участки
        CREATE TABLE Lands (
            Id INTEGER PRIMARY KEY,
            Area INTEGER NOT NULL
        );

        -- Сделки
        CREATE TABLE Deals (
            Id INTEGER PRIMARY KEY,
            Title TEXT NOT NULL
        );
        ";

        command.ExecuteNonQuery();
        
        // --- Затем заполняем таблицы начальными данными ---
        var insertDataCmd = connection.CreateCommand();
        insertDataCmd.CommandText =
        @"
        INSERT INTO Agents (LastName, FirstName, MiddleName, Password, CommissionRate) VALUES
        ('Иванов', 'Иван', 'Петрович', 'pass123', 0.05),
        ('Петрова', 'Анна', 'Сергеевна', 'secure456', 0.06),
        ('Сидоров', 'Олег', 'Николаевич', 'qwerty789', 0.07);

        INSERT INTO Clients (LastName, FirstName, MiddleName, Password, Phone, Email) VALUES
        ('Смирнов', 'Алексей', 'Игоревич', 'pass1', '+79001234567', 'smirnov@mail.com'),
        ('Кузнецова', 'Елена', 'Андреевна', 'pass2', '+79007654321', 'kuznetsova@yandex.ru'),
        ('Попов', 'Михаил', 'Олегович', 'pass3', '+79009876543', 'popov@gmail.com');

        INSERT INTO Addresses (City, Street, House, Building) VALUES
        ('Казань', 'Ленина', '10', 'А'),
        ('Москва', 'Тверская', '15', NULL),
        ('Сочи', 'Горная', '8', 'Б');

        INSERT INTO Apartments (Area, Rooms, Floor) VALUES
        (55.3, 2, 3),
        (72.1, 3, 5),
        (38.7, 1, 2);

        INSERT INTO Districts (Name, Area) VALUES
        ('Советский', '55.75, 49.14'),
        ('Вахитовский', '55.78, 49.12'),
        ('Приволжский', '55.70, 49.25');

        INSERT INTO Houses (Floors, Area) VALUES
        (2, 120.5),
        (1, 95.0),
        (3, 150.3);

        INSERT INTO Lands (Area) VALUES
        (1500),
        (2000),
        (1800);

        INSERT INTO Deals (Title) VALUES
        ('Казань, Баумана, до 5 млн'),
        ('Уфа, Ленина, до 3 млн');
        ";
        insertDataCmd.ExecuteNonQuery();
    }
}
