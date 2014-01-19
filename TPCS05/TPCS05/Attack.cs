using System;

namespace TPCS05
{
    public class Attack
    {
        public string Name;
        private int min_damage;
        private int max_damage;
        private int critical_rate;
        private int critical_bonus_rate;
        private int critical_fail_rate;
        Random rand = new Random();

        public Attack(string name, int min_damage, int max_damage, int critical_rate, int critical_bonus_rate, int critical_fail_rate)
        {
            this.Name = name;
            this.min_damage = min_damage;
            this.max_damage = max_damage;
            this.critical_rate = critical_rate;
            this.critical_bonus_rate = critical_bonus_rate;
            this.critical_fail_rate = critical_fail_rate;
        }

        public int Damage()
        {
            int nimporte = rand.Next(100);
            if (nimporte < critical_rate)
                return min_damage;
            int damage = rand.Next(min_damage, max_damage);
            if (nimporte > critical_rate)
                return damage + (damage * critical_bonus_rate / 100);
            return damage;
        }
    }
}