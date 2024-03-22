BEGIN
CREATE DATABASE Olympiads;
END
GO

BEGIN
USE Olympiads;
END
GO


-- Создание таблицы школ
CREATE TABLE Schools (
    SchoolID INT PRIMARY KEY,
    SchoolName VARCHAR(255),
    Location VARCHAR(255)
);
-- Создание таблицы участников
CREATE TABLE Participants (
    ParticipantID INT PRIMARY KEY,
    FirstName VARCHAR(255),
    LastName VARCHAR(255),
    Gender VARCHAR(10),
    DateOfBirth DATE,
    SchoolID INT,
	FOREIGN KEY (SchoolID) REFERENCES Schools(SchoolID)
);

-- Создание таблицы олимпиад
CREATE TABLE Olympiads (
    OlympiadID INT PRIMARY KEY,
    OlympiadName VARCHAR(255),
    OlympiadDate DATE,
    Location VARCHAR(255)
);

-- Создание таблицы участников олимпиады
CREATE TABLE OlympiadParticipants (
    OlympiadParticipantID INT PRIMARY KEY,
    ParticipantID INT,
    OlympiadID INT,
    FOREIGN KEY (ParticipantID) REFERENCES Participants(ParticipantID),
    FOREIGN KEY (OlympiadID) REFERENCES Olympiads(OlympiadID)
);

-- Создание таблицы результатов
CREATE TABLE Results (
    ResultID INT PRIMARY KEY,
    ParticipantID INT,
    OlympiadID INT,
    Score INT,
    FOREIGN KEY (ParticipantID) REFERENCES Participants(ParticipantID),
    FOREIGN KEY (OlympiadID) REFERENCES Olympiads(OlympiadID)
);

-- Создание таблицы предметов
CREATE TABLE Subjects (
    SubjectID INT PRIMARY KEY,
    SubjectName VARCHAR(255)
);

-- Создание таблицы заданий
CREATE TABLE Tasks (
    TaskID INT PRIMARY KEY,
    OlympiadID INT,
    SubjectID INT,
    TaskDescription TEXT,
    FOREIGN KEY (OlympiadID) REFERENCES Olympiads(OlympiadID),
    FOREIGN KEY (SubjectID) REFERENCES Subjects(SubjectID)
);
