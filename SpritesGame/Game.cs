using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace SpritesGame
{
    public class Game
    {
        private Minotaur _minotaur;
        private List<Zombie> _zombies;
        private List<Zombie> _deadZombies;


        public Minotaur Minotaur
        {
            get
            {
                return _minotaur;
            }
        }
        public List<Zombie> Zombies
        {
            get
            {
                return _zombies;
            }
        }

        public Game()
        {
            _minotaur = new Minotaur();
            _zombies = new List<Zombie>();
            _deadZombies = new List<Zombie>();
            CreateZombie(true);
        }

        public void CreateZombie(bool facingRight)
        {
            _zombies.Add(new Zombie(facingRight));
        }

        public void Update()
        {
            _minotaur.Update();
            foreach (Zombie z in _zombies)
            {
                z.Update();
                if (z.Alive == false && z.Animation.Name != "die")
                {
                    z.Animation.Assign("die");
                    _deadZombies.Add(z);
                }
            }
            foreach (Zombie z in _deadZombies)
            {
                if (z.Animation.Ended && z.Animation.Name == "die")
                {
                    _zombies.Remove(z);
                    if (_zombies.Count < 1)
                    {
                        CreateZombie(true);
                    }
                }
                
            }
            
        }

        public void Draw(Window w)
        {
            w.DrawBitmap(SplashKit.LoadBitmap("Layer11", @"Background\Layer_0011_0.png"), 0, 0);
            w.DrawBitmap(SplashKit.LoadBitmap("Layer10", @"Background\Layer_0010_1.png"), 0, 0);
            w.DrawBitmap(SplashKit.LoadBitmap("Layer9", @"Background\Layer_0009_2.png"), 0, 0);
            w.DrawBitmap(SplashKit.LoadBitmap("Layer8", @"Background\Layer_0008_3.png"), 0, 0);
            w.DrawBitmap(SplashKit.LoadBitmap("Layer7", @"Background\Layer_0007_Lights.png"), 0, 0);
            w.DrawBitmap(SplashKit.LoadBitmap("Layer6", @"Background\Layer_0006_4.png"), 0, 0);
            w.DrawBitmap(SplashKit.LoadBitmap("Layer5", @"Background\Layer_0005_5.png"), 0, 0);
            w.DrawBitmap(SplashKit.LoadBitmap("Layer4", @"Background\Layer_0004_Lights.png"), 0, 0);
            w.DrawBitmap(SplashKit.LoadBitmap("Layer3", @"Background\Layer_0003_6.png"), 0, 0);
            w.DrawBitmap(SplashKit.LoadBitmap("Layer2", @"Background\Layer_0002_7.png"), 0, 0);
            w.DrawBitmap(SplashKit.LoadBitmap("Layer1", @"Background\Layer_0001_8.png"), 0, 0);
            _minotaur.Draw(w);
            foreach (Zombie z in _zombies)
            {
                z.Draw(w);
            }
            w.DrawBitmap(SplashKit.LoadBitmap("Layer0", @"Background\Layer_0000_9.png"), 0, 0);
        }
    }
}
