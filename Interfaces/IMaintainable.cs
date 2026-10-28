using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Core interfaces architecture developed by (shymaa_358274)
namespace ApplianceMaintenanceSystem.Interfaces
{
    // Defining the interface for maintainable devices
    public interface IMaintaintainable
    {
        // 1. a function to initiate the device maintenance process
        void StartMaintenance();

        // 2. a function to return device details as text
        string GetDetails();
    }
}
