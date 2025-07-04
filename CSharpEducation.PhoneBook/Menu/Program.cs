namespace Menu
{
    class Start
    {
        static void Main()
        {
            var book = Phonebook.getInstance();
            List<Abonent> abonents = new List<Abonent>();

            while (true)
            {
                Console.WriteLine("Меню: \n");
                Console.WriteLine("1. Добавить нового абонента");
                Console.WriteLine("2. Вывести список всех абонентов");
                Console.WriteLine("3. Получать абонента по номеру телефона");
                Console.WriteLine("4. Получать номер телефона по имени абонента");
                Console.WriteLine("5. Удалить абонента");
                Console.WriteLine("6. Завершение работы\n");

                string step = Console.ReadLine();

                if (step == "1")
                {
                    Abonent abonent = new Abonent();
                    Console.Write("Введите имя абонента: ");
                    abonent.Name = Console.ReadLine();

                    Console.Write("Введите номер абонента: ");
                    abonent.Nomber = Console.ReadLine();

                    if (book.check_original_abonent(abonent))
                        book.write_text_file(abonent);
                    else
                        Console.WriteLine("Абонент с таким именем или номером уже есть");

                    Console.WriteLine();
                }

                if (step == "2")
                {
                    abonents = book.getArray_abonent();
                    if (abonents.Count > 0)
                    {
                        for (int i = 0; i < abonents.Count; i++)
                        {
                            Abonent abonent1 = abonents[i];
                            Console.WriteLine($"{i + 1} - Имя: {abonent1.Name}, номер: {abonent1.Nomber}");
                        }
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("Абонентов пока нет\n");
                    }
                }

                if (step == "3")
                {
                    Abonent abonent = new Abonent();
                    Console.Write("Введите номер абонента: ");
                    abonent.Nomber = Console.ReadLine();
                    Console.WriteLine($"Имя абонента - {book.search_abonent_name(abonent)}");
                }

                if (step == "4")
                {
                    Abonent abonent = new Abonent();
                    Console.Write("Введите имя абонента: ");
                    abonent.Name= Console.ReadLine();
                    Console.WriteLine($"Номер абонента - {book.search_abonent_nomber(abonent)}");
                }

                if (step == "5")
                {
                    abonents = book.getArray_abonent();
                    if (abonents.Count > 0)
                    {
                        Console.WriteLine($"Список доступных абонентов: ");
                        for (int i = 0; i < abonents.Count; i++)
                        {
                            Abonent abonent1 = abonents[i];
                            Console.WriteLine($"{i + 1} - Имя: {abonent1.Name}, номер: {abonent1.Nomber}");
                        }

                        int delete_nomber = 0;
                        Console.Write($"\nВыберете номер абонента для удаления: ");
                        try
                        {
                            delete_nomber = Convert.ToInt32(Console.ReadLine());
                        }
                        catch
                        {
                            Console.WriteLine($"Не удалось удалить, ошибка с типом данных\n" +
                                $"Введите число от 1 до {abonents.Count}\n");
                        }

                        if (delete_nomber > abonents.Count || delete_nomber > abonents.Count)
                        {
                            if (abonents.Count == 1)
                            {
                                Console.WriteLine($"Не удалось удалить, выход за пределы набора\n" +
                                    $"Сейчас в книге только один абонент\n");
                            }
                            else
                            {
                                Console.WriteLine($"Не удалось удалить, выход за пределы набора\n" +
                                    $"Введите число от 1 до {abonents.Count}\n");
                            }
                        }
                        else
                        {
                            book.delete_abonent(delete_nomber - 1);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Абонентов пока нет\n");
                    }
                }

                if (step == "6")
                {
                    book.write_text_file_end();
                    Console.WriteLine("До скорых встреч !\n");
                    break;
                }
            }
        }
    }
}
