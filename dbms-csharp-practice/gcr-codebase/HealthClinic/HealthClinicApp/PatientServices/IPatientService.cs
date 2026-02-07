 public interface IPatientService
    {
        void RegisterPatient(Patient patient);
        void UpdatePatient(int patientId, Patient patient);
        List<Patient> SearchPatients(int? id, string phone, string name);
         List<VisitHistory> GetPatientVisitHistory(int patientId);
    }