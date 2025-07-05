using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAccountingSystem
{
    public abstract class Employee
    {
        public string Name { get; set; }
        public decimal BaseSalary { get; set; }

        public abstract decimal CalculateSalary();
    }
}
