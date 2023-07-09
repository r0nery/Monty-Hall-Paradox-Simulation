namespace Monty_Hall_Paradox_Simulation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество симуляций");
            int total = Convert.ToInt32(Console.ReadLine());
            WinCounter badCounter = new WinCounter();
            WinCounter goodCounter = new WinCounter();

            for (int i = 0; i < total; i++)
            {
                Set set = new Set();
                int choice = new Random().Next(3);
                badCounter.AddResult(Simulation.BadDescision(set, choice));
                goodCounter.AddResult(Simulation.GoodDescision(set, choice));                
            }
            Console.WriteLine("Результаты плохой стратегии:");
            badCounter.PrintStatistics();
            Console.WriteLine("\nРезультаты хорошей стратегии:");
            goodCounter.PrintStatistics();


            
        }
    }
}