 public interface IPatientService
    {
        void RegisterPatient(Patient patient);
        void UpdatePatient(int patientId, Patient patient);
        List<Patient> SearchPatients(int? id, string phone, string name);
         List<VisitHistory> GetPatientVisitHistory(int patientId);
        void RecordPatientVisit(int appointmentId, string diagnosis, string prescription, string notes);
        List<VisitHistory> GetDetailedMedicalHistory(int patientId);
        void AddPrescriptionBatch(int visitId, List<PrescriptionEntry> medicines);
    }