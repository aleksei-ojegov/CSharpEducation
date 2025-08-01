using EmployeeAccountingSystem;
using System.Collections.Generic;
using System;

namespace EmployeeAccountingSystem
{
    /// <summary>
    /// <Класс для старта консольного приложения.
    /// </summary>
    class Start
    {
        /// <summary>
        /// <Класс Main.
        /// </summary>
        static void Main()
        {
            /// <summary>
            /// <Поле для создания объекта класса сотрудника с полной занятостью.
            /// </summary>
            var fullTimeManager = new EmployeeManager<FullTimeEmployee>();

            /// <summary>
            /// <Поле для создания объекта класса сотрудника с почасовой оплатой.
            /// </summary>
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

                /// <summary>
                /// <Поле для записи выбора действия меню с консоли.
                /// </summary>
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

        /// <summary>
        /// <Метод для добавления сотрудника с полной занятостью.
        /// </summary>
        /// <param name="manager">Ссылка на класс менеджера сотрудников с полной занятостью.</param>
        private static void AddFullTimeEmployee(EmployeeManager<FullTimeEmployee> manager)
        {
            Console.Write("Имя сотрудника: ");
            
            /// <summary>
            /// <Поле для записи имени сотрудника с консоли.
            /// </summary>
            string name = Console.ReadLine();

            Console.Write("Зарплата сотрудника, целым числом: ");
            try
            {
                /// <summary>
                /// <Поле для записи зарплаты сотрудника с консоли.
                /// </summary>
                int salary = Convert.ToInt32(Console.ReadLine());

                /// <summary>
                /// <Поле для создания объекта класса сотрудника с полной занятостью.
                /// </summary>
                var employee = new FullTimeEmployee { Name = name, BaseSalary = salary };
                manager.Add(employee);

                Console.WriteLine($"Добавлен полный сотрудник {name}\n");
            }
            catch
            {
                Console.WriteLine("Ошибка - введите целое число, для зарплаты сотрудника\n");
            }
        }

        /// <summary>
        /// <Метод для добавления сотрудника с почасовой оплатой.
        /// </summary>
        /// <param name="manager">Ссылка на класс менеджера сотрудников с почасовой оплатой.</param>
        private static void AddPartTimeEmployee(EmployeeManager<PartTimeEmployee> manager)
        {
            Console.Write("Имя сотрудника: ");
            
            /// <summary>
            /// <Поле для записи имени сотрудника с консоли.
            /// </summary>
            string name = Console.ReadLine();

            try
            {
                Console.Write("Колличество рабочих часов часов: ");

                /// <summary>
                /// <Поле для записи колличества отрадотаных часов сотрудником с консоли.
                /// </summary>
                int hoursWorked = Convert.ToInt32(Console.ReadLine());

                Console.Write("Плата за час: ");

                /// <summary>
                /// <Поле для записи платы за час отработанный сотрудником с консоли.
                /// </summary>
                int hourlyRate = Convert.ToInt32(Console.ReadLine());

                /// <summary>
                /// <Поле для создания объекта класса сотрудника с почасовой оплатой.
                /// </summary>
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

        /// <summary>
        /// <Метод для получения информации о сотруднике.
        /// </summary>
        /// <param name="fullTimeManager">Ссылка на класс менеджера сотрудников с полной занятостью.</param>
        /// <param name="partTimeManager">Ссылка на класс менеджера сотрудников с почасовой оплатой.</param>
        private static void GetInformationEmployee(EmployeeManager<FullTimeEmployee> fullTimeManager, EmployeeManager<PartTimeEmployee> partTimeManager)
        {
            Console.Write("Имя сотрудника: ");

            /// <summary>
            /// <Поле для записи имени сотрудника с консоли.
            /// </summary>
            string name = Console.ReadLine();

            Console.Write("Введите '1' если сотрудник полный,\n" +
                "или введите '2' если сотрудник частичный: ");
            
            try
            {
                /// <summary>
                /// <Поле для выбора типа сотрудника с консоли.
                /// </summary>
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        /// <summary>
                        /// <Поле для записи объекта класса сотрудника с полной занятостью из метода класса менеджера сотрудников.
                        /// </summary>
                        var fullTimeEmployee = fullTimeManager.Get(name);
                        
                        Console.WriteLine($"Полный сотрудник: Имя - {fullTimeEmployee.Name}, зарплата - {fullTimeEmployee.CalculateSalary()}");
                        break;
                    case "2":
                        /// <summary>
                        /// <Поле для записи объекта класса сотрудника с почасовой оплатой из метода класса менеджера сотрудников.
                        /// </summary>
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

            /// <summary>
            /// <Поле для записи имени сотрудника с консоли.
            /// </summary>
            string name = Console.ReadLine();

            Console.Write("Введите '1' если сотрудник полный,\n" +
                "или введите '2' если сотрудник частичный: ");

            try
            {
                /// <summary>
                /// <Поле для выбора типа сотрудника с консоли.
                /// </summary>
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        /// <summary>
                        /// <Поле для записи объекта класса сотрудника с полной занятостью из метода класса менеджера сотрудников.
                        /// </summary>
                        var fullTimeEmployee = fullTimeManager.Get(name);

                        Console.Write("Введите новую зарплату: ");
                        fullTimeEmployee.BaseSalary = Convert.ToInt32(Console.ReadLine());
                        fullTimeManager.Update(fullTimeEmployee);

                        Console.WriteLine($"Обновлён полный сотрудник {name}\n");
                        break;

                    case "2":
                        /// <summary>
                        /// <Поле для записи объекта класса сотрудника с почасовой оплатой из метода класса менеджера сотрудников.
                        /// </summary>
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

            /// <summary>
            /// <Поле для записи имени сотрудника с консоли.
            /// </summary>
            string name = Console.ReadLine();

            Console.Write("Введите '1' если сотрудник полный,\n" +
                "или введите '2' если сотрудник частичный: ");

            try
            {
                /// <summary>
                /// <Поле для выбора типа сотрудника с консоли.
                /// </summary>
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
