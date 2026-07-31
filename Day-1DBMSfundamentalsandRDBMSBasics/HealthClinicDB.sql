use Health_Clinic;
-- Doctor Table
CREATE TABLE Doctor
(
    DoctorID INT IDENTITY(1,1) PRIMARY KEY,
    FirstName VARCHAR(50) NOT NULL,
    LastName VARCHAR(50) NOT NULL,
    Specialization VARCHAR(100) NOT NULL,
    Phone VARCHAR(15) UNIQUE
);

-- Patient Table
CREATE TABLE Patient
(
    PatientID INT IDENTITY(1,1) PRIMARY KEY,
    FirstName VARCHAR(50) NOT NULL,
    LastName VARCHAR(50) NOT NULL,
    DateOfBirth DATE NOT NULL,
    Gender CHAR(1) CHECK (Gender IN ('M','F','O')),
    Phone VARCHAR(15) UNIQUE,
    Address VARCHAR(200)
);

-- Appointment Table
CREATE TABLE Appointment
(
    AppointmentID INT IDENTITY(1,1) PRIMARY KEY,

    PatientID INT NOT NULL,

    DoctorID INT NOT NULL,

    AppointmentDate DATE NOT NULL,

    TimeSlot TIME NOT NULL,

    Status VARCHAR(20) NOT NULL
        CONSTRAINT DF_Appointment_Status
        DEFAULT ('Scheduled'),

    CONSTRAINT FK_Appointment_Patient
        FOREIGN KEY (PatientID)
        REFERENCES Patient(PatientID),

    CONSTRAINT FK_Appointment_Doctor
        FOREIGN KEY (DoctorID)
        REFERENCES Doctor(DoctorID)
);