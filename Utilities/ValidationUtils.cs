using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
//Validation utilities and static verification methods developed by (areej_338249)
namespace ApplianceMaintenanceSystem.Utilities
{
    //  (Static Class) Objects cannot be instantiated from it \ it is intended for data validation and static members
    public static class ValidationUtils
    {
        //  (Static Property) To calculate the total number of devices processed at the center
        public static int TotalProcessedAppliances { get; set; } = 0;

        // a static function for validating a serial number  
        public static bool IsValidSerialNumber(string serialNumber)
        {
            if (string.IsNullOrEmpty(serialNumber))
                return false;

            // Using a regular expression (Regex) To ensure the accuracy of the geometric condition
            Regex regex = new Regex(@"^[A-Z]{2}-\d{4}$");
            return regex.IsMatch(serialNumber);
        }

        // a fixed function for validating the model name (ensuring it is not empty and consists of at least two characters)
        public static bool IsValidModelName(string modelName)
        {
            return !string.IsNullOrWhiteSpace(modelName) && modelName.Length >= 2;
        }
    }
}
