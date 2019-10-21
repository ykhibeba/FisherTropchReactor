using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixedCatalystReactor.Entity
{
    public class FixedBedComponentModel
    {
        public double[] AlkanK0 { get; set; }
        public double[] AlkenK0 { get; set; }
        public double[] AlkinK0 { get; set; }

        public double[] AlkanE { get; set; }
        public double[] AlkenE { get; set; }
        public double[] AlkinE { get; set; }

        public double T { get; set; }

        public readonly double R = 8.31;

        public double B { get; set; }
        public double A { get; set; }
        public double K4 { get; set; }
        public double Kp { get; set; }

        public double cCO0 { get; set; }
        public double cH20 { get; set; }

        public int Time { get; set; }

    }
}
