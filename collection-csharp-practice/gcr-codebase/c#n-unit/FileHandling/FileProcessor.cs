using System.IO;

namespace Calculator
{
    // Handles basic file operations
    public class FileProcessor
    {
        // Writes content to a file
        public void WriteToFile(string filename, string content)
        {
            File.WriteAllText(filename, content);
        }

        // Reads content from a file
        public string ReadFromFile(string filename)
        {
            // This will throw FileNotFoundException if file does not exist
            return File.ReadAllText(filename);
        }
    }
}
