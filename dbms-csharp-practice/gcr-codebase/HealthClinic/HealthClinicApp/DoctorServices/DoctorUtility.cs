using Microsoft.Data.SqlClient;
 public class DoctorUtility : IDoctorService
    {
        public void AddDoctor(Doctor doctor)
        {
            if (doctor.ConsultationFee <= 0)
                throw new DoctorException("Consultation fee must be greater than zero.");

            using SqlConnection con = ConnectionDB.GetConnection();

            string query = @"
                INSERT INTO Doctors
                (DoctorName, SpecialtyId, ContactNumber, ConsultationFee)
                VALUES
                (@Name, @SpecialtyId, @Contact, @Fee)";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Name", doctor.Name);
            cmd.Parameters.AddWithValue("@SpecialtyId", doctor.SpecialtyId);
            cmd.Parameters.AddWithValue("@Contact", doctor.Contact);
            cmd.Parameters.AddWithValue("@Fee", doctor.ConsultationFee);

            con.Open();
            cmd.ExecuteNonQuery();
        }
    }