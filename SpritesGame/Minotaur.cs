using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace SpritesGame
{
    public class Minotaur : Character
    {
        public Minotaur() : base(320, 670, true)
        {
            SplashKit.SetResourcesPath(@"C:\Users\aligo\source\repos\SpritesGame\Resources\");
            _bmp = SplashKit.LoadBitmap("MinotaurBmp", @"Minotaur - Sprite Sheet.png");
            _bmp.SetCellDetails(96, 96, 11, 20, 266);
            _script = SplashKit.LoadAnimationScript("MinotaurScript", @"MinotaurAnimations.txt");
            _animation = _script.CreateAnimation("idleright");
            _opt = SplashKit.OptionWithAnimation(_animation);
        }

        public override void Update()
        {
            _animation.Update();
            _position.X += 0.2 * (_destination.X - _position.X);
        }

        public void Attack(List<Zombie> targets)
        {
            for (int i = 0; i < targets.Count; i++)
            {
                if (SplashKit.BitmapCollision(targets[i].BMP, targets[i].Position.X, targets[i].Position.Y, _bmp, _position.X, _position.Y))
                {
                    targets[i].Alive = false;
                }
            }
        }
    }
}