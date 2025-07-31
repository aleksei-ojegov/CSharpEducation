using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EmployeeAccountingSystem
{
    /// <summary>
    /// <Исключение срабатывает, когда работник с таким именем уже существует.
    /// </summary>
    public class EmployeeExceptionExists : Exception
    {
        public EmployeeExceptionExists(string name)
            : base($"Сотрудник с именем {name} уже существует") { }
    }

    /// <summary>
    /// <Исключение срабатывает, когда работник с таким именем не найден.
    /// </summary>
    public class EmployeeExceptionNotExists : Exception
    {
        public EmployeeExceptionNotExists(string name)
            : base($"Сотрудник с именем {name} не найден") { }
    }

    /// <summary>
    /// <Класс для управления сотрудниками.
    /// </summary>
    public class EmployeeManager<T> : IEmployeeManager<T> where T : Employee
    {
        /// <summary>
        /// <Поле для словоря, хранящего сотрудников.
        /// </summary>
        private readonly Dictionary<string, T> _employees = new();

        public void Add(T employee)
        {
            if (_employees.ContainsKey(employee.Name))
            {
                throw new EmployeeExceptionExists(employee.Name);
            }

            _employees[employee.Name] = employee;
        }

        public T Get(string name)
        {
            if (!_employees.ContainsKey(name))
            {
                throw new EmployeeExceptionNotExists(name);
            }

            return _employees[name];
        }

        public void Update(T employee)
        {
            if (!_employees.ContainsKey(employee.Name))
            {
                throw new EmployeeExceptionNotExists(employee.Name);
            }

            _employees[employee.Name] = employee;
        }

        public void Remove(string name)
        {
            if (!_employees.ContainsKey(name))
            {
                throw new EmployeeExceptionNotExists(name);
            }

            _employees.Remove(name);
        }
    }
}
