using System;
using System.Linq;
using System.Threading;
using System.Collections.Generic;

namespace Mega_Monsters_Party
{
    internal class Program
    {
        class board
        {
            public string[] viewBoard = new string[42];
            public string spaces = "        ";
            bool drawn = false;
            public char ch = '[';
            public void createTheBoard()
            {
                for (int i = 0; i < viewBoard.Length; i++)
                {
                    viewBoard[i] = "[ ]";
                }
                viewBoard[0] = $"{spaces}[123]";
                viewBoard[9] = $"{spaces}[S]";
                viewBoard[19] = $"{spaces}[$]";
                viewBoard[30] = $"{spaces}[S]";

                viewBoard[5] = "[!]";
                viewBoard[15] = "[!]";
                viewBoard[16] = "[!]";
                viewBoard[23] = "[!]";
                viewBoard[35] = "[!]";
                viewBoard[39] = "[!]";
                viewBoard[40] = "[!]";

                viewBoard[7] = "[$]";
                viewBoard[18] = "[$]";
                viewBoard[28] = "[$]";
                viewBoard[31] = "[$]";

                viewBoard[11] = "[A]";
                viewBoard[13] = "[A]";
                viewBoard[34] = "[A]";

                viewBoard[26] = "[X]";
                viewBoard[33] = "[X]";

                viewBoard[32] = "[S]";
                viewBoard[21] = "[S]";
                viewBoard[17] = "[S]";

                viewBoard[41] = "[F]\n";
            }

            public void drawTheBoard()
            {
                Console.Clear();
                if (!drawn)
                {
                    viewBoard[0] = viewBoard[0].Insert(0, "\n\n");
                    viewBoard[9] = viewBoard[9].Insert(0, "\n\n");
                    viewBoard[19] = viewBoard[19].Insert(0, "\n\n");
                    viewBoard[30] = viewBoard[30].Insert(0, "\n\n");
                    drawn = true;
                }/////////////////////////////////////////////////////////
                players.getInfoAboutPlayers();
                foreach (var j in viewBoard)
                {
                    Console.Write(j + " ");
                }
            }

            public void correctTheBoard()
            {
                for (int i = 0; i < viewBoard.Length; i++)
                {
                    if (viewBoard[i] == "[]")
                    {
                        viewBoard[i] = "[ ]";
                    }
                    if (viewBoard[i] == $"\n\n{spaces}[]")
                    {
                        viewBoard[i] = $"\n\n{spaces}[ ]";
                    }
                }
            }
        }

        class cub
        {
            static Random rnd = new Random();
            public int rndvalue = 0;
            public void whichValue(string whichPlayer)
            {
                rndvalue = rnd.Next(1, 7);
                Console.Write($"\n        Игроку {whichPlayer} выпадает");
                Thread.Sleep(230);
                Console.Write(".");
                Thread.Sleep(230);
                Console.Write(".");
                Thread.Sleep(230);
                Console.Write(".");
                Console.Write($"{rndvalue}!\n");
                Console.Write("\n\n        Продолжить --> 'Enter' ");
                Console.ReadLine();
            }
        }

        class players : board
        {
            static board b = new board();
            static game g = new game();
            static Random rnd = new Random();

            public static string playerName;
            public static int posP1 = 0;
            public static string bot1Name;
            public static int posB1 = 0;
            public static string bot2Name;
            public static int posB2 = 0;

            public static int P1M = 0;
            public static int B1M = 0;
            public static int B2M = 0;

            public static bool playerIsDead = false;
            public static bool bot1IsDead = false;
            public static bool bot2IsDead = false;

            public static bool playerOnFinish = false;
            public static bool bot1OnFinish = false;
            public static bool bot2OnFinish = false;

            public static List<string> playerInventory = new List<string>();
            public static List<string> bot1Inventory = new List<string>();
            public static List<string> bot2Inventory = new List<string>();

            public static int quantity1stcart;
            public static int quantity2stcart;
            public static int quantity3stcart;

            public static int quantity1stcartInInventoryPlayer;
            public static int quantity2stcartInInventoryPlayer;
            public static int quantity3stcartInInventoryPlayer;

            public static int quantity1stcartInInventoryBot1;
            public static int quantity2stcartInInventoryBot1;
            public static int quantity3stcartInInventoryBot1;

            public static int quantity1stcartInInventoryBot2;
            public static int quantity2stcartInInventoryBot2;
            public static int quantity3stcartInInventoryBot2;

            public static bool player_5StepsBack = false;
            public static bool bot1_5StepsBack = false;
            public static bool bot2_5StepsBack = false;

            public static bool exitCycleP1 = false;
            public static bool exitCycleB1 = false;
            public static bool exitCycleB2 = false;
            public static bool exitInventory = false;

            public static int skippingTheMovePlayerCount = 3;
            public static int skippingTheMoveBot1Count = 3;
            public static int skippingTheMoveBot2Count = 3;

            public static bool OneTime = false;

