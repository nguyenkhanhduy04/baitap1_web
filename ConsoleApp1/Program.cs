using System;
using System.Threading;
using GameTaiXiuLibrary;

class Program
{
    static void Main(string[] args)
    {
        TaiXiuGame game = new TaiXiuGame(1000); // von ban dau

        while (true)
        {
            Console.WriteLine("=== Game Tai Xiu ===");
            Console.WriteLine("So du hien tai: " + game.Balance);
            Console.Write("Dat cuoc (Tai/Xiu): ");
            string bet = Console.ReadLine();

            Console.Write("So tien cuoc: ");
            int money = int.Parse(Console.ReadLine());

            Console.WriteLine("Dang lac xuc xac... cho 5 giay...");
            Thread.Sleep(5000);

            string result = game.PlaceBet(bet, money);
            Console.WriteLine(result);

            Console.WriteLine("Nhan Enter de tiep tuc, hoac go 'q' de thoat.");
            string exit = Console.ReadLine();
            if (exit.ToLower() == "q") break;
        }
    }
}
