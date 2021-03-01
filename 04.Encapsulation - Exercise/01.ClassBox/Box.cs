using System;
using System.Collections.Generic;
using System.Text;

namespace _01.ClassBox
{
    public class Box
    {
        private double length;
        private double width;
        private double height;
        public Box(double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;
        }

        public double Length {
            get
            {
                return this.length; 
            }
            private set
            {
                if(value<=0)
                {
                    throw new ArgumentException("Length cannot be zero or negative.");
                }
                length = value;
            }
        }
        public double Width
        {
            get
            {
                return this.width;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Width cannot be zero or negative.");
                }
                width = value;
            }
        }
        public double Height
        {
            get
            {
                return this.height;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Height cannot be zero or negative.");
                }
                height = value;
            }
        }

        public string SurfaceArea(double length, double width, double height)
        {
            double sum = (2 * length * width) + (2 * length * height) + (2 * width * height);

            return $"Surface Area - {sum:f2}";
        }
        public string LateralSurfaceArea(double length, double width, double height)
        {
            double sum = (2 * length * height) + (2 * width * height);
            return $"Lateral Surface Area - {sum:f2}";
        }
        public string Volume(double length, double width, double height)
        {
            double sum = height * length * width;
            return $"Volume - {sum:f2}";
        }
    }
}
