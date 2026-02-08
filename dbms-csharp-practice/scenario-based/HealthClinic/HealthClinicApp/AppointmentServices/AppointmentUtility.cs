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
public void GenerateBill(int visitId, decimal additionalCharges)
{
    using SqlConnection con = ConnectionDB.GetConnection();
    con.Open();

    // 1. Get Consultation Fee by joining Visits -> Appointments -> Doctors
    string feeQuery = @"
        SELECT D.ConsultationFee 
        FROM Visits V
        JOIN Appointments A ON V.AppointmentId = A.AppointmentId
        JOIN Doctors D ON A.DoctorId = D.DoctorId
        WHERE V.VisitId = @VisitId";

    decimal consultFee = 0;
    using (SqlCommand cmd = new SqlCommand(feeQuery, con))
    {
        cmd.Parameters.AddWithValue("@VisitId", visitId);
        object result = cmd.ExecuteScalar();
        
        if (result == null) 
            throw new Exception("Visit record not found. Ensure the visit is recorded before billing.");
            
        consultFee = (decimal)result;
    }

    // 2. Insert into Bills table
    string billQuery = @"
        INSERT INTO Bills (VisitId, ConsultationAmount, AdditionalCharges)
        VALUES (@VisitId, @ConsultFee, @Extra)";

    using (SqlCommand billCmd = new SqlCommand(billQuery, con))
    {
        billCmd.Parameters.AddWithValue("@VisitId", visitId);
        billCmd.Parameters.AddWithValue("@ConsultFee", consultFee);
        billCmd.Parameters.AddWithValue("@Extra", additionalCharges);
        billCmd.ExecuteNonQuery();
    }

    Console.WriteLine($"Bill generated successfully for Visit ID: {visitId}");
}
public void RecordPayment(int billId, string paymentMode)
{
    using SqlConnection con = ConnectionDB.GetConnection();
    con.Open();

    using SqlTransaction transaction = con.BeginTransaction();

    try
    {
        // 1. Get the total amount from the bill to log in the transaction
        string getAmountQuery = "SELECT TotalAmount FROM Bills WHERE BillId = @BillId";
        decimal totalAmount = 0;
        using (SqlCommand cmd = new SqlCommand(getAmountQuery, con, transaction))
        {
            cmd.Parameters.AddWithValue("@BillId", billId);
            object result = cmd.ExecuteScalar();
            if (result == null) throw new Exception("Bill not found.");
            totalAmount = (decimal)result;
        }

        // 2. Update the Bills table
        string updateBillQuery = @"
            UPDATE Bills 
            SET PaymentStatus = 'PAID', 
                PaymentDate = GETDATE(), 
                PaymentMode = @Mode 
            WHERE BillId = @BillId";
        
        using (SqlCommand updateCmd = new SqlCommand(updateBillQuery, con, transaction))
        {
            updateCmd.Parameters.AddWithValue("@BillId", billId);
            updateCmd.Parameters.AddWithValue("@Mode", paymentMode);
            updateCmd.ExecuteNonQuery();
        }

        // 3. Insert into PaymentTransactions table
        string insertTransQuery = @"
            INSERT INTO PaymentTransactions (BillId, AmountPaid, PaymentMode)
            VALUES (@BillId, @Amount, @Mode)";
        
        using (SqlCommand insertCmd = new SqlCommand(insertTransQuery, con, transaction))
        {
            insertCmd.Parameters.AddWithValue("@BillId", billId);
            insertCmd.Parameters.AddWithValue("@Amount", totalAmount);
            insertCmd.Parameters.AddWithValue("@Mode", paymentMode);
            insertCmd.ExecuteNonQuery();
        }

        transaction.Commit();
        Console.WriteLine($"Payment of {totalAmount:C} recorded successfully via {paymentMode}.");
    }
    catch (Exception)
    {
        transaction.Rollback();
        throw;
    }
}
public void ViewOutstandingBills()
{
    using SqlConnection con = ConnectionDB.GetConnection();
    con.Open();

    // Query to aggregate unpaid bills per patient
    string query = @"
        SELECT 
            P.PatientId,
            P.Name AS PatientName,
            COUNT(B.BillId) AS UnpaidCount,
            SUM(B.TotalAmount) AS TotalOwed
        FROM Bills B
        JOIN Visits V ON B.VisitId = V.VisitId
        JOIN Appointments A ON V.AppointmentId = A.AppointmentId
        JOIN Patients P ON A.PatientId = P.PatientId
        WHERE B.PaymentStatus = 'UNPAID'
        GROUP BY P.PatientId, P.Name
        ORDER BY TotalOwed DESC";

    using (SqlCommand cmd = new SqlCommand(query, con))
    {
        using (SqlDataReader reader = cmd.ExecuteReader())
        {
            Console.WriteLine("\n--- Outstanding Bills Report ---");
            Console.WriteLine($"{"ID",-5} | {"Patient Name",-20} | {"Unpaid",-8} | {"Total Owed"}");
            Console.WriteLine(new string('-', 55));

            bool found = false;
            while (reader.Read())
            {
                found = true;
                Console.WriteLine($"{reader["PatientId"],-5} | " +
                                  $"{reader["PatientName"],-20} | " +
                                  $"{reader["UnpaidCount"],-8} | " +
                                  $"{reader["TotalOwed"]:C}");
            }

            if (!found)
            {
                Console.WriteLine("Great news! There are no outstanding bills.");
            }
        }
    }
}
public void GenerateRevenueReport(DateTime startDate, DateTime endDate, decimal minThreshold)
{
    using SqlConnection con = ConnectionDB.GetConnection();
    con.Open();

    string query = @"
        SELECT 
            CAST(B.BillingDate AS DATE) AS RevenueDate,
            D.DoctorName,
            S.SpecialtyName,
            SUM(B.TotalAmount) AS DailyTotal
        FROM Bills B
        JOIN Visits V ON B.VisitId = V.VisitId
        JOIN Appointments A ON V.AppointmentId = A.AppointmentId
        JOIN Doctors D ON A.DoctorId = D.DoctorId
        JOIN Specialties S ON D.SpecialtyId = S.SpecialtyId
        WHERE B.PaymentStatus = 'PAID' 
          AND B.BillingDate BETWEEN @Start AND @End
        GROUP BY CAST(B.BillingDate AS DATE), D.DoctorName, S.SpecialtyName
        HAVING SUM(B.TotalAmount) >= @Threshold
        ORDER BY RevenueDate DESC, DailyTotal DESC";

    using (SqlCommand cmd = new SqlCommand(query, con))
    {
        cmd.Parameters.AddWithValue("@Start", startDate.Date);
        cmd.Parameters.AddWithValue("@End", endDate.Date.AddDays(1).AddSeconds(-1));
        cmd.Parameters.AddWithValue("@Threshold", minThreshold);

        using (SqlDataReader reader = cmd.ExecuteReader())
        {
            Console.WriteLine($"\n--- Revenue Report ({startDate:yyyy-MM-dd} to {endDate:yyyy-MM-dd}) ---");
            Console.WriteLine($"{"Date",-12} | {"Doctor",-15} | {"Specialty",-15} | {"Revenue"}");
            Console.WriteLine(new string('-', 60));

            bool found = false;
            while (reader.Read())
            {
                found = true;
                Console.WriteLine($"{((DateTime)reader["RevenueDate"]):yyyy-MM-dd,-12} | " +
                                  $"{reader["DoctorName"],-15} | " +
                                  $"{reader["SpecialtyName"],-15} | " +
                                  $"{reader["DailyTotal"]:C}");
            }

            if (!found) Console.WriteLine("No revenue data found for the selected criteria.");
        }
    }
}
}