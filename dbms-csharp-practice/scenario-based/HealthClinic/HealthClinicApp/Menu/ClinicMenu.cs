 using Microsoft.Data.SqlClient;
 public class ClinicMenu
    {
        private readonly IPatientService patientService;
        private readonly IDoctorService doctorService;
        private readonly IAppointmentService appointmentService;
       
        public ClinicMenu()
        {
            patientService = new PatientUtility();
            doctorService = new DoctorUtility();
            appointmentService = new AppointmentUtility();
        }

        public void ShowMenu()
        {
            while (true)
            {
                Console.WriteLine("\n=== Health Clinic System ===");
                Console.WriteLine("1. Register Patient");
                Console.WriteLine("2. Update Patient");
                Console.WriteLine("3. Search Patient");
                Console.WriteLine("4. View Patient Visit History");
                Console.WriteLine("5. Add Doctor Profile");
                Console.WriteLine("6. Assign/Update Doctor Specialty (Admin)");
                Console.WriteLine("7. View Doctor by Speciality");
                Console.WriteLine("8. Deactivate Doctor");
                Console.WriteLine("9. Book New Appointment");
                Console.WriteLine("10. Check Availability");
                Console.WriteLine("11. Cancel Appointment");
                Console.WriteLine("12. Reschedule Appointment");
                Console.WriteLine("13. View Daily Schedule");
                Console.WriteLine("0. Exit");
                Console.Write("Choose option: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        RegisterPatient();
                        break;
                    case "2":
                        UpdatePatient();
                        break;
                    case "3":
                        SearchPatient();
                        break;
                    case "4":
                        ViewPatientHistory();
                        break;
                    case "5":
                        AddDoctorProfile();
                        break;
                    case "6":
                        doctorService.AssignOrUpdateDoctorSpecialty(); 
                        break;
                    case "7":
                         ViewDoctorsBySpecialty();
                         break;
                    case "8":
                         DeactivateDoctor();
                         break;
                    case "9":
                        BookAppointment();
                        break;
                    case "10":
                        CheckAvailability();
                        break;
                    case "11":
                        CancelAppointment();
                        break;
                    case "12":
                        RescheduleAppointment();
                        break;
                    case "13":
                        ViewDailySchedule();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }
            }
        }

        private void RegisterPatient()
{
    try 
    {
        Patient p = new Patient();

        Console.Write("Name: ");
        p.Name = Console.ReadLine();

        Console.Write("DOB (yyyy-mm-dd): ");
        p.DateOfBirth = DateTime.Parse(Console.ReadLine());

        Console.Write("Contact Number: ");
        p.ContactNumber = Console.ReadLine();

        Console.Write("Email: ");
        p.Email = Console.ReadLine();

        Console.Write("Address: ");
        p.Address = Console.ReadLine();

        Console.Write("Blood Group: ");
        p.BloodGroup = Console.ReadLine();

        patientService.RegisterPatient(p);
        Console.WriteLine("Patient registered successfully.");
    }
    catch (PatientAlreadyExistsException ex)
    {
        Console.WriteLine($"Registration Error: {ex.Message}");
    }
    catch (FormatException)
    {
        Console.WriteLine("Error: Invalid date format. Please use yyyy-mm-dd.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"An unexpected error occurred: {ex.Message}");
    }
}

        private void UpdatePatient()
        {
            Console.Write("Enter Patient ID: ");
            int id = int.Parse(Console.ReadLine());

            Patient p = new Patient();

            Console.Write("New Name: ");
            p.Name = Console.ReadLine();

            Console.Write("New DOB (yyyy-mm-dd): ");
            p.DateOfBirth = DateTime.Parse(Console.ReadLine());

            Console.Write("New Contact Number: ");
            p.ContactNumber = Console.ReadLine();

            Console.Write("New Email: ");
            p.Email = Console.ReadLine();

            Console.Write("New Address: ");
            p.Address = Console.ReadLine();

            Console.Write("New Blood Group: ");
            p.BloodGroup = Console.ReadLine();

            patientService.UpdatePatient(id, p);
            Console.WriteLine("Patient updated successfully.");
        }

        private void SearchPatient()
        {
            Console.Write("Search by ID (press enter to skip): ");
            string idInput = Console.ReadLine();

            Console.Write("Search by Phone (press enter to skip): ");
            string phone = Console.ReadLine();

            Console.Write("Search by Name (press enter to skip): ");
            string name = Console.ReadLine();

            int? id = string.IsNullOrEmpty(idInput) ? null : int.Parse(idInput);
            phone = string.IsNullOrEmpty(phone) ? null : phone;
            name = string.IsNullOrEmpty(name) ? null : name;

            List<Patient> results = patientService.SearchPatients(id, phone, name);

            if (results.Count == 0)
            {
                Console.WriteLine("No patients found.");
                return;
            }

            foreach (var p in results)
            {
                Console.WriteLine($"ID: {p.PatientId}, Name: {p.Name}, Phone: {p.ContactNumber}, Blood: {p.BloodGroup}");
            }
        }
        private void ViewPatientHistory()
        {
            Console.Write("Enter Patient ID: ");
            int patientId = int.Parse(Console.ReadLine());
            var visits = patientService.GetPatientVisitHistory(patientId);

        if (visits.Count == 0)
        {
        Console.WriteLine("No visit history found.");
        return;
        }

        Console.WriteLine("\n--- Visit History ---");
        foreach (var v in visits)
        {
        Console.WriteLine($"Date: {v.VisitDate:d} | Doctor: {v.DoctorName} | Diagnosis: {v.Diagnosis}");
        }
    }
   private void AddDoctorProfile()
{
    try
    {
        using (SqlConnection con = ConnectionDB.GetConnection())
        {
            con.Open();
            Console.WriteLine("\n--- Available Specialties ---");
            string fetch = "SELECT SpecialtyId, SpecialtyName FROM Specialties";
            using SqlCommand cmd = new SqlCommand(fetch, con);
            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine($"{reader["SpecialtyId"]} - {reader["SpecialtyName"]}");
            }
        }

        Console.Write("\nDoctor Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Specialty ID from the list above: ");
        int specialtyId = int.Parse(Console.ReadLine());

        Console.Write("Contact Number: ");
        string contact = Console.ReadLine();

        Console.Write("Consultation Fee: ");
        decimal fee = decimal.Parse(Console.ReadLine());

        Doctor doctor = new Doctor
        {
            Name = name,
            SpecialtyId = specialtyId,
            Contact = contact,
            ConsultationFee = fee
        };

        doctorService.AddDoctor(doctor);
        Console.WriteLine("Doctor profile added successfully.");
    }
    catch (DoctorException ex)
    {
        Console.WriteLine($"Clinic Error: {ex.Message}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Unexpected Error: {ex.Message}");
    }
}
    private void ViewDoctorsBySpecialty()
{
    Console.Write("Enter Specialty Name (e.g., Cardiology): ");
    string specialty = Console.ReadLine();
    
    if (string.IsNullOrWhiteSpace(specialty))
    {
        Console.WriteLine("Specialty name cannot be empty.");
        return;
    }

    doctorService.ViewDoctorsBySpecialty(specialty);
}
 private void DeactivateDoctor()
{
    try
    {
        Console.Write("Enter Doctor ID to deactivate: ");
        int id = int.Parse(Console.ReadLine());

        doctorService.DeactivateDoctor(id);
        Console.WriteLine("Doctor profile deactivated successfully.");
    }
    catch (DoctorException ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Unexpected Error: {ex.Message}");
    }
}
private void BookAppointment()
{
    try
    {
        Console.Write("Enter Patient ID: ");
        int pId = int.Parse(Console.ReadLine());

        Console.Write("Enter Doctor ID: ");
        int dId = int.Parse(Console.ReadLine());

        Console.Write("Enter Date and Time (yyyy-mm-dd hh:mm): ");
        DateTime appDate = DateTime.Parse(Console.ReadLine());

        // Assuming you initialized appointmentService in the constructor
        appointmentService.BookAppointment(pId, dId, appDate);
        Console.WriteLine("Appointment booked successfully with status: SCHEDULED.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Booking Failed: {ex.Message}");
    }
}
private void CheckAvailability()
{
    try
    {
        Console.Write("Enter Doctor ID: ");
        int dId = int.Parse(Console.ReadLine());

        Console.Write("Enter Date to check (yyyy-mm-dd): ");
        DateTime checkDate = DateTime.Parse(Console.ReadLine());

        appointmentService.CheckDoctorAvailability(dId, checkDate);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error checking availability: {ex.Message}");
    }
}
private void CancelAppointment()
{
    try
    {
        Console.Write("Enter Appointment ID to cancel: ");
        int appId = int.Parse(Console.ReadLine());

        appointmentService.CancelAppointment(appId);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Cancellation Failed: {ex.Message}");
    }
}
private void RescheduleAppointment()
{
    try
    {
        Console.WriteLine("\n--- Reschedule Appointment ---");
        Console.Write("Enter Appointment ID: ");
        int appId = int.Parse(Console.ReadLine());

        Console.Write("Enter New Doctor ID: ");
        int dId = int.Parse(Console.ReadLine());

        Console.Write("Enter New Date and Time (yyyy-mm-dd hh:mm): ");
        DateTime newDate = DateTime.Parse(Console.ReadLine());

        appointmentService.RescheduleAppointment(appId, dId, newDate);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
}
private void ViewDailySchedule()
{
    try
    {
        Console.Write("Enter Date to view (yyyy-mm-dd): ");
        DateTime scheduleDate = DateTime.Parse(Console.ReadLine());

        appointmentService.ViewDailySchedule(scheduleDate);
    }
    catch (FormatException)
    {
        Console.WriteLine("Error: Invalid date format. Use yyyy-mm-dd.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
}


    }