using System;
using System.Windows.Forms;
using GameTaiXiuLibrary;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private TaiXiuGame game;
        private Timer timer;
        private int countdown = 5;
        private string betChoice;
        private int betAmount;

        public Form1()
        {
            InitializeComponent();

            game = new TaiXiuGame(1000);

            // Timer WinForms
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += new EventHandler(Timer_Tick);

            InitUI();
        }

        private Label lblBalance, lblCountdown, lblResult;
        private TextBox txtBetAmount;
        private Button btnTai, btnXiu;

        private void InitUI()
        {
            this.Text = "Game Tài Xỉu";
            this.Width = 400;
            this.Height = 300;

            lblBalance = new Label();
            lblBalance.Text = "Số dư: " + game.Balance;
            lblBalance.Left = 20; lblBalance.Top = 20;
            this.Controls.Add(lblBalance);

            Label lblNhap = new Label();
            lblNhap.Text = "Nhập số tiền cược:";
            lblNhap.Left = 20; lblNhap.Top = 60;
            this.Controls.Add(lblNhap);

            txtBetAmount = new TextBox();
            txtBetAmount.Left = 150; txtBetAmount.Top = 60;
            this.Controls.Add(txtBetAmount);

            btnTai = new Button();
            btnTai.Text = "Tài (11-18)";
            btnTai.Left = 20; btnTai.Top = 100;
            btnTai.Click += new EventHandler(BtnTai_Click);
            this.Controls.Add(btnTai);

            btnXiu = new Button();
            btnXiu.Text = "Xỉu (3-10)";
            btnXiu.Left = 150; btnXiu.Top = 100;
            btnXiu.Click += new EventHandler(BtnXiu_Click);
            this.Controls.Add(btnXiu);

            lblCountdown = new Label();
            lblCountdown.Text = "Thời gian: ";
            lblCountdown.Left = 20; lblCountdown.Top = 150;
            this.Controls.Add(lblCountdown);

            lblResult = new Label();
            lblResult.Text = "";
            lblResult.Left = 20; lblResult.Top = 200;
            lblResult.Width = 300;
            this.Controls.Add(lblResult);
        }

        private void BtnTai_Click(object sender, EventArgs e)
        {
            StartGame("tai");
        }

        private void BtnXiu_Click(object sender, EventArgs e)
        {
            StartGame("xiu");
        }

        private void StartGame(string choice)
        {
            if (!int.TryParse(txtBetAmount.Text, out betAmount) || betAmount <= 0)
            {
                MessageBox.Show("Nhập số tiền cược hợp lệ!");
                return;
            }

            if (betAmount > game.Balance)
            {
                MessageBox.Show("Không đủ số dư!");
                return;
            }

            betChoice = choice;
            countdown = 5;
            lblCountdown.Text = "Thời gian: " + countdown + "s";
            lblResult.Text = "Đang lắc xúc xắc...";
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            countdown--;
            lblCountdown.Text = "Thời gian: " + countdown + "s";

            if (countdown == 0)
            {
                timer.Stop();
                string result = game.PlaceBet(betChoice, betAmount);
                lblResult.Text = result;
                lblBalance.Text = "Số dư: " + game.Balance;
            }
        }
    }
}
