using System;
using SplashKitSDK;

namespace MyGame
{
    public class GameMain
    {
        public static void Main()
        {
            SplashKit.LoadSoundEffect("Splat", "C:/Users/aligo/source/repos/03-FruitKarate_Pt1/Resources/sounds/Splat.wav");
            SplashKit.LoadBitmap("Cherry", "C:/Users/aligo/source/repos/03-FruitKarate_Pt1/Resources/images/Cherry.png");
            SplashKit.LoadBitmap("Gooseberry", "C:/Users/aligo/source/repos/03-FruitKarate_Pt1/Resources/images/Gooseberry.png");
            SplashKit.LoadBitmap("Blueberry", "C:/Users/aligo/source/repos/03-FruitKarate_Pt1/Resources/images/Blueberry.png");
            SplashKit.LoadBitmap("Pomegranate", "C:/Users/aligo/source/repos/03-FruitKarate_Pt1/Resources/images/Pomegranate.png");
            SplashKit.LoadBitmap("Apricot", "C:/Users/aligo/source/repos/03-FruitKarate_Pt1/Resources/images/Apricot.png");
            SplashKit.LoadBitmap("Raspberry", "C:/Users/aligo/source/repos/03-FruitKarate_Pt1/Resources/images/Raspberry.png");
            SplashKit.LoadBitmap("Blackberry", "C:/Users/aligo/source/repos/03-FruitKarate_Pt1/Resources/images/Blackberry.png");
            SplashKit.LoadBitmap("Strawberry", "C:/Users/aligo/source/repos/03-FruitKarate_Pt1/Resources/images/Strawberry.png");
            SplashKit.LoadBitmap("Currant", "C:/Users/aligo/source/repos/03-FruitKarate_Pt1/Resources/images/Currant.png");
            SplashKit.LoadBitmap("Currant", "C:/Users/aligo/source/repos/03-FruitKarate_Pt1/Resources/images/Currant.png");

            FruitKarate _game = new FruitKarate();

            // open the game window
            new Window("Fruit Karate", 800, 600);

            // run the game loop
            while (!SplashKit.WindowCloseRequested("Fruit Karate"))
            {
                // fetch the next batch of UI interaction
                SplashKit.ProcessEvents();

                // check user input - space to launch fruit
                if (SplashKit.KeyTyped(KeyCode.SpaceKey))
                {
                    _game.LaunchFruit();
                }

                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    _game.PunchAt(SplashKit.MousePosition());
                }

                // update the postition and velocity of fruit
                _game.Update();

                // clear the screen to white
                SplashKit.ClearScreen(Color.White);

                // draw everything in the game
                _game.Draw();

                // draw onto the screen, limit to 60fps
                SplashKit.RefreshScreen(60);
            }
        }
    }
}