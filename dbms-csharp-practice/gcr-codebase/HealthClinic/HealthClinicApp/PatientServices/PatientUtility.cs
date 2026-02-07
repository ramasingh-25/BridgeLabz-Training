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

            con.Open();
            cmd.ExecuteNonQuery();
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

        // ✅ UC-1.3 SEARCH
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
    }