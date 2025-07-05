using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAccountingSystem
{
    public class PartTimeEmployee : Employee
    {
        public int WorkingHours { get; set; } 
        public int PricePerHour { get; set; } 

        public override decimal CalculateSalary()
        {
            return WorkingHours * PricePerHour; 
        }
    }
}
