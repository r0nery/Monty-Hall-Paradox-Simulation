using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monty_Hall_Paradox_Simulation
{
    internal class KeyInputWaiter
    {
        public static ConsoleKey WaitForKey (List<ConsoleKey> keys, string message)
        {
            ConsoleKey key;
            do
            {
                Console.WriteLine(message);
                key = Console.ReadKey().Key;
                Console.Clear();
            }
            while (!keys.Contains(key));
            return key;
        }
    }
}
