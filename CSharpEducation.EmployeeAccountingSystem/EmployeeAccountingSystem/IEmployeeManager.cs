using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAccountingSystem
{
    /// <summary>
    /// <Интрефейс для управления сотрудниками.
    /// </summary>
    public interface IEmployeeManager<T> where T : Employee
    {
        /// <summary>
        /// <Метод для добавления сотрудника.
        /// </summary>
        /// <param name="employee">Объект класса сотрудника.</param>
        void Add(T employee);

        /// <summary>
        /// <Метод для вывода сотрудника по его имени.
        /// </summary>
        /// <param name="name">Имя сотрудника.</param>
        /// <returns>Возращает объект сордника, иначе исключение.</returns>
        T Get(string name);

        /// <summary>
        /// <Метод для обновления сотрудника.
        /// </summary>
        /// <param name="employee">Объект класса сотрудника.</param>
        void Update(T employee);

        /// <summary>
        /// <Метод для удаления сотрудника.
        /// </summary>
        /// <param name="name">Имя сотрудника.</param>
        void Remove(string name);
    }
}
