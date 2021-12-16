using System;
using System.Windows;
using System.Windows.Input;


namespace Games
{
    class Clas2048
    {
        Random rand = new Random();
        int[,] arr = new int[4, 4]{{0,0,0,0},
                                {0,0,0,0},
                                {0,0,0,0},
                                {0,0,0,0}};
        int score = 0;
        public int Score { get => score; }

        public int GetArrInt(int i)
        {
            return arr[i / 4, i % 4];
        }
        public string GetArrString(int i)
        {
            if (arr[i / 4, i % 4] == 0)
                return "";
            else
                return arr[i / 4, i % 4].ToString();
        }

        private void FillArr()
        {
            int temp;
            int val;
            val = rand.Next(0, 10);
            if (val == 9)
                val = 4;
            else val = 2;
            do
            {
                temp = rand.Next(0, 16);
                if (arr[temp / 4, temp % 4] == 0)
                {
                    arr[temp / 4, temp % 4] = val;
                    break;
                }
            } while (true);
        }
        private void InitArr()
        {

            for (int i = 0; i < 2; i++)
            {
                FillArr();
                if (!check())
                    break;
            }
        }
        public void start2048()
        {
            InitArr();
        }
        public bool RUN2048(KeyEventArgs e)
        {
            Moving(e);
            if (check())
            {
                InitArr();
                return true;
            }
            else
            {
                MessageBoxResult temp = MessageBox.Show("Ваш счет =" + score + ". Желаете снова начать игру?", "Конец", MessageBoxButton.YesNo);


                if (temp == MessageBoxResult.Yes)
                {
                    arr = new int[4, 4]{{0,0,0,0},
                                {0,0,0,0},
                                {0,0,0,0},
                                {0,0,0,0}};
                    score = 0;
                    return true;
                }
                else return false;

            }
        }
        private bool check()// проверка свободных клеток 
        {
            foreach (int i in arr)
            {
                if (i == 0)
                    return true;
            }
            return false;
        }

        private void MoveUp()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 1; j < 4; j++)
                {
                    if (arr[j, i] != 0 && arr[j - 1, i] == 0)
                    {
                        arr[j - 1, i] = arr[j, i];
                        arr[j, i] = 0;
                        j = 0;
                    }
                    else if (arr[j, i] != 0 && arr[j - 1, i] == arr[j, i])
                    {
                        arr[j - 1, i] *= 2;
                        arr[j, i] = 0;
                        score += arr[j - 1, i];
                        j = 0;

                    }

                }
            }

        }
        private void MoveDown()
        {
            for (int i = 3; i >= 0; i--)
            {
                for (int j = 2; j >= 0; j--)
                {
                    if (arr[j, i] != 0 && arr[j + 1, i] == 0)
                    {
                        arr[j + 1, i] = arr[j, i];
                        arr[j, i] = 0;
                        j = 3;
                    }
                    else if (arr[j, i] != 0 && arr[j + 1, i] == arr[j, i])
                    {
                        arr[j + 1, i] *= 2;
                        arr[j, i] = 0;
                        score += arr[j + 1, i];
                        j = 3;
                    }

                }
            }
        }
        private void MoveLeft()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 1; j < 4; j++)
                {
                    if (arr[i, j] != 0 && arr[i, j - 1] == 0)
                    {
                        arr[i, j - 1] = arr[i, j];
                        arr[i, j] = 0;
                        j = 0;
                    }
                    else if (arr[i, j] != 0 && arr[i, j - 1] == arr[i, j])
                    {
                        arr[i, j - 1] *= 2;
                        arr[i, j] = 0;
                        score += arr[i, j - 1];
                        j = 0;
                    }

                }
            }
        }
        private void MoveRight()
        {
            for (int i = 3; i >= 0; i--)
            {
                for (int j = 2; j >= 0; j--)
                {
                    if (arr[i, j] != 0 && arr[i, j + 1] == 0)
                    {
                        arr[i, j + 1] = arr[i, j];
                        arr[i, j] = 0;
                        j = 3;
                    }
                    else if (arr[i, j] != 0 && arr[i, j + 1] == arr[i, j])
                    {
                        arr[i, j + 1] *= 2;
                        arr[i, j] = 0;
                        score += arr[i, j + 1];
                        j = 3;
                    }

                }
            }


        }
        private void Moving(KeyEventArgs e)
        {
            switch (e.Key.ToString())
            {
                case "Up": MoveUp(); break;
                case "Down": MoveDown(); break;
                case "Left": MoveLeft(); break;
                case "Right": MoveRight(); break;
            }
        }
    }
}
