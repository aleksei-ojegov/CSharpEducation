using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAccountingSystem
{
    /// <summary>
    /// <Класс сотрудник с почасовой оплатой.
    /// </summary>
    public class PartTimeEmployee : Employee
    {
        /// <summary>
        /// <Свойство определяющее количество отработанных часов.
        /// </summary>
        public int WorkingHours { get; set; }

        /// <summary>
        /// <Свойство определяющее оплату за отработанный час.
        /// </summary>
        public int PricePerHour { get; set; } 

        public override decimal CalculateSalary()
        {
            return WorkingHours * PricePerHour; 
        }
    }
}
