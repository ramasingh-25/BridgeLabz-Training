namespace Calculator
{
    // Simulates a database connection
    public class DatabaseConnection
    {
        public bool IsConnected { get; private set; }

        // Connect to database
        public void Connect()
        {
            IsConnected = true;
        }

        // Disconnect from database
        public void Disconnect()
        {
            IsConnected = false;
        }
    }
}
