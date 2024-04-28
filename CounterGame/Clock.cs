using System;
using System.Collections.Generic;
using System.Text;

namespace CounterGame
{
    public class Clock
    {
        private Counter _sec;
        private Counter _min;
        private Counter _hour;

        public Clock()
        {
            _sec = new Counter("Sec");
            _min = new Counter("Min");
            _hour = new Counter("Hour");
        }

        public void Reset()
        {
            _sec.Reset();
            _min.Reset();
            _hour.Reset();
        }

        public void Tick()
        {
            _sec.Increment();
            if (_sec.Ticks >= 60)
            {
                _sec.Reset();
                _min.Increment();

                if (_min.Ticks >= 60)
                {
                    _min.Reset();
                    _hour.Increment();

                    if (_hour.Ticks >= 24)
                    {
                        _sec.Reset();
                        _min.Reset();
                        _hour.Reset();
                    }
                }
            }
        }

        public string Print()
        {
            string display = _hour.Ticks.ToString("00") + ":" +  _min.Ticks.ToString("00") + ":" + _sec.Ticks.ToString("00");
            Console.WriteLine(display);
            return display;
        }
    }
}
