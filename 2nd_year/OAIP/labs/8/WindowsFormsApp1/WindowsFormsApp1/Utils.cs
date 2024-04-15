using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    internal class Utils
    {
    }

    internal class ShapeContainer
    {
        public static List<Figure> figureList;
        public ShapeContainer()
        {
            figureList = new List<Figure>();
        }
        public static void AddFigure(Figure figure)
        {
            figureList.Add(figure);
        }
    }

    internal class Init
    {
        public static Pen pen;
        public static Bitmap bitmap;
        public static PictureBox pictureBox;
    }
}
