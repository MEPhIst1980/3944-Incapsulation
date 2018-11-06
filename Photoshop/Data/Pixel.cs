using System;

namespace MyPhotoshop
{

    public struct Pixel
    {
        public static readonly double MinValue = 0;
        public static readonly double MaxValue = 1;

        public static double TrimChannel(double c)
        {
            if (c < MinValue)
            {
                return MinValue;
            }

            if (c > MaxValue)
            {
                return MaxValue;
            }
            return c;
        }

        private double CheckChannel(double c)
        {
            if (
                    (c >= MinValue)
                    &&
                    (c <= MaxValue)
                )
            {
                return c;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        private double _R;
        public double R {
            get
            {
                return _R;
            }
            private set
            {
                _R = CheckChannel(value);
            }
        }

        private double _G;
        public double G
        {
            get
            {
                return _G;
            }
            private set
            {
                _G = CheckChannel(value);
            }
        }

        private double _B;
        public double B
        {
            get
            {
                return _B;
            }
            private set
            {
                _B = CheckChannel(value);
            }
        }

        public Pixel(double r, double g, double b)
        {
            _R = _G = _B = 0;
            R = r;
            G = g;
            B = b;
        }

        public static Pixel operator * (Pixel a, double c)
        {
            return new Pixel(
                TrimChannel((double)a.R * c),
                TrimChannel((double)a.G * c),
                TrimChannel((double)a.B * c)
             );
        }

        public static Pixel operator *(double c, Pixel a)
        {
            return a * c;
        }
    }
}

