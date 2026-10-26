using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplianceMaintenanceSystem.Events
{
    // 1.(Delegate) To change the maintenance status and define the form of the future function
    public delegate void RepairStatusChangedEventHandler(string serialNumber, string newStatus);

    // a category responsible for managing operations and initiating events related to maintenance status
    public class RepairCenterManager
    {
        // 2.(Event) Using the authorization defined above
        public event RepairStatusChangedEventHandler OnRepairStatusChanged;

        // a function to complete maintenance and trigger an event when a specific condition is met (such as the completion or delay of a repair)
        public void CompleteRepair(string serialNumber, bool isSuccessfullyFixed)
        {
            // Determining the status 
            string status = isSuccessfullyFixed ? "The repair was completed successfully and is under delivery" : "(Delayed repair) Waiting for spare parts";

            // 3.  (Raise Event) Checking that the event is not equal to a null value
            OnRepairStatusChanged?.Invoke(serialNumber, status);
        }
    }
}
