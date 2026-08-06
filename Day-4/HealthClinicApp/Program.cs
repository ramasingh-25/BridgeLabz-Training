using HealthClinicApp.Menu;

namespace HealthClinicApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ClinicMenu menu = new ClinicMenu();
            menu.Start();
        }
    }
}