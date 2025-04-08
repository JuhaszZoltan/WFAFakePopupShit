CREATE DATABASE taskdb;
USE taskdb;

CREATE TABLE tasks (
[id] INT PRIMARY KEY IDENTITY,
[timestamp] DATETIME NOT NULL DEFAULT GETDATE(),
[text] TEXT NULL,
[checked] BIT NOT NULL DEFAULT 0);

INSERT INTO tasks ([text], [checked]) VALUES
('first test', 0),
('second test', 1),
('third test', 1);
