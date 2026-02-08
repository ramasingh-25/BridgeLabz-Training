using Microsoft.Data.SqlClient;
 public class DoctorUtility : IDoctorService
    {
        public void AddDoctor(Doctor doctor)
{
    if (doctor.ConsultationFee <= 0)
        throw new DoctorException("Consultation fee must be greater than zero.");

    using SqlConnection con = ConnectionDB.GetConnection();
    con.Open();

    // 1. Validate that the SpecialtyId exists to prevent the Foreign Key conflict
    string checkSpecialty = "SELECT COUNT(1) FROM Specialties WHERE SpecialtyId = @SpecialtyId";
    using (SqlCommand checkCmd = new SqlCommand(checkSpecialty, con))
    {
        checkCmd.Parameters.AddWithValue("@SpecialtyId", doctor.SpecialtyId);
        int exists = (int)checkCmd.ExecuteScalar();

        if (exists == 0)
        {
            throw new DoctorException($"Invalid Specialty ID: {doctor.SpecialtyId}. Please choose a valid specialty from the list.");
        }
    }

    // 2. Proceed with the INSERT if validation passes
    string query = @"
        INSERT INTO Doctors
        (DoctorName, SpecialtyId, ContactNumber, ConsultationFee)
        VALUES
        (@Name, @SpecialtyId, @Contact, @Fee)";

    using (SqlCommand cmd = new SqlCommand(query, con))
    {
        cmd.Parameters.AddWithValue("@Name", doctor.Name);
        cmd.Parameters.AddWithValue("@SpecialtyId", doctor.SpecialtyId);
        cmd.Parameters.AddWithValue("@Contact", doctor.Contact);
        cmd.Parameters.AddWithValue("@Fee", doctor.ConsultationFee);

        cmd.ExecuteNonQuery();
    }
}
        public void AssignOrUpdateDoctorSpecialty()
        {
            using SqlConnection conn = ConnectionDB.GetConnection();
            conn.Open();

            SqlTransaction transaction = conn.BeginTransaction();

            try
            {
                Console.WriteLine("\n--- Available Specialties ---");

                string fetchSpecialties = "SELECT SpecialtyId, SpecialtyName FROM Specialties";
                using (SqlCommand cmd = new SqlCommand(fetchSpecialties, conn, transaction))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader["SpecialtyId"]} - {reader["SpecialtyName"]}");
                    }
                }

                Console.Write("\nEnter Doctor ID: ");
                int doctorId = int.Parse(Console.ReadLine());

                Console.Write("Enter Specialty ID to assign/update: ");
                int specialtyId = int.Parse(Console.ReadLine());

                string updateQuery = @"
                    UPDATE Doctors 
                    SET SpecialtyId = @SpecialtyId 
                    WHERE DoctorId = @DoctorId";

                using SqlCommand updateCmd = new SqlCommand(updateQuery, conn, transaction);
                updateCmd.Parameters.AddWithValue("@DoctorId", doctorId);
                updateCmd.Parameters.AddWithValue("@SpecialtyId", specialtyId);

                int rows = updateCmd.ExecuteNonQuery();

                if (rows == 0)
                {
                    throw new DoctorException("Doctor ID not found.");
                }

                transaction.Commit();
                Console.WriteLine(" Doctor specialty assigned/updated successfully.");
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                Console.WriteLine($" Error: {ex.Message}");
            }
        }
        public void ViewDoctorsBySpecialty(string specialtyName)
{
    using SqlConnection con = ConnectionDB.GetConnection();
    
    // JOIN query to get doctor details along with their specialty name
    string query = @"
        SELECT d.DoctorName, s.SpecialtyName, d.ContactNumber, d.ConsultationFee
        FROM Doctors d
        JOIN Specialties s ON d.SpecialtyId = s.SpecialtyId
        WHERE s.SpecialtyName LIKE @SpecialtyName";

    SqlCommand cmd = new SqlCommand(query, con);
    cmd.Parameters.AddWithValue("@SpecialtyName", "%" + specialtyName + "%");

    con.Open();
    using SqlDataReader reader = cmd.ExecuteReader();

    Console.WriteLine($"\n--- Doctors specialized in: {specialtyName} ---");
    bool found = false;
    while (reader.Read())
    {
        found = true;
        Console.WriteLine($"Name: {reader["DoctorName"]} | Contact: {reader["ContactNumber"]} | Fee: {reader["ConsultationFee"]:C}");
    }

    if (!found)
    {
        Console.WriteLine("No doctors found for this specialty.");
    }
}
public void DeactivateDoctor(int doctorId)
{
    using SqlConnection con = ConnectionDB.GetConnection();
    con.Open();

    string checkQuery = @"
        SELECT COUNT(*) FROM Appointments 
        WHERE DoctorName = (SELECT DoctorName FROM Doctors WHERE DoctorId = @Id)
        AND AppointmentDate >= GETDATE()";

    using (SqlCommand checkCmd = new SqlCommand(checkQuery, con))
    {
        checkCmd.Parameters.AddWithValue("@Id", doctorId);
        int futureAppointments = (int)checkCmd.ExecuteScalar();

        if (futureAppointments > 0)
        {
            throw new DoctorException($"Cannot deactivate doctor. There are {futureAppointments} scheduled future appointments.");
        }
    }

    string updateQuery = "UPDATE Doctors SET IsActive = 0 WHERE DoctorId = @Id";
    using (SqlCommand updateCmd = new SqlCommand(updateQuery, con))
    {
        updateCmd.Parameters.AddWithValue("@Id", doctorId);
        int rows = updateCmd.ExecuteNonQuery();

        if (rows == 0) throw new DoctorException("Doctor ID not found.");
    }
}
    }