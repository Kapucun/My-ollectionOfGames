using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System.Windows.Shapes;
using System.Windows.Threading;



namespace Games
{
    /// <summary>
    /// Interaction logic for WindowSnake.xaml
    /// </summary>
    public partial class WindowSnake : Window
    {

        DispatcherTimer time;
        List<Snake> snakebody;
        List<Food> food;
        Random rd = new Random();
        int x = 100;
        int y = 100;
        int direction = 0;
        int left = 4;
        int right = 6;
        int up = 8;
        int down = 2;
        int score = 0;
        int count = 0;

        public WindowSnake()
        {
            InitializeComponent();
            time = new DispatcherTimer();
            snakebody = new List<Snake>();
            food = new List<Food>();
            snakebody.Add(new Snake(x, y));
            food.Add(new Food(rd.Next(0, 37) * 10, rd.Next(0, 35) * 10));
            time.Interval = new TimeSpan(0, 0, 0, 0, 100);   /*you can change speed of the snake here */
            time.Tick += time_Tick;
        }
        void addfoodincanvas()
        {
            food[0].setfoodposition();
            CanvaSnake.Children.Insert(0, food[0].ell);
        }


        void addsnakeincanvas()
        {
            foreach (Snake snake in snakebody)
            {
                snake.setsnakeposition();
                CanvaSnake.Children.Add(snake.rec);
            }
        }
        
        void time_Tick(object sender, EventArgs e)
        {
            if (direction != 0)
            {
                for (int i = snakebody.Count - 1; i > 0; i--)
                {
                    snakebody[i] = snakebody[i - 1];
                }
            }
            if (direction == up)
                y -= 10;
            if (direction == down)
                y += 10;
            if (direction == left)
                x -= 10;
            if (direction == right)
                x += 10;
            if (snakebody[0].x == food[0].x && snakebody[0].y == food[0].y)
            {
                snakebody.Add(new Snake(food[0].x, food[0].y));
                food[0] = new Food(rd.Next(0, 37) * 10, rd.Next(0, 35) * 10);
                CanvaSnake.Children.RemoveAt(0);
                addfoodincanvas();
                score++;
                Score.Text = score.ToString();
            }
            snakebody[0] = new Snake(x, y);

            if (snakebody[0].x > 370 || snakebody[0].y > 350 || snakebody[0].x < 0 || snakebody[0].y < 0)
            {
                this.Close();
            }
            for (int i = 1; i < snakebody.Count; i++)
            {
                if (snakebody[0].x == snakebody[i].x && snakebody[0].y == snakebody[i].y)
                    this.Close();
            }
            for (int i = 0; i < CanvaSnake.Children.Count; i++)
            {
                if (CanvaSnake.Children[i] is Rectangle)
                    count++;
            }
            CanvaSnake.Children.RemoveRange(1, count);
            count = 0;
            addsnakeincanvas();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Up && direction != down)
                direction = up;
            if (e.Key == Key.Down && direction != up)
                direction = down;
            if (e.Key == Key.Left && direction != right)
                direction = left;
            if (e.Key == Key.Right && direction != left)
                direction = right;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            addsnakeincanvas();
            addfoodincanvas();
            time.Start();
        }
    }
}
