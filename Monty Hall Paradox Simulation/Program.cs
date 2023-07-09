namespace Monty_Hall_Paradox_Simulation
{
    internal class Program
    {
        // TODO выделиить константы в отдельный класс
        static List<ConsoleKey> modeSelectKeys = new List<ConsoleKey>()
        { ConsoleKey.D1, ConsoleKey.D2, ConsoleKey.NumPad1, ConsoleKey.NumPad2 };
        const string modeSelectMessage =
            "Выберите режим:\n1 - Хочу поиграть сам\t2 - Хочу запустить симуляцию\n";
        static List<ConsoleKey> roomSelectKeys = new List<ConsoleKey>()
        { ConsoleKey.D1, ConsoleKey.D2, ConsoleKey.D3, ConsoleKey.NumPad1, ConsoleKey.NumPad2, ConsoleKey.NumPad3 };
        const string roomSelectMessage =
            "Выберите комнату: 1, 2 или 3";

        static void Main(string[] args)
        {
            ConsoleKey key = KeyInputWaiter.WaitForKey(modeSelectKeys, modeSelectMessage);

            switch (key)
            {
                case ConsoleKey.NumPad1:
                case ConsoleKey.D1:
                    PlayYourself();
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    Console.WriteLine("Введите количество симуляций");
                    // TODO: обработать некорректный ввод
                    int runs = Convert.ToInt32(Console.ReadLine());
                    RunSimulation(runs);
                    break;
            }
        }
        static void PlayYourself()
        {
            WinCounter winCounter = new WinCounter();
            int runs = 1;
            Set set;
            while (runs < int.MaxValue)
            {
                int choice = 0;
                ConsoleKey choiceKey = KeyInputWaiter.WaitForKey(roomSelectKeys, roomSelectMessage);
                switch (choiceKey)
                {
                    case ConsoleKey.NumPad1:
                    case ConsoleKey.D1:
                        choice = 0;
                        break;
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        choice = 1;
                        break;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        choice = 2;
                        break;
                }

                set = new Set();
                bool result = Simulation.PlayerDescision(set, choice);
                winCounter.AddResult(result);
                if (result)
                    Console.WriteLine("Ура, победа!\n");
                else Console.WriteLine("Вы проиграли\n");

                ConsoleKey continueKey = KeyInputWaiter.WaitForKey
                    (new List<ConsoleKey>() { ConsoleKey.Y, ConsoleKey.N }, "Продолжить? y/n");
                if (continueKey == ConsoleKey.N)
                    runs = int.MaxValue;
            }
            winCounter.PrintStatistics();
        }
        static void RunSimulation(int runs)
        {
            WinCounter badCounter = new WinCounter();
            WinCounter goodCounter = new WinCounter();

            for (int i = 0; i < runs; i++)
            {
                Set set = new Set();
                int choice = new Random().Next(3);
                badCounter.AddResult(Simulation.BadDescision(set, choice));
                goodCounter.AddResult(Simulation.GoodDescision(set, choice));
            }
            Console.WriteLine("\n0Результаты плохой стратегии:");
            badCounter.PrintStatistics();
            Console.WriteLine("\nРезультаты хорошей стратегии:");
            goodCounter.PrintStatistics();
        }
    }
}