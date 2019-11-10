using Extreme.Mathematics;
using Extreme.Mathematics.Calculus.OrdinaryDifferentialEquations;

namespace FisherTropchTemperatureControl
{
    public static class TemperatureControlModule
    {
        public static double cp;
        public static double K;
        public static double K0;
        public static double F;
        public static double T0;
        public static double Txl;
        public static double delH;
        public static double Kp;
        public static double Tizod;
        public static double Wvh;
        public static double Tzad;
        public static double[] cCO;
        public static double[] cH2;

        private static int j = 0;

        public static double[] T;
        public static double[] W;

        public static void Calculate()
        {
            j = 0;
            T = new double[cCO.Length];
            W = new double[cCO.Length];
            var rk4 = new ClassicRungeKuttaIntegrator();
            rk4.DifferentialFunction = FisherTropsh;
            rk4.InitialTime = 0;
            rk4.StepSize = 1;
            rk4.InitialValue = Vector.Create(T0, Wvh);
            
            for (int i = 0; i < cCO.Length; i++)
            {
                var y = rk4.Integrate(i);
                T[i] = y[0];
                W[i] = y[1];
                j++;
            }
        }


        private static Vector<double> FisherTropsh(double t, Vector<double> y, Vector<double> dy)
        {
            if (dy == null)
                dy = Vector.Create<double>(2);

            dy[0] = 1 / cp * (delH * K0 * cH2[j] * cCO[j] - K * F * (y[0] - Txl));
            dy[1] = -Kp * (1 / cp * (delH * K0 * cH2[j] * cCO[j] - K * F * (y[0] - Txl))) + Kp / Tizod * (Tzad - y[0]);
           
            return dy;
        }
    }
}
