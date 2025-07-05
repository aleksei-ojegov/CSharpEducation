using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAccountingSystem
{
    public class FullTimeEmployee : Employee
    {
        public override decimal CalculateSalary()
        {
            return BaseSalary;
        }
    }
}
