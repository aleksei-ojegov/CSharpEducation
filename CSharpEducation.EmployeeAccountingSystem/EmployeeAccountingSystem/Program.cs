using EmployeeAccountingSystem;
using System.Collections.Generic;
using System;

namespace EmployeeAccountingSystem
{
    class Start
    {
        static void Main()
        {
            var fullTimeManager = new EmployeeManager<FullTimeEmployee>();
            var partTimeManager = new EmployeeManager<PartTimeEmployee>();

            while (true)
            {
                Console.WriteLine("============================================");
                Console.WriteLine("1. Добавить полного сотрудника");
                Console.WriteLine("2. Добавить частичного сотрудника");
                Console.WriteLine("3. Получить информацию о сотруднике");
                Console.WriteLine("4. Обновить данные сотрудника");
                Console.WriteLine("5. Удалить сотрудника");
                Console.WriteLine("6. Выйти");
                Console.Write("Выберите действие: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddFullTimeEmployee(fullTimeManager);
                        break;
                    case "2":
                        AddPartTimeEmployee(partTimeManager);
                        break;
                    case "3":
                        GetInformationEmployee(fullTimeManager, partTimeManager);
                        break;
                    case "4":
                        UpdateEmployeeData(fullTimeManager, partTimeManager);
                        break;
                    case "5":
                        RemoveEmployee(fullTimeManager, partTimeManager);
                        break;
                    case "6":
                        Console.WriteLine("Завершение работы");
                        return;
                    default:
                        Console.WriteLine("Некоректный выбор, введите число от 1 до 5\n");
                        break;
                }
            }
        }

        private static void AddFullTimeEmployee(EmployeeManager<FullTimeEmployee> manager)
        {
            Console.Write("Имя сотрудника: ");
            string name = Console.ReadLine();

            Console.Write("Зарплата сотрудника, целым числом: ");
            try
            {
                int salary = Convert.ToInt32(Console.ReadLine());
                var employee = new FullTimeEmployee { Name = name, BaseSalary = salary };
                manager.Add(employee);

                Console.WriteLine($"Добавлен полный сотрудник {name}\n");
            }
            catch
            {
                Console.WriteLine("Ошибка - введите целое число, для зарплаты сотрудника\n");
            }
        }

        private static void AddPartTimeEmployee(EmployeeManager<PartTimeEmployee> manager)
        {
            Console.Write("Имя сотрудника: ");
            string name = Console.ReadLine();

            try
            {
                Console.Write("Колличество рабочих часов часов: ");
                int hoursWorked = Convert.ToInt32(Console.ReadLine());

                Console.Write("Плата за час: ");
                int hourlyRate = Convert.ToInt32(Console.ReadLine());

                var employee = new PartTimeEmployee
                {
                    Name = name,
                    WorkingHours = hoursWorked,
                    PricePerHour = hourlyRate
                };
                manager.Add(employee);

                Console.WriteLine($"Добавлен частичный сотрудник {name}\n");
            }
            catch
            {
                Console.WriteLine("Ошибка - введите целое число, для колличества часов работы и его платы\n");
            }
        }

        private static void GetInformationEmployee(EmployeeManager<FullTimeEmployee> fullTimeManager, EmployeeManager<PartTimeEmployee> partTimeManager)
        {
            Console.Write("Имя сотрудника: ");
            string name = Console.ReadLine();

            Console.Write("Введите '1' если сотрудник полный,\n" +
                "или введите '2' если сотрудник частичный: ");
            
            try
            {
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        var fullTimeEmployee = fullTimeManager.Get(name);
                        Console.WriteLine($"Полный сотрудник: Имя - {fullTimeEmployee.Name}, зарплата - {fullTimeEmployee.CalculateSalary()}");
                        break;
                    case "2":
                        var partTimeEmployee = partTimeManager.Get(name);
                        Console.WriteLine($"Частичный сотрудник: Имя - {partTimeEmployee.Name}, зарплата - {partTimeEmployee.CalculateSalary()}");
                        break;
                    default:
                        Console.WriteLine("Некоректный выбор, введите число 1 или 2\n");
                        break;
                }
                
            }
            catch (EmployeeExceptionNotExists)
            {
                Console.WriteLine($"Сотрудник с именем {name} не существует\n");
            }
        }

        private static void UpdateEmployeeData(EmployeeManager<FullTimeEmployee> fullTimeManager, EmployeeManager<PartTimeEmployee> partTimeManager)
        {
            Console.Write("Имя сотрудника: ");
            string name = Console.ReadLine();

            Console.Write("Введите '1' если сотрудник полный,\n" +
                "или введите '2' если сотрудник частичный: ");

            try
            {
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        var fullTimeEmployee = fullTimeManager.Get(name);

                        Console.Write("Введите новую зарплату: ");
                        fullTimeEmployee.BaseSalary = Convert.ToInt32(Console.ReadLine());
                        fullTimeManager.Update(fullTimeEmployee);

                        Console.WriteLine($"Обновлён полный сотрудник {name}\n");
                        break;

                    case "2":
                        var partTimeEmployee = partTimeManager.Get(name);

                        Console.Write("Введите новое количество рабочих часов: ");
                        partTimeEmployee.WorkingHours = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Введите новую плату за час: ");
                        partTimeEmployee.PricePerHour = Convert.ToInt32(Console.ReadLine());
                        partTimeManager.Update(partTimeEmployee);

                        Console.WriteLine($"Обновлён частичный сотрудник {name}\n");
                        break;
                    default:
                        Console.WriteLine("Некоректный выбор, введите число 1 или 2\n");
                        break;
                }

            }
            catch (EmployeeExceptionNotExists)
            {
                Console.WriteLine($"Сотрудник с именем {name} не существует\n");
            }
        }

        private static void RemoveEmployee(EmployeeManager<FullTimeEmployee> fullTimeManager, EmployeeManager<PartTimeEmployee> partTimeManager)
        {
            Console.Write("Имя сотрудника: ");
            string name = Console.ReadLine();

            Console.Write("Введите '1' если сотрудник полный,\n" +
                "или введите '2' если сотрудник частичный: ");

            try
            {
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        fullTimeManager.Remove(name);
                        Console.WriteLine($"Полный сотрудник {name} удален\n");
                        break;

                    case "2":
                        partTimeManager.Remove(name);
                        Console.WriteLine($"Частичный сотрудник {name} удален\n");
                        break;
                    default:
                        Console.WriteLine("Некоректный выбор, введите число 1 или 2\n");
                        break;
                }

            }
            catch (EmployeeExceptionNotExists)
            {
                Console.WriteLine($"Сотрудник с именем {name} не существует\n");
            }
        }
    }
}
