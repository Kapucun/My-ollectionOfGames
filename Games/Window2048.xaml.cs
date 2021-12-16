using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Games
{
    /// <summary>
    /// Interaction logic for Window2048.xaml
    /// </summary>
    public partial class Window2048 : Window
    {
        public Window2048()
        {
            InitializeComponent();
            game2048.start2048();
            AddDictionary();
            ShowField2048();

        }

        Dictionary<int, SolidColorBrush> colores= new Dictionary<int, SolidColorBrush>(11);
       // Color color = new Color();
        private void AddDictionary()
        {
            SolidColorBrush color = new SolidColorBrush();
            color = Brushes.Silver;
            colores.Add(0, color);
            color = Brushes.AntiqueWhite;
            colores.Add(2, color);
            color = Brushes.LightGoldenrodYellow;
            colores.Add(4, color);
            color = Brushes.Wheat;
            colores.Add(8, color);
            color = Brushes.Orange;
            colores.Add(16, color);
            color = Brushes.MistyRose;
            colores.Add(32, color);
            color = Brushes.Moccasin;
            colores.Add(64, color);
            color = Brushes.Khaki;
            colores.Add(128, color);
            color = Brushes.DarkKhaki;
            colores.Add(256, color);
            color = Brushes.Yellow;
            colores.Add(512, color);
            color = Brushes.Aqua;
            colores.Add(1024, color);
            color = Brushes.Red;
            colores.Add(2048, color);
        }

        
        Clas2048 game2048 = new Clas2048();

        private void ShowField2048()
        {
            int i = 0;
            int j = 0;
            foreach (UIElement it in field2048.Children)
            {
                if (it is Rectangle)
                {
                    (it as Rectangle).Fill = colores[game2048.GetArrInt(j)];
                    j++;
                }

                if (it is TextBlock)
                {
                    (it as TextBlock).Text = game2048.GetArrString(i);
                    i++;
                }

            }
            
        }
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (game2048.RUN2048(e))
                ShowField2048();
            else
            { this.Close();}
            Score.Text = game2048.Score.ToString();

        }
    }
}
