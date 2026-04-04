public interface IDoctorService
    {
        void AddDoctor(Doctor doctor);
        void AssignOrUpdateDoctorSpecialty();
        void ViewDoctorsBySpecialty(string specialtyName);
        void DeactivateDoctor(int doctorId);
    }