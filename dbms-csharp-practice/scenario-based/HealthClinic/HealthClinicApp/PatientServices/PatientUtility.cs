 using Microsoft.Data.SqlClient;
 public class PatientUtility : IPatientService
    {
        public void RegisterPatient(Patient patient)
{
    using SqlConnection con = ConnectionDB.GetConnection();

    string query = @"INSERT INTO Patients
                    (Name, DateOfBirth, ContactNumber, Email, Address, BloodGroup)
                    VALUES
                    (@Name, @DateOfBirth, @ContactNumber, @Email, @Address, @BloodGroup)";

    SqlCommand cmd = new SqlCommand(query, con);
    cmd.Parameters.AddWithValue("@Name", patient.Name);
    cmd.Parameters.AddWithValue("@DateOfBirth", patient.DateOfBirth);
    cmd.Parameters.AddWithValue("@ContactNumber", patient.ContactNumber);
    cmd.Parameters.AddWithValue("@Email", patient.Email);
    cmd.Parameters.AddWithValue("@Address", patient.Address);
    cmd.Parameters.AddWithValue("@BloodGroup", patient.BloodGroup);

    try
    {
        con.Open();
        cmd.ExecuteNonQuery();
    }
    catch (SqlException ex) when (ex.Number == 2627 || ex.Number == 2601)
    {
        // Throw your custom exception when a duplicate phone number is found
        throw new PatientAlreadyExistsException($"A patient with contact number '{patient.ContactNumber}' is already registered.");
    }
}

        public void UpdatePatient(int patientId, Patient patient)
        {
            using SqlConnection con = ConnectionDB.GetConnection();

            string query = @"UPDATE Patients SET
                            Name=@Name,
                            DateOfBirth=@DateOfBirth,
                            ContactNumber=@ContactNumber,
                            Email=@Email,
                            Address=@Address,
                            BloodGroup=@BloodGroup
                            WHERE PatientId=@PatientId";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@PatientId", patientId);
            cmd.Parameters.AddWithValue("@Name", patient.Name);
            cmd.Parameters.AddWithValue("@DateOfBirth", patient.DateOfBirth);
            cmd.Parameters.AddWithValue("@ContactNumber", patient.ContactNumber);
            cmd.Parameters.AddWithValue("@Email", patient.Email);
            cmd.Parameters.AddWithValue("@Address", patient.Address);
            cmd.Parameters.AddWithValue("@BloodGroup", patient.BloodGroup);

            con.Open();
            int rows = cmd.ExecuteNonQuery();

            if (rows == 0)
                throw new PatientNotFoundException("Patient not found.");
        }

        public List<Patient> SearchPatients(int? id, string contactnumber, string name)
        {
            List<Patient> patients = new();

            using SqlConnection con = ConnectionDB.GetConnection();

            string query = @"SELECT * FROM Patients
                             WHERE (@Id IS NULL OR PatientId = @Id)
                             AND (@ContactNumber IS NULL OR ContactNumber = @ContactNumber)
                             AND (@Name IS NULL OR Name LIKE '%' + @Name + '%')";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Id", (object?)id ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@ContactNumber", (object?)contactnumber ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Name", (object?)name ?? DBNull.Value);

            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                patients.Add(new Patient
                {
                    PatientId = (int)reader["PatientId"],
                    Name = reader["Name"].ToString(),
                    DateOfBirth = (DateTime)reader["DateOfBirth"],
                    ContactNumber = reader["ContactNumber"].ToString(),
                    Email = reader["Email"].ToString(),
                    Address = reader["Address"].ToString(),
                    BloodGroup = reader["BloodGroup"].ToString()
                });
            }

            return patients;
        }
        public List<VisitHistory> GetPatientVisitHistory(int patientId)
{
    List<VisitHistory> visits = new();

    using SqlConnection con = ConnectionDB.GetConnection();

    string query = @"
        SELECT 
            a.DoctorName,
            v.Diagnosis,
            v.VisitDate
        FROM Appointments a
        JOIN Visits v ON a.AppointmentId = v.AppointmentId
        WHERE a.PatientId = @PatientId
        ORDER BY v.VisitDate";

    SqlCommand cmd = new SqlCommand(query, con);
    cmd.Parameters.AddWithValue("@PatientId", patientId);

    con.Open();
    SqlDataReader reader = cmd.ExecuteReader();

    while (reader.Read())
    {
        visits.Add(new VisitHistory
        {
            DoctorName = reader["DoctorName"].ToString(),
            Diagnosis = reader["Diagnosis"].ToString(),
            VisitDate = (DateTime)reader["VisitDate"]
        });
    }

    return visits;
}
public void RecordPatientVisit(int appointmentId, string diagnosis, string prescription, string notes)
{
    using SqlConnection con = ConnectionDB.GetConnection();
    con.Open();

    SqlTransaction transaction = con.BeginTransaction();

    try
    {
        // 1. Insert into Visits table
        string visitQuery = @"
            INSERT INTO Visits (AppointmentId, Diagnosis, Prescription, Notes, VisitDate)
            VALUES (@AppId, @Diagnosis, @Prescription, @Notes, GETDATE())";

        using (SqlCommand vCmd = new SqlCommand(visitQuery, con, transaction))
        {
            vCmd.Parameters.AddWithValue("@AppId", appointmentId);
            vCmd.Parameters.AddWithValue("@Diagnosis", diagnosis);
            vCmd.Parameters.AddWithValue("@Prescription", prescription);
            vCmd.Parameters.AddWithValue("@Notes", notes);
            vCmd.ExecuteNonQuery();
        }

        // 2. Update Appointment status to 'COMPLETED'
        string updateQuery = "UPDATE Appointments SET Status = 'COMPLETED' WHERE AppointmentId = @AppId";
        
        using (SqlCommand uCmd = new SqlCommand(updateQuery, con, transaction))
        {
            uCmd.Parameters.AddWithValue("@AppId", appointmentId);
            int rows = uCmd.ExecuteNonQuery();
            if (rows == 0) throw new Exception("Appointment record not found.");
        }

        transaction.Commit();
        Console.WriteLine("Visit recorded and appointment marked as completed.");
    }
    catch (Exception)
    {
        transaction.Rollback();
        throw;
    }
}
public List<VisitHistory> GetDetailedMedicalHistory(int patientId)
{
    List<VisitHistory> history = new();
    using SqlConnection con = ConnectionDB.GetConnection();

    // JOIN between Appointments and Visits to get the full clinical picture
    string query = @"
        SELECT 
            A.DoctorId, 
            D.DoctorName,
            V.Diagnosis, 
            V.Prescription, 
            V.Notes, 
            V.VisitDate
        FROM Visits V
        JOIN Appointments A ON V.AppointmentId = A.AppointmentId
        JOIN Doctors D ON A.DoctorId = D.DoctorId
        WHERE A.PatientId = @PatientId
        ORDER BY V.VisitDate DESC";

    SqlCommand cmd = new SqlCommand(query, con);
    cmd.Parameters.AddWithValue("@PatientId", patientId);

    con.Open();
    using SqlDataReader reader = cmd.ExecuteReader();

    while (reader.Read())
    {
        history.Add(new VisitHistory
        {
            DoctorName = reader["DoctorName"].ToString(),
            Diagnosis = reader["Diagnosis"].ToString(),
            Prescription = reader["Prescription"].ToString(),
            Notes = reader["Notes"].ToString(),
            VisitDate = (DateTime)reader["VisitDate"]
        });
    }
    return history;
}
public void AddPrescriptionBatch(int visitId, List<PrescriptionEntry> medicines)
{
    if (medicines == null || medicines.Count == 0) return;

    using SqlConnection con = ConnectionDB.GetConnection();
    con.Open();

    // Batch Insert logic
    using (SqlTransaction transaction = con.BeginTransaction())
    {
        try
        {
            foreach (var med in medicines)
            {
                string query = @"
                    INSERT INTO Prescriptions (VisitId, MedicineName, Dosage, Duration)
                    VALUES (@VisitId, @MedName, @Dosage, @Duration)";

                using (SqlCommand cmd = new SqlCommand(query, con, transaction))
                {
                    cmd.Parameters.AddWithValue("@VisitId", visitId);
                    cmd.Parameters.AddWithValue("@MedName", med.MedicineName);
                    cmd.Parameters.AddWithValue("@Dosage", med.Dosage);
                    cmd.Parameters.AddWithValue("@Duration", med.Duration);
                    cmd.ExecuteNonQuery();
                }
            }
            transaction.Commit();
            Console.WriteLine($"{medicines.Count} medicines added to prescription successfully.");
        }
        catch (Exception)
        {
            transaction.Rollback();
            throw;
        }
    }
}
    }