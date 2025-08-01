using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAccountingSystem
{
    /// <summary>
    /// Класс для сотрудника с полной занятостью.
    /// </summary>
    public class FullTimeEmployee : Employee
    {
        public override decimal CalculateSalary()
        {
            return BaseSalary;
        }
    }
}
