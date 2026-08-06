using Microsoft.Data.SqlClient;
using HealthClinicApp.Entities;

namespace HealthClinicApp.Services
{
    public class HealthClinic
    {
        private readonly string connectionString =
    "Server=DESKTOP-E58U4KE\\SQLEXPRESS;Database=Health_Clinic;Trusted_Connection=True;TrustServerCertificate=True;";
        // Doctor CRUD

        // Add Doctor
        public void AddDoctor(Doctor doctor)
        {
            using SqlConnection con = new SqlConnection(connectionString);

            string query = @"INSERT INTO Doctor
                            (FirstName, LastName, Specialization, Phone, Email)
                            VALUES
                            (@FirstName, @LastName, @Specialization, @Phone, @Email)";

            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@FirstName", doctor.FirstName);
            cmd.Parameters.AddWithValue("@LastName", doctor.LastName);
            cmd.Parameters.AddWithValue("@Specialization", doctor.Specialization);
            cmd.Parameters.AddWithValue("@Phone", (object?)doctor.Phone ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Email", (object?)doctor.Email ?? DBNull.Value);

            con.Open();

            int rows = cmd.ExecuteNonQuery();

            if (rows > 0)
                Console.WriteLine("Doctor added successfully.");
            else
                Console.WriteLine("Failed to add doctor.");
        }

        // View Doctors
        public void ViewDoctors()
        {
            using SqlConnection con = new SqlConnection(connectionString);

            string query = "SELECT * FROM Doctor";

            SqlCommand cmd = new SqlCommand(query, con);

            con.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            Console.WriteLine("\n========== DOCTOR LIST ==========");

            while (reader.Read())
            {
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("Doctor ID      : " + reader["DoctorID"]);
                Console.WriteLine("First Name     : " + reader["FirstName"]);
                Console.WriteLine("Last Name      : " + reader["LastName"]);
                Console.WriteLine("Specialization : " + reader["Specialization"]);
                Console.WriteLine("Phone          : " + reader["Phone"]);
                Console.WriteLine("Email          : " + reader["Email"]);
            }

            reader.Close();
        }
                // Update Doctor
        public void UpdateDoctor(Doctor doctor)
        {
            using SqlConnection con = new SqlConnection(connectionString);

            string query = @"UPDATE Doctor
                             SET FirstName=@FirstName,
                                 LastName=@LastName,
                                 Specialization=@Specialization,
                                 Phone=@Phone,
                                 Email=@Email
                             WHERE DoctorID=@DoctorID";

            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@DoctorID", doctor.DoctorID);
            cmd.Parameters.AddWithValue("@FirstName", doctor.FirstName);
            cmd.Parameters.AddWithValue("@LastName", doctor.LastName);
            cmd.Parameters.AddWithValue("@Specialization", doctor.Specialization);
            cmd.Parameters.AddWithValue("@Phone", (object?)doctor.Phone ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Email", (object?)doctor.Email ?? DBNull.Value);

            con.Open();

            int rows = cmd.ExecuteNonQuery();

            if (rows > 0)
                Console.WriteLine("Doctor updated successfully.");
            else
                Console.WriteLine("Doctor not found.");
        }

        // Delete Doctor
        public void DeleteDoctor(int doctorId)
        {
            using SqlConnection con = new SqlConnection(connectionString);

            string query = "DELETE FROM Doctor WHERE DoctorID=@DoctorID";

            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@DoctorID", doctorId);

            con.Open();

            int rows = cmd.ExecuteNonQuery();

            if (rows > 0)
                Console.WriteLine("Doctor deleted successfully.");
            else
                Console.WriteLine("Doctor not found.");
        }

        // Patient CRUD

        // Add Patient
        public void AddPatient(Patient patient)
        {
            using SqlConnection con = new SqlConnection(connectionString);

            string query = @"INSERT INTO Patient
                            (FirstName, LastName, DateOfBirth, Gender, Phone, Address)
                            VALUES
                            (@FirstName, @LastName, @DateOfBirth, @Gender, @Phone, @Address)";

            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@FirstName", patient.FirstName);
            cmd.Parameters.AddWithValue("@LastName", patient.LastName);
            cmd.Parameters.AddWithValue("@DateOfBirth", patient.DateOfBirth);
            cmd.Parameters.AddWithValue("@Gender", (object?)patient.Gender ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Phone", (object?)patient.Phone ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Address", (object?)patient.Address ?? DBNull.Value);

            con.Open();

            int rows = cmd.ExecuteNonQuery();

            if (rows > 0)
                Console.WriteLine("Patient added successfully.");
            else
                Console.WriteLine("Failed to add patient.");
        }

        // View Patients
        public void ViewPatients()
        {
            using SqlConnection con = new SqlConnection(connectionString);

            string query = "SELECT * FROM Patient";

            SqlCommand cmd = new SqlCommand(query, con);

            con.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            Console.WriteLine("\n========== PATIENT LIST ==========");

            while (reader.Read())
            {
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("Patient ID    : " + reader["PatientID"]);
                Console.WriteLine("First Name    : " + reader["FirstName"]);
                Console.WriteLine("Last Name     : " + reader["LastName"]);
                Console.WriteLine("Date of Birth : " +
                    Convert.ToDateTime(reader["DateOfBirth"]).ToShortDateString());
                Console.WriteLine("Gender        : " + reader["Gender"]);
                Console.WriteLine("Phone         : " + reader["Phone"]);
                Console.WriteLine("Address       : " + reader["Address"]);
            }

            reader.Close();
        }
                // Update Patient
        public void UpdatePatient(Patient patient)
        {
            using SqlConnection con = new SqlConnection(connectionString);

            string query = @"UPDATE Patient
                             SET FirstName=@FirstName,
                                 LastName=@LastName,
                                 DateOfBirth=@DateOfBirth,
                                 Gender=@Gender,
                                 Phone=@Phone,
                                 Address=@Address
                             WHERE PatientID=@PatientID";

            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@PatientID", patient.PatientID);
            cmd.Parameters.AddWithValue("@FirstName", patient.FirstName);
            cmd.Parameters.AddWithValue("@LastName", patient.LastName);
            cmd.Parameters.AddWithValue("@DateOfBirth", patient.DateOfBirth);
            cmd.Parameters.AddWithValue("@Gender", (object?)patient.Gender ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Phone", (object?)patient.Phone ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@Address", (object?)patient.Address ?? DBNull.Value);

            con.Open();

            int rows = cmd.ExecuteNonQuery();

            if (rows > 0)
                Console.WriteLine("Patient updated successfully.");
            else
                Console.WriteLine("Patient not found.");
        }

        // Delete Patient
        public void DeletePatient(int patientId)
        {
            using SqlConnection con = new SqlConnection(connectionString);

            string query = "DELETE FROM Patient WHERE PatientID=@PatientID";

            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@PatientID", patientId);

            con.Open();

            int rows = cmd.ExecuteNonQuery();

            if (rows > 0)
                Console.WriteLine("Patient deleted successfully.");
            else
                Console.WriteLine("Patient not found.");
        }

        // Appointment CRUD

        // Add Appointment
        public void AddAppointment(Appointment appointment)
        {
            using SqlConnection con = new SqlConnection(connectionString);

            string query = @"INSERT INTO Appointment
                            (PatientID, DoctorID, AppointmentDate, TimeSlot, Status)
                            VALUES
                            (@PatientID, @DoctorID, @AppointmentDate, @TimeSlot, @Status)";

            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@PatientID", appointment.PatientID);
            cmd.Parameters.AddWithValue("@DoctorID", appointment.DoctorID);
            cmd.Parameters.AddWithValue("@AppointmentDate", appointment.AppointmentDate);
            cmd.Parameters.AddWithValue("@TimeSlot", appointment.TimeSlot);
            cmd.Parameters.AddWithValue("@Status", appointment.Status);

            con.Open();

            int rows = cmd.ExecuteNonQuery();

            if (rows > 0)
                Console.WriteLine("Appointment added successfully.");
            else
                Console.WriteLine("Failed to add appointment.");
        }

        // View Appointments
        public void ViewAppointments()
        {
            using SqlConnection con = new SqlConnection(connectionString);

            string query = @"
            SELECT
                A.AppointmentID,
                P.FirstName + ' ' + P.LastName AS PatientName,
                D.FirstName + ' ' + D.LastName AS DoctorName,
                A.AppointmentDate,
                A.TimeSlot,
                A.Status
            FROM Appointment A
            INNER JOIN Patient P
                ON A.PatientID = P.PatientID
            INNER JOIN Doctor D
                ON A.DoctorID = D.DoctorID";

            SqlCommand cmd = new SqlCommand(query, con);

            con.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            Console.WriteLine("\n========== APPOINTMENT LIST ==========");

            while (reader.Read())
            {
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("Appointment ID : " + reader["AppointmentID"]);
                Console.WriteLine("Patient Name   : " + reader["PatientName"]);
                Console.WriteLine("Doctor Name    : " + reader["DoctorName"]);
                Console.WriteLine("Date           : " + Convert.ToDateTime(reader["AppointmentDate"]).ToShortDateString());
                Console.WriteLine("Time Slot      : " + reader["TimeSlot"]);
                Console.WriteLine("Status         : " + reader["Status"]);
            }

            reader.Close();
        }

        // Update Appointment
        public void UpdateAppointment(Appointment appointment)
        {
            using SqlConnection con = new SqlConnection(connectionString);

            string query = @"UPDATE Appointment
                             SET PatientID=@PatientID,
                                 DoctorID=@DoctorID,
                                 AppointmentDate=@AppointmentDate,
                                 TimeSlot=@TimeSlot,
                                 Status=@Status
                             WHERE AppointmentID=@AppointmentID";

            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@AppointmentID", appointment.AppointmentID);
            cmd.Parameters.AddWithValue("@PatientID", appointment.PatientID);
            cmd.Parameters.AddWithValue("@DoctorID", appointment.DoctorID);
            cmd.Parameters.AddWithValue("@AppointmentDate", appointment.AppointmentDate);
            cmd.Parameters.AddWithValue("@TimeSlot", appointment.TimeSlot);
            cmd.Parameters.AddWithValue("@Status", appointment.Status);

            con.Open();

            int rows = cmd.ExecuteNonQuery();

            if (rows > 0)
                Console.WriteLine("Appointment updated successfully.");
            else
                Console.WriteLine("Appointment not found.");
        }

        // Delete Appointment
        public void DeleteAppointment(int appointmentId)
        {
            using SqlConnection con = new SqlConnection(connectionString);

            string query = "DELETE FROM Appointment WHERE AppointmentID=@AppointmentID";

            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@AppointmentID", appointmentId);

            con.Open();

            int rows = cmd.ExecuteNonQuery();

            if (rows > 0)
                Console.WriteLine("Appointment deleted successfully.");
            else
                Console.WriteLine("Appointment not found.");
        }
    }
}