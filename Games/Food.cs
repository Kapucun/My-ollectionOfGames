using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Controls;

namespace Games
{
    class Food
    {
        public int x, y;
        public Ellipse ell = new Ellipse();
        public Food(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public void setfoodposition()
        {
            ell.Width = ell.Height = 10;
            ell.Fill = Brushes.Blue;
            Canvas.SetLeft(ell, x);
            Canvas.SetTop(ell, y);
        }
    }
}
