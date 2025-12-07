using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Game2048
{
    public partial class MainWindow : Window
    {
        private const int V = 0;
        int[,] grid = new int[4, 4];
        TextBlock[,] tiles = new TextBlock[4, 4];
        int score;
        Random rand = new Random();

        public MainWindow()
        {
            InitializeComponent();
            CreateGrid();
            NewGame();
        }

        void CreateGrid()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    var border = new Border
                    {
                        Background = GetColor(0),
                        CornerRadius = new CornerRadius(4),
                        Margin = new Thickness(4)
                    };

                    tiles[i, j] = new TextBlock
                    {
                        FontSize = 32,
                        FontWeight = FontWeights.Bold,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center
                    };

                    border.Child = tiles[i, j];
                    Grid.SetRow(border, i);
                    Grid.SetColumn(border, j);
                    GameGrid.Children.Add(border);
                }
            }
        }

        void NewGame()
        {
            Array.Clear(grid, 0, grid.Length);
            score = 0;
            GameOverPanel.Visibility = Visibility.Collapsed;
            AddTile();
            AddTile();
            Draw();
        }

        void AddTile()
        {
            var empty = (from i in Enumerable.Range(0, 4)
                         from j in Enumerable.Range(0, 4)
                         where grid[i, j] == 0
                         select (i, j)).ToList();

            if (empty.Any())
            {
                var pos = empty[rand.Next(empty.Count)];
                grid[pos.i, pos.j] = rand.NextDouble() < 0.9 ? 2 : 4;
            }
        }

        void Draw()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    int val = grid[i, j];
                    tiles[i, j].Text = val == 0 ? "" : val.ToString();
                    tiles[i, j].Foreground = val <= 4 ? new SolidColorBrush(Color.FromRgb(0x77, 0x6e, 0x65)) : Brushes.White;
                    ((Border)tiles[i, j].Parent).Background = GetColor(val);
                }
            }
            ScoreText.Text = score.ToString();
        }

        Brush GetColor(int n)
        {
            switch(n)
        {
                case 0:
                    return new SolidColorBrush(Color.FromRgb(0xcd, 0xc1, 0xb4));
                case 2:
                    return new SolidColorBrush(Color.FromRgb(0xee, 0xe4, 0xda));
                case 4:
                    return new SolidColorBrush(Color.FromRgb(0xed, 0xe0, 0xc8));
                case 8:
                    return new SolidColorBrush(Color.FromRgb(0xf2, 0xb1, 0x79));
                case 16:
                    return new SolidColorBrush(Color.FromRgb(0xf5, 0x95, 0x63));
                case 32:
                    return  new SolidColorBrush(Color.FromRgb(0xf6, 0x7c, 0x5f));
                case 64:
                    return new SolidColorBrush(Color.FromRgb(0xf6, 0x5e, 0x3b));
                case 128:
                    return new SolidColorBrush(Color.FromRgb(0xed, 0xcf, 0x72));
                case 256:
                    return new SolidColorBrush(Color.FromRgb(0xed, 0xcc, 0x61));
                case 512:
                    return new SolidColorBrush(Color.FromRgb(0xed, 0xc8, 0x50));
                case 1024: 
                    return new SolidColorBrush(Color.FromRgb(0xed, 0xc5, 0x3f));
                case 2048:
                    return  new SolidColorBrush(Color.FromRgb(0xed, 0xc2, 0x2e));
                default:
                    return new SolidColorBrush(Color.FromRgb(0x3c, 0x3a, 0x32));
        }
        }
        

        void Window_KeyDown(object sender, KeyEventArgs e)
        {
            var oldGrid = (int[,])grid.Clone();

            switch (e.Key)
            {
                case Key.Left: Move(0); break;
                case Key.Right: Move(1); break;
                case Key.Up: Move(2); break;
                case Key.Down: Move(3); break;
                default: return;
            }

            if (!grid.Cast<int>().SequenceEqual(oldGrid.Cast<int>()))
            {
                AddTile();
                Draw();

                if (grid.Cast<int>().Any(x => x == 2048))
                    EndGame("Перемога! 🎉");
                else if (IsGameOver())
                    EndGame("Гра закінчена");
            }
        }

        void Move(int dir)
        {
            for (int i = 0; i < 4; i++)
            {
                int[] line = new int[4];

                for (int j = 0; j < 4; j++)
                {
                    if (dir == 0) line[j] = grid[i, j];           // Ліво
                    else if (dir == 1) line[j] = grid[i, 3 - j];  // Право
                    else if (dir == 2) line[j] = grid[j, i];      // Вгору
                    else line[j] = grid[3 - j, i];                // Вниз
                }

                var merged = Merge(line);

                for (int j = 0; j < 4; j++)
                {
                    if (dir == 0) grid[i, j] = merged[j];
                    else if (dir == 1) grid[i, 3 - j] = merged[j];
                    else if (dir == 2) grid[j, i] = merged[j];
                    else grid[3 - j, i] = merged[j];
                }
            }
        }

        int[] Merge(int[] line)
        {
            var nums = line.Where(x => x != 0).ToArray();
            var result = new int[4];
            int pos = 0;

            for (int i = 0; i < nums.Length; i++)
            {
                if (i < nums.Length - 1 && nums[i] == nums[i + 1])
                {
                    result[pos++] = nums[i] * 2;
                    score += nums[i] * 2;
                    i++;
                }
                else
                {
                    result[pos++] = nums[i];
                }
            }
            return result;
        }

        bool IsGameOver()
        {
            if (grid.Cast<int>().Any(x => x == 0))
                return false;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (grid[i, j] == grid[i, j + 1] || grid[j, i] == grid[j + 1, i])
                        return false;
                }
            }
            return true;
        }

        void EndGame(string msg)
        {
            GameOverText.Text = msg;
            FinalScoreText.Text = string.Format("Рахунок: {0}", score);
            GameOverPanel.Visibility = Visibility.Visible;
        }

        void NewGame_Click(object sender, RoutedEventArgs e)
        {
            NewGame();
        }
    }
}