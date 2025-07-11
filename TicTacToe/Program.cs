using System;
using System.Drawing;

class TicTacToe
{
    static int[,] get_box_index(int number)
    {
        int[,] indexs = new int[1, 2];
        switch (number)
        {
            case 1:
                indexs[0, 0] = 0;
                indexs[0, 1] = 0;
                break;
            case 2:
                indexs[0, 0] = 0;
                indexs[0, 1] = 2;
                break;
            case 3:
                indexs[0, 0] = 0;
                indexs[0, 1] = 4;
                break;
            case 4:
                indexs[0, 0] = 2;
                indexs[0, 1] = 0;
                break;
            case 5:
                indexs[0, 0] = 2;
                indexs[0, 1] = 2;
                break;
            case 6:
                indexs[0, 0] = 2;
                indexs[0, 1] = 4;
                break;
            case 7:
                indexs[0, 0] = 4;
                indexs[0, 1] = 0;
                break;
            case 8:
                indexs[0, 0] = 4;
                indexs[0, 1] = 2;
                break;
            case 9:
                indexs[0, 0] = 4;
                indexs[0, 1] = 4;
                break;
        }
        return indexs;
    }

    static bool get_winner_combination(int[] number)
    {
        bool result = false;
        int[] mass = new int[9];
        for (int i = 0; i < 9; i++)
        {
            mass[i] = Array.IndexOf(number, i + 1);
        }

        if (mass[0] != -1 && mass[1] != -1 && mass[2] != -1) // 1 2 3
            result = true;

        if (mass[0] != -1 && mass[3] != -1 && mass[6] != -1) // 1 4 7
            result = true;

        if (mass[0] != -1 && mass[4] != -1 && mass[8] != -1) // 1 5 9
            result = true;

        if (mass[1] != -1 && mass[4] != -1 && mass[7] != -1) // 2 5 8
            result = true;

        if (mass[3] != -1 && mass[4] != -1 && mass[5] != -1) // 4 5 6
            result = true;

        if (mass[2] != -1 && mass[4] != -1 && mass[6] != -1) // 3 5 7
            result = true;

        if (mass[2] != -1 && mass[5] != -1 && mass[8] != -1) // 3 6 9
            result = true;

        if (mass[6] != -1 && mass[7] != -1 && mass[8] != -1) // 7 8 9
            result = true;

        return result;
    }

    static void Main()
    {
        string[,] box = new string[5, 5] {
        { "1", "|", "2", "|", "3" } ,
        { "-", "+", "-", "+", "-" } ,
        { "4", "|", "5", "|", "6" } ,
        { "-", "+", "-", "+", "-" } ,
        { "7", "|", "8", "|", "9" } };
        int[] select_player_1 = new int[9];
        int[] select_player_2 = new int[9];
        int[] nomber_pol = new int[9];
        int[,] nomber_pol_player = new int[2, 9];
        string player = "";
        int select_player = 0;
        bool corect_in = false;
        bool winner = false;
        string X = "X";
        string O = "O";

        for (int i = 0; i < box.GetLength(0); i++)
        {
            for (int j = 0; j < box.GetLength(1); j++)
            {
                Console.Write(box[i, j]);
            }
            Console.WriteLine();
        }

        for (int i = 0; i < 9; i++)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Ход ");
            if (i % 2 == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                player = "крестиков";
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                player = "ноликов";
            }

            Console.WriteLine(player + '\n');
            Console.ForegroundColor = ConsoleColor.White;
            try
            {
                select_player = Convert.ToInt32(Console.ReadLine());
                int get_replay = Array.IndexOf(nomber_pol, select_player);
                if (select_player < 1 || select_player > 9)
                {
                    Console.WriteLine("Выход за пределы\n" +
                        "Введите число от 1 до 9");
                    i--;
                    continue;
                }
                else if (get_replay != -1)
                {
                    Console.WriteLine("Данный ход уже был\n" +
                        "Введите число от 1 до 9, которое ещё не использовалось");
                    i--;
                    continue;
                }
                else
                {
                    nomber_pol[i] = select_player;
                    corect_in = true;
                }

                int[,] nn = get_box_index(select_player);

                if (i % 2 == 0 && corect_in)
                {
                    select_player_1[i] = select_player;
                    nomber_pol_player[0, i] = 1;
                    nomber_pol_player[1, i] = select_player;
                    box[nn[0, 0], nn[0, 1]] = X;
                }
                else
                {
                    select_player_2[i] = select_player;
                    nomber_pol_player[0, i] = 2;
                    nomber_pol_player[1, i] = select_player;
                    box[nn[0, 0], nn[0, 1]] = O;
                }

            }
            catch
            {
                Console.WriteLine("Неверный тип данных, сходите правильно");
                i--;
            }

            Console.WriteLine();
            for (int k = 0; k < box.GetLength(0); k++)
            {
                for (int j = 0; j < box.GetLength(1); j++)
                {
                    if (box[k, j] == X)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else if (box[k, j] == O)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    Console.Write(box[k, j]);
                }
                Console.WriteLine();
            }

            if (i % 2 == 0)
            {
                select_player_1[i] = select_player;
                if (get_winner_combination(select_player_1))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Победитель играл крестами !");
                    winner = true;
                    break;
                }
            }
            else
            {
                select_player_2[i] = select_player;
                if (get_winner_combination(select_player_2))
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Победитель играл нулями !");
                    winner = true;
                    break;
                }
            }
        }

        if (!winner)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Ничья");
        }
        Console.ForegroundColor = ConsoleColor.White;
        Console.ReadLine();
    }
}
