using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAccountingSystem
{
    public class EmployeeExceptionExists : Exception
    {
        public EmployeeExceptionExists(string name)
            : base($"Сотрудник с именем {name} уже существует") { }
    }
}
