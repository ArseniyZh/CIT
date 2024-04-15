using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApp1
{
    abstract internal class Figure
    {
        public int x, y, w, h;

        public static void DeleteF(Figure figure, bool flag = true, int ind = 0)
        {
            if (flag == true)
            {
                Graphics g = Graphics.FromImage(Init.bitmap);
                ShapeContainer.figureList.Remove(figure);
                g.Clear(Color.White);
                Init.pictureBox.Image = Init.bitmap;
                foreach (Figure f in ShapeContainer.figureList)
                {
                    f.Draw();
                }
            }
            else
            {
                Graphics g = Graphics.FromImage(Init.bitmap);
                ShapeContainer.figureList.Remove(figure);
                g.Clear(Color.White);
                Init.pictureBox.Image = Init.bitmap;
                foreach (Figure f in ShapeContainer.figureList)
                {
                    f.Draw();
                }
                ShapeContainer.figureList.Insert(ind, figure);
            }
        }

        public virtual void MoveTo(int x, int y, int ind)
        {
            if (!((this.x + x < 0 && this.y + y < 0) || (this.y + y < 0) || (this.x + x > Init.pictureBox.Width && this.y + y < 0) ||
                (this.x + w + x > Init.pictureBox.Width) || (this.x + x > Init.pictureBox.Width && this.y + y > Init.pictureBox.Height) ||
                (this.y + h + y > Init.pictureBox.Height) || (this.x + x < 0 && this.y + y > Init.pictureBox.Height) || (this.x + x < 0)))
            {
                this.x += x;
                this.y += y;
                DeleteF(this, false, ind);
                Draw();
            }
        }

        abstract public void Draw();
    }

    internal class Ellipse : Figure
    {
        public Ellipse(int x, int y, int w, int h)
        {
            this.x = x;
            this.y = y;
            this.w = w;
            this.h = h;
        }
        public Ellipse()
        {
            x = 0;
            y = 0;
            w = 0;
            h = 0;
        }
        public override void Draw()
        {
            Graphics g = Graphics.FromImage(Init.bitmap);
            g.DrawEllipse(Init.pen, x, y, w, h);
            Init.pictureBox.Image = Init.bitmap;
        }
    }

    internal class Circle : Ellipse
    {
        public Circle(int x, int y, int w) : base(x, y, w, w) { }
    }

    internal class Rectangle : Figure
    {
        public Rectangle(int x, int y, int w, int h)
        {
            this.x = x;
            this.y = y;
            this.w = w;
            this.h = h;
        }
        public Rectangle()
        {
            x = 0;
            y = 0;
            w = 0;
            h = 0;
        }
        public override void Draw()
        {
            Graphics g = Graphics.FromImage(Init.bitmap);
            g.DrawRectangle(Init.pen, x, y, w, h);
            Init.pictureBox.Image = Init.bitmap;
        }
    }

    internal class Square : Rectangle
    {
        public Square(int x, int y, int w) : base(x, y, w, w) { }
    }

    internal class Polygon : Figure
    {
        int n; // Количество сторон

        public Polygon(int x, int y, int w, int n)
        {
            this.x = x;
            this.y = y;
            this.w = w;
            this.n = n;
            h = w; // Для правильных многоугольников ширина и высота равны
        }

        public override void Draw()
        {
            double startAngle = n % 2 == 0 ? -90 : -90 + (180.0 / n); // Угол для горизонтальной нижней стороны
            Graphics g = Graphics.FromImage(Init.bitmap);
            Point[] p = new Point[n];
            for (int i = 0; i < n; i++)
            {
                double z = 2 * Math.PI / n * i + startAngle * (Math.PI / 180); // Переводим градусы в радианы
                p[i].X = (int)(x + w / 2 + Math.Round(Math.Cos(z) * w / 2));
                p[i].Y = (int)(y + h / 2 - Math.Round(Math.Sin(z) * h / 2));
            }
            g.DrawPolygon(Init.pen, p);
            Init.pictureBox.Image = Init.bitmap;
        }
    }


    internal class Triangle : Polygon
    {
        public Triangle(int x, int y, int w) : base(x, y, w, 3) { }
    }

    internal class House : Figure
    {
        Rectangle baseHouse;
        Polygon roof;
        Circle window;

        public House(int x, int y, int w, int h)
        {
            this.x = x;
            this.y = y;
            this.w = w;
            this.h = h;

            baseHouse = new Rectangle(x, y + h / 3, w, h * 2 / 3);
            roof = new Polygon(x, y - h * 2 / 5, w, 3);
            window = new Circle(x + w / 2 - w / 10, y + h / 2, w / 5);
        }

        public override void Draw()
        {
            baseHouse.Draw();
            roof.Draw();
            window.Draw();
        }
    }
}
