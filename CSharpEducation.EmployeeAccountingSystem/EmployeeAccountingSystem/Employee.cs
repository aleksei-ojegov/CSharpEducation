using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAccountingSystem
{
 /// <summary>
 /// <Базовый класс для создание работника.
 /// </summary>
    public abstract class Employee
    {
        /// <summary>
        /// <Свойство для имени работника.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// <Свойство для зарплаты работника.
        /// </summary>
        public decimal BaseSalary { get; set; }

        /// <summary>
        /// <Метод для вычисления зарплаты работника.
        /// </summary>
        public abstract decimal CalculateSalary();
    }
}
