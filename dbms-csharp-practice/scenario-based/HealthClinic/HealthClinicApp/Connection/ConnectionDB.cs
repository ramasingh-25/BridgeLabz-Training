using Microsoft.Data.SqlClient;

public static class ConnectionDB
{
    private static readonly string masterConn = "Server=localhost\\SQLEXPRESS;Database=master;Trusted_Connection=True;TrustServerCertificate=True";
    private static readonly string appConn = "Server=localhost\\SQLEXPRESS;Database=HealthClinicDB;Trusted_Connection=True;TrustServerCertificate=True";

    public static SqlConnection GetConnection() => new SqlConnection(appConn);

    public static void InitializeDatabase()
    {
        CreateDatabase();
        CreateTables();
    }

    private static void CreateDatabase()
    {
        using SqlConnection con = new SqlConnection(masterConn);
        con.Open();
        string query = "IF DB_ID('HealthClinicDB') IS NULL CREATE DATABASE HealthClinicDB";
        new SqlCommand(query, con).ExecuteNonQuery();
    }

    private static void CreateTables()
    {
        using SqlConnection con = new SqlConnection(appConn);
        con.Open();

        string query = @"
        IF OBJECT_ID('Patients') IS NULL
        CREATE TABLE Patients (
            PatientId INT IDENTITY PRIMARY KEY,
            Name NVARCHAR(100),
            DateOfBirth DATETIME,
            ContactNumber NVARCHAR(15) UNIQUE,
            Email NVARCHAR(100),
            Address NVARCHAR(255),
            BloodGroup NVARCHAR(10)
        );

        IF OBJECT_ID('Specialties') IS NULL
        CREATE TABLE Specialties (
            SpecialtyId INT IDENTITY PRIMARY KEY,
            SpecialtyName NVARCHAR(100) UNIQUE
        );

       IF OBJECT_ID('Doctors') IS NULL
    CREATE TABLE Doctors (
        DoctorId INT IDENTITY PRIMARY KEY,
        DoctorName NVARCHAR(100),
        SpecialtyId INT,
        ContactNumber NVARCHAR(15),
        ConsultationFee DECIMAL(10,2),
        IsActive BIT DEFAULT 1,
        FOREIGN KEY (SpecialtyId) REFERENCES Specialties(SpecialtyId)
    );

    IF OBJECT_ID('Appointments') IS NULL
    CREATE TABLE Appointments (
        AppointmentId INT IDENTITY PRIMARY KEY,
        PatientId INT,
        DoctorId INT, 
        AppointmentDate DATETIME,
        Status NVARCHAR(20) DEFAULT 'SCHEDULED', 
        FOREIGN KEY (PatientId) REFERENCES Patients(PatientId),
        FOREIGN KEY (DoctorId) REFERENCES Doctors(DoctorId) 
        
    );
    IF OBJECT_ID('AppointmentAudit') IS NULL
CREATE TABLE AppointmentAudit (
    AuditId INT IDENTITY PRIMARY KEY,
    AppointmentId INT,
    OldStatus NVARCHAR(20),
    NewStatus NVARCHAR(20),
    ChangedDate DATETIME DEFAULT GETDATE(),
    Action NVARCHAR(100)
);

      IF OBJECT_ID('Visits') IS NULL
CREATE TABLE Visits (
    VisitId INT IDENTITY PRIMARY KEY,
    AppointmentId INT,
    Diagnosis NVARCHAR(200),
    Prescription NVARCHAR(MAX), 
    Notes NVARCHAR(MAX),       
    VisitDate DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (AppointmentId) REFERENCES Appointments(AppointmentId)
);
IF OBJECT_ID('Prescriptions') IS NULL
CREATE TABLE Prescriptions (
    PrescriptionId INT IDENTITY PRIMARY KEY,
    VisitId INT,
    MedicineName NVARCHAR(100),
    Dosage NVARCHAR(50),
    Duration NVARCHAR(50),
    FOREIGN KEY (VisitId) REFERENCES Visits(VisitId)
);
IF OBJECT_ID('Bills') IS NULL
CREATE TABLE Bills (
    BillId INT IDENTITY PRIMARY KEY,
    VisitId INT,
    ConsultationAmount DECIMAL(10,2),
    AdditionalCharges DECIMAL(10,2),
    TotalAmount AS (ConsultationAmount + AdditionalCharges), 
    PaymentStatus NVARCHAR(20) DEFAULT 'UNPAID',
    PaymentDate DATETIME NULL,                  
    PaymentMode NVARCHAR(50) NULL,              
    FOREIGN KEY (VisitId) REFERENCES Visits(VisitId)
);

IF OBJECT_ID('PaymentTransactions') IS NULL
CREATE TABLE PaymentTransactions (
    TransactionId INT IDENTITY PRIMARY KEY,
    BillId INT,
    AmountPaid DECIMAL(10,2),
    TransactionDate DATETIME DEFAULT GETDATE(),
    PaymentMode NVARCHAR(50),
    FOREIGN KEY (BillId) REFERENCES Bills(BillId)
);
";
        new SqlCommand(query, con).ExecuteNonQuery();
        SeedSpecialties(con);
    }

    private static void SeedSpecialties(SqlConnection con)
    {
        string query = @"
        IF NOT EXISTS (SELECT 1 FROM Specialties)
        INSERT INTO Specialties (SpecialtyName)
        VALUES ('General Physician'), ('Cardiology'), ('Orthopedics'), ('Dermatology');";
        new SqlCommand(query, con).ExecuteNonQuery();
    }
}