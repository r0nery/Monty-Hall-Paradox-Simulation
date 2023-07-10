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
            int open = -1;

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
            bool[] openRooms = new bool[3] {false, false, false};
            openRooms[open]=true;
            SetVisualizer setVisualizer = new SetVisualizer(set, openRooms, choice);
            setVisualizer.PrintSet();
            string chaneChoiceMessage =
                "\n\nВы выбрали дверь №" + (choice+1) +
                "\nВедущий открывает дверь №" + (open+1) + ", за ней коза.\nХотите поменять решение на "+(newChoice+1)+"?\t[y/n]";
            ConsoleKey key = KeyInputWaiter.WaitForKey(new List<ConsoleKey>() { ConsoleKey.Y, ConsoleKey.N }, chaneChoiceMessage);

            switch (key)
            {                  
                case ConsoleKey.N:
                    setVisualizer = new SetVisualizer(set, new bool[]{true, true, true}, choice);
                    setVisualizer.PrintSet();
                    return set.Check(choice);
                case ConsoleKey.Y:
                    setVisualizer = new SetVisualizer(set, new bool[] { true, true, true }, newChoice);
                    setVisualizer.PrintSet();
                    return set.Check(newChoice);
            }

            return false;

        }
    }
}
