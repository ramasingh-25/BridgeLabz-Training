Use Health_Clinic;
CREATE TABLE Doctor_Audit
(
    AuditID INT IDENTITY(1,1) PRIMARY KEY,
    DoctorID INT,
    ActionType VARCHAR(20),
    ActionDate DATETIME DEFAULT GETDATE()
);

CREATE TABLE Patient_Audit
(
    AuditID INT IDENTITY(1,1) PRIMARY KEY,
    PatientID INT,
    ActionType VARCHAR(20),
    ActionDate DATETIME DEFAULT GETDATE()
);

CREATE PROCEDURE sp_InsertDoctor
(
    @FirstName VARCHAR(50),
    @LastName VARCHAR(50),
    @Specialization VARCHAR(100),
    @Phone VARCHAR(15),
    @Email VARCHAR(100)
)
AS
BEGIN
    INSERT INTO Doctor
    (
        FirstName,
        LastName,
        Specialization,
        Phone,
        Email
    )
    VALUES
    (
        @FirstName,
        @LastName,
        @Specialization,
        @Phone,
        @Email
    );
END;

SELECT COLUMN_NAME
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'Doctor';

ALTER TABLE Doctor
ADD Email VARCHAR(100);


EXEC sp_InsertDoctor
'Rahul',
'Sharma',
'Cardiologist',
'9876543510',
'rahul@gmail.com';

--update Trigger
CREATE PROCEDURE sp_UpdateDoctor
(
    @DoctorID INT,
    @Phone VARCHAR(15),
    @Email VARCHAR(100)
)
AS
BEGIN
    UPDATE Doctor
    SET
        Phone=@Phone,
        Email=@Email
    WHERE DoctorID=@DoctorID;
END;

EXEC sp_UpdateDoctor
1,
'9999999999',
'newmail@gmail.com';

--Delete Doctor

CREATE PROCEDURE sp_DeleteDoctor
(
    @DoctorID INT
)
AS
BEGIN
    DELETE FROM Doctor
    WHERE DoctorID=@DoctorID;
END;

EXEC sp_DeleteDoctor 1;

SELECT * FROM Doctor
WHERE DoctorID = 1;

SELECT *
FROM Appointment
WHERE DoctorID = 1;

CREATE OR ALTER PROCEDURE sp_DeleteDoctor
(
    @DoctorID INT
)
AS
BEGIN
    IF EXISTS (SELECT 1 FROM Doctor WHERE DoctorID = @DoctorID)
    BEGIN
        DELETE FROM Doctor
        WHERE DoctorID = @DoctorID;

        PRINT 'Doctor deleted successfully.';
    END
    ELSE
    BEGIN
        PRINT 'Doctor not found.';
    END
END;

EXEC sp_DeleteDoctor 1;
DELETE FROM Appointment
WHERE DoctorID = 1;
EXEC sp_DeleteDoctor 1;

SELECT * FROM Doctor;
SELECT * FROM Appointment;


--Doctor Triggers
CREATE TRIGGER trg_Doctor_Insert
ON Doctor
AFTER INSERT
AS
BEGIN

    INSERT INTO Doctor_Audit
    (
        DoctorID,
        ActionType
    )
    SELECT
        DoctorID,
        'INSERT'
    FROM inserted;

END;

CREATE TRIGGER trg_Doctor_Update
ON Doctor
AFTER UPDATE
AS
BEGIN

    INSERT INTO Doctor_Audit
    (
        DoctorID,
        ActionType
    )
    SELECT
        DoctorID,
        'UPDATE'
    FROM inserted;

END;

CREATE TRIGGER trg_Doctor_Delete
ON Doctor
AFTER DELETE
AS
BEGIN

    INSERT INTO Doctor_Audit
    (
        DoctorID,
        ActionType
    )
    SELECT
        DoctorID,
        'DELETE'
    FROM deleted;

END;


--check doctor audit

SELECT * FROM Doctor;

SELECT * FROM Doctor_Audit;


--Create Patient Stored Procedue
CREATE OR ALTER PROCEDURE sp_InsertPatient
(
    @FirstName VARCHAR(50),
    @LastName VARCHAR(50),
    @DateOfBirth DATE,
    @Gender VARCHAR(10),
    @Phone VARCHAR(15),
    @Address VARCHAR(255)
)
AS
BEGIN
    INSERT INTO Patient
    (
        FirstName,
        LastName,
        DateOfBirth,
        Gender,
        Phone,
        Address
    )
    VALUES
    (
        @FirstName,
        @LastName,
        @DateOfBirth,
        @Gender,
        @Phone,
        @Address
    );

    PRINT 'Patient inserted successfully.';
END;
GO

EXEC sp_InsertPatient
    @FirstName = 'Amit',
    @LastName = 'Singh',
    @DateOfBirth = '2001-05-15',
    @Gender = 'M',
    @Phone = '9876543212',
    @Address = 'Delhi';

    SELECT * FROM Patient;
GO

CREATE OR ALTER PROCEDURE sp_UpdatePatient
(
    @PatientID INT,
    @Phone VARCHAR(15),
    @Address VARCHAR(255)
)
AS
BEGIN
    UPDATE Patient
    SET
        Phone = @Phone,
        Address = @Address
    WHERE PatientID = @PatientID;
END;
GO

CREATE OR ALTER PROCEDURE sp_UpdatePatient
(
    @PatientID INT,
    @Phone VARCHAR(15),
    @Address VARCHAR(255)
)
AS
BEGIN
    UPDATE Patient
    SET
        Phone = @Phone,
        Address = @Address
    WHERE PatientID = @PatientID;

    PRINT 'Patient updated successfully.';
END;
GO

EXEC sp_UpdatePatient
    @PatientID = 1,
    @Phone = '9999999999',
    @Address = 'Lucknow';


    --Delete Patient

    CREATE PROCEDURE sp_DeletePatient
(
@PatientID INT
)

AS
BEGIN

DELETE FROM Patient
WHERE PatientID=@PatientID;

END;


CREATE TRIGGER trg_Patient_Insert
ON Patient
AFTER INSERT
AS
BEGIN

INSERT INTO Patient_Audit
(
PatientID,
ActionType
)

SELECT
PatientID,
'INSERT'
FROM inserted;

END;


--update
CREATE TRIGGER trg_Patient_Update
ON Patient
AFTER UPDATE
AS
BEGIN

INSERT INTO Patient_Audit
(
PatientID,
ActionType
)

SELECT
PatientID,
'UPDATE'
FROM inserted;

END;

--Delete
CREATE TRIGGER trg_Patient_Delete
ON Patient
AFTER DELETE
AS
BEGIN

INSERT INTO Patient_Audit
(
PatientID,
ActionType
)

SELECT
PatientID,
'DELETE'
FROM deleted;

END;

EXEC sp_InsertDoctor
'Raj',
'Kumar',
'Neurologist',
'9876540211',
'raj@gmail.com';

SELECT * FROM Doctor_Audit;
EXEC sp_UpdateDoctor
1,
'9999999999',
'doctor@gmail.com';

SELECT * FROM Doctor_Audit;

EXEC sp_DeleteDoctor 1;

SELECT * FROM Doctor_Audit;