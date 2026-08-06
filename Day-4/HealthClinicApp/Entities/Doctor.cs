namespace HealthClinicApp.Entities
{
    public class Doctor
    {
        public int DoctorID { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Specialization { get; set; } = string.Empty;

        public string? Phone { get; set; }

        public string? Email { get; set; }
    }
}