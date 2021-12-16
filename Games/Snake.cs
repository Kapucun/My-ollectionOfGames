using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Controls;

namespace Games
{
    class Snake
    {
        public int x, y;
        public Rectangle rec = new Rectangle();
       
        public Snake(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public void setsnakeposition()
        {
            rec.Width = rec.Height = 10;
            rec.Fill = Brushes.Red;
            Canvas.SetLeft(rec, x);
            Canvas.SetTop(rec, y);
        }
    }
}
