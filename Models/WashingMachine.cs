using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplianceMaintenanceSystem.Models
{
    public class WashingMachine : Appliance
    {
        public int DrumCapacityKg { get; set; }

        public WashingMachine(string serial, string model, decimal baseCost, int capacity)
            : base(serial, model, baseCost)
        {
            DrumCapacityKg = capacity;
        }

        //  (Override) To calculate the cost of repairing the washing machine
        public override decimal CalculateRepairCost()
        {
            return _baseCost + (DrumCapacityKg * 5.0m);
        }

        public override string GetDetails()
        {
            return $"[washing machine] " + base.GetDetails() + $" | Capacity: {DrumCapacityKg} kg | Cost: {CalculateRepairCost()} currency";
        }
    }
}
