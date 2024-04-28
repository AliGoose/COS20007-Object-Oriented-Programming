using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using SplashKitSDK;

namespace ShapeDrawer
{
    public class Drawing
    {
        private readonly List<Shape> _shapes;
        private Color _background;

        public Color Background
        {
            get
            {
                return _background;
            }
            set
            {
                _background = value;
            }
        }
        public int ShapeCount
        {
            get { return _shapes.Count; }
        }
        public List<Shape> SelectedShapes
        {
            get
            {
                List<Shape> Result = new List<Shape>();
                foreach (Shape s in _shapes)
                {
                    if (s.Selected  == true)
                    {
                        Result.Add(s);
                    }
                }
                return Result;
            }
        }

        public Drawing(Color background)
        {
            _shapes = new List<Shape>();
            _background = background;
        }
        public Drawing () : this(Color.White) //default constructor
        {

        }

        public void AddShape(Shape a)
        {
            _shapes.Add(a);
        }

        public void Draw()
        {
            SplashKit.ClearScreen(_background);
            foreach (Shape s in _shapes)
            {
                s.Draw();
            }
        }

        public void SelectShapesAt(Point2D pt)
        {
            foreach (Shape s in _shapes)
            {
                if (s.IsAt(pt))
                {
                    s.Selected = !s.Selected;
                }
            }
        }

        public void DeleteSelectedShapes()
        {
            foreach (Shape a in SelectedShapes)
            {
                _shapes.Remove(a);
            }
            
        }

        public void Save(string filename)
        {
            StreamWriter writer;

            writer = new StreamWriter(filename);
            writer.WriteColor(Background);
            writer.WriteLine(ShapeCount);

            foreach (Shape s in _shapes)
            {
                s.SaveTo(writer);
            }

            writer.Close();
        }

        public void Load(string filename)
        {
            StreamReader reader = new StreamReader(filename);
            try
            {
                int count;
                Shape s;
                string kind;

                Background = reader.ReadColor();
                count = reader.ReadInteger();
                _shapes.Clear();

                for (int i = 0; i < count; i++)
                {
                    kind = reader.ReadLine();
                    s = Shape.CreateShape(kind);

                    s.LoadFrom(reader);
                    AddShape(s);
                }
            }
            finally
            {
                reader.Close();
            }
        }
    }
}
