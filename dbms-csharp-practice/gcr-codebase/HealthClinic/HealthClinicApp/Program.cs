 class Program
    {
        static void Main(string[] args)
        {
            ConnectionDB.InitializeDatabase();
            ClinicMenu menu = new ClinicMenu();

            while (true)
            {
                menu.ShowMenu();
                Console.WriteLine();
            }
        }
    }