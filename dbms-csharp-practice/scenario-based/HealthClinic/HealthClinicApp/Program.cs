 class Program
    {
        static void Main(string[] args)
        {
            ConnectionDB.InitializeDatabase();
            new ClinicMenu().ShowMenu();
        }
    }