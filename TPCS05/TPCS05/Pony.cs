using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace TPCS05
{
    public enum PonyColor
    {
        Applejack,
        Rarity,
        PinkiePie,
        Fluttershy,
        TwilightSparkle,
        RainbowDash
    };
    public class Pony
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private int pv;
        public int Pv
        {
            get { return pv; }
            set { pv = value; }
        }

        private int pv_max;
        public int PvMax
        {
            get { return pv_max; }
            set { pv_max = value; }
        }

        private PonyColor color;
        public PonyColor Color
        {
            get { return color; }
            set { color = value; }
        }

        private int age;
        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        private Attack[] attack_tab = new Attack[2];

        public Pony(string name, int pv_max, PonyColor color, int age)
        {
            this.name = name;
            this.pv = pv_max;
            this.pv_max = pv_max;
            this.color = color;
            this.age = age;
        }

        public void SetAttack(Attack newAttack, int n)
        {
            n = n % 2;
            attack_tab[n] = newAttack;
        }

        public Attack GetAttack(int n)
        {
            n = n % 2;
            return attack_tab[n];
        }

        public bool IsAlive()
        {
            return (pv < 0);
        }

        public void LoosePV(Attack AttaqueQuiTue)
        {
            pv = pv - AttaqueQuiTue.Damage();
        }

        public string Talk()
        {
            return "Hello!";
        }
    }
}
