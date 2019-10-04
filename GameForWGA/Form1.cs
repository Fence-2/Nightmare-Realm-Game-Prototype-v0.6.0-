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
        }

        public Bitmap crystalTexture = Resources.crystal, //itemNumber = 1
                      parchmentTexture = Resources.parchment, //itemNumber = 2
                      swordTexture = Resources.sword; //itemNumber = 3

        int itemNum, buttonNum, crystalCount, parchmentCount, swordCount;

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
    }
}
