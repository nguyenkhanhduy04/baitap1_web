using System;

namespace GameTaiXiuLibrary
{
    public class TaiXiuGame
    {
        private Random random = new Random();

        public int Balance { get; private set; }

        public TaiXiuGame(int initialBalance)
        {
            Balance = initialBalance;
        }

        // Kiểm tra dữ liệu cược có hợp lệ không
        public string ValidateBet(string choice, int amount)
        {
            if (amount <= 0)
                return "So tien cuoc khong hop le!";
            if (amount > Balance)
                return "Khong du so du!";
            string bet = choice.ToLower();
            if (bet != "tai" && bet != "xiu")
                return "Chi duoc chon Tai hoac Xiu!";
            return null; // hop le
        }

        // Thực hiện một ván chơi
        public string PlaceBet(string choice, int amount)
        {
            // validate truoc
            string error = ValidateBet(choice, amount);
            if (error != null)
                return error;

            int dice1 = random.Next(1, 7);
            int dice2 = random.Next(1, 7);
            int dice3 = random.Next(1, 7);
            int total = dice1 + dice2 + dice3;

            string result = (total >= 11) ? "tai" : "xiu";

            if (choice.ToLower() == result)
            {
                Balance += amount;
                return string.Format(
                    "Ket qua: {0}-{1}-{2} = {3} ({4}). Ban THANG! So du: {5}",
                    dice1, dice2, dice3, total, result.ToUpper(), Balance
                );
            }
            else
            {
                Balance -= amount;
                return string.Format(
                    "Ket qua: {0}-{1}-{2} = {3} ({4}). Ban THUA! So du: {5}",
                    dice1, dice2, dice3, total, result.ToUpper(), Balance
                );
            }
        }
    }
}
