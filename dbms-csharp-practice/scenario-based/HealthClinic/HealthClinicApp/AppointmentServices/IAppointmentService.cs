public interface IAppointmentService
{
    void BookAppointment(int patientId, int doctorId, DateTime appointmentDate);
    void CheckDoctorAvailability(int doctorId, DateTime date);
    void CancelAppointment(int appointmentId);
    void RescheduleAppointment(int appointmentId, int newDoctorId, DateTime newDate);
    void ViewDailySchedule(DateTime date);
}