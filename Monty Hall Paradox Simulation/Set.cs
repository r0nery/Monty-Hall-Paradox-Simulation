using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monty_Hall_Paradox_Simulation
{
    internal class Set
    {
        private bool[] rooms = new bool[3];
        public int[] LoosingNums { get; }
        public int WinningNum { get; }

        public Set() { 
            Random rand = new Random();
            LoosingNums = new int[2];            
            rooms[rand.Next(rooms.Length)] = true; 
            for (int i = 0, j = 0; i < rooms.Length; i++)
            {
                if (rooms[i]) 
                {
                    WinningNum = i;
                }
                else
                {
                    LoosingNums[j] = i;
                    j++;
                }
            }
        }
        public bool Check(int n)
        {
            return (rooms[n]);
        }
    }
}
