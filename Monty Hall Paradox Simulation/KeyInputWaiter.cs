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
            Console.WriteLine(message);
            do
            {
                key = Console.ReadKey().Key;
                Console.Write("\b \b");
            }
            while (!keys.Contains(key));

            Console.Clear();
            
            return key;
        }
    }
}
