using System;
using System.Drawing;

class TicTacToe
{
    static void Main()
    {
        string[,] box = new string[5,5] {
        { "1", "|", "2", "|", "3" } , 
        { "-", "+", "-", "+", "-" } , 
        { "4", "|", "5", "|", "6" } , 
        { "-", "+", "-", "+", "-" } , 
        { "7", "|", "8", "|", "9" } };
        int[] select_player_1 = new int[9];
        int[] select_player_2 = new int[9];
        int[] nomber_pol = new int[9] {1,2,3,4,5,6,7,8,9};
        string player = "";
        int select_player = 0;
        bool corect_in = false;

        for (int i = 0; i < box.GetLength(0); i++)
        {
            for (int j = 0; j < box.GetLength(1); j++)
            {
                Console.Write(box[i, j]);
                //Console.ForegroundColor = ConsoleColor.Red;
            }
            Console.WriteLine();
        }

        for (int i = 0; i < 9; i++)
        {
            if(i%2 == 0)
            {
                player = "за крестиками";
            }
            else
            {
                player = "за ноликами";
            }

            Console.WriteLine($"Ход игрока {player}:");
            try
            {
                select_player = Convert.ToInt32(Console.ReadLine());
                if (select_player < 0 || select_player > 9)
                {
                    Console.WriteLine("Выход за пределы, сходите правильно");
                    i--;
                    continue;
                }
                else
                {
                    corect_in = true;
                }

                if (i % 2 == 0 && corect_in)
                {
                    select_player_1[i] = select_player;
                }
                else
                {
                    select_player_2[i] = select_player;
                }
            }
            catch 
            {
                Console.WriteLine("Неверный тип данных, сходите правильно");
                i--;
            }
        }
    }
}