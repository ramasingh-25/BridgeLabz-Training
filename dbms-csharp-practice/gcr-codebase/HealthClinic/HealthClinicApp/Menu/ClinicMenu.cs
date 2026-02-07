 public class ClinicMenu
    {
        private readonly IPatientService patientService;
        private readonly IDoctorService doctorService;
        public ClinicMenu()
        {
            patientService = new PatientUtility();
            doctorService = new DoctorUtility();
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
        Console.Write("Doctor Name: ");
        string name = Console.ReadLine();

        Console.Write("Specialty ID: ");
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
        Console.WriteLine(ex.Message);
    }
    catch (Exception ex)
    {
        Console.WriteLine("Error: " + ex.Message);
    }
}


    }