using System;

namespace BridgelabzCollection.AIResumeScreening
{
    public class ResumeMenu
    {
        public static void Start()
        {
            Resume<SoftwareEngineer> se = new Resume<SoftwareEngineer>();
            Resume<DataScientist> ds = new Resume<DataScientist>();

            bool running = true;

            while (running)
            {

                Console.WriteLine("===== AI RESUME SCREENING =====");
                Console.WriteLine("1. Add Software Engineer");
                Console.WriteLine("2. Add Data Scientist");
                Console.WriteLine("3. Process Software Engineer Resumes");
                Console.WriteLine("4. Process Data Scientist Resumes");
                Console.WriteLine("5. Exit");
                int choice =int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddSoftwareEngineer(se);
                        break;

                    case 2:
                        AddDataScientist(ds);
                        break;

                    case 3:
                        Console.WriteLine("\n--- Software Engineer Screening ---");
                        se.Process();
                        break;

                    case 4:
                        Console.WriteLine("\n--- Data Scientist Screening ---");
                        ds.Process();
                        break;

                    case 5:
                        running = false;
                        Console.WriteLine("Exiting Resume Screening...");
                        break;

                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }
                Console.WriteLine();
            }
        }

        private static void AddSoftwareEngineer(Resume<SoftwareEngineer> se)
        {
            Console.Write("Enter name: ");
            string name = Console.ReadLine();

            Console.Write("Enter experience (years): ");
            int exp = int.Parse(Console.ReadLine());

            SoftwareEngineer role = new SoftwareEngineer(name, exp);
            ResumeUtility.AddRole(se, role);
        }

        private static void AddDataScientist(Resume<DataScientist> ds)
        {
            Console.Write("Enter name: ");
            string name = Console.ReadLine();

            Console.Write("Enter experience (years): ");
            int exp =int.Parse(Console.ReadLine());
            DataScientist role = new DataScientist(name, exp);
            ResumeUtility.AddRole(ds, role);
        }
    }
}
