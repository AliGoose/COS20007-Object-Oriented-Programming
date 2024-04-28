using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace _10._3HDAnimation
{
    public class Minotaur
    {
        private Point2D _postion;
        private Vector2D _vector;
        private bool _facingRight;

        public Point2D Position
        {
            get
            {
                return _postion;
            }
        }
        public bool FacingRight
        {
            get
            {
                return _facingRight;
            }
        }

        public Minotaur()
        {
            _postion.X = 320;
            _postion.Y = 280;
            _vector.X = 0;
            _vector.Y = 0;
        }

        public void Move(int x, int y)
        {
            if(x < 0)
            {
                _facingRight = false;
            }
            if(x > 0)
            {
                _facingRight = true;
            }
            _vector.X = x;
            _vector.Y = y;
        }

        public void Update()
        {
            _vector.X = 0.9 * _vector.X;
            _postion.X += _vector.X;
        }
    }
}
