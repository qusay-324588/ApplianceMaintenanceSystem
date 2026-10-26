using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplianceMaintenanceSystem.Interfaces;

namespace ApplianceMaintenanceSystem.Models
{
    // an abstract class that implements an interface and contains common properties, as well as an abstract method for calculating repair costs
    public abstract class Appliance : IMaintaintainable
    {
        // Custom fields (Encapsulation - Special fields to prevent direct modification)
        private string _serialNumber;
        private string _modelName;
        protected decimal _baseCost;
        private string _status;

        //  (Read-only after creation) For the serial number
        public string SerialNumber
        {
            get { return _serialNumber; }
        }

        public string ModelName
        {
            get { return _modelName; }
            set { _modelName = value; }
        }

        public string Status
        {
            get { return _status; }
            set { _status = value; }
        }

        //  (Constructor) To set initial values ​​when creating the object
        protected Appliance(string serialNumber, string modelName, decimal baseCost)
        {
            _serialNumber = serialNumber;
            _modelName = modelName;
            _baseCost = baseCost;
            _status = "On hold";
        }

        //  (Abstract Method) Subclasses must implement it in their own way
        public abstract decimal CalculateRepairCost();

        public virtual void StartMaintenance()
        {
            _status = "Currently under maintenance";
        }

        public virtual string GetDetails()
        {
            return $"Serial number: {_serialNumber} | Model: {_modelName} | the condition: {_status}";
        }
    }
}
