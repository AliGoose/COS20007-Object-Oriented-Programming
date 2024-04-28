using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using SplashKitSDK;

namespace ShapeDrawer
{
    public class MyRectangle : Shape
    {
        private int _height;
        private int _width;

        public int Height
        {
            get
            {
                return _height;
            }
            set
            {
                _height = value;
            }
        }
        public int Width
        {
            get
            {
                return _width;
            }
            set
            {
                _width = value;
            }
        }

        public MyRectangle(Color clr, float x, float y, int width, int height): base(clr)
        {
            X = x;
            Y = y;
            _width = width;
            _height = height;
        }
        public MyRectangle () : this(Color.Green, 0, 0, 100, 100)
        {

        }

        public override void Draw()
        {
            SplashKit.FillRectangle(_Color, X, Y, _width, _height);
            if (Selected)
            {
                DrawOutline();
                SplashKit.FillRectangle(_Color, X, Y, _width, _height);
            }
        }

        public override void DrawOutline()
        {
            SplashKit.FillRectangle(Color.Black, X - 2, Y - 2, _width + 4, _height + 4);
        }

        public override bool IsAt(Point2D pt)
        {
            bool i = false;
            if (pt.X >= X && pt.X <= X + Width && pt.Y >= Y && pt.Y <= Y + Height)
            {
                i = true;
            }
            return i;
        }

        public override void SaveTo(StreamWriter writer)
        {
            //writer.WriteLine("Rectangle");
            base.SaveTo(writer);
            writer.WriteLine(Width);
            writer.WriteLine(Height);
        }

        public override void LoadFrom(StreamReader reader)
        {
            base.LoadFrom(reader);
            Width = reader.ReadInteger();
            Height = reader.ReadInteger();
        }
    }
}
