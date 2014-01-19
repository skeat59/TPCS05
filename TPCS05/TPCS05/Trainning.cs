using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TPCS05
{
    static class Trainning
    {
        public static void Train()
        {
            Pony my_first_pony = new Pony("Barthelemy", 42, PonyColor.Applejack, 42) ;
            my_first_pony.Name = "Barthelemy";
            my_first_pony.Color = PonyColor.Applejack;
        }
    }
}