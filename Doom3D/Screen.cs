using Doom3D.Constants;
using Doom3D.Core;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Doom3D
{
    public partial class Screen : Form
    {
        private Controller controller;
        private PictureBox gameWindow = new PictureBox();

        public Screen()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            this.KeyPreview = true;
            ShowStartMenu();
        }

        private void ShowStartMenu()
        {
            var welcome = new Label()
            {
                Size = new Size(800, 100),
                Location = new Point(this.Width / 2 - Size.Width/2, this.Height * (1 / 6)),
                Text = "Выбери уровень",
                Font = new Font("Tahoma", 40, FontStyle.Regular),
                ForeColor = Color.Black,
                TextAlign = ContentAlignment.BottomCenter
            };
            this.Controls.Add(welcome);

            var levels = DataBase.LevelCards;

            for(int i = 0; i < 1; i++)//костыль, в идеале надо отрисовывать все уровни и листать их
            {
                var levelButton = new Button()
                {
                    Size = new Size(200, 100),
                    BackColor = Color.DarkGray,
                    Location = new Point(this.Width / 2 - Size.Width/2, this.Height /2), //* ((i+2)/6)),
                    Text = levels[i].Name,
                    Font = new Font("Tahoma", 30, FontStyle.Regular)
                };
                levelButton.Click += levelButtonClick;
                //Добавить отрисовку описания уровня и его миниатюры

                this.Controls.Add(levelButton);
            }
        }

        private void levelButtonClick(object sender, EventArgs e)//создание контроллера игры и запуск
        {
            switch (((Button) sender).Text)
            {
                case "На время":
                    controller = new Controller(this, Mode.OnTime);
                    this.Controls.Clear();
                    gameWindow.Size = Values.GameWindowSize;
                    //Добавить стартовый экран уровня
                    this.Controls.Add(gameWindow);
                    break;
            }
        }

        public void ChangeGameWindowImage(Image img)
        {
            gameWindow.Image = img;
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            controller.HandleKey(e.KeyCode, true);
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            controller.HandleKey(e.KeyCode, false);
        }

        private void GameForm_Load(object sender, EventArgs e)
        {

        }
    }
}