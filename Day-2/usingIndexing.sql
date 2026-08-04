Use Health_Clinic;
INSERT INTO Doctor (FirstName, LastName, Specialization, Phone)
VALUES
('Rajesh', 'Sharma', 'Cardiologist', '9876543210'),
('Priya', 'Verma', 'Dermatologist', '9876543211'),
('Amit', 'Gupta', 'Orthopedic', '9876543212'),
('Neha', 'Singh', 'Pediatrician', '9876543213'),
('Rohit', 'Mehta', 'Neurologist', '9876543214'),
('Anjali', 'Kapoor', 'Gynecologist', '9876543215'),
('Vikas', 'Yadav', 'ENT Specialist', '9876543216'),
('Pooja', 'Mishra', 'Ophthalmologist', '9876543217'),
('Sandeep', 'Agarwal', 'General Physician', '9876543218'),
('Kavita', 'Joshi', 'Psychiatrist', '9876543219');
INSERT INTO Patient
(FirstName, LastName, DateOfBirth, Gender, Phone, Address)
VALUES
('Rahul', 'Singh', '1998-05-10', 'M', '9123456780', 'Lucknow'),
('Sneha', 'Sharma', '1995-08-21', 'F', '9123456781', 'Kanpur'),
('Arjun', 'Verma', '2000-11-15', 'M', '9123456782', 'Delhi'),
('Riya', 'Gupta', '1997-03-18', 'F', '9123456783', 'Noida'),
('Karan', 'Yadav', '1992-07-30', 'M', '9123456784', 'Agra'),
('Pooja', 'Mishra', '1999-12-05', 'F', '9123456785', 'Prayagraj'),
('Aman', 'Tiwari', '1994-01-25', 'M', '9123456786', 'Varanasi'),
('Nisha', 'Kapoor', '1996-09-12', 'F', '9123456787', 'Jaipur'),
('Deepak', 'Pandey', '1993-06-08', 'M', '9123456788', 'Bhopal'),
('Ananya', 'Saxena', '2001-02-14', 'F', '9123456789', 'Gurugram');

INSERT INTO Appointment
(PatientID, DoctorID, AppointmentDate, TimeSlot, Status)
VALUES
(1, 1, '2026-08-05', '09:00:00', 'Scheduled'),
(2, 2, '2026-08-05', '10:00:00', 'Completed'),
(3, 3, '2026-08-06', '11:00:00', 'Cancelled'),
(4, 4, '2026-08-06', '12:00:00', 'Scheduled'),
(5, 5, '2026-08-07', '09:30:00', 'Scheduled'),
(6, 6, '2026-08-07', '10:30:00', 'Completed'),
(7, 7, '2026-08-08', '11:30:00', 'Scheduled'),
(8, 8, '2026-08-08', '01:00:00', 'Cancelled'),
(9, 9, '2026-08-09', '02:00:00', 'Scheduled'),
(10, 10, '2026-08-09', '03:00:00', 'Completed');

SELECT * FROM Doctor;

SELECT * FROM Patient;

SELECT * FROM Appointment;

--ASSIGNMENT DAY-2

--Extend the Health Clinic schema: add a rooms table and a doctor_room relationship
--reflecting doctors assigned to specific consultation rooms.

CREATE TABLE Room
(
    RoomID INT IDENTITY(1,1) PRIMARY KEY,
    RoomNumber VARCHAR(10) NOT NULL UNIQUE,
    Floor INT NOT NULL,
    RoomType VARCHAR(50) NOT NULL
);

CREATE TABLE Doctor_Room
(
    DoctorID INT NOT NULL,
    RoomID INT NOT NULL,

    PRIMARY KEY (DoctorID, RoomID),

    FOREIGN KEY (DoctorID)
        REFERENCES Doctor(DoctorID)
        ON DELETE CASCADE,

    FOREIGN KEY (RoomID)
        REFERENCES Room(RoomID)
        ON DELETE CASCADE
);

INSERT INTO Room (RoomNumber, Floor, RoomType)
VALUES
('R101',1,'Consultation'),
('R102',1,'Consultation'),
('R201',2,'Emergency'),
('R202',2,'ICU'),
('R301',3,'Operation Theatre');

INSERT INTO Doctor_Room (DoctorID, RoomID)
VALUES
(1,1),
(2,2),
(3,3),
(4,1),
(5,4),
(6,5),
(7,2),
(8,3),
(9,1),
(10,5);

SELECT * FROM Room;

SELECT * FROM Doctor_Room;

SELECT
    D.DoctorID,
    D.FirstName + ' ' + D.LastName AS DoctorName,
    D.Specialization,
    R.RoomNumber,
    R.RoomType,
    R.Floor
FROM Doctor D
JOIN Doctor_Room DR
    ON D.DoctorID = DR.DoctorID
JOIN Room R
    ON DR.RoomID = R.RoomID;

--Write and run EXPLAIN on at least 3 different queries against the appointments table —
--one with no index, one using a single-column index, one using the composite index — and
--note the differences in the type and rows columns.

    SELECT *
FROM Appointment
WHERE AppointmentDate = '2026-08-05';

CREATE INDEX IX_Appointment_Date
ON Appointment(AppointmentDate);

SELECT *
FROM Appointment
WHERE AppointmentDate = '2026-08-05';

CREATE INDEX IX_Doctor_Date
ON Appointment(DoctorID, AppointmentDate);

SELECT *
FROM Appointment
WHERE DoctorID = 1
AND AppointmentDate = '2026-08-05';

SELECT *
FROM Appointment
WHERE AppointmentDate = '2026-08-05';

--Take the patient_phones design and verify it satisfies 1NF, 2NF, and 3NF — write a short
--justification for each.

CREATE TABLE Patient_Phone
(
    PhoneID INT IDENTITY(1,1) PRIMARY KEY,
    PatientID INT NOT NULL,
    PhoneNumber VARCHAR(15) NOT NULL UNIQUE,

    CONSTRAINT FK_PatientPhone_Patient
    FOREIGN KEY (PatientID)
    REFERENCES Patient(PatientID)
    ON DELETE CASCADE
);

INSERT INTO Patient_Phone (PatientID, PhoneNumber)
VALUES
(1,'9876500001'),
(1,'9876500002'),
(2,'9876500003'),
(3,'9876500004'),
(3,'9876500005'),
(4,'9876500006'),
(5,'9876500007'),
(6,'9876500008'),
(7,'9876500009'),
(8,'9876500010');

SELECT *
FROM Patient_Phone;

--Q4
--Create a covering index for a query that reports doctor_id, appointment_date,
--status from the appointments table, and verify with EXPLAIN that Extra shows Using
--index.

SELECT DoctorID, AppointmentDate, Status
FROM Appointment
WHERE DoctorID = 1;

CREATE NONCLUSTERED INDEX IX_Appointment_Covering
ON Appointment (DoctorID)
INCLUDE (AppointmentDate, Status);

SELECT
    DoctorID,
    AppointmentDate,
    Status
FROM Appointment
WHERE DoctorID = 1;

CREATE INDEX IX_Doctor
ON Appointment(DoctorID);

SELECT
DoctorID,
AppointmentDate,
Status
FROM Appointment
WHERE DoctorID = 1;

SET STATISTICS IO ON;
GO

SELECT
    DoctorID,
    AppointmentDate,
    Status
FROM Appointment
WHERE DoctorID = 1;
GO

SET STATISTICS IO OFF;


