using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameForWGA
{
    public partial class GameWindow : Form
    {
        public GameWindow()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint
| ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
            UpdateStyles();
        }

        public Bitmap crystalTexture = Resources.crystal, //itemNumber = 1
                      parchmentTexture = Resources.parchment, //itemNumber = 2
                      swordTexture = Resources.sword; //itemNumber = 3

        int itemNum, buttonNum, crystalCount, parchmentCount, swordCount, buttonLocOnGrid_X, buttonLocOnGrid_Y, direction;

        Point buttonLocOnGrid, startingMousePoint, startingButtonLocOnGrid;

        Button buttonToMove;
        private void GameLoad(object sender, EventArgs e)
        {
            GameStart();
        }

        int[,] gameCell = new int[5, 5];

        Random rnd = new Random();

        private Bitmap SetRandomItem()
        {
            itemNum = rnd.Next(1, 4);

            if (itemNum == 1 && crystalCount < 5)
            {
                crystalCount++;
                return crystalTexture;
            }

            else if (itemNum == 2 && parchmentCount < 5)
            {
                parchmentCount++;
                return parchmentTexture;
            }

            else if (swordCount < 5)
            {
                swordCount++;
                return swordTexture;
            }
            else
            {
                return SetRandomItem();
            }
        }

        private void ClearTheWeb()
        {
            crystalCount = parchmentCount = swordCount = 0;
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                {
                    gameCell[i, j] = 0;
                }
            gameCell[0, 1] = gameCell[0, 3] = gameCell[2, 1] = gameCell[2, 3] = gameCell[4, 1] = gameCell[4, 3] = 2; //Значение Гор = 2
        }

        private void GameStart()
        {
            ClearTheWeb();
            for (int item = 0; item < 15; item++)
            {
                buttonNum = rnd.Next(1, 16);
                switch (buttonNum)
                {
                    case 1:
                        if (gameCell[0, 0] != 1)
                        {
                            gameCell[0, 0] = 1;
                            item_1.BackgroundImage = SetRandomItem();
                        }
                        else item--;
                        break;
                    case 2:
                        if (gameCell[1, 0] != 1)
                        {
                            gameCell[1, 0] = 1;
                            item_2.BackgroundImage = SetRandomItem();
                        }
                        else item--;
                        break;
                    case 3:
                        if (gameCell[2, 0] != 1)
                        {
                            gameCell[2, 0] = 1;
                            item_3.BackgroundImage = SetRandomItem();
                        }
                        else item--;
                        break;
                    case 4:
                        if (gameCell[3, 0] != 1)
                        {
                            gameCell[3, 0] = 1;
                            item_4.BackgroundImage = SetRandomItem();
                        }
                        else item--;
                        break;
                    case 5:
                        if (gameCell[4, 0] != 1)
                        {
                            gameCell[4, 0] = 1;
                            item_5.BackgroundImage = SetRandomItem();
                        }
                        else item--;
                        break;
                    case 6:
                        if (gameCell[0, 2] != 1)
                        {
                            gameCell[0, 2] = 1;
                            item_6.BackgroundImage = SetRandomItem();
                        }
                        else item--;
                        break;
                    case 7:
                        if (gameCell[1, 2] != 1)
                        {
                            gameCell[1, 2] = 1;
                            item_7.BackgroundImage = SetRandomItem();
                        }
                        else item--;
                        break;
                    case 8:
                        if (gameCell[2, 2] != 1)
                        {
                            gameCell[2, 2] = 1;
                            item_8.BackgroundImage = SetRandomItem();
                        }
                        else item--;
                        break;
                    case 9:
                        if (gameCell[3, 2] != 1)
                        {
                            gameCell[3, 2] = 1;
                            item_9.BackgroundImage = SetRandomItem();
                        }
                        else item--;
                        break;
                    case 10:
                        if (gameCell[4, 2] != 1)
                        {
                            gameCell[4, 2] = 1;
                            item_10.BackgroundImage = SetRandomItem();
                        }
                        else item--;
                        break;
                    case 11:
                        if (gameCell[0, 4] != 1)
                        {
                            gameCell[0, 4] = 1;
                            item_11.BackgroundImage = SetRandomItem();
                        }
                        else item--;
                        break;
                    case 12:
                        if (gameCell[1, 4] != 1)
                        {
                            gameCell[1, 4] = 1;
                            item_12.BackgroundImage = SetRandomItem();
                        }
                        else item--;
                        break;
                    case 13:
                        if (gameCell[2, 4] != 1)
                        {
                            gameCell[2, 4] = 1;
                            item_13.BackgroundImage = SetRandomItem();
                        }
                        else item--;
                        break;
                    case 14:
                        if (gameCell[3, 4] != 1)
                        {
                            gameCell[3, 4] = 1;
                            item_14.BackgroundImage = SetRandomItem();
                        }
                        else item--;
                        break;
                    case 15:
                        if (gameCell[4, 4] != 1)
                        {
                            gameCell[4, 4] = 1;
                            item_15.BackgroundImage = SetRandomItem();
                        }
                        else item--;
                        break;
                }
            }
        }

        private Point WhereThisButtonIsOnTheGrid(Point buttonLocation)
        {
            buttonLocOnGrid_X = buttonLocOnGrid_Y = 0;
            switch (buttonLocation.X)
            {
                case 3:
                    buttonLocOnGrid_X = 0;
                    break;
                case 59:
                    buttonLocOnGrid_X = 1;
                    break;
                case 115:
                    buttonLocOnGrid_X = 2;
                    break;
                case 171:
                    buttonLocOnGrid_X = 3;
                    break;
                case 227:
                    buttonLocOnGrid_X = 4;
                    break;
            }
            switch (buttonLocation.Y)
            {
                case 3:
                    buttonLocOnGrid_Y = 0;
                    break;
                case 59:
                    buttonLocOnGrid_Y = 1;
                    break;
                case 115:
                    buttonLocOnGrid_Y = 2;
                    break;
                case 171:
                    buttonLocOnGrid_Y = 3;
                    break;
                case 227:
                    buttonLocOnGrid_Y = 4;
                    break;
            }
            return new Point(buttonLocOnGrid_X, buttonLocOnGrid_Y);
        }

        private void MouseUpMethod(Button item, int ButtonLocationOnGrid_X, int ButtonLocationOnGrid_Y, MouseEventArgs mouseNow)
        {
            if (mouseNow.Button == MouseButtons.Left && direction == 0)
            {
                //Проверка на движение вправо
                if (mouseNow.X > startingMousePoint.X &&
                    Math.Abs(mouseNow.X - startingMousePoint.X) > Math.Abs(mouseNow.Y - startingMousePoint.Y) &&
                    Math.Abs(mouseNow.X - startingMousePoint.X) > item.Width / 3 &&
                    ButtonLocationOnGrid_X != 4 &&
                    gameCell[buttonLocOnGrid_X + 1, buttonLocOnGrid_Y] == 0)
                {
                    gameCell[buttonLocOnGrid_X + 1, buttonLocOnGrid_Y] = 1;
                    gameCell[buttonLocOnGrid_X, buttonLocOnGrid_Y] = 0;
                    direction = 1;
                    buttonToMove = item;
                    timerDo.Enabled = true;
                }
                //Проверка на движение влево
                else if (mouseNow.X < startingMousePoint.X &&
                        Math.Abs(mouseNow.X - startingMousePoint.X) > Math.Abs(mouseNow.Y - startingMousePoint.Y) &&
                        Math.Abs(mouseNow.X - startingMousePoint.X) > item.Width / 3 &&
                    ButtonLocationOnGrid_X != 0 &&
                    gameCell[buttonLocOnGrid_X - 1, buttonLocOnGrid_Y] == 0)
                {
                    gameCell[buttonLocOnGrid_X - 1, buttonLocOnGrid_Y] = 1;
                    gameCell[buttonLocOnGrid_X, buttonLocOnGrid_Y] = 0;
                    direction = 2;
                    buttonToMove = item;
                    timerDo.Enabled = true;
                }
                //Проверка на движение вверх
                else if (mouseNow.Y < startingMousePoint.Y &&
                        Math.Abs(mouseNow.Y - startingMousePoint.Y) > Math.Abs(mouseNow.X - startingMousePoint.X) &&
                        Math.Abs(mouseNow.Y - startingMousePoint.Y) > item.Height / 3 &&
                    ButtonLocationOnGrid_Y != 0 &&
                    gameCell[buttonLocOnGrid_X, buttonLocOnGrid_Y - 1] == 0)
                {
                    gameCell[buttonLocOnGrid_X, buttonLocOnGrid_Y - 1] = 1;
                    gameCell[buttonLocOnGrid_X, buttonLocOnGrid_Y] = 0;
                    direction = 3;
                    buttonToMove = item;
                    timerDo.Enabled = true;
                }
                //Проверка на движение вниз
                else if (mouseNow.Y > startingMousePoint.Y &&
                        Math.Abs(mouseNow.Y - startingMousePoint.Y) > Math.Abs(mouseNow.X - startingMousePoint.X) &&
                        Math.Abs(mouseNow.Y - startingMousePoint.Y) > item.Height / 3 &&
                    ButtonLocationOnGrid_Y != 4 &&
                    gameCell[buttonLocOnGrid_X, buttonLocOnGrid_Y + 1] == 0)
                {
                    gameCell[buttonLocOnGrid_X, buttonLocOnGrid_Y + 1] = 1;
                    gameCell[buttonLocOnGrid_X, buttonLocOnGrid_Y] = 0;
                    direction = 4;
                    buttonToMove = item;
                    timerDo.Enabled = true;
                }
            }
        }
        private void MouseDownMethod(Button s, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && direction == 0)
            {
                startingButtonLocOnGrid = s.Location;
                startingMousePoint = e.Location;
            }
        }

        private void GoRight(Button item)
        {
            if (item.Location.X < startingButtonLocOnGrid.X + 56)
            {
                item.Left += 4;
            }
            else
            {
                timerDo.Enabled = false;
                direction = 0;
            }
        }

        private void GoLeft(Button item)
        {
            if (item.Location.X > startingButtonLocOnGrid.X - 56)
            {
                item.Left -= 4;
            }
            else
            {
                timerDo.Enabled = false;
                direction = 0;
            }
                
        }
        private void GoUp(Button item)
        {
            if (item.Location.Y > startingButtonLocOnGrid.Y - 56)
            {
                item.Top -= 4;
            }
            else
            {
                timerDo.Enabled = false;
                direction = 0;
            }
        }
        private void GoDown(Button item)
        {
            if (item.Location.Y < startingButtonLocOnGrid.Y + 56)
            {
                item.Top += 4;
            }
            else
            {
                timerDo.Enabled = false;
                direction = 0;
            }
        }

        private void timerDo_Tick(object sender,EventArgs e)
        {
            switch (direction)
            {
                case 1:
                    GoRight(buttonToMove);
                    break;
                case 2:
                    GoLeft(buttonToMove);
                    break;
                case 3:
                    GoUp(buttonToMove);
                    break;
                case 4:
                    GoDown(buttonToMove);
                    break;
            }
            
        }

        private void item_1_MouseDown(object sender, MouseEventArgs e)
        {
            MouseDownMethod(item_1, e);
        }

        private void item_1_MouseUp(object sender, MouseEventArgs e)
        {
            buttonLocOnGrid = WhereThisButtonIsOnTheGrid(item_1.Location);
            MouseUpMethod(item_1, buttonLocOnGrid.X, buttonLocOnGrid.Y, e);
        }
        
        private void item_2_MouseDown(object sender, MouseEventArgs e)
        {
            MouseDownMethod(item_2, e);
        }

        private void item_2_MouseUp(object sender, MouseEventArgs e)
        {
            buttonLocOnGrid = WhereThisButtonIsOnTheGrid(item_2.Location);
            MouseUpMethod(item_2, buttonLocOnGrid.X, buttonLocOnGrid.Y, e);
        }

        private void item_3_MouseDown(object sender, MouseEventArgs e)
        {
            MouseDownMethod(item_3, e);
        }

        private void item_3_MouseUp(object sender, MouseEventArgs e)
        {
            buttonLocOnGrid = WhereThisButtonIsOnTheGrid(item_3.Location);
            MouseUpMethod(item_3, buttonLocOnGrid.X, buttonLocOnGrid.Y, e);
        }

        private void item_4_MouseDown(object sender, MouseEventArgs e)
        {
            MouseDownMethod(item_4, e);
        }

        private void item_4_MouseUp(object sender, MouseEventArgs e)
        {
            buttonLocOnGrid = WhereThisButtonIsOnTheGrid(item_4.Location);
            MouseUpMethod(item_4, buttonLocOnGrid.X, buttonLocOnGrid.Y, e);
        }

        private void item_5_MouseDown(object sender, MouseEventArgs e)
        {
            MouseDownMethod(item_5, e);
        }

        private void item_5_MouseUp(object sender, MouseEventArgs e)
        {
            buttonLocOnGrid = WhereThisButtonIsOnTheGrid(item_5.Location);
            MouseUpMethod(item_5, buttonLocOnGrid.X, buttonLocOnGrid.Y, e);
        }

        private void item_6_MouseDown(object sender, MouseEventArgs e)
        {
            MouseDownMethod(item_6, e);
        }

        private void item_6_MouseUp(object sender, MouseEventArgs e)
        {
            buttonLocOnGrid = WhereThisButtonIsOnTheGrid(item_6.Location);
            MouseUpMethod(item_6, buttonLocOnGrid.X, buttonLocOnGrid.Y, e);
        }

        private void item_7_MouseDown(object sender, MouseEventArgs e)
        {
            MouseDownMethod(item_7, e);
        }

        private void item_7_MouseUp(object sender, MouseEventArgs e)
        {
            buttonLocOnGrid = WhereThisButtonIsOnTheGrid(item_7.Location);
            MouseUpMethod(item_7, buttonLocOnGrid.X, buttonLocOnGrid.Y, e);
        }

        private void item_8_MouseDown(object sender, MouseEventArgs e)
        {
            MouseDownMethod(item_8, e);
        }

        private void item_8_MouseUp(object sender, MouseEventArgs e)
        {
            buttonLocOnGrid = WhereThisButtonIsOnTheGrid(item_8.Location);
            MouseUpMethod(item_8, buttonLocOnGrid.X, buttonLocOnGrid.Y, e);
        }

        private void item_9_MouseDown(object sender, MouseEventArgs e)
        {
            MouseDownMethod(item_9, e);
        }

        private void item_9_MouseUp(object sender, MouseEventArgs e)
        {
            buttonLocOnGrid = WhereThisButtonIsOnTheGrid(item_9.Location);
            MouseUpMethod(item_9, buttonLocOnGrid.X, buttonLocOnGrid.Y, e);
        }

        private void item_10_MouseDown(object sender, MouseEventArgs e)
        {
            MouseDownMethod(item_10, e);
        }

        private void item_10_MouseUp(object sender, MouseEventArgs e)
        {
            buttonLocOnGrid = WhereThisButtonIsOnTheGrid(item_10.Location);
            MouseUpMethod(item_10, buttonLocOnGrid.X, buttonLocOnGrid.Y, e);
        }

        private void item_11_MouseDown(object sender, MouseEventArgs e)
        {
            MouseDownMethod(item_11, e);
        }

        private void item_11_MouseUp(object sender, MouseEventArgs e)
        {
            buttonLocOnGrid = WhereThisButtonIsOnTheGrid(item_11.Location);
            MouseUpMethod(item_11, buttonLocOnGrid.X, buttonLocOnGrid.Y, e);
        }

        private void item_12_MouseDown(object sender, MouseEventArgs e)
        {
            MouseDownMethod(item_12, e);
        }

        private void item_12_MouseUp(object sender, MouseEventArgs e)
        {
            buttonLocOnGrid = WhereThisButtonIsOnTheGrid(item_12.Location);
            MouseUpMethod(item_12, buttonLocOnGrid.X, buttonLocOnGrid.Y, e);
        }

        private void item_13_MouseDown(object sender, MouseEventArgs e)
        {
            MouseDownMethod(item_13, e);
        }

        private void item_13_MouseUp(object sender, MouseEventArgs e)
        {
            buttonLocOnGrid = WhereThisButtonIsOnTheGrid(item_13.Location);
            MouseUpMethod(item_13, buttonLocOnGrid.X, buttonLocOnGrid.Y, e);
        }

        private void item_14_MouseDown(object sender, MouseEventArgs e)
        {
            MouseDownMethod(item_14, e);
        }

        private void item_14_MouseUp(object sender, MouseEventArgs e)
        {
            buttonLocOnGrid = WhereThisButtonIsOnTheGrid(item_14.Location);
            MouseUpMethod(item_14, buttonLocOnGrid.X, buttonLocOnGrid.Y, e);
        }

        private void item_15_MouseDown(object sender, MouseEventArgs e)
        {
            MouseDownMethod(item_15, e);
        }

        private void item_15_MouseUp(object sender, MouseEventArgs e)
        {
            buttonLocOnGrid = WhereThisButtonIsOnTheGrid(item_15.Location);
            MouseUpMethod(item_15, buttonLocOnGrid.X, buttonLocOnGrid.Y, e);
        }

        
    }
}
