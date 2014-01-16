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
            // FIXME
            // Set two attacks for each pony
            // FIXME
            // Create an Arena with the two ponies
            // FIXME
            Application.Run(new Form1(arena));
#else
            Application.Run(new Form1());
#endif
        }
    }
}