using System;
using System.Globalization;

namespace Calculator
{
    // Formats date from yyyy-MM-dd to dd-MM-yyyy
    public class DateFormatter
    {
        public string FormatDate(string inputDate)
        {
            try
            {
                DateTime date = DateTime.ParseExact(
                    inputDate,
                    "yyyy-MM-dd",
                    CultureInfo.InvariantCulture
                );

                return date.ToString("dd-MM-yyyy");
            }
            catch
            {
                return "Invalid Date";
            }
        }
    }
}
