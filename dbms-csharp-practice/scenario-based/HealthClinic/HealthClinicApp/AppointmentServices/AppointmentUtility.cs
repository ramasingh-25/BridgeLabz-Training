using Microsoft.Data.SqlClient;

public class AppointmentUtility : IAppointmentService
{
    public void BookAppointment(int patientId, int doctorId, DateTime appointmentDate)
    {
        using SqlConnection con = ConnectionDB.GetConnection();
        con.Open();

        string checkQuery = @"
            SELECT COUNT(1) FROM Appointments 
            WHERE DoctorId = @DoctorId 
            AND AppointmentDate = @Date 
            AND Status = 'SCHEDULED'";

        using (SqlCommand checkCmd = new SqlCommand(checkQuery, con))
        {
            checkCmd.Parameters.AddWithValue("@DoctorId", doctorId);
            checkCmd.Parameters.AddWithValue("@Date", appointmentDate);

            int exists = (int)checkCmd.ExecuteScalar();
            if (exists > 0)
            {
                throw new Exception("The doctor is already booked for this time slot.");
            }
        }

        string insertQuery = @"
            INSERT INTO Appointments (PatientId, DoctorId, AppointmentDate, Status)
            VALUES (@PatientId, @DoctorId, @Date, 'SCHEDULED')";

        using (SqlCommand insertCmd = new SqlCommand(insertQuery, con))
        {
            insertCmd.Parameters.AddWithValue("@PatientId", patientId);
            insertCmd.Parameters.AddWithValue("@DoctorId", doctorId);
            insertCmd.Parameters.AddWithValue("@Date", appointmentDate);

            insertCmd.ExecuteNonQuery();
        }
    }
    public void CheckDoctorAvailability(int doctorId, DateTime date)
{
    using SqlConnection con = ConnectionDB.GetConnection();

    string query = @"
        SELECT 
            DATEPART(HOUR, AppointmentDate) AS SlotHour, 
            COUNT(*) AS BookedSlots
        FROM Appointments
        WHERE DoctorId = @DoctorId 
          AND CAST(AppointmentDate AS DATE) = @SelectedDate
          AND Status = 'SCHEDULED'
        GROUP BY DATEPART(HOUR, AppointmentDate)";

    SqlCommand cmd = new SqlCommand(query, con);
    cmd.Parameters.AddWithValue("@DoctorId", doctorId);
    cmd.Parameters.AddWithValue("@SelectedDate", date.Date);

    con.Open();
    using SqlDataReader reader = cmd.ExecuteReader();

    Console.WriteLine($"\n--- Availability for Doctor ID: {doctorId} on {date:yyyy-MM-dd} ---");
    const int maxCapacityPerSlot = 3; // Example clinic capacity constraint
    
    bool hasAppointments = false;
    while (reader.Read())
    {
        hasAppointments = true;
        int hour = (int)reader["SlotHour"];
        int count = (int)reader["BookedSlots"];
        string status = count >= maxCapacityPerSlot ? "FULL" : $"{maxCapacityPerSlot - count} slots left";

        Console.WriteLine($"Time Slot: {hour}:00 | Booked: {count}/{maxCapacityPerSlot} | Status: {status}");
    }

    if (!hasAppointments)
    {
        Console.WriteLine("All slots are currently empty for this date.");
    }
}
public void CancelAppointment(int appointmentId)
{
    using SqlConnection con = ConnectionDB.GetConnection();
    con.Open();

    // Start a transaction
    SqlTransaction transaction = con.BeginTransaction();

    try
    {
        string statusQuery = "SELECT Status FROM Appointments WHERE AppointmentId = @Id";
        string oldStatus = "";
        using (SqlCommand cmd = new SqlCommand(statusQuery, con, transaction))
        {
            cmd.Parameters.AddWithValue("@Id", appointmentId);
            var result = cmd.ExecuteScalar();
            if (result == null) throw new Exception("Appointment not found.");
            oldStatus = result.ToString();
        }

        // 2. Update Status to 'CANCELLED'
        string updateQuery = "UPDATE Appointments SET Status = 'CANCELLED' WHERE AppointmentId = @Id";
        using (SqlCommand updateCmd = new SqlCommand(updateQuery, con, transaction))
        {
            updateCmd.Parameters.AddWithValue("@Id", appointmentId);
            updateCmd.ExecuteNonQuery();
        }

        // 3. Log the action in AppointmentAudit table
        string auditQuery = @"
            INSERT INTO AppointmentAudit (AppointmentId, OldStatus, NewStatus, Action)
            VALUES (@Id, @OldStatus, 'CANCELLED', 'Receptionist/Patient Cancellation')";
        
        using (SqlCommand auditCmd = new SqlCommand(auditQuery, con, transaction))
        {
            auditCmd.Parameters.AddWithValue("@Id", appointmentId);
            auditCmd.Parameters.AddWithValue("@OldStatus", oldStatus);
            auditCmd.ExecuteNonQuery();
        }

        // Commit the transaction
        transaction.Commit();
        Console.WriteLine("Appointment cancelled and audited successfully.");
    }
    catch (Exception)
    {
        transaction.Rollback();
        throw;
    }
}
public void RescheduleAppointment(int appointmentId, int newDoctorId, DateTime newDate)
{
    using SqlConnection con = ConnectionDB.GetConnection();
    con.Open();

    // Start transaction to allow for ROLLBACK if conflicts are found
    SqlTransaction transaction = con.BeginTransaction();

    try
    {
        string checkQuery = @"
            SELECT COUNT(1) FROM Appointments 
            WHERE DoctorId = @DoctorId 
            AND AppointmentDate = @NewDate 
            AND Status = 'SCHEDULED'
            AND AppointmentId != @AppId"; 

        using (SqlCommand checkCmd = new SqlCommand(checkQuery, con, transaction))
        {
            checkCmd.Parameters.AddWithValue("@DoctorId", newDoctorId);
            checkCmd.Parameters.AddWithValue("@NewDate", newDate);
            checkCmd.Parameters.AddWithValue("@AppId", appointmentId);

            int exists = (int)checkCmd.ExecuteScalar();
            if (exists > 0)
            {
                transaction.Rollback();
                throw new Exception("The new slot is already booked for this doctor.");
            }
        }

        string updateQuery = @"
            UPDATE Appointments 
            SET DoctorId = @DoctorId, 
                AppointmentDate = @NewDate, 
                Status = 'SCHEDULED' 
            WHERE AppointmentId = @AppId";

        using (SqlCommand updateCmd = new SqlCommand(updateQuery, con, transaction))
        {
            updateCmd.Parameters.AddWithValue("@DoctorId", newDoctorId);
            updateCmd.Parameters.AddWithValue("@NewDate", newDate);
            updateCmd.Parameters.AddWithValue("@AppId", appointmentId);

            int rowsAffected = updateCmd.ExecuteNonQuery();
            if (rowsAffected == 0)
            {
                transaction.Rollback();
                throw new Exception("Appointment record not found.");
            }
        }
        string auditQuery = @"
            INSERT INTO AppointmentAudit (AppointmentId, NewStatus, Action)
            VALUES (@AppId, 'SCHEDULED', 'Rescheduled to ' + CAST(@NewDate AS NVARCHAR))";
        
        using (SqlCommand auditCmd = new SqlCommand(auditQuery, con, transaction))
        {
            auditCmd.Parameters.AddWithValue("@AppId", appointmentId);
            auditCmd.Parameters.AddWithValue("@NewDate", newDate);
            auditCmd.ExecuteNonQuery();
        }

        transaction.Commit();
        Console.WriteLine("Appointment rescheduled successfully.");
    }
    catch (Exception ex)
    {
        if (transaction.Connection != null)
        {
            transaction.Rollback();
        }
        throw new Exception($"Rescheduling failed: {ex.Message}");
    }
}
public void ViewDailySchedule(DateTime date)
{
    using SqlConnection con = ConnectionDB.GetConnection();

    string query = @"
        SELECT 
            A.AppointmentId,
            A.AppointmentDate,
            P.Name AS PatientName,
            D.DoctorName,
            A.Status
        FROM Appointments A
        JOIN Patients P ON A.PatientId = P.PatientId
        JOIN Doctors D ON A.DoctorId = D.DoctorId
        WHERE CAST(A.AppointmentDate AS DATE) = @SelectedDate
        ORDER BY A.AppointmentDate ASC";

    SqlCommand cmd = new SqlCommand(query, con);
    cmd.Parameters.AddWithValue("@SelectedDate", date.Date);

    con.Open();
    using SqlDataReader reader = cmd.ExecuteReader();

    Console.WriteLine($"\n--- Appointment Schedule for {date:yyyy-MM-dd} ---");
    Console.WriteLine($"{"ID",-5} | {"Time",-8} | {"Patient",-20} | {"Doctor",-20} | {"Status"}");
    Console.WriteLine(new string('-', 70));

    bool found = false;
    while (reader.Read())
    {
        found = true;
        DateTime appTime = (DateTime)reader["AppointmentDate"];
        Console.WriteLine($"{reader["AppointmentId"],-5} | " +
                          $"{appTime:HH:mm} | " +
                          $"{reader["PatientName"],-20} | " +
                          $"{reader["DoctorName"],-20} | " +
                          $"{reader["Status"]}");
    }

    if (!found)
    {
        Console.WriteLine("No appointments scheduled for this date.");
    }
}
}