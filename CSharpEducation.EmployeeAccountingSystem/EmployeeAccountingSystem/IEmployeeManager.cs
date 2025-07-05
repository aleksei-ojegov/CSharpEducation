using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAccountingSystem
{
    public interface IEmployeeManager<T> where T : Employee
    {
        void Add(T employee);
        T Get(string name);
        void Update(T employee);
        void Remove(string name);
    }
}
