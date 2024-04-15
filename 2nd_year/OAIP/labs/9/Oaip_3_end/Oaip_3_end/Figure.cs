using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace oaip_9
{
    abstract internal class Figure
    {
        public int x, y, w, h;
        public string name;

        public static void DeleteF(Figure figure, bool flag = true)
        {
            Graphics g = Graphics.FromImage(Init.bitmap);
            if (flag)
            {
                ShapeContainer.figureList.Remove(figure);
                g.Clear(Color.White);
                foreach (Figure f in ShapeContainer.figureList)
                {
                    f.Draw();
                }
            }
            else
            {
                g.Clear(Color.White);
                foreach (Figure f in ShapeContainer.figureList)
                {
                    f.Draw();
                }
            }
            Init.pictureBox.Image = Init.bitmap;
        }


        public virtual void MoveTo(int x, int y)
        {
            if (!((this.x + x < 0 && this.y + y < 0) || (this.y + y < 0) || (this.x + x > Init.pictureBox.Width && this.y + y < 0) ||
                (this.x + w + x > Init.pictureBox.Width) || (this.x + x > Init.pictureBox.Width && this.y + y > Init.pictureBox.Height) ||
                (this.y + h + y > Init.pictureBox.Height) || (this.x + x < 0 && this.y + y > Init.pictureBox.Height) || (this.x + x < 0)))
            {
                this.x += x;
                this.y += y;
                DeleteF(this, false);
                Draw();
            }
            else
            {
                MessageBox.Show("Вышли за экран");
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
                p[i].X = (int)(x + Math.Round(Math.Cos(z) * w / 2));
                p[i].Y = (int)(y - Math.Round(Math.Sin(z) * h / 2));
            }
            g.DrawPolygon(Init.pen, p);
            Init.pictureBox.Image = Init.bitmap;
        }
    }

    internal class _Polygon : Figure
    {
        List<Point> points;

        public _Polygon(List<Point> points)
        {
            this.points = new List<Point>(points);
        }

        public override void Draw()
        {
            if (points.Count < 3)
            {
                throw new InvalidOperationException("A polygon must have at least three points.");
            }

            Graphics g = Graphics.FromImage(Init.bitmap);
            g.DrawPolygon(Init.pen, points.ToArray());
            Init.pictureBox.Image = Init.bitmap;
        }

        public override void MoveTo(int newX, int newY)
        {
            for (int i = 0; i < points.Count; i++)
            {
                points[i] = new Point(points[i].X + newX, points[i].Y + newY);
            }

            this.x += newX;
            this.y += newY;

            DeleteF(this, false);
            Draw();
        }
    }


    internal class Triangle : Polygon
    {
        public Triangle(int x, int y, int w) : base(x, y, w, 3) { }
    }

    internal class House : Figure
    {
        Rectangle baseHouse;
        _Polygon roof;
        Circle window;

        public House(string name, int x, int y, int w, int h)
        {
            this.name = name;
            this.x = x;
            this.y = y;
            this.w = w;
            this.h = h;

            baseHouse = new Rectangle(x, y, w, h);
            List<Point> roofPoints = new List<Point>
        {
            new Point(x, y), // Левая нижняя точка крыши
            new Point(x + w, y), // Правая нижняя точка крыши
            new Point(x + w / 2, y - h / 3) // Верхняя точка крыши
        };
            roof = new _Polygon(roofPoints);
            window = new Circle(x + w / 2 - w / 10, y + h / 2, w / 5);
        }

        public override void Draw()
        {
            baseHouse.Draw();
            roof.Draw();
            window.Draw();
        }

        public override void MoveTo(int x, int y)
        {
            int deltaX = x - this.x;
            int deltaY = y - this.y;

            this.x += deltaX;
            this.y += deltaY;

            baseHouse.MoveTo(x, y);
            roof.MoveTo(x, y);
            window.MoveTo(x, y);

            Draw();
        }

    }
}
