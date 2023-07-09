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
            int open = 0;

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

    }
}
