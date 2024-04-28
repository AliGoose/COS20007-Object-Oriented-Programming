using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using SplashKitSDK;

namespace ShapeDrawer
{
    public class Program
    {
        private enum ShapeKind
        {
            Rectangle,
            Circle,
            Line
        }

        public static void Main()
        {
            Shape.RegisterShape("Rectangle", typeof(MyRectangle));
            Shape.RegisterShape("Circle", typeof(MyCircle));
            Shape.RegisterShape("Line", typeof(MyLine));

            ShapeKind kindToAdd = ShapeKind.Circle;
            Drawing myDrawing = new Drawing();

            new Window("ShapeDrawer", 800, 600);
            do
            {
                SplashKit.ProcessEvents();
                //SplashKit.ClearScreen();
                SplashKit.RefreshScreen(60);
                myDrawing.Draw();

                if (SplashKit.KeyTyped(KeyCode.SKey))
                {
                    myDrawing.Save("TestDrawing.txt");
                }

                if (SplashKit.KeyTyped(KeyCode.OKey))
                {
                    try
                    {
                        myDrawing.Load("C:/Users/aligo/source/repos/ShapeDrawer/bin/Debug/netcoreapp5.0/TestDrawing.txt");
                    } catch (Exception e)
                    {
                        Console.Error.WriteLine("Error loading file: {0}", e.Message);
                    }
                    
                }

                if (SplashKit.KeyTyped(KeyCode.RKey))
                {
                    kindToAdd = ShapeKind.Rectangle;
                }

                if (SplashKit.KeyTyped(KeyCode.CKey))
                {
                    kindToAdd = ShapeKind.Circle;
                }

                if (SplashKit.KeyTyped(KeyCode.LKey))
                {
                    kindToAdd = ShapeKind.Line;
                }

                if (SplashKit.MouseDown(MouseButton.LeftButton))
                {
                    Shape newShape;

                    if (kindToAdd == ShapeKind.Circle)
                    {
                        MyCircle newCircle = new MyCircle();
                        newShape = newCircle;
                        while (SplashKit.MouseDown(MouseButton.LeftButton))
                        {
                            SplashKit.ProcessEvents();
                        }
                        
                    }
                    else if (kindToAdd == ShapeKind.Rectangle)
                    {
                        MyRectangle newRect = new MyRectangle();
                        newShape = newRect;
                        while (SplashKit.MouseDown(MouseButton.LeftButton))
                        {
                            SplashKit.ProcessEvents();
                        }
                    }
                    else
                    {
                        MyLine newLine = new MyLine();
                        newLine.EndX = SplashKit.MouseX();
                        newLine.EndY = SplashKit.MouseY();

                        while (SplashKit.MouseDown(MouseButton.LeftButton))
                        {
                            SplashKit.ProcessEvents();
                        }

                        newShape = newLine;
                    }

                    newShape.X = SplashKit.MouseX();
                    newShape.Y = SplashKit.MouseY();
                    myDrawing.AddShape(newShape);
                }

                if (SplashKit.KeyTyped(KeyCode.SpaceKey))
                {
                    myDrawing.Background = SplashKit.RandomRGBColor(255);
                }

                if (SplashKit.MouseClicked(MouseButton.RightButton))
                {
                    myDrawing.SelectShapesAt(SplashKit.MousePosition());
                }

                if (SplashKit.KeyTyped(KeyCode.BackspaceKey))
                {
                    myDrawing.DeleteSelectedShapes();
                }




            } while (!SplashKit.WindowCloseRequested("ShapeDrawer"));
        }
    }
}