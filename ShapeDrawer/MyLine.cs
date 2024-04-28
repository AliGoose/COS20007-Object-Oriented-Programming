using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using SplashKitSDK;

namespace ShapeDrawer
{
    public class MyLine : Shape
    {
        private float _endX;
        private float _endY;

        public float EndX
        {
            get
            {
                return _endX;
            }
            set
            {
                _endX = value;
            }
        }
        public float EndY
        {
            get
            {
                return _endY;
            }
            set
            {
                _endY = value;
            }
        }

        public MyLine(Color color, float startX, float startY, float endX, float endY)
        {
            _Color = color;
            X = startX;
            Y = startY;
            _endX = endX;
            _endY = endY;
        }
        public MyLine() : this(Color.Red, 0, 0, 0, 0)
        {
            
        }

        public override void Draw()
        {
            SplashKit.DrawLine(_Color, X, Y, _endX, _endY);
            if (Selected)
            {
                DrawOutline();
                SplashKit.DrawLine(_Color, X, Y, _endX, _endY);
            }
        }

        public override void DrawOutline()
        {
            SplashKit.FillCircle(Color.Black, X, Y,  5);
            SplashKit.FillCircle(Color.Black, _endX, _endY, 5);
        }

        public override bool IsAt(Point2D pt)
        {
            bool i = false;
            if (SplashKit.PointLineDistance(pt, SplashKit.LineFrom(X, Y, _endX, _endY)) <= 5)
            {
                i = true;
            }
            return i;
        }

        public override void SaveTo(StreamWriter writer)
        {
            //writer.WriteLine("Line");
            base.SaveTo(writer);
            writer.WriteLine(EndX);
            writer.WriteLine(EndY);
        }

        public override void LoadFrom(StreamReader reader)
        {
            base.LoadFrom(reader);
            EndX = reader.ReadInteger();
            EndY = reader.ReadInteger();
        }
    }
}
