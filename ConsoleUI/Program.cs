using SlurryReactor;
using SlurryReactor.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //public const double Esh = 1181;
            //public const double Eft = 118.1;
            //public const double Ksh = 0.0000000001;
            //public const double Kft = 0.001;
            var constants = new ConstantInputModel
            {
                K1 = 8.8073 * Math.Pow(10, 6),
                K2 = 13.66 * Math.Pow(10, 6),
                K3 = 48.502 * Math.Pow(10, 6),
                K4 = 68.763 * Math.Pow(10, 6),
                K5 = 22.097 * Math.Pow(10, 6),
                K = 17.838 * Math.Pow(10, 6),
                B1 = -769.491,
                B2 = -424.565,
                B3 = 636.999,
                B4 = 746.846,
                B5 = 95.8691,
                B = 427.218,
                B0 = 1.0298 * Math.Pow(10, -3),
                Eft = 136.1,
                Esh = 1181,
                Kft = 0.001,
                Ksh = 0.000000001
            };
            var component = new FiniteComponentInputModel
            {
                Alfa = 0.4,
                Density = 600,
                EndTime = 100,
                G1 = 4,
                G2 = 28,
                Gama = 0,
                M = 50,
                T = 400
            };

            var reactor = new FiniteComponentReactor(constants, component);
            reactor.StartCalc();
        }
    }
}
