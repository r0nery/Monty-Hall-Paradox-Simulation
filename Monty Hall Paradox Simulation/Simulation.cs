using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monty_Hall_Paradox_Simulation
{
    static class Simulation
    {
        public static bool GoodDescision(Set set, int choice)
        {
            int open = -1;

            if (set.LoosingNums.Contains(choice))
            {
                foreach(int i in set.LoosingNums)
                {
                    if (i != choice)
                        open = i;
                }
            }
            else
            {
                open = set.LoosingNums[new Random().Next(2)];
            }

            for (int i = 0; i < 3; i++)
            {
                if (i != choice && i != open)
                    return set.Check(i);
            }

            return false;

        }

        public static bool BadDescision(Set set, int choice)
        {
            return set.Check(choice);
        }

        public static bool PlayerDescision(Set set, int choice)
        {
            int open = 0;
            //Console.WriteLine("Вы выбрали дверь №" + (choice+1));

            if (set.LoosingNums.Contains(choice))
            {
                foreach (int i in set.LoosingNums)
                {
                    if (i != choice)
                        open = i;
                }
            }
            else
            {
                open = set.LoosingNums[new Random().Next(2)];
            }

            int newChoice = -1;
            for (int i = 0; i < 3; i++)
            {
                if (i != choice && i != open)
                {
                    newChoice = i;
                    break;
                }                    
            }

            string chaneChoiceMessage =
                "Вы выбрали дверь №" + (choice+1) +
                "\nВедущий открывает дверь №" + (open+1) + ", за ней коза. Хотите поменять решение на "+(newChoice+1)+"?\ny/n";
            ConsoleKey key = KeyInputWaiter.WaitForKey(new List<ConsoleKey>() { ConsoleKey.Y, ConsoleKey.N }, chaneChoiceMessage);

            switch (key)
            {
                case ConsoleKey.Y:
                    return set.Check(newChoice);   
                case ConsoleKey.N:
                    return set.Check(choice);
            }

            return false;

        }
    }
}
