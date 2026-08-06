namespace HealthClinicApp.Entities
{
    public class Patient
    {
        public int PatientID { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public DateTime DateOfBirth { get; set; }

        public string? Gender { get; set; }

        public string? Phone { get; set; }

        public string? Address { get; set; }
    }
}