using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static TextBlock[][] textArr = new TextBlock[4][];
        public static int[][] intArr = new int[4][]; 
        private static Random rnd = new Random();

        public MainWindow()
        {
            InitializeComponent();
            GenerateLabels();
            Draw();



        }

        public void GenerateLabels()
        {

            textArr[0] = new TextBlock[4];
            textArr[1] = new TextBlock[4];
            textArr[2] = new TextBlock[4];
            textArr[3] = new TextBlock[4];


            intArr[0] = new int[4];
            intArr[1] = new int[4];
            intArr[2] = new int[4];
            intArr[3] = new int[4];

            int rows = 4;
            int column = 4;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    TextBlock tx = new TextBlock();
                    textArr[i][j] = tx;
                    tx.Text = "0";
                    intArr[i][j] = 0;
                    mygrid.Children.Add(tx);
                    Grid.SetColumn(tx, j);
                    Grid.SetRow(tx, i);
                    //mygrid.RegisterName(tx.Name, tx);
                }
            }
        }


        private void ToRight()
        {
            for (int i = 0; i < intArr.Length; i++)
            {
                int count = intArr[i].Length - 1;
                for (int j = intArr[i].Length - 1; j >= 0; j--)
                {
                    if (intArr[i][j] != 0)
                    {
                        int x = intArr[i][j];
                        intArr[i][j] = 0;
                        intArr[i][count] = x;
                        count--;
                    }
                }
            }
        }

        private void MergeRight()
        {
            for (int i = 0; i < intArr.Length; i++)
            {
                for (int j = intArr[i].Length - 1; j > 0; j--)
                {
                    if (intArr[i][j] == intArr[i][j - 1] && intArr[i][j] != 0)
                    {
                        intArr[i][j - 1] = 0;
                        intArr[i][j] *= 2;
                    }
                }
            }
        }



        public void MoveRight()
        {
            ToRight();
            MergeRight();
            ToRight();
        }

        private void ToLeft()
        {
            for (int i = 0; i < intArr.Length; i++)
            {
                int count = 0;
                for (int j = 0; j < intArr[i].Length; j++)
                {
                    if (intArr[i][j] != 0)
                    {
                        int x = intArr[i][j];
                        intArr[i][j] = 0;
                        intArr[i][count] = x;
                        count++;
                    }
                }
            }
        }

        private void MergeLeft()
        {
            for (int i = 0; i < intArr.Length; i++)
            {
                for (int j = 0; j < intArr[i].Length - 1; j++)
                {
                    if (intArr[i][j] == intArr[i][j + 1] && intArr[i][j] != 0)
                    {
                        intArr[i][j + 1] = 0;
                        intArr[i][j] *= 2;
                    }
                }
            }
        }

        public void MoveLeft()
        {
            ToLeft();
            MergeLeft();
            ToLeft();
        }


        private void ToUp()
        {


            int[] rows = new int[intArr.Length];
            for (int i = 0; i < intArr.Length; i++)
            {
                for (int j = 0; j < intArr[i].Length; j++)
                {
                    if (intArr[i][j] != 0)
                    {
                        int x = intArr[i][j];
                        intArr[i][j] = 0;
                        intArr[rows[j]][j] = x;
                        rows[j]++;
                    }
                }
            }
        }
        private void MergeUp()
        {
            for (int i = 0; i < intArr.Length - 1; i++)
            {
                for (int j = 0; j < intArr[i].Length; j++)
                {
                    if (intArr[i][j] == intArr[i + 1][j] && intArr[i][j] != 0)
                    {
                        intArr[i + 1][j] = 0;
                        intArr[i][j] *= 2;
                    }
                }
            }
        }
        public void MoveUp()
        {
            ToUp();
            MergeUp();
            ToUp();
        }

        private void ToDown()
        {


            int[] rows = { intArr[0].Length - 1, intArr[0].Length - 1, intArr[0].Length - 1, intArr[0].Length - 1 };
            for (int i = intArr.Length - 1; i >= 0; i--)
            {
                for (int j = 0; j < intArr[i].Length; j++)
                {
                    if (intArr[i][j] != 0)
                    {
                        int x = intArr[i][j];
                        intArr[i][j] = 0;
                        intArr[rows[j]][j] = x;
                        rows[j]--;
                    }
                }
            }
        }
        private void MergeDown()
        {
            for (int i = intArr.Length - 1; i > 0; i--)
            {
                for (int j = 0; j < intArr[i].Length; j++)
                {
                    if (intArr[i][j] == intArr[i - 1][j] && intArr[i][j] != 0)
                    {
                        intArr[i - 1][j] = 0;
                        intArr[i][j] *= 2;
                    }
                }
            }
        }

        public void MoveDown()
        {
            ToDown();
            MergeDown();
            ToDown();
        }
        public void AddNum()
        {
            
            int line = rnd.Next(intArr.Length);
            int place = rnd.Next(intArr[0].Length);

            while (intArr[line][place] != 0)
            {
                line = rnd.Next(intArr.Length);
                place = rnd.Next(intArr[0].Length);
            }

            if (rnd.Next(101) >= 85)
            {
                intArr[line][place] = 4;
            }
            else
            {
                intArr[line][place] = 2;
            }
            
        }



        public void Colors()
        {
            for (int i = 0; i < textArr.Length; i++)
            {
                for (int j = 0; j < textArr[i].Length; j++)
                {

                    if (intArr[i][j] == 4)
                    {
                        textArr[i][j].Foreground = Brushes.Olive;
                    }
                    else if (intArr[i][j] == 8)
                    {
                        textArr[i][j].Foreground = Brushes.Orange;
                    }
                    else if (intArr[i][j] == 16)
                    {
                        textArr[i][j].Foreground = Brushes.Orange;
                    }
                    else if (intArr[i][j] == 32)
                    {
                        textArr[i][j].Foreground = Brushes.OrangeRed;
                    }
                    else if (intArr[i][j] == 64)
                    {
                        textArr[i][j].Foreground = Brushes.Red;
                    }
                    else if (intArr[i][j] == 128)
                    {
                        textArr[i][j].Foreground = Brushes.Gold;
                    }
                    else if (intArr[i][j] == 256)
                    {
                        textArr[i][j].Foreground = Brushes.Cyan;
                    }
                    else if (intArr[i][j] == 512)
                    {
                        textArr[i][j].Foreground = Brushes.Green;
                    }
                    else if (intArr[i][j] == 1024)
                    {
                        textArr[i][j].Foreground = Brushes.Blue;
                    }
                    else if (intArr[i][j] == 2048)
                    {
                        textArr[i][j].Foreground = Brushes.Gold;
                    }

                }
            }


        }

        public void ResetColors()
        {
            for (int i = 0; i < textArr.Length; i++)
            {
                for (int j = 0; j < textArr[i].Length; j++)
                {

                    textArr[i][j].Foreground = Brushes.Black;
                }
            }


        }

        public void Draw()
        {
            ResetColors();
            AddNum();
            Colors();
            
            for (int i = 0; i < intArr.Length; i++)
            {
                for (int j = 0; j < intArr.Length; j++)
                {
                    if (intArr[i][j] == 0)
                    {
                        textArr[i][j].Text = "";
                    }
                    else
                    {
                        textArr[i][j].Text = intArr[i][j].ToString();
                    }
                }
            }



        }

        private void mygrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Up)
            {
                MoveUp();
            }
            else if (e.Key == Key.Down)
            {
                MoveDown();
            }
            else if (e.Key == Key.Left)
            {
                MoveLeft();
            }
            else if (e.Key == Key.Right)
            {
                MoveRight();
            }
            Draw();
        }
    }
}
