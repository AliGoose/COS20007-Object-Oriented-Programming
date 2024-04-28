using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using SplashKitSDK;

namespace ShapeDrawer
{
    public abstract class Shape
    {
        private static Dictionary<string, Type> _ShapeClassRegistery = new Dictionary<string, Type>();

        public static void RegisterShape(string name, Type t)
        {
            _ShapeClassRegistery[name] = t;
        }

        public static Shape CreateShape(string name)
        {
            return (Shape)Activator.CreateInstance(_ShapeClassRegistery[name]);
        }

        public static string FindKey(Type shape)
        {
            foreach (string s in _ShapeClassRegistery.Keys)
            {
                if(shape == _ShapeClassRegistery[s])
                {
                    return s;
                }
            }
            return null;
            
        }

        private Color _color;
        private float _x;
        private float _y;
        private bool _selected;

        public Color _Color
        {
            get
            {
                return _color;
            }
            set
            {
                _color = value;
            }
        }
        public float X
        {
            get
            {
                return _x;
            }
            set
            {
                _x = value;
            }
        }
        public float Y
        {
            get
            {
                return _y;
            }
            set
            {
                _y = value;
            }
        }
        public bool Selected
        {
            get
            {
                return _selected;
            }
            set
            {
                _selected = value;
            }
        }

        public Shape(Color color)
        {
            _color = color;
        }

        public Shape() : this(Color.Yellow)
        {

        }

        public abstract void Draw();

        public abstract bool IsAt(Point2D pt);

        public abstract void DrawOutline();

        public virtual void SaveTo(StreamWriter writer)
        {
            writer.WriteLine(FindKey(GetType()));
            writer.WriteColor(_Color);
            writer.WriteLine(X);
            writer.WriteLine(Y);
        }

        public virtual void LoadFrom(StreamReader reader)
        {
            _Color = reader.ReadColor();
            X = reader.ReadInteger();
            Y = reader.ReadInteger();
        }
    }
}
