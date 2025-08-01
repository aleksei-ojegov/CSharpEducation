using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAccountingSystem
{
    public class EmployeeExceptionNotExists : Exception
    {
        public EmployeeExceptionNotExists(string name)
            : base($"Сотрудник с именем {name} не найден") { }
    }
}
