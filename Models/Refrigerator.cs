using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplianceMaintenanceSystem.Models
{
    public class Refrigerator : Appliance
    {
        public bool HasDualDoor { get; set; }

        public Refrigerator(string serial, string model, decimal baseCost, bool dualDoor)
            : base(serial, model, baseCost)
        {
            HasDualDoor = dualDoor;
        }

        public override decimal CalculateRepairCost()
        {
            decimal dualDoorFee = HasDualDoor ? 50.0m : 0.0m;
            return _baseCost + dualDoorFee;
        }

        public override string GetDetails()
        {
            return $"[refrigerator] " + base.GetDetails() + $" | Double door: {(HasDualDoor ? "yes" : "no")} | Cost: {CalculateRepairCost()} currency";
        }
    }
}
