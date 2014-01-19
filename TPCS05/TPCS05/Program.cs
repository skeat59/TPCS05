using System;
using System.Windows.Forms;

namespace TPCS05
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
           

#if PONY
            // Create the left and right ponies here
            Pony left = new Pony("LEFT", 42, PonyColor.Applejack, 42);
            Pony right = new Pony("RIGHT", 42, PonyColor.Rarity, 42);
            // Set two attacks for each pony
            left.SetAttack(new Attack("charge", 2, 42, 18, 24, 42),2);
            left.SetAttack(new Attack("chargebis", 2, 42, 18, 24, 42), 1);

            right.SetAttack(new Attack("charge", 2, 42, 18, 24, 42), 0);
           right.SetAttack(new Attack("chargebis", 2, 42, 18, 24, 42), 1);
            // Create an Arena with the two ponies
            Arena arena = new Arena(ref left, ref right);
            Application.Run(new Form1(arena));
#else
            Application.Run(new Form1());
#endif
        }
    }
}