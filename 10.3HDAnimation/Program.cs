using System;
using SplashKitSDK;


namespace _10._3HDAnimation
{
    public class Program
    {
        public static void Main()
        {
            Window w = new Window("Minotaur Animation", 640, 640);

            SplashKit.SetResourcesPath(@"C:\Users\aligo\source\repos\10.3HDAnimation\Resources\");

            Bitmap minotaurBmp = SplashKit.LoadBitmap("MinotaurBmp", "Minotaur - Sprite Sheet.png");
            minotaurBmp.SetCellDetails(96, 96, 11, 20, 220);

            AnimationScript minotaurScript = SplashKit.LoadAnimationScript("MinotaurScript", @"MinotaurAnimation.txt");

            Animation test = minotaurScript.CreateAnimation("WalkRight");

            DrawingOptions opt = SplashKit.OptionWithAnimation(test);

            Minotaur minotaur = new Minotaur();
    

        while (!w.CloseRequested)
            {
                w.Clear(Color.LightSkyBlue);
                w.FillRectangle(Color.Green, 0, 320, 640, 320);
                w.DrawBitmap(minotaurBmp, minotaur.Position.X, minotaur.Position.Y, opt);

                w.Refresh(60);

                test.Update();
                minotaur.Update();

                SplashKit.ProcessEvents();

                if (SplashKit.KeyTyped(KeyCode.RightKey))
                {
                    test.Assign("WalkRight");
                    minotaur.Move(5, 0);
                }
                else if (SplashKit.KeyTyped(KeyCode.LeftKey))
                {
                    test.Assign("WalkLeft");
                    minotaur.Move(-5, 0);
                }
                else if (SplashKit.KeyTyped(KeyCode.SpaceKey))
                {
                    if (minotaur.FacingRight == true)
                    {
                        test.Assign("AttackRight");
                    }
                    else
                    {
                        test.Assign("AttackLeft");
                    }
                }
            }
        }
    }
}
