using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monty_Hall_Paradox_Simulation
{
    internal class WinCounter
    {
        private int wins = 0;
        private int total = 0;

        private double GetWinPercentage()
        {
            return  wins / ((double)total / 100);
        }

        public void AddResult(bool isWin)
        {
            total++;
            if (isWin)
                wins++;
        }
        public void PrintStatistics()
        {
            double success = GetWinPercentage();
            Console.WriteLine($"\n\nВсего игр: {total}\tИз них побед: {wins}\tУспешность: {success}%");
        }
    }
}
