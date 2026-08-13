CREATE DATABASE ContactDB;
GO

USE ContactDB;
GO

CREATE TABLE Contacts
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Email NVARCHAR(150) NOT NULL,
    Phone NVARCHAR(20) NOT NULL
);
GO

INSERT INTO Contacts (Name, Email, Phone)
VALUES
('Rama Singh', 'rama@gmail.com', '9876543210'),
('Amit Kumar', 'amit@gmail.com', '9876543211');
GO

SELECT * FROM Contacts;

