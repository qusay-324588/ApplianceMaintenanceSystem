using System;
using System.Collections.Generic;
using ApplianceMaintenanceSystem.Models;
using ApplianceMaintenanceSystem.Utilities;
using ApplianceMaintenanceSystem.Events;
//Main execution logic and testing scenarios developed by (loseen-362726)
namespace ApplianceMaintenanceSystem
{
    class Program
    {
        static void Main(string[] args)
        {
           
            Console.WriteLine("=== Home appliance maintenance and repair center management system ===");

            // 1. Static Class Testing and Input Validation (Validation & Static Class)
            string testSerial = "WM-2026";
            if (ValidationUtils.IsValidSerialNumber(testSerial))
            {
                Console.WriteLine($" Serial number [Static verification matches the conditions] ({testSerial}).");
            }

            // 2. Creating a main menu for devices (polymorphism) - Polymorphism with List
            List<Appliance> centerAppliances = new List<Appliance>();

            // Adding objects from the three subclasses (Inheritance)
            centerAppliances.Add(new WashingMachine("WM-1001", "LG Turbo", 100.0m, 8));
            centerAppliances.Add(new AirConditioner("AC-2002", "Samsung Inverter", 150.0m, 2));
            centerAppliances.Add(new Refrigerator("RF-3003", "Beko FrostFree", 120.0m, true));

            // 3. Setting up the events and authorization system (Delegates & Events)
            RepairCenterManager manager = new RepairCenterManager();
            manager.OnRepairStatusChanged += (serial, status) => {
                Console.WriteLine($"\n Device number : [Maintenance system event alert] ({serial}) His status changed to: --> {status}");
            };

            // 4. Processing devices and displaying their details and costs using polymorphism
            decimal totalExpectedRevenue = 0;
            foreach (var appliance in centerAppliances)
            {
                appliance.StartMaintenance();
                Console.WriteLine(appliance.GetDetails());
                totalExpectedRevenue += appliance.CalculateRepairCost();

                // Incrementing the fixed counter for the fixed category
                ValidationUtils.TotalProcessedAppliances++;
            }

            Console.WriteLine($"\n Total devices being processed at the center : {ValidationUtils.TotalProcessedAppliances}");
            Console.WriteLine($"Total expected maintenance revenue : {totalExpectedRevenue} currency");

            // 5. Simulating the triggering of a maintenance-completion event for a specific device
            Console.WriteLine("\n--- Simulate triggering events (Events) ---");
            manager.CompleteRepair("WM-1001", true);
            manager.CompleteRepair("AC-2002", false);

            Console.WriteLine("\n==========================================");
          
        }
    }
}
