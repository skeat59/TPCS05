namespace TPCS05
{
    public class Arena
    {
        public Pony Left;
        public Pony Right;
        int joueur = 0;
        public Arena(ref Pony left, ref Pony right)
        {
            this.Left =  left;
            this.Right =  right;
        }

        public void ChangeAttacker()
        {
            joueur = (joueur + 1) % 2;
        }

        public void AttackWith(int n)
        {
            if (joueur == 0)
            {
                Right.LoosePV(Right.GetAttack(n));
            }
            else
            {
                Left.LoosePV(Left.GetAttack(n));
            }
        }

        public bool IsFinished()
        {
            return (Left.IsAlive() || Right.IsAlive());
        }
    }
}