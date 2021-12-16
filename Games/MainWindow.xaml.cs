using System.Windows;


namespace Games
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button2048_Click(object sender, RoutedEventArgs e)
        {
            Window2048 window2048 = new Window2048();
            window2048.Owner = this;
            window2048.Show();
        }
        private void ButtonSnake_Click(object sender, RoutedEventArgs e)
        {
            WindowSnake windowSnake = new WindowSnake();
            windowSnake.Owner = this;
            windowSnake.Show();

        }
        private void ButtonTetris_Click(object sender, RoutedEventArgs e)
        {
            WindowTetris windowTetris = new WindowTetris();
            windowTetris.Owner = this;
            windowTetris.Show();
        }
    }
}
