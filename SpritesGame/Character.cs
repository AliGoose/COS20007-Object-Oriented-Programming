using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace SpritesGame
{
    public abstract class Character
    {
        protected Point2D _position;
        protected Point2D _destination;
        protected bool _facingRight;
        protected bool _alive;
        protected Bitmap _bmp;
        protected AnimationScript _script;
        protected Animation _animation;
        protected DrawingOptions _opt;

        public Bitmap BMP
        {
            get
            {
                return _bmp;
            }
        }
        public Animation Animation
        {
            get
            {
                return _animation;
            }
        }
        public Point2D Position
        {
            get
            {
                return _position;
            }
        }
        public bool FacingRight
        {
            get
            {
                return _facingRight;
            }
        }
        public bool Alive
        {
            get
            {
                return _alive;
            }
            set
            {
                _alive = value;
            }
        }

        public Character(double x, double y, bool facingRight)
        {
            _position.X = x;
            _position.Y = y;
            _destination.X = x;
            _destination.Y = y;
            _facingRight = facingRight;
            _alive = true;
        }

        public abstract void Update();

        public void Move(int x, int y)
        {
            if (x < 0)
            {
                _facingRight = false;
            }
            else if (x > 0)
            {
                _facingRight = true;
            }
            _destination.X += x;
            _destination.Y += y;
        }

        public void Draw(Window w)
        {
            w.DrawBitmap(_bmp, _position.X, _position.Y, _opt);
        }
    }
}
