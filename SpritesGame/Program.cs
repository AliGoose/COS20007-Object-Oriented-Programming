using System;
using SplashKitSDK;

namespace SpritesGame
{
    public class Program
    {
        public static void Main()
        {
            Window w = new Window("Minotaur Animation", 928, 793);

            Game game = new Game();

            while (!w.CloseRequested)
            {
                w.Refresh(60);
                w.Clear(Color.White);
                game.Draw(w);
                game.Update();

                SplashKit.ProcessEvents();

                if (SplashKit.KeyTyped(KeyCode.SpaceKey) && !(game.Minotaur.Animation.Name == "attackright" || game.Minotaur.Animation.Name == "attackleft"))
                {
                    if (game.Minotaur.FacingRight == true)
                    {
                        game.Minotaur.Animation.Assign("attackright");
                    }
                    else
                    {
                        game.Minotaur.Animation.Assign("attackleft");
                    }
                }
                if (game.Minotaur.Animation.Name == "attackright" || game.Minotaur.Animation.Name == "attackleft")
                {
                    game.Minotaur.Attack(game.Zombies);
                }
                if (SplashKit.KeyDown(KeyCode.RightKey) && !(game.Minotaur.Animation.Name == "attackright" || game.Minotaur.Animation.Name == "attackleft"))
                {
                    game.Minotaur.Move(2, 0);
                    if ((game.Minotaur.Animation.EnteredFrame && game.Minotaur.Animation.Name != "walkright") || (game.Minotaur.Animation.Ended && game.Minotaur.Animation.Name == "walkright"))
                    {
                        game.Minotaur.Animation.Assign("walkright");
                    }
                }
                if (SplashKit.KeyDown(KeyCode.LeftKey) && !(game.Minotaur.Animation.Name == "attackright" || game.Minotaur.Animation.Name == "attackleft"))
                {
                    game.Minotaur.Move(-2, 0);
                    if (game.Minotaur.Animation.EnteredFrame && game.Minotaur.Animation.Name != "walkleft" || (game.Minotaur.Animation.Ended && game.Minotaur.Animation.Name == "walkleft"))
                    {

                        game.Minotaur.Animation.Assign("walkleft");
                    }
                }
                if (game.Minotaur.Animation.Ended)
                {
                    if (game.Minotaur.FacingRight == true)
                    {
                        game.Minotaur.Animation.Assign("idleright");
                    }
                    else
                    {
                        game.Minotaur.Animation.Assign("idleleft");
                    }
                }
            }
        }
    }
}

