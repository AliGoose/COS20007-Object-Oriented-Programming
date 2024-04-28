using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace SpritesGame
{
    public class Zombie : Character
    {
        public Zombie(bool facingRight) : base(-50, 685, facingRight)
        {
            SplashKit.SetResourcesPath(@"C:\Users\aligo\source\repos\SpritesGame\Resources\");
            _bmp = SplashKit.LoadBitmap("ZombieBmp", @"ZombieUpdated.png");
            _bmp.SetCellDetails(48, 48, 13, 6, 78);
            _script = SplashKit.LoadAnimationScript("ZombieScript", @"ZombieAnimations.txt");
            _animation = _script.CreateAnimation("idle");
            _opt = SplashKit.OptionWithAnimation(_animation);
        }

        public override void Update()
        {
            _animation.Update();
            _position.X += 0.2 * (_destination.X - _position.X);
            if (_position.X > 950)
            {
                _position.X = -50;
                _destination.X = -50;
            }

            if (Alive == true)
            {
                Move(1, 0);
                if ((Animation.EnteredFrame && Animation.Name != "walk") || (Animation.Ended && Animation.Name == "walk"))
                {
                    Animation.Assign("walk");
                }
            }
        }
    }
}
