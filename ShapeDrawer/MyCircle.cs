using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using SplashKitSDK;

namespace ShapeDrawer
{
    public class MyCircle : Shape
    {
        private int _radius;

        public int Radius
        {
            get
            {
                return _radius;
            }
            set
            {
                _radius = value;
            }
        }

        public MyCircle(Color color, int radius)
        {
            _radius = radius;
            _Color = color;
        }
        public MyCircle() : this(Color.Blue, 50)
        {

        }

        public override void Draw()
        {
            SplashKit.FillCircle(_Color, X, Y, _radius);
            if (Selected)
            {
                DrawOutline();
                SplashKit.FillCircle(_Color, X, Y, _radius);
            }
        }

        public override void DrawOutline()
        {
            SplashKit.FillCircle(Color.Black, X, Y, _radius + 2);
        }

        public override bool IsAt(Point2D pt)
        {
            bool i = false;
            if (SplashKit.LineLength(SplashKit.LineFrom(pt.X, pt.Y, X, Y)) <= _radius)
            {
                i = true;
            }
            return i;
        }

        public override void SaveTo(StreamWriter writer)
        {
            //writer.WriteLine("Circle");
            base.SaveTo(writer);
            writer.WriteLine(Radius);
        }

        public override void LoadFrom(StreamReader reader)
        {
            base.LoadFrom(reader);
            Radius = reader.ReadInteger();
        }
    }
}
