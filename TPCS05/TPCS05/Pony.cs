using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace TPCS05
{
    public class Pony
    {
        private string name;
        public string Name
        {
            get { return name;  }
            set { name = value;}
        }
        
        private int pv;
        public int Pv
        {
            get { return pv;  }
            set { pv = value; }
        }

        private int pv_max;
        public int Pv_max
        {
            get { return pv_max; }
            set { pv_max = value; }
        }

        public enum PonyColor { Applejack, Rarity, PinkiePie, Fluttershy, TwilightSparkle, RainBowDash };
        private PonyColor color;
        public PonyColor color
        {
            get { return color; }
            set { color = value; }
        }
        static int age;
    }
}