            public static void setNames()
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("Введите ваше имя:   (4-10 символов, пробелы удалятся)");
                    Console.Write("\n--> ");
                    playerName = Console.ReadLine();
                    playerName = playerName.Replace(" ", "");
                    playerName = playerName.Replace("\t", string.Empty);
                    if (playerName.Count() < 4)
                    {
                        Console.WriteLine("Нужно минимум 4 буквы");
                        Console.ReadLine();
                        continue;
                    }
                    if (playerName.Count() > 10)
                    {
                        Console.WriteLine("Нужно меньше 10 символов");
                        Console.ReadLine();
                        continue;
                    }
                    break;
                }//p1
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("Введите имя первого бота:   (4-10 символов, пробелы удалятся)");
                    Console.Write("\n--> ");
                    bot1Name = Console.ReadLine();
                    bot1Name = bot1Name.Replace(" ", "");
                    bot1Name = bot1Name.Replace("\t", string.Empty);
                    if (bot1Name.Count() < 4)
                    {
                        Console.WriteLine("Нужно минимум 4 буквы");
                        Console.ReadLine();
                        continue;
                    }
                    if (bot1Name.Count() > 10)
                    {
                        Console.WriteLine("Нужно меньше 10 символов");
                        Console.ReadLine();
                        continue;
                    }
                    if (bot1Name == playerName)
                    {
                        Console.WriteLine("Имена не могут быть одинаковыми");
                        Console.ReadLine();
                        continue;
                    }
                    break;
                }//b1
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("Введите имя второго бота:   (4-10 символов, пробелы удалятся)");
                    Console.Write("\n--> ");
                    bot2Name = Console.ReadLine();
                    bot2Name = bot2Name.Replace(" ", "");
                    bot2Name = bot2Name.Replace("\t", string.Empty);
                    if (bot2Name.Count() < 4)
                    {
                        Console.WriteLine("Нужно минимум 4 буквы");
                        Console.ReadLine();
                        continue;
                    }
                    if (bot2Name.Count() > 10)
                    {
                        Console.WriteLine("Нужно меньше 10 символов");
                        Console.ReadLine();
                        continue;
                    }
                    if (bot2Name == playerName || bot2Name == bot1Name)
                    {
                        Console.WriteLine("Имена не могут быть одинаковыми");
                        Console.ReadLine();
                        continue;
                    }
                    break;
                }//b2
            }
            public static void getInfoAboutPlayers()
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                if (!playerOnFinish)
                {
                    if (!playerIsDead) Console.WriteLine($"1) {playerName}: клетка: {posP1 + 1} денег: {P1M}$");
                    else Console.WriteLine("1) Выбыл");
                }
                else Console.WriteLine($"1) На финише!");
                if (!bot1OnFinish)
                {
                    if (!bot1IsDead) Console.WriteLine($"2) {bot1Name}: клетка: {posB1 + 1} денег: {B1M}$");
                    else Console.WriteLine("2) Выбыл");
                }
                else Console.WriteLine($"2) На финише!");
                if (!bot2OnFinish)
                {
                    if (!bot2IsDead) Console.WriteLine($"3) {bot2Name}: клетка: {posB2 + 1} денег: {B2M}$");
                    else Console.WriteLine("3) Выбыл");
                }
                else Console.WriteLine($"3) На финише!");

                Console.ForegroundColor = ConsoleColor.White;
            }
            public static void stackItems(List<string> inventory, int which)
            {
                quantity1stcart = 0;
                quantity2stcart = 0;
                quantity3stcart = 0;
                for (int i = 0; i < inventory.Count; i++)
                {
                    if (inventory[i] == "карта подставы")
                    {
                        quantity1stcart++;
                    }
                    if (inventory[i] == "карта вызова")
                    {
                        quantity2stcart++;
                    }
                    if (inventory[i] == "карта заточения")
                    {
                        quantity3stcart++;
                    }
                }
                if (which == 0)
                {
                    quantity1stcartInInventoryPlayer = quantity1stcart;
                    quantity2stcartInInventoryPlayer = quantity2stcart;
                    quantity3stcartInInventoryPlayer = quantity3stcart;
                }
                if (which == 1)
                {
                    quantity1stcartInInventoryBot1 = quantity1stcart;
                    quantity2stcartInInventoryBot1 = quantity2stcart;
                    quantity3stcartInInventoryBot1 = quantity3stcart;
                }
                if (which == 2)
                {
                    quantity1stcartInInventoryBot2 = quantity1stcart;
                    quantity2stcartInInventoryBot2 = quantity2stcart;
                    quantity3stcartInInventoryBot2 = quantity3stcart;
                }
            }// стакает предметы в инвентаре
            public static void openInventory()
            {
                int inventoryChoice = 0;
                while (inventoryChoice != 4)
                {
                    Console.Clear();
                    stackItems(playerInventory, 0);
                    if (playerInventory.Count > 0)
                    {
                        Console.WriteLine("\t Инвентарь:");
                        if (quantity1stcartInInventoryPlayer > 0) Console.WriteLine($"Карта подставы (у вас {quantity1stcartInInventoryPlayer} шт)\n");
                        if (quantity2stcartInInventoryPlayer > 0) Console.WriteLine($"Карта вызова (у вас {quantity2stcartInInventoryPlayer} шт)\n");
                        if (quantity3stcartInInventoryPlayer > 0) Console.WriteLine($"Карта заточения (у вас {quantity3stcartInInventoryPlayer} шт)\n");

                        if (quantity1stcartInInventoryPlayer > 0) Console.WriteLine("\nИспользовать карту подставы(1)");
                        if (quantity2stcartInInventoryPlayer > 0) Console.WriteLine("Использовать карту вызова(2)");
                        if (quantity3stcartInInventoryPlayer > 0) Console.WriteLine("Использовать карту заточения(3)");
                        Console.Write("\nЗакрыть инвентарь(4)");
                        Console.Write("\n\n--> ");

                        try
                        {
                            inventoryChoice = int.Parse(Console.ReadLine());
                            switch (inventoryChoice)
                            {
                                case 1:
                                    if (quantity1stcartInInventoryPlayer > 0)
                                    {
                                        playerInventory.Remove("карта подставы");
                                        int victimChoice = 0;
                                        while (victimChoice != 1 && victimChoice != 2)
                                        {
                                            Console.Clear();
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("\tВыберите жертву");
                                            if (!bot1IsDead) Console.WriteLine($"\n{bot1Name}, позиция: {posB1 + 1} (1)");
                                            if (!bot2IsDead) Console.Write($"{bot2Name}, позиция: {posB2 + 1} (2)");
                                            Console.Write("\n\n--> ");
                                            try
                                            {
                                                victimChoice = int.Parse(Console.ReadLine());
                                                Console.ForegroundColor = ConsoleColor.White;
                                                switch (victimChoice)
                                                {
                                                    case 1:
                                                        if (!bot1IsDead)
                                                        {
                                                            posB1 -= 5;
                                                            if (posB1 < 0) posB1 = 0;
                                                            exitCycleP1 = true;
                                                            bot1_5StepsBack = true;
                                                        }
                                                        break;
                                                    case 2:
                                                        if (!bot2IsDead)
                                                        {
                                                            posB2 -= 5;
                                                            if (posB2 < 0) posB2 = 0;
                                                            exitCycleP1 = true;
                                                            bot2_5StepsBack = true;
                                                        }
                                                        break;
                                                    default:
                                                        Console.WriteLine("Введите либо 1 либо 2");
                                                        Console.ReadLine();
                                                        continue;
                                                }
                                            }
                                            catch
                                            {
                                                Console.WriteLine("Ошибка");
                                                Console.ReadLine();
                                            }
                                            if (exitCycleP1) break;
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("У вас нет такой карты");
                                        Console.ReadLine();
                                    }
                                    break;
                                case 2:
                                    if (quantity2stcartInInventoryPlayer > 0)
                                    {
                                        playerInventory.Remove("карта вызова");

                                        int victimChoice = 0;
                                        while (victimChoice != 1 && victimChoice != 2)
                                        {
                                            Console.Clear();
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("\tВыберите жертву");
                                            if (!bot1IsDead) Console.WriteLine($"\n{bot1Name}, деньги: {B1M} (1)");
                                            if (!bot2IsDead) Console.Write($"{bot2Name}, деньги: {B2M} (2)");
                                            Console.Write("\n\n(если вы выберите игрока у которого меньше $10, то получите столько, сколько у него есть)");
                                            Console.Write("\n\n--> ");
                                            try
                                            {
                                                victimChoice = int.Parse(Console.ReadLine());
                                                Console.ForegroundColor = ConsoleColor.White;
                                                switch (victimChoice)
                                                {
                                                    case 1:
                                                        if (!bot1IsDead)
                                                            g.attackKNB(true, 1, "player", false, 0);
                                                        break;
                                                    case 2:
                                                        if (!bot2IsDead)
                                                            g.attackKNB(true, 2, "player", false, 0);
                                                        break;
                                                    default:
                                                        Console.WriteLine("Введите либо 1 либо 2");
                                                        Console.ReadLine();
                                                        continue;
                                                }
                                            }
                                            catch
                                            {
                                                Console.WriteLine("Ошибка");
                                                Console.ReadLine();
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("У вас нет такой карты");
                                        Console.ReadLine();
                                    }
                                    break;
                                case 3:
                                    if (quantity3stcartInInventoryPlayer > 0)
                                    {
                                        playerInventory.Remove("карта заточения");
                                        int victimChoice = 0;
                                        exitCycleP1 = true;
                                        while (victimChoice != 1 && victimChoice != 2)
                                        {
                                            Console.Clear();
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("\tВыберите жертву");
                                            if (!bot1IsDead) Console.WriteLine($"\n{bot1Name}, позиция: {posB1} (1)");
                                            if (!bot2IsDead) Console.Write($"{bot2Name}, позиция: {posB2} (2)");
                                            Console.Write("\n\n--> ");
                                            try
                                            {
                                                victimChoice = int.Parse(Console.ReadLine());
                                                Console.ForegroundColor = ConsoleColor.White;

                                                switch (victimChoice)
                                                {
                                                    case 1:
                                                        if (!bot1IsDead)
                                                            skippingTheMoveBot1Count = 0;
                                                        break;
                                                    case 2:
                                                        if (!bot2IsDead)
                                                            skippingTheMoveBot2Count = 0;
                                                        break;
                                                    default:
                                                        Console.WriteLine("Введите либо 1 либо 2");
                                                        Console.ReadLine();
                                                        continue;
                                                }
                                            }
                                            catch
                                            {
                                                Console.WriteLine("Ошибка");
                                                Console.ReadLine();
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("У вас нет такой карты");
                                        Console.ReadLine();
                                    }
                                    break;
                                default:
                                    Console.WriteLine("Введите от 1 до 4");
                                    Console.ReadLine();
                                    continue;
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Ошибка");
                            Console.ReadLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Ваш инвентарь пуст\n");
                        Console.Write("Закрыть инвентарь(4)");
                        Console.Write("\n\n--> ");
                        try
                        {
                            inventoryChoice = int.Parse(Console.ReadLine());
                            if (inventoryChoice != 4)
                            {
                                Console.WriteLine("Ошибка");
                                Console.ReadLine();
                                continue;
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Ошибка");
                            Console.ReadLine();
                        }
                    }
                    if (exitCycleP1) break;
                    if (exitInventory)
                    {
                        exitInventory = false;
                        break;
                    }
                }
            }
            public static void botsUsedTheCard(int whichBot)
            {
                if (whichBot == 1)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        stackItems(bot1Inventory, 1);
                        if (!OneTime)// использовать карту можно только 1 раз
                        {
                            if (rnd.Next(1, 101) > 20)// 80% бот думает использовать ли карту
                            {
                                if (quantity1stcartInInventoryBot1 > 0)
                                {
                                    if (rnd.Next(1, 101) > 30)// 70% что бот использует именно эту карту
                                    {
                                        bot1Inventory.Remove("карта подставы");
                                        OneTime = true;
                                        if (rnd.Next(1, 101) > 40)// 60% что бот использует эту карту против игрока и 40 против бота
                                        {
                                            if (!playerIsDead)
                                            {
                                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                                Console.Write($"\n\n        Игрок {bot1Name} использовал карту подставы против игрока {playerName}");
                                                Console.Write("\n\n           Продолжить --> 'Enter' ");
                                                Console.ReadLine();
                                                Console.ForegroundColor = ConsoleColor.White;
                                                posP1 -= 5;
                                                if (posP1 < 0) posP1 = 0;
                                                exitCycleB1 = true;
                                                player_5StepsBack = true;
                                            }
                                        }
                                        else
                                        {
                                            if (!bot2IsDead)
                                            {
                                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                                Console.Write($"\n\n        Игрок {bot1Name} использовал карту подставы против игрока {bot2Name}");
                                                Console.Write("\n             Продолжить --> 'Enter' ");
                                                Console.ReadLine();
                                                Console.ForegroundColor = ConsoleColor.White;
                                                posB2 -= 5;
                                                if (posB2 < 0) posB2 = 0;
                                                exitCycleB1 = true;
                                                bot2_5StepsBack = true;
                                            }
                                        }
                                    }
                                }
                                if (quantity2stcartInInventoryBot1 > 0)
                                {
                                    if (rnd.Next(1, 101) > 30)// 70% что бот использует именно эту карту
                                    {
                                        bot1Inventory.Remove("карта вызова");
                                        OneTime = true;
                                        if (rnd.Next(1, 101) > 40)// 60 % что бот использует эту карту против игрока
                                        {
                                            if (!playerIsDead)
                                            {
                                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                                Console.Write($"\n\n        Игрок {bot1Name} использовал карту вызова против игрока {playerName}");
                                                Console.Write("\n\n           Продолжить --> 'Enter' ");
                                                Console.ReadLine();
                                                g.attackKNB(true, 1, "bot", false, 0);
                                                Console.ForegroundColor = ConsoleColor.White;
                                            }
                                        }
                                        else
                                        {
                                            if (!bot2IsDead)
                                            {
                                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                                Console.Write($"\n\n        Игрок {bot1Name} использовал карту вызова против игрока {bot2Name}");
                                                Console.Write("\n             Продолжить --> 'Enter' ");
                                                Console.ReadLine();
                                                g.attackKNB(false, 0, "bot", true, 1);
                                                Console.ForegroundColor = ConsoleColor.White;
                                            }
                                        }
                                    }
                                }
                                if (quantity3stcartInInventoryBot1 > 0)
                                {
                                    bot1Inventory.Remove("карта заточения");
                                    OneTime = true;
                                    if (rnd.Next(1,101) >= 50 )
                                    {
                                        if (!playerIsDead)
                                        {
                                            Console.ForegroundColor = ConsoleColor.DarkRed;
                                            Console.Write($"\n\n        Игрок {bot1Name} использовал карту заточения против игрока {playerName}");
                                            Console.Write("\n\n           Продолжить --> 'Enter' ");
                                            Console.ReadLine();
                                            skippingTheMovePlayerCount = 0;
                                        }
                                    }
                                    else
                                    {
                                        if (!bot2IsDead)
                                        {
                                            Console.ForegroundColor = ConsoleColor.DarkRed;
                                            Console.Write($"\n\n        Игрок {bot1Name} использовал карту заточения против игрока {bot2Name}");
                                            Console.Write("\n\n           Продолжить --> 'Enter' ");
                                            Console.ReadLine();
                                            skippingTheMoveBot2Count = 0;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                if (whichBot == 2)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        stackItems(bot2Inventory, 2);
                        if (!OneTime)// использовать карту можно только 1 раз
                        {
                            if (rnd.Next(1, 101) > 20)// 80% бот думает использовать ли карту
                            {
                                if (quantity1stcartInInventoryBot2 > 0)
                                {
                                    if (rnd.Next(1, 101) > 30)// 70% что бот использует именно эту карту
                                    {
                                        bot2Inventory.Remove("карта подставы");
                                        OneTime = true;
                                        if (rnd.Next(1, 101) > 50)// 50 % что бот использует эту карту против игрока
                                        {
                                            if (!playerIsDead)
                                            {
                                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                                Console.Write($"\n\n        Игрок {bot2Name} использовал карту подставы против игрока {playerName}");
                                                Console.Write("\n\n           Продолжить --> 'Enter' ");
                                                Console.ReadLine();
                                                Console.ForegroundColor = ConsoleColor.White;
                                                posP1 -= 5;
                                                if (posP1 < 0) posP1 = 0;
                                                exitCycleB2 = true;
                                                player_5StepsBack = true;
                                            }
                                        }
                                        else
                                        {
                                            if (!bot1IsDead)
                                            {
                                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                                Console.Write($"\n\n        Игрок {bot2Name} использовал карту подставы против игрока {bot1Name}");
                                                Console.Write("\n\n           Продолжить --> 'Enter' ");
                                                Console.ReadLine();
                                                Console.ForegroundColor = ConsoleColor.White;
                                                posB1 -= 5;
                                                if (posB1 < 0) posB1 = 0;
                                                exitCycleB2 = true;
                                                bot1_5StepsBack = true;
                                            }
                                        }
                                    }
                                }
                                if (quantity2stcartInInventoryBot2 > 0)
                                {
                                    if (rnd.Next(1, 101) > 30)// 70% что бот использует именно эту карту
                                    {
                                        bot2Inventory.Remove("карта вызова");
                                        OneTime = true;
                                        if (rnd.Next(1, 101) > 40)// 60 % что бот использует эту карту против игрока
                                        {
                                            if (!playerIsDead)
                                            {
                                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                                Console.Write($"\n\n        Игрок {bot2Name} использовал карту вызова против игрока {playerName}");
                                                Console.Write("\n\n           Продолжить --> 'Enter' ");
                                                Console.ReadLine();
                                                g.attackKNB(true, 2, "bot", false, 0);
                                                Console.ForegroundColor = ConsoleColor.White;
                                            }
                                        }
                                        else
                                        {
                                            if (!bot1IsDead)
                                            {
                                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                                Console.Write($"\n\n        Игрок {bot2Name} использовал карту вызова против игрока {bot1Name}");
                                                Console.Write("\n             Продолжить --> 'Enter' ");
                                                Console.ReadLine();
                                                g.attackKNB(false, 0, "bot", true, 2);
                                                Console.ForegroundColor = ConsoleColor.White;
                                            }
                                        }
                                    }
                                }
                                if (quantity3stcartInInventoryBot2 > 0)
                                {
                                    bot2Inventory.Remove("карта заточения");
                                    OneTime = true;
                                    if (rnd.Next(1, 101) >= 50)
                                    {
                                        if (!playerIsDead)
                                        {
                                            Console.ForegroundColor = ConsoleColor.DarkRed;
                                            Console.Write($"\n\n        Игрок {bot2Name} использовал карту заточения против игрока {playerName}");
                                            Console.Write("\n\n           Продолжить --> 'Enter' ");
                                            Console.ReadLine();
                                            skippingTheMovePlayerCount = 0;
                                        }
                                    }
                                    else
                                    {
                                        if (!bot1IsDead)
                                        {
                                            Console.ForegroundColor = ConsoleColor.DarkRed;
                                            Console.Write($"\n\n        Игрок {bot2Name} использовал карту заточения против игрока {bot1Name}");
                                            Console.Write("\n\n           Продолжить --> 'Enter' ");
                                            Console.ReadLine();
                                            skippingTheMoveBot1Count = 0;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                OneTime = false;
            }
        }

        class shop : players
        {
            int cart1QuantityInShop = 5;
            int cart2QuantityInShop = 5;
            int cart3QuantityInShop = 5;
            Random rnd = new Random();
            public void onShop(bool isPlayer, int whichBot)
            {
                int onShopChoice = 0;
                if (isPlayer)
                {
                    while (onShopChoice != 4)
                    {
                        Console.Clear();
                        Console.WriteLine($"\n         Ваш баланс: {P1M}, выберите что купить");
                        Console.WriteLine($"\n1 - Карточка подставы - игрок, выбранный вами перемещается на 5 клеток назад(цена: 14$) (осталось {cart1QuantityInShop}шт)\r\n\r\n2 - Карточка вызова - игрок, выбранный вами в качестве соперника, сражается с вами в камень-ножницы-бумага,\r\n    победитель получает 10 монет от другого (цена: 4$) (осталось {cart2QuantityInShop}шт)\r\n\r\n3 - Карточка заточения - игрок, выбранный вами, пропустит следующие 3 хода (цена: 25$) (осталось {cart3QuantityInShop}шт)\n");
                        Console.Write("4 - Выйти из магазина");
                        Console.Write("\n\n--> ");
                        try
                        {
                            onShopChoice = int.Parse(Console.ReadLine());
                            switch (onShopChoice)
                            {
                                case 1:
                                    if (P1M >= 14 && cart1QuantityInShop > 0)
                                    {
                                        playerInventory.Add("карта подставы");
                                        cart1QuantityInShop--;
                                        P1M -= 14;
                                    }
                                    else if (P1M < 14)
                                    {
                                        Console.WriteLine($"\nДля покупки этого товара вам нужно ещё {14 - P1M}$");
                                        Console.ReadLine();
                                    }
                                    else if (cart1QuantityInShop == 0)
                                    {
                                        Console.WriteLine($"\nДанный товар закончился");
                                        Console.ReadLine();
                                    }
                                    continue;
                                case 2:
                                    if (P1M >= 4 && cart2QuantityInShop > 0)
                                    {
                                        playerInventory.Add("карта вызова");
                                        cart2QuantityInShop--;
                                        P1M -= 4;
                                    }
                                    else if (P1M < 4)
                                    {
                                        Console.WriteLine($"\nДля покупки этого товара вам нужно ещё {4 - P1M}$");
                                        Console.ReadLine();
                                    }
                                    else if (cart2QuantityInShop == 0)
                                    {
                                        Console.WriteLine($"\nДанный товар закончился");
                                        Console.ReadLine();
                                    }
                                    continue;
                                case 3:
                                    if (P1M >= 25 && cart3QuantityInShop > 0)
                                    {
                                        playerInventory.Add("карта заточения");
                                        cart3QuantityInShop--;
                                        P1M -= 25;
                                    }
                                    else if (P1M < 25)
                                    {
                                        Console.WriteLine($"\nДля покупки этого товара вам нужно ещё {25 - P1M}$");
                                        Console.ReadLine();
                                    }
                                    else if (cart3QuantityInShop == 0)
                                    {
                                        Console.WriteLine($"\nДанный товар закончился");
                                        Console.ReadLine();
                                    }
                                    continue;
                                case 4:
                                    // выход из магазина
                                    break;
                                //case 5: // check inventory
                                //    Console.WriteLine();
                                //    foreach(string s in playerInventory)
                                //    {
                                //        Console.Write($"{s}; ");
                                //    }
                                //    Console.ReadLine();
                                //    break;
                                default:
                                    Console.WriteLine("Введите от 1 до 4");
                                    Console.ReadLine();
                                    continue;
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Ошибка");
                            Console.ReadLine();
                        }
                    }
                }
                else
                {
                    if (whichBot == 1)
                    {
                        if (B1M >= 25)
                        {
                            if (rnd.Next(1, 101) >= 65)//35%
                            {
                                if (cart3QuantityInShop > 0)
                                {
                                    bot1Inventory.Add("карта заключения");
                                    cart3QuantityInShop--;
                                    B1M -= 25;
                                }
                            }
                        }
                        if (B1M >= 14)
                        {
                            if (rnd.Next(1, 101) >= 65)//35%
                            {
                                if (cart2QuantityInShop > 0)
                                {
                                    bot1Inventory.Add("карта вызова");
                                    cart2QuantityInShop--;
                                    B1M -= 14;
                                }
                            }
                        }
                        if (B1M >= 4)
                        {
                            if (rnd.Next(1, 101) >= 65)//35%
                            {
                                if (cart1QuantityInShop > 0)
                                {
                                    bot1Inventory.Add("карта подставы");
                                    cart1QuantityInShop--;
                                    B1M -= 4;
                                }
                            }
                        }
                    }

                    if (whichBot == 2)
                    {
                        if (B2M >= 25)
                        {
                            if (rnd.Next(1, 101) >= 65)//35%
                            {
                                if (cart3QuantityInShop > 0)
                                {
                                    bot2Inventory.Add("карта заключения");
                                    cart3QuantityInShop--;
                                    B2M -= 25;
                                }
                            }
                        }
                        if (B2M >= 14)
                        {
                            if (rnd.Next(1, 101) >= 65)//35%
                            {
                                if (cart2QuantityInShop > 0)
                                {
                                    bot2Inventory.Add("карта вызова");
                                    cart2QuantityInShop--;
                                    B2M -= 14;
                                }
                            }
                        }
                        if (B2M >= 4)
                        {
                            if (rnd.Next(1, 101) >= 65)//35%
                            {
                                if (cart1QuantityInShop > 0)
                                {
                                    bot2Inventory.Add("карта подставы");
                                    cart1QuantityInShop--;
                                    B2M -= 4;
                                }
                            }
                        }
                    }
                }
            }
        }

        class game : players
        {
            static board b = new board();
            players p = new players();
            cub c = new cub();
            shop s = new shop();
            Random rnd = new Random();
            bool boardiscreated = false;
            int index;
            int rndm;

            public void gameplay()
            {
                Random rnd = new Random();
                bool deShop = false;
                setNames();
                while (true)
                {
                    if (!boardiscreated)
                    {
                        b.createTheBoard();
                        boardiscreated = true;
                    }

                    if (!playerIsDead)
                    {
                        if (skippingTheMovePlayerCount >= 3)
                        {
                            if (!playerOnFinish)
                            {
                                int gameplayPlayerChoice = 0;
                                while (gameplayPlayerChoice != 1)
                                {
                                    try
                                    {
                                        Console.Clear();
                                        b.drawTheBoard();
                                        Console.WriteLine($"\n\n{b.spaces}{b.spaces}    Выберите действие");
                                        Console.Write("         бросить кость(1)  открыть инвентарь(2)\n");
                                        Console.Write("\n  --> ");
                                        gameplayPlayerChoice = int.Parse(Console.ReadLine());
                                        switch (gameplayPlayerChoice)
                                        {
                                            case 1:
                                                c.whichValue(playerName);
                                                b.viewBoard[posP1] = b.viewBoard[posP1].Replace("1", "");
                                                posP1 += c.rndvalue;
                                                if (posP1 >= 41)
                                                {
                                                    playerOnFinish = true;
                                                    b.viewBoard[41] = b.viewBoard[41].Insert(1, "1");
                                                }
                                                Console.Clear();
                                                break;
                                            case 2:
                                                openInventory();

                                                if (bot1_5StepsBack)
                                                {
                                                    index = b.viewBoard[posB1].IndexOf(b.ch);
                                                    index++;
                                                    if (posB1 == 9 || posB1 == 19 || posB1 == 30 || posB1 == 30)
                                                    {
                                                        b.viewBoard[posB1] = b.viewBoard[posB1].Insert(index, "2");
                                                    }
                                                    else
                                                    {
                                                        b.viewBoard[posB1] = b.viewBoard[posB1].Insert(2, "2");
                                                        b.viewBoard[posB1] = b.viewBoard[posB1].Replace(" ", "");
                                                    }
                                                    b.viewBoard[posB1 + 5] = b.viewBoard[posB1 + 5].Replace("2", "");
                                                    bot1_5StepsBack = false;
                                                }
                                                if (bot2_5StepsBack)
                                                {
                                                    index = b.viewBoard[posB2].IndexOf(b.ch);
                                                    index++;
                                                    if (posB2 == 9 || posB2 == 19 || posB2 == 30)
                                                    {
                                                        b.viewBoard[posB2] = b.viewBoard[posB2].Insert(index, "3");
                                                    }
                                                    else
                                                    {
                                                        b.viewBoard[posB2] = b.viewBoard[posB2].Insert(2, "3");
                                                        b.viewBoard[posB2] = b.viewBoard[posB2].Replace(" ", "");
                                                    }
                                                    b.viewBoard[posB2 + 5] = b.viewBoard[posB2 + 5].Replace("3", "");
                                                    bot2_5StepsBack = false;
                                                }

                                                b.drawTheBoard();
                                                if (exitCycleP1) break;
                                                continue;
                                            default:
                                                Console.WriteLine("Введите от 1 до 2");
                                                Console.ReadLine();
                                                continue;
                                        }
                                    }
                                    catch
                                    {
                                        Console.WriteLine("Ошибка");
                                        Console.ReadLine();
                                    }
                                    if (exitCycleP1) break;
                                }
                            }
                            
                            if (!playerOnFinish)
                            {
                                if (!exitCycleP1)// если игрок за ход использовал карту, то он уже не может бросить кость
                                {
                                    exitCycleP1 = false;
                                    b.drawTheBoard();
                                    b.viewBoard[posP1] = b.viewBoard[posP1].Replace("1", "");


                                    index = b.viewBoard[posP1].IndexOf(b.ch);
                                    index++;
                                    if (posP1 == 9 || posP1 == 19 || posP1 == 30)
                                    {
                                        b.viewBoard[posP1] = b.viewBoard[posP1].Insert(index, "1");
                                    }
                                    else
                                    {
                                        b.viewBoard[posP1] = b.viewBoard[posP1].Insert(1, "1");
                                        b.viewBoard[posP1] = b.viewBoard[posP1].Replace(" ", "");
                                    }

                                    b.correctTheBoard();
                                    while (posP1 == 5 || posP1 == 15 || posP1 == 16 || posP1 == 23 || posP1 == 35 || posP1 == 39 || posP1 == 40)
                                    {
                                        if (posP1 == 5 || posP1 == 15 || posP1 == 16 || posP1 == 23 || posP1 == 35 || posP1 == 39 || posP1 == 40)
                                        {
                                            b.drawTheBoard();
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine($"\n{b.spaces}{b.spaces}{playerName} попадает в неприятность и отправляется на 3 хода назад.");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.Write("\n   Продолжить ->'Enter'");
                                            Console.ReadLine();
                                            b.viewBoard[posP1] = b.viewBoard[posP1].Replace("1", "");
                                            posP1 -= 3;
                                            b.viewBoard[posP1] = b.viewBoard[posP1].Insert(1, "1");
                                            b.viewBoard[posP1] = b.viewBoard[posP1].Replace(" ", "");
                                        }
                                    }// 1!

                                    if (posP1 == 7 || posP1 == 18 || posP1 == 28 || posP1 == 31 || posP1 == 19)
                                    {
                                        b.drawTheBoard();
                                        rndm = rnd.Next(5, 21);
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.WriteLine($"\n{b.spaces}{b.spaces}Игрок {playerName} попадает в клетку с деньгами и получает {rndm} монет (и ещё 3 за ход)");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        P1M += rndm;
                                        Console.Write("\n   Продолжить ->'Enter'");
                                        Console.ReadLine();
                                    }// 1$

                                    if (posP1 == 26 || posP1 == 33)
                                    {
                                        b.drawTheBoard();
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine($"\n{b.spaces}{b.spaces}Игрок {playerName} попадает в смертельную клетку и выбывает из игры");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        playerIsDead = true;
                                        b.viewBoard[posP1] = b.viewBoard[posP1].Replace("1", "");
                                        Console.Write("\n   Продолжить ->'Enter'");
                                        Console.ReadLine();
                                    }// 1X

                                    if (posP1 == 11 || posP1 == 13 || posP1 == 34)
                                    {
                                        b.drawTheBoard();
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine($"\n{b.spaces}Игрок {playerName} попадает в A клетку и выбирает кого атаковать");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.Write($"\n{b.spaces}Продолжить --> 'Enter'");
                                        Console.ReadLine();
                                        int victimChoiceG = 0;
                                        while (victimChoiceG != 1 && victimChoiceG != 2)
                                        {
                                            try
                                            {
                                                Console.Clear();
                                                b.drawTheBoard();
                                                Console.WriteLine("\n\nВыберите жертву");
                                                if (!bot1IsDead) Console.WriteLine($"\n{bot1Name}(1)");
                                                if (!bot2IsDead) Console.Write($"{bot2Name}(2)");
                                                Console.Write("\n\n--> ");

                                                victimChoiceG = int.Parse(Console.ReadLine());
                                                switch (victimChoiceG)
                                                {
                                                    case 1:
                                                        if (!bot1IsDead)
                                                        {
                                                            if (B1M < 5)
                                                            {
                                                                int doubleB1M = B1M;
                                                                B1M = 0;
                                                                P1M += doubleB1M;
                                                            }
                                                            else
                                                            {
                                                                B1M -= 5;
                                                                P1M += 5;
                                                            }
                                                        }
                                                        break;
                                                    case 2:
                                                        if (!bot2IsDead)
                                                        {
                                                            if (B2M < 5)
                                                            {
                                                                int doubleB2M = B2M;
                                                                B2M = 0;
                                                                P1M += doubleB2M;
                                                            }
                                                            else
                                                            {
                                                                B2M -= 5;
                                                                P1M += 5;
                                                            }
                                                        }
                                                        break;
                                                    default:
                                                        Console.WriteLine("Введите либо 1 либо 2");
                                                        Console.ReadLine();
                                                        continue;
                                                }
                                            }
                                            catch
                                            {
                                                Console.WriteLine("Ошибка");
                                                Console.ReadLine();
                                            }
                                        }
                                    }// 1A

                                    if (posP1 == 9 || posP1 == 32 || posP1 == 21 || posP1 == 17 || posP1 == 30)
                                    {
                                        b.drawTheBoard();
                                        Console.ForegroundColor = ConsoleColor.Blue;
                                        Console.WriteLine($"\n{b.spaces}{b.spaces}Игрок {playerName} попадает в магазин");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.Write("\n   Продолжить -> 'Enter'");
                                        Console.ReadLine();
                                        s.onShop(true, 0);
                                        deShop = true;
                                    }// 1S

                                    b.correctTheBoard();
                                    b.drawTheBoard();
                                }
                                exitCycleP1 = false;
                                if (deShop)
                                {
                                    Console.Write("\n\n   Продолжить -> 'Enter'");
                                    Console.ReadLine();
                                    deShop = false;
                                }

                                b.correctTheBoard();
                                P1M += 3;
                                b.drawTheBoard();
                            }
                        }
                        else
                        {
                            skippingTheMovePlayerCount++;
                            Console.WriteLine($"{playerName} пропускает ход из-за заточения (осталось пропустить ещё {3 - skippingTheMovePlayerCount})");
                            Console.WriteLine("Продолжить --> 'Enter'");
                        }
                    }
                    checkGameStatus();

                    if (!bot1IsDead)
                    {
                        if (skippingTheMoveBot1Count >= 3)
                        {
                            if (bot1Inventory.Count > 0)
                            {
                                if (rnd.Next(1, 101) > 20)
                                {
                                    botsUsedTheCard(1);
                                }
                            }

                            if (player_5StepsBack)
                            {
                                index = b.viewBoard[posP1].IndexOf(b.ch);
                                index++;
                                if (posP1 == 9 || posP1 == 19 || posP1 == 30 || posP1 == 30)
                                {
                                    b.viewBoard[posP1] = b.viewBoard[posP1].Insert(index, "1");
                                }
                                else
                                {
                                    b.viewBoard[posP1] = b.viewBoard[posP1].Insert(2, "1");
                                    b.viewBoard[posP1] = b.viewBoard[posP1].Replace(" ", "");
                                }
                                b.viewBoard[posP1 + 5] = b.viewBoard[posP1 + 5].Replace("1", "");
                                player_5StepsBack = false;
                            }
                            if (bot2_5StepsBack)
                            {
                                index = b.viewBoard[posB2].IndexOf(b.ch);
                                index++;
                                if (posB2 == 9 || posB2 == 19 || posB2 == 30)
                                {
                                    b.viewBoard[posB2] = b.viewBoard[posB2].Insert(index, "3");
                                }
                                else
                                {
                                    b.viewBoard[posB2] = b.viewBoard[posB2].Insert(2, "3");
                                    b.viewBoard[posB2] = b.viewBoard[posB2].Replace(" ", "");
                                }
                                b.viewBoard[posB2 + 5] = b.viewBoard[posB2 + 5].Replace("3", "");
                                bot2_5StepsBack = false;
                            }

                            b.drawTheBoard();
                            if (!exitCycleB1)
                            {
                                c.whichValue(bot1Name);
                                b.viewBoard[posB1] = b.viewBoard[posB1].Replace("2", "");
                                posB1 += c.rndvalue;
                                if (posB1 >= 41)
                                {
                                    bot1OnFinish = true;
                                    b.viewBoard[41] = b.viewBoard[41].Insert(1, "2");
                                }
                                if (!bot1OnFinish)
                                {
                                    exitCycleB1 = false;
                                    b.viewBoard[posB1] = b.viewBoard[posB1].Replace("2", "");
                                    

                                    index = b.viewBoard[posB1].IndexOf(b.ch);
                                    index++;
                                    if (posB1 == 9 || posB1 == 19 || posB1 == 30)
                                    {
                                        b.viewBoard[posB1] = b.viewBoard[posB1].Insert(index, "2");
                                    }
                                    else
                                    {
                                        b.viewBoard[posB1] = b.viewBoard[posB1].Insert(1, "2");
                                        b.viewBoard[posB1] = b.viewBoard[posB1].Replace(" ", "");
                                    }

                                    b.correctTheBoard();
                                    while (posB1 == 5 || posB1 == 15 || posB1 == 16 || posB1 == 23 || posB1 == 35 || posB1 == 39 || posB1 == 40)
                                    {
                                        if (posB1 == 5 || posB1 == 15 || posB1 == 16 || posB1 == 23 || posB1 == 35 || posB1 == 39 || posB1 == 40)
                                        {
                                            b.drawTheBoard();
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine($"\n{b.spaces}{b.spaces}{bot1Name} попадает в неприятность и отправляется на 3 хода назад.");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.Write("\n   Продолжить ->'Enter'");
                                            Console.ReadLine();
                                            b.viewBoard[posB1] = b.viewBoard[posB1].Replace("2", "");
                                            posB1 -= 3;
                                            b.viewBoard[posB1] = b.viewBoard[posB1].Insert(2, "2");
                                            b.viewBoard[posB1] = b.viewBoard[posB1].Replace(" ", "");
                                        }
                                    }// 2!

                                    if (posB1 == 7 || posB1 == 18 || posB1 == 28 || posB1 == 31 || posB1 == 19)
                                    {
                                        b.drawTheBoard();
                                        rndm = rnd.Next(5, 21);
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.WriteLine($"\n{b.spaces}{b.spaces}Игрок {bot1Name} попадает в клетку с деньгами и получает {rndm} монет (и ещё 3 за ход)");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        B1M += rndm;
                                        Console.Write("\n   Продолжить ->'Enter'");
                                        Console.ReadLine();
                                    }// 2$

                                    if (posB1 == 26 || posB1 == 33)
                                    {
                                        b.drawTheBoard();
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine($"\n{b.spaces}{b.spaces}Игрок {bot1Name} попадает в смертельную клетку и выбывает из игры");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        bot1IsDead = true;
                                        b.viewBoard[posB1] = b.viewBoard[posB1].Replace("2", "");
                                        Console.Write("\n   Продолжить ->'Enter' ");
                                        Console.ReadLine();
                                    }// 2X

                                    if (posB1 == 11 || posB1 == 13 || posB1 == 34)
                                    {
                                        b.drawTheBoard();
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine($"\n{b.spaces}Игрок {bot1Name} попадает в A клетку и выбирает кого атаковать");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.Write($"\n{b.spaces}Продолжить --> 'Enter'");
                                        Console.ReadLine();
                                        Console.Clear();
                                        b.drawTheBoard();
                                        Console.Write($"\n{spaces}{bot1Name} выбирает кого атаковать");
                                        Thread.Sleep(270);
                                        Console.Write(".");
                                        Thread.Sleep(270);
                                        Console.Write(".");
                                        Thread.Sleep(270);
                                        Console.WriteLine(".");
                                        if (rnd.Next(1, 101) >= 50)
                                        {
                                            if (!playerIsDead)
                                            {
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine($"\n{spaces}Жертвой стал {playerName}");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.Write($"\n{spaces}Продолжить --> 'Enter' ");
                                                Console.ReadLine();
                                                if (P1M < 5)
                                                {
                                                    int doubleP1M = P1M;
                                                    P1M = 0;
                                                    B1M += doubleP1M;
                                                }
                                                else
                                                {
                                                    B1M += 5;
                                                    P1M -= 5;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            if (!bot2IsDead)
                                            {
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine($"\n{spaces}Жертвой стал {bot2Name}");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.Write($"{spaces}Продолжить --> 'Enter' ");
                                                Console.ReadLine();
                                                if (B2M < 5)
                                                {
                                                    int doubleB2M = B2M;
                                                    B2M = 0;
                                                    B1M += doubleB2M;
                                                }
                                                else
                                                {
                                                    B1M += 5;
                                                    B2M -= 5;
                                                }
                                            }
                                        }
                                    }// 2A

                                    if (posB1 == 9 || posB1 == 32 || posB1 == 21 || posB1 == 17 || posB1 == 30)
                                    {
                                        b.drawTheBoard();
                                        Console.ForegroundColor = ConsoleColor.Blue;
                                        Console.WriteLine($"\n{b.spaces}{b.spaces}Игрок {bot1Name} попадает в магазин");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.Write("\n   Продолжить ->'Enter'");
                                        Console.ReadLine();
                                        s.onShop(false, 1);
                                    }// 2S

                                    b.correctTheBoard();
                                    B1M += 3;
                                    b.drawTheBoard();
                                    if (posB1 >= 41)// win
                                    {
                                        Console.WriteLine("Игрок 2 победил");
                                        Console.ReadLine();
                                    }
                                }
                            }
                            exitCycleB1 = false;
                        }
                        else
                        {
                            skippingTheMoveBot1Count++;
                            Console.WriteLine($"\n       {bot1Name} пропускает ход из-за заточения (осталось пропустить ещё {3 - skippingTheMoveBot1Count})");
                            Console.Write($"{spaces}Продолжить --> 'Enter' ");
                            Console.ReadLine();
                        }
                    }
                    checkGameStatus();

                    if (!bot2IsDead)
                    {
                        if (skippingTheMoveBot2Count >= 3)
                        {
                            if (bot2Inventory.Count > 0)
                            {
                                if (rnd.Next(1, 101) > 20)
                                {
                                    botsUsedTheCard(2);
                                }
                            }

                            if (player_5StepsBack)
                            {
                                index = b.viewBoard[posP1].IndexOf(b.ch);
                                index++;
                                if (posP1 == 9 || posP1 == 19 || posP1 == 30 || posP1 == 30)
                                {
                                    b.viewBoard[posP1] = b.viewBoard[posP1].Insert(index, "1");
                                }
                                else
                                {
                                    b.viewBoard[posP1] = b.viewBoard[posP1].Insert(2, "1");
                                    b.viewBoard[posP1] = b.viewBoard[posP1].Replace(" ", "");
                                }
                                b.viewBoard[posP1 + 5] = b.viewBoard[posP1 + 5].Replace("1", "");
                                player_5StepsBack = false;
                            }
                            if (bot1_5StepsBack)
                            {
                                index = b.viewBoard[posB1].IndexOf(b.ch);
                                index++;
                                if (posB1 == 9 || posB1 == 19 || posB1 == 30 || posB1 == 30)
                                {
                                    b.viewBoard[posB1] = b.viewBoard[posB1].Insert(index, "2");
                                }
                                else
                                {
                                    b.viewBoard[posB1] = b.viewBoard[posB1].Insert(2, "2");
                                    b.viewBoard[posB1] = b.viewBoard[posB1].Replace(" ", "");
                                }
                                b.viewBoard[posB1 + 5] = b.viewBoard[posB1 + 5].Replace("2", "");
                                bot1_5StepsBack = false;
                            }

                            b.drawTheBoard();
                            if (!exitCycleB2)
                            {
                                c.whichValue(bot2Name);
                                b.viewBoard[posB2] = b.viewBoard[posB2].Replace("3", "");
                                posB2 += c.rndvalue;
                                if (posB2 >= 41)
                                {
                                    bot2OnFinish = true;
                                    b.viewBoard[41] = b.viewBoard[41].Insert(1, "3");
                                }
                                if (!bot2OnFinish)
                                {
                                    exitCycleB2 = false;

                                    b.viewBoard[posB2] = b.viewBoard[posB2].Replace("3", "");

                                    index = b.viewBoard[posB2].IndexOf(b.ch);
                                    index++;
                                    if (posB2 == 9 || posB2 == 19 || posB2 == 30)
                                    {
                                        b.viewBoard[posB2] = b.viewBoard[posB2].Insert(index, "3");
                                    }
                                    else
                                    {
                                        b.viewBoard[posB2] = b.viewBoard[posB2].Insert(1, "3");
                                        b.viewBoard[posB2] = b.viewBoard[posB2].Replace(" ", "");
                                    }

                                    b.correctTheBoard();
                                    while (posB2 == 5 || posB2 == 15 || posB2 == 16 || posB2 == 23 || posB2 == 35 || posB2 == 39 || posB2 == 40)
                                    {
                                        if (posB2 == 5 || posB2 == 15 || posB2 == 16 || posB2 == 23 || posB2 == 35 || posB2 == 39 || posB2 == 40)
                                        {
                                            b.drawTheBoard();
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine($"\n{b.spaces}{b.spaces}{bot1Name} попадает в неприятность и отправляется на 3 хода назад.");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.Write("\n   Продолжить ->'Enter'");
                                            Console.ReadLine();
                                            b.viewBoard[posB2] = b.viewBoard[posB2].Replace("3", "");
                                            posB2 -= 3;
                                            b.viewBoard[posB2] = b.viewBoard[posB2].Insert(2, "3");
                                            b.viewBoard[posB2] = b.viewBoard[posB2].Replace(" ", "");
                                        }
                                    }// 3!

                                    if (posB2 == 7 || posB2 == 18 || posB2 == 28 || posB2 == 31 || posB2 == 19)
                                    {
                                        b.drawTheBoard();
                                        rndm = rnd.Next(5, 21);
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.WriteLine($"\n{b.spaces}{b.spaces}Игрок {bot2Name} попадает в клетку с деньгами и получает {rndm} монет (и ещё 3 за ход)");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        B2M += rndm;
                                        Console.Write("\n   Продолжить ->'Enter'");
                                        Console.ReadLine();
                                    }// 3$

                                    if (posB2 == 26 || posB2 == 33)
                                    {
                                        b.drawTheBoard();
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine($"\n{b.spaces}{b.spaces}Игрок {bot2Name} попадает в смертельную клетку и выбывает из игры");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        bot2IsDead = true;
                                        b.viewBoard[posB2] = b.viewBoard[posB2].Replace("3", "");
                                        Console.Write("\n   Продолжить ->'Enter'");
                                        Console.ReadLine();
                                    }// 3X

                                    if (posB2 == 11 || posB2 == 13 || posB2 == 34)
                                    {
                                        b.drawTheBoard();
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine($"\n{b.spaces}Игрок {bot2Name} попадает в A клетку и выбирает кого атаковать");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.Write($"\n{b.spaces}Продолжить --> 'Enter'");
                                        Console.ReadLine();
                                        Console.Clear();
                                        b.drawTheBoard();
                                        Console.Write($"\n{spaces}{bot2Name} выбирает кого атаковать");
                                        Thread.Sleep(270);
                                        Console.Write(".");
                                        Thread.Sleep(270);
                                        Console.Write(".");
                                        Thread.Sleep(270);
                                        Console.WriteLine(".");
                                        if (rnd.Next(1, 101) >= 50)
                                        {
                                            if (!playerIsDead)
                                            {
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine($"\n{spaces}Жертвой стал {playerName}");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.Write($"\n{spaces}Продолжить --> 'Enter' ");
                                                Console.ReadLine();
                                                if (P1M < 5)
                                                {
                                                    int doubleP1M = P1M;
                                                    P1M = 0;
                                                    B2M += doubleP1M;
                                                }
                                                else
                                                {
                                                    B2M += 5;
                                                    P1M -= 5;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            if (!bot1IsDead)
                                            {
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine($"\n{spaces}Жертвой стал {bot1Name}");
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.Write($"{spaces}Продолжить --> 'Enter' ");
                                                Console.ReadLine();
                                                if (B1M < 5)
                                                {
                                                    int doubleB1M = B1M;
                                                    B1M = 0;
                                                    B2M += doubleB1M;
                                                }
                                                else
                                                {
                                                    B2M += 5;
                                                    B1M -= 5;
                                                }
                                            }
                                        }
                                    }// 3A

                                    if (posB2 == 9 || posB2 == 32 || posB2 == 21 || posB2 == 17 || posB2 == 30)
                                    {
                                        b.drawTheBoard();
                                        Console.ForegroundColor = ConsoleColor.Blue;
                                        Console.WriteLine($"\n{b.spaces}{b.spaces}Игрок {bot2Name} попадает в магазин");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.Write("\n   Продолжить ->'Enter'");
                                        Console.ReadLine();
                                        s.onShop(false, 2);
                                    }// 3S

                                    b.correctTheBoard();
                                    B2M += 3;
                                    b.drawTheBoard();
                                    if (posB2 >= 41)// win
                                    {
                                        Console.WriteLine("Игрок 3 победил");
                                        Console.ReadLine();
                                    }
                                }
                            }
                            exitCycleB2 = false;
                        }
                        else
                        {
                            skippingTheMoveBot2Count++;
                            Console.WriteLine($"\n       {bot2Name} пропускает ход из-за заточения (осталось пропустить ещё {3 - skippingTheMoveBot2Count})");
                            Console.Write($"{spaces}Продолжить --> 'Enter' ");
                            Console.ReadLine();
                        }
                    }
                    checkGameStatus();
                }
            }

            public void attackKNB(bool playerVsBot, int whichBot, string whoAttackedFirst, bool botVsBot, int whichBotAttackedFirst)// кто кого
            {
                int choiceKNBplayer;
                int choiceKNBbot1;
                int choiceKNBbot2;

                if (playerVsBot)
                {
                    if (whoAttackedFirst == "player" && whichBot == 1)
                    {
                        while (true)
                        {
                            Console.Clear();
                            b.drawTheBoard();
                            Console.WriteLine($"\n\n{spaces}Игрок {playerName} атакует игрока {bot1Name}");
                            Console.WriteLine($"{spaces}{spaces}    Выберите:");
                            Console.Write($"{spaces}камень(1)  ножницы(2)  бумага(3)");
                            Console.Write("\n\n--> ");
                            try
                            {
                                choiceKNBplayer = int.Parse(Console.ReadLine());
                                if (choiceKNBplayer < 1 || choiceKNBplayer > 3)
                                {
                                    Console.WriteLine("Введите цифру от 1 до 3");
                                    Console.ReadLine();
                                    continue;
                                }
                                choiceKNBbot1 = rnd.Next(1, 4);

                                if (choiceKNBplayer == 1) Console.WriteLine($"\n{playerName} выбрал камень");
                                if (choiceKNBplayer == 2) Console.WriteLine($"\n{playerName} выбрал ножницы");
                                if (choiceKNBplayer == 3) Console.WriteLine($"\n{playerName} выбрал бумагу");

                                if (choiceKNBbot1 == 1) Console.WriteLine($"{bot1Name} выбрал камень");
                                if (choiceKNBbot1 == 2) Console.WriteLine($"{bot1Name} выбрал ножницы");
                                if (choiceKNBbot1 == 3) Console.WriteLine($"{bot1Name} выбрал бумагу");

                                if (choiceKNBplayer == choiceKNBbot1)
                                {
                                    Console.WriteLine("Переигрываем");
                                    Console.ReadLine();
                                    continue;
                                }
                                if ((choiceKNBplayer == 1 && choiceKNBbot1 == 2) || (choiceKNBplayer == 2 && choiceKNBbot1 == 3) || (choiceKNBplayer == 3 && choiceKNBbot1 == 1))
                                {
                                    Console.WriteLine($"Победил: {playerName}");
                                    Console.WriteLine($"\n {bot1Name} отдаёт 10$ игроку {playerName}");
                                    Console.ReadLine();
                                    if (B1M < 10)
                                    {
                                        int doubleB1M = B1M;
                                        B1M = 0;
                                        P1M += doubleB1M;
                                    }
                                    else
                                    {
                                        B1M -= 10;
                                        P1M += 10;
                                    }
                                    exitInventory = true;
                                    break;
                                }
                                if ((choiceKNBplayer == 2 && choiceKNBbot1 == 1) || (choiceKNBplayer == 3 && choiceKNBbot1 == 2) || (choiceKNBplayer == 1 && choiceKNBbot1 == 3))
                                {
                                    Console.WriteLine($"Победил: {bot1Name}");
                                    Console.WriteLine($"\n {playerName} отдаёт 10$ игроку {bot1Name}");
                                    Console.ReadLine();
                                    if (P1M < 10)
                                    {
                                        int doubleP1M = P1M;
                                        P1M = 0;
                                        B1M += doubleP1M;
                                    }
                                    else
                                    {
                                        P1M -= 10;
                                        B1M += 10;
                                    }
                                    exitInventory = true;
                                    break;
                                }
                            }
                            catch
                            {
                                Console.WriteLine("Ошибка");
                                Console.ReadLine();
                            }
                        }
                    }
                    if (whoAttackedFirst == "player" && whichBot == 2)
                    {
                        while (true)
                        {
                            Console.Clear();
                            b.drawTheBoard();
                            Console.WriteLine($"\n\n{spaces}Игрок {playerName} атакует игрока {bot2Name}");
                            Console.WriteLine($"{spaces}{spaces}    Выберите:");
                            Console.Write($"{spaces}камень(1)  ножницы(2)  бумага(3)");
                            Console.Write("\n\n--> ");
                            try
                            {
                                choiceKNBplayer = int.Parse(Console.ReadLine());
                                if (choiceKNBplayer < 1 || choiceKNBplayer > 3)
                                {
                                    Console.WriteLine("Введите цифру от 1 до 3");
                                    Console.ReadLine();
                                    continue;
                                }
                                choiceKNBbot2 = rnd.Next(1, 4);

                                if (choiceKNBplayer == 1) Console.WriteLine($"\n{playerName} выбрал камень");
                                if (choiceKNBplayer == 2) Console.WriteLine($"\n{playerName} выбрал ножницы");
                                if (choiceKNBplayer == 3) Console.WriteLine($"\n{playerName} выбрал бумагу");

                                if (choiceKNBbot2 == 1) Console.WriteLine($"{bot2Name} выбрал камень");
                                if (choiceKNBbot2 == 2) Console.WriteLine($"{bot2Name} выбрал ножницы");
                                if (choiceKNBbot2 == 3) Console.WriteLine($"{bot2Name} выбрал бумагу");

                                if (choiceKNBplayer == choiceKNBbot2)
                                {
                                    Console.WriteLine("Переигрываем");
                                    Console.ReadLine();
                                    continue;
                                }
                                if ((choiceKNBplayer == 1 && choiceKNBbot2 == 2) || (choiceKNBplayer == 2 && choiceKNBbot2 == 3) || (choiceKNBplayer == 3 && choiceKNBbot2 == 1))
                                {
                                    Console.WriteLine($"Победил: {playerName}");
                                    Console.WriteLine($"\n {bot2Name} отдаёт 10$ игроку {playerName}");
                                    Console.ReadLine();
                                    if (B2M < 10)
                                    {
                                        int doubleB2M = B2M;
                                        B2M = 0;
                                        P1M += doubleB2M;
                                    }
                                    else
                                    {
                                        B2M -= 10;
                                        P1M += 10;
                                    }
                                    exitInventory = true;
                                    break;
                                }
                                if ((choiceKNBplayer == 2 && choiceKNBbot2 == 1) || (choiceKNBplayer == 3 && choiceKNBbot2 == 2) || (choiceKNBplayer == 1 && choiceKNBbot2 == 3))
                                {
                                    Console.WriteLine($"Победил: {bot1Name}");
                                    Console.WriteLine($"\n {playerName} отдаёт 10$ игроку {bot1Name}");
                                    Console.ReadLine();
                                    if (P1M < 10)
                                    {
                                        int doubleP1M = P1M;
                                        P1M = 0;
                                        B1M += doubleP1M;
                                    }
                                    else
                                    {
                                        P1M -= 10;
                                        B1M += 10;
                                    }
                                    exitInventory = true;
                                    break;
                                }

                            }
                            catch
                            {
                                Console.WriteLine("Ошибка");
                                Console.ReadLine();
                            }
                        }
                    }
                    if (whoAttackedFirst == "bot" && whichBot == 1)
                    {
                        while (true)
                        {
                            Console.Clear();
                            b.drawTheBoard();
                            Console.WriteLine($"\n\n{spaces}Игрок {bot1Name} атакует игрока {playerName}");
                            Console.WriteLine($"{spaces}{spaces}    Выберите:");
                            Console.Write($"{spaces}камень(1)  ножницы(2)  бумага(3)");
                            Console.Write("\n\n--> ");
                            try
                            {
                                choiceKNBplayer = int.Parse(Console.ReadLine());
                                if (choiceKNBplayer < 1 || choiceKNBplayer > 3)
                                {
                                    Console.WriteLine("Введите цифру от 1 до 3");
                                    Console.ReadLine();
                                    continue;
                                }
                                choiceKNBbot1 = rnd.Next(1, 4);

                                if (choiceKNBplayer == 1) Console.WriteLine($"\n{playerName} выбрал камень");
                                if (choiceKNBplayer == 2) Console.WriteLine($"\n{playerName} выбрал ножницы");
                                if (choiceKNBplayer == 3) Console.WriteLine($"\n{playerName} выбрал бумагу");

                                if (choiceKNBbot1 == 1) Console.WriteLine($"{bot1Name} выбрал камень");
                                if (choiceKNBbot1 == 2) Console.WriteLine($"{bot1Name} выбрал ножницы");
                                if (choiceKNBbot1 == 3) Console.WriteLine($"{bot1Name} выбрал бумагу");

                                if (choiceKNBplayer == choiceKNBbot1)
                                {
                                    Console.WriteLine("Переигрываем");
                                    Console.ReadLine();
                                    continue;
                                }
                                if ((choiceKNBplayer == 1 && choiceKNBbot1 == 2) || (choiceKNBplayer == 2 && choiceKNBbot1 == 3) || (choiceKNBplayer == 3 && choiceKNBbot1 == 1))
                                {
                                    Console.WriteLine($"Победил: {playerName}");
                                    Console.WriteLine($"\n {bot1Name} отдаёт 10$ игроку {playerName}");
                                    Console.ReadLine();
                                    if (B1M < 10)
                                    {
                                        int doubleB1M = B1M;
                                        B1M = 0;
                                        P1M += doubleB1M;
                                    }
                                    else
                                    {
                                        B1M -= 10;
                                        P1M += 10;
                                    }
                                    exitInventory = true;
                                    break;
                                }
                                if ((choiceKNBplayer == 2 && choiceKNBbot1 == 1) || (choiceKNBplayer == 3 && choiceKNBbot1 == 2) || (choiceKNBplayer == 1 && choiceKNBbot1 == 3))
                                {
                                    Console.WriteLine($"Победил: {bot1Name}");
                                    Console.WriteLine($"\n {playerName} отдаёт 10$ игроку {bot1Name}");
                                    Console.ReadLine();
                                    if (P1M < 10)
                                    {
                                        int doubleP1M = P1M;
                                        P1M = 0;
                                        B1M += doubleP1M;
                                    }
                                    else
                                    {
                                        P1M -= 10;
                                        B1M += 10;
                                    }
                                    exitInventory = true;
                                    break;
                                }

                            }
                            catch
                            {
                                Console.WriteLine("Ошибка");
                                Console.ReadLine();
                            }
                        }
                    }
                    if (whoAttackedFirst == "bot" && whichBot == 2)
                    {
                        while (true)
                        {
                            Console.Clear();
                            b.drawTheBoard();
                            Console.WriteLine($"\n\n{spaces}Игрок {bot2Name} атакует игрока {playerName}");
                            Console.WriteLine($"{spaces}{spaces}    Выберите:");
                            Console.Write($"{spaces}камень(1)  ножницы(2)  бумага(3)");
                            Console.Write("\n\n--> ");
                            try
                            {
                                choiceKNBplayer = int.Parse(Console.ReadLine());
                                if (choiceKNBplayer < 1 || choiceKNBplayer > 3)
                                {
                                    Console.WriteLine("Введите цифру от 1 до 3");
                                    Console.ReadLine();
                                    continue;
                                }
                                choiceKNBbot2 = rnd.Next(1, 4);

                                if (choiceKNBplayer == 1) Console.WriteLine($"\n{playerName} выбрал камень");
                                if (choiceKNBplayer == 2) Console.WriteLine($"\n{playerName} выбрал ножницы");
                                if (choiceKNBplayer == 3) Console.WriteLine($"\n{playerName} выбрал бумагу");

                                if (choiceKNBbot2 == 1) Console.WriteLine($"{bot2Name} выбрал камень");
                                if (choiceKNBbot2 == 2) Console.WriteLine($"{bot2Name} выбрал ножницы");
                                if (choiceKNBbot2 == 3) Console.WriteLine($"{bot2Name} выбрал бумагу");

                                if (choiceKNBplayer == choiceKNBbot2)
                                {
                                    Console.WriteLine("Переигрываем");
                                    Console.ReadLine();
                                    continue;
                                }
                                if ((choiceKNBplayer == 1 && choiceKNBbot2 == 2) || (choiceKNBplayer == 2 && choiceKNBbot2 == 3) || (choiceKNBplayer == 3 && choiceKNBbot2 == 1))
                                {
                                    Console.WriteLine($"Победил: {playerName}");
                                    Console.WriteLine($"\n {bot2Name} отдаёт 10$ игроку {playerName}");
                                    Console.ReadLine();
                                    if (B2M < 10)
                                    {
                                        int doubleB2M = B2M;
                                        B2M = 0;
                                        P1M += doubleB2M;
                                    }
                                    else
                                    {
                                        B2M -= 10;
                                        P1M += 10;
                                    }
                                    exitInventory = true;
                                    break;
                                }
                                if ((choiceKNBplayer == 2 && choiceKNBbot2 == 1) || (choiceKNBplayer == 3 && choiceKNBbot2 == 2) || (choiceKNBplayer == 1 && choiceKNBbot2 == 3))
                                {
                                    Console.WriteLine($"Победил: {bot1Name}");
                                    Console.WriteLine($"\n {playerName} отдаёт 10$ игроку {bot1Name}");
                                    Console.ReadLine();
                                    if (P1M < 10)
                                    {
                                        int doubleP1M = P1M;
                                        P1M = 0;
                                        B1M += doubleP1M;
                                    }
                                    else
                                    {
                                        P1M -= 10;
                                        B1M += 10;
                                    }
                                    exitInventory = true;
                                    break;
                                }

                            }
                            catch
                            {
                                Console.WriteLine("Ошибка");
                                Console.ReadLine();
                            }
                        }
                    }
                }

                if (botVsBot)
                {
                    while (true)
                    {
                        Console.Clear();
                        b.drawTheBoard();
                        if (whichBotAttackedFirst == 1) Console.Write($"\n\nИгрок {bot1Name} атакует игрока {bot2Name}");
                        if (whichBotAttackedFirst == 2) Console.Write($"\n\nИгрок {bot2Name} атакует игрока {bot1Name}");
                        Thread.Sleep(270);
                        Console.Write(".");
                        Thread.Sleep(270);
                        Console.Write(".");
                        Thread.Sleep(270);
                        Console.Write(".");
                        Thread.Sleep(270);
                        Console.Write(".");
                        Thread.Sleep(270);
                        Console.Write(".\n\n");

                        choiceKNBbot1 = rnd.Next(1, 4);
                        choiceKNBbot2 = rnd.Next(1, 4);

                        if (choiceKNBbot1 == 1) Console.WriteLine($"{bot1Name} выбрал камень");
                        if (choiceKNBbot1 == 2) Console.WriteLine($"{bot1Name} выбрал ножницы");
                        if (choiceKNBbot1 == 3) Console.WriteLine($"{bot1Name} выбрал бумагу");

                        if (choiceKNBbot2 == 1) Console.WriteLine($"{bot2Name} выбрал камень");
                        if (choiceKNBbot2 == 2) Console.WriteLine($"{bot2Name} выбрал ножницы");
                        if (choiceKNBbot2 == 3) Console.WriteLine($"{bot2Name} выбрал бумагу");

                        if (choiceKNBbot1 == choiceKNBbot2)
                        {
                            Console.Write("\n\nПереигрываем");
                            Thread.Sleep(270);
                            Console.Write(".");
                            Thread.Sleep(270);
                            Console.Write(".");
                            Thread.Sleep(270);
                            Console.Write(".");
                            Thread.Sleep(270);
                            Console.Write(".");
                            Thread.Sleep(270);
                            Console.Write(".");
                            Thread.Sleep(270);
                            Console.Write(".");
                            Thread.Sleep(270);
                            Console.Write(".\n\n");
                            continue;
                        }
                        if ((choiceKNBbot2 == 1 && choiceKNBbot1 == 2) || (choiceKNBbot2 == 2 && choiceKNBbot1 == 3) || (choiceKNBbot2 == 3 && choiceKNBbot1 == 1))
                        {
                            Console.WriteLine($"Победил: {bot2Name}");
                            Console.WriteLine($"\n {bot1Name} отдаёт 10$ игроку {bot2Name}");
                            Console.ReadLine();
                            if (B1M < 10)
                            {
                                int doubleB1M = B1M;
                                B1M = 0;
                                B2M += doubleB1M;
                            }
                            else
                            {
                                B1M -= 10;
                                B2M += 10;
                            }
                            exitInventory = true;
                            break;
                        }
                        if ((choiceKNBbot2 == 2 && choiceKNBbot1 == 1) || (choiceKNBbot2 == 3 && choiceKNBbot1 == 2) || (choiceKNBbot2 == 1 && choiceKNBbot1 == 3))
                        {
                            Console.WriteLine($"Победил: {bot1Name}");
                            Console.WriteLine($"\n {bot2Name} отдаёт 10$ игроку {bot1Name}");
                            Console.ReadLine();
                            if (B2M < 10)
                            {
                                int doubleB2M = B2M;
                                B2M = 0;
                                B1M += doubleB2M;
                            }
                            else
                            {
                                B2M -= 10;
                                B1M += 10;
                            }
                            exitInventory = true;
                            break;
                        }
                    }
                }
            }
            
            public void checkGameStatus()
            {
                if (playerOnFinish)
                {
                    Thread.Sleep(700);
                    Console.WriteLine("\n\nКонец игры");
                    Console.Write($"\nПобедил: {playerName}");
                    Console.Write(".");
                    Thread.Sleep(320);
                    Console.Write(".");
                    Thread.Sleep(320);
                    Console.Write(".");
                    Thread.Sleep(320);
                    Console.Write(".");
                    Thread.Sleep(320);
                    Console.Write(".");
                    Environment.Exit(0);
                }
                if (bot1OnFinish)
                {
                    Thread.Sleep(700);
                    Console.WriteLine("\n\nКонец игры");
                    Console.Write($"\nПобедил: {bot1Name}");
                    Console.Write(".");
                    Thread.Sleep(320);
                    Console.Write(".");
                    Thread.Sleep(320);
                    Console.Write(".");
                    Thread.Sleep(320);
                    Console.Write(".");
                    Thread.Sleep(320);
                    Console.Write(".");
                    Environment.Exit(0);
                }
                if (bot2OnFinish)
                {
                    Thread.Sleep(700);
                    Console.WriteLine("\n\nКонец игры");
                    Console.Write($"\nПобедил: {bot2Name}");
                    Console.Write(".");
                    Thread.Sleep(320);
                    Console.Write(".");
                    Thread.Sleep(320);
                    Console.Write(".");
                    Thread.Sleep(320);
                    Console.Write(".");
                    Thread.Sleep(320);
                    Console.Write(".");
                    Environment.Exit(0);
                }
                if (playerIsDead && bot1IsDead && !bot2IsDead)
                {
                    Thread.Sleep(700);
                    Console.WriteLine("\n\nКонец игры");
                    Console.Write($"\nПобедил: {bot2Name}");
                    Console.Write(".");
                    Thread.Sleep(320);
                    Console.Write(".");
                    Thread.Sleep(320);
                    Console.Write(".");
                    Thread.Sleep(320);
                    Console.Write(".");
                    Thread.Sleep(320);
                    Console.Write(".");
                    Environment.Exit(0);
                }
                if (playerIsDead && !bot1IsDead && bot2IsDead)
                {
                    Thread.Sleep(700);
                    Console.WriteLine("\n\nКонец игры");
                    Console.Write($"\nПобедил: {bot1Name}");
                    Console.Write(".");
                    Thread.Sleep(320);
                    Console.Write(".");
                    Thread.Sleep(320);
                    Console.Write(".");
                    Thread.Sleep(320);
                    Console.Write(".");
                    Thread.Sleep(320);
                    Console.Write(".");
                    Environment.Exit(0);
                }
                if (!playerIsDead && bot1IsDead && bot2IsDead)
                {
                    Thread.Sleep(700);
                    Console.WriteLine("\n\nКонец игры");
                    Console.Write($"\nПобедил: {playerName}");
                    Console.Write(".");
                    Thread.Sleep(320);
                    Console.Write(".");
                    Thread.Sleep(320);
                    Console.Write(".");
                    Thread.Sleep(320);
                    Console.Write(".");
                    Thread.Sleep(320);
                    Console.Write(".");
                    Environment.Exit(0);
                }
            }
        }

        //class timer
        //{
        //    public static int seconds;
        //    public static int minutes;
        //    public void tick()
        //    {
        //        while (true)
        //        {
        //            Thread.Sleep(1000);
        //            seconds++;
        //        }
        //    }

        //    public static object timeInTheGame()
        //    {
        //        minutes = seconds / 60;
        //        string min = Convert.ToString(minutes); 
        //        string sec = Convert.ToString(seconds);
        //        object timeInGame = $"{min}:{sec}";
        //        return timeInGame;
        //    }
        //}

        static void Main(string[] args)
        {
            Console.Title = "Mega Monster Party";
            Console.ForegroundColor = ConsoleColor.White;

            game g = new game();
            //timer timer = new timer();

            //Thread t1 = new Thread(timer.tick);

            void menu()
            {
                while (true)
                {
                    try
                    {
                        Console.Clear();
                        Console.WriteLine("Играть(1)");
                        Console.WriteLine("Руководство(2)");
                        Console.Write("Выйти(3)");
                        Console.Write("\n\n--> ");
                        int menuChoice = int.Parse(Console.ReadLine());
                        switch (menuChoice)
                        {
                            case 1:
                                g.gameplay();
                                //t1.Start();
                                break;
                            case 2:
                                guide();
                                break;
                            case 3:
                                System.Environment.Exit(0);
                                break;
                            default:
                                Console.WriteLine("Введите от 1 до 3");
                                Console.ReadLine();
                                continue;
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Ошибка");
                        Console.ReadLine();
                    }
                }
            }

            void guide()
            {
                while (true)
                {
                    try
                    {
                        Console.Clear();
                        Console.Clear();

                        Console.WriteLine("Суть игры в том, чтобы добраться до финиша преодолевая препятствия и используя всевозможные возможности игры. \r\n\r\nЗа каждый ход игрок получает 3 монеты.");


                        Console.WriteLine("\nПросмотреть виды клеток(1)");
                        Console.Write("Назад(2)");
                        Console.Write("\n\n--> ");
                        int guideChoice = int.Parse(Console.ReadLine());
                        switch (guideChoice)
                        {
                            case 1:
                                while (true)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Вы можете попасть как в полезную клетку, так и не очень, из них:\r\n\r\n[ ] - пустая клетка\r\n\r\n[!] - Препятствие (Игрок, вступивший сюда, перемещается на 3 клетки назад)\r\n\r\n[$] - Деньги (Игрок, вступивший на эту клетку, получает монеты от 5 до 10)\r\n\r\n[X] - Смерть (Игрок выбывает)\r\n\r\n[A] - Атака (Игрок, вступивший на эту клетку, выбирает жертву и отбирает у нее 4 золотых) \r\n\r\n[S] - Магазин (Игрок вступивший на эту клетку выбирает что купить из 3 предложенных карточек,\r\n      карточки можно использовать в любой момент игры)\nЗа ход можно потратить только 1 карточку\r");
                                    Console.WriteLine("\nПросмотреть товары в магазине(1)");
                                    Console.Write("Назад(2)");
                                    Console.Write("\n\n--> ");
                                    try
                                    {
                                        int guide2choice = int.Parse(Console.ReadLine());
                                        switch (guide2choice)
                                        {
                                            case 1:
                                                while (true)
                                                {
                                                    Console.Clear();
                                                    Console.WriteLine("Товары в магазине:\n\r\nКарточка подставы - игрок, выбранный вами перемещается на 5 клеток назад(цена: 14 монет)\r\n\r\nКарточка вызова - игрок, выбранный вами в качестве соперника, сражается с вами в камень-ножницы-бумага,\r\nпобедитель получает 10 монет от другого (цена: 4 монеты)\r\n\r\nКарточка заточения - игрок, выбранный вами, пропустит следующие 3 хода(цена: 25 монет)\r");
                                                    Console.Write("\nНазад(1)");
                                                    Console.Write("\n\n--> ");
                                                    try
                                                    {
                                                        int guide3choice = int.Parse(Console.ReadLine());
                                                        switch (guide3choice)
                                                        {
                                                            case 1:
                                                                guide();
                                                                break;
                                                            default:
                                                                Console.WriteLine("Ошибка");
                                                                continue;
                                                        }
                                                    }
                                                    catch
                                                    {
                                                        Console.WriteLine("Ошибка");
                                                        Console.ReadLine();
                                                    }
                                                }
                                            case 2:
                                                guide();
                                                break;
                                            default:
                                                Console.WriteLine("Ошибка");
                                                Console.ReadLine();
                                                continue;
                                        }
                                    }
                                    catch
                                    {
                                        Console.WriteLine("Ошибка");
                                        Console.ReadLine();
                                    }
                                }
                            case 2:
                                menu();
                                break;
                            default:
                                Console.WriteLine("Ошибка");
                                Console.ReadLine();
                                continue;
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Ошибка");
                        Console.ReadLine();
                    }
                }
            }

            menu();
        }
    }
}
