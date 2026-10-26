using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplianceMaintenanceSystem.Models
{
    public class AirConditioner : Appliance
    {
        public int HorsePower { get; set; } // Air conditioner capacity in horsepower

        public AirConditioner(string serial, string model, decimal baseCost, int hp)
            : base(serial, model, baseCost)
        {
            HorsePower = hp;
        }

        public override decimal CalculateRepairCost()
        {
            return _baseCost + (HorsePower * 25.0m);
        }

        public override string GetDetails()
        {
            return $"[air conditioner] " + base.GetDetails() + $" | ability: {HorsePower} horse | Cost: {CalculateRepairCost()} currency";
        }
    }
}
