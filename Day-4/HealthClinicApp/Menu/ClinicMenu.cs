using HealthClinicApp.Entities;
using HealthClinicApp.Services;

namespace HealthClinicApp.Menu
{
    public class ClinicMenu
    {
        private readonly HealthClinic hc = new HealthClinic();

        public void Start()
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("========== HEALTH CLINIC MANAGEMENT ==========");
                Console.WriteLine("1. Doctor");
                Console.WriteLine("2. Patient");
                Console.WriteLine("3. Appointment");
                Console.WriteLine("4. Exit");
                Console.Write("Enter Choice : ");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        DoctorMenu();
                        break;

                    case 2:
                        PatientMenu();
                        break;

                    case 3:
                        AppointmentMenu();
                        break;

                    case 4:
                        return;

                    default:
                        Console.WriteLine("Invalid Choice");
                        Console.ReadKey();
                        break;
                }
            }
        }

        // Doctor Menu

        public void DoctorMenu()
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("========== DOCTOR MENU ==========");
                Console.WriteLine("1. Add Doctor");
                Console.WriteLine("2. View Doctors");
                Console.WriteLine("3. Update Doctor");
                Console.WriteLine("4. Delete Doctor");
                Console.WriteLine("5. Back");

                Console.Write("Enter Choice : ");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:

                        Doctor doctor = new Doctor();

                        Console.Write("First Name : ");
                        doctor.FirstName = Console.ReadLine();

                        Console.Write("Last Name : ");
                        doctor.LastName = Console.ReadLine();

                        Console.Write("Specialization : ");
                        doctor.Specialization = Console.ReadLine();

                        Console.Write("Phone : ");
                        doctor.Phone = Console.ReadLine();

                        Console.Write("Email : ");
                        doctor.Email = Console.ReadLine();

                        hc.AddDoctor(doctor);

                        Console.ReadKey();
                        break;

                    case 2:

                        hc.ViewDoctors();

                        Console.ReadKey();
                        break;

                    case 3:

                        Doctor d = new Doctor();

                        Console.Write("Doctor ID : ");
                        d.DoctorID = Convert.ToInt32(Console.ReadLine());

                        Console.Write("First Name : ");
                        d.FirstName = Console.ReadLine();

                        Console.Write("Last Name : ");
                        d.LastName = Console.ReadLine();

                        Console.Write("Specialization : ");
                        d.Specialization = Console.ReadLine();

                        Console.Write("Phone : ");
                        d.Phone = Console.ReadLine();

                        Console.Write("Email : ");
                        d.Email = Console.ReadLine();

                        hc.UpdateDoctor(d);

                        Console.ReadKey();
                        break;

                    case 4:

                        Console.Write("Doctor ID : ");

                        int doctorId = Convert.ToInt32(Console.ReadLine());

                        hc.DeleteDoctor(doctorId);

                        Console.ReadKey();
                        break;

                    case 5:
                        return;

                    default:
                        Console.WriteLine("Invalid Choice");
                        Console.ReadKey();
                        break;
                }
            }
        }
                // Patient Menu

        public void PatientMenu()
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("========== PATIENT MENU ==========");
                Console.WriteLine("1. Add Patient");
                Console.WriteLine("2. View Patients");
                Console.WriteLine("3. Update Patient");
                Console.WriteLine("4. Delete Patient");
                Console.WriteLine("5. Back");

                Console.Write("Enter Choice : ");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:

                        Patient patient = new Patient();

                        Console.Write("First Name : ");
                        patient.FirstName = Console.ReadLine();

                        Console.Write("Last Name : ");
                        patient.LastName = Console.ReadLine();

                        Console.Write("Date of Birth (yyyy-MM-dd) : ");
                        patient.DateOfBirth = Convert.ToDateTime(Console.ReadLine());

                        Console.Write("Gender : ");
                        patient.Gender = Console.ReadLine();

                        Console.Write("Phone : ");
                        patient.Phone = Console.ReadLine();

                        Console.Write("Address : ");
                        patient.Address = Console.ReadLine();

                        hc.AddPatient(patient);

                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey();
                        break;

                    case 2:

                        hc.ViewPatients();

                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey();
                        break;

                    case 3:

                        Patient p = new Patient();

                        Console.Write("Patient ID : ");
                        p.PatientID = Convert.ToInt32(Console.ReadLine());

                        Console.Write("First Name : ");
                        p.FirstName = Console.ReadLine();

                        Console.Write("Last Name : ");
                        p.LastName = Console.ReadLine();

                        Console.Write("Date of Birth (yyyy-MM-dd) : ");
                        p.DateOfBirth = Convert.ToDateTime(Console.ReadLine());

                        Console.Write("Gender : ");
                        p.Gender = Console.ReadLine();

                        Console.Write("Phone : ");
                        p.Phone = Console.ReadLine();

                        Console.Write("Address : ");
                        p.Address = Console.ReadLine();

                        hc.UpdatePatient(p);

                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey();
                        break;

                    case 4:

                        Console.Write("Patient ID : ");

                        int patientId = Convert.ToInt32(Console.ReadLine());

                        hc.DeletePatient(patientId);

                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey();
                        break;

                    case 5:
                        return;

                    default:
                        Console.WriteLine("Invalid Choice");
                        Console.ReadKey();
                        break;
                }
            }
        }
                // Appointment Menu

        public void AppointmentMenu()
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("========== APPOINTMENT MENU ==========");
                Console.WriteLine("1. Add Appointment");
                Console.WriteLine("2. View Appointments");
                Console.WriteLine("3. Update Appointment");
                Console.WriteLine("4. Delete Appointment");
                Console.WriteLine("5. Back");

                Console.Write("Enter Choice : ");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:

                        Appointment appointment = new Appointment();

                        Console.Write("Patient ID : ");
                        appointment.PatientID = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Doctor ID : ");
                        appointment.DoctorID = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Appointment Date (yyyy-MM-dd) : ");
                        appointment.AppointmentDate = Convert.ToDateTime(Console.ReadLine());

                        Console.Write("Time Slot (HH:mm:ss) : ");
                        appointment.TimeSlot = TimeSpan.Parse(Console.ReadLine());

                        Console.Write("Status : ");
                        appointment.Status = Console.ReadLine();

                        hc.AddAppointment(appointment);

                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey();
                        break;

                    case 2:

                        hc.ViewAppointments();

                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey();
                        break;

                    case 3:

                        Appointment a = new Appointment();

                        Console.Write("Appointment ID : ");
                        a.AppointmentID = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Patient ID : ");
                        a.PatientID = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Doctor ID : ");
                        a.DoctorID = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Appointment Date (yyyy-MM-dd) : ");
                        a.AppointmentDate = Convert.ToDateTime(Console.ReadLine());

                        Console.Write("Time Slot (HH:mm:ss) : ");
                        a.TimeSlot = TimeSpan.Parse(Console.ReadLine());

                        Console.Write("Status : ");
                        a.Status = Console.ReadLine();

                        hc.UpdateAppointment(a);

                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey();
                        break;

                    case 4:

                        Console.Write("Appointment ID : ");

                        int appointmentId = Convert.ToInt32(Console.ReadLine());

                        hc.DeleteAppointment(appointmentId);

                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey();
                        break;

                    case 5:
                        return;

                    default:
                        Console.WriteLine("Invalid Choice");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}