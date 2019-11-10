using Extreme.Mathematics;
using Extreme.Mathematics.Calculus.OrdinaryDifferentialEquations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FisherTropchTemperatureControl
{
    public class Example
    {
        public Example()
        {

        }

        public void Calc()
        {
            ClassicRungeKuttaIntegrator rk4 = new ClassicRungeKuttaIntegrator();
            rk4.DifferentialFunction = Lorentz;
            rk4.InitialTime = 0;
            rk4.InitialStepsize = 0.1;
            rk4.InitialValue = Vector.Create(ExampleModel.CA0, ExampleModel.CB0, ExampleModel.CC0, ExampleModel.V0, ExampleModel.T0, ExampleModel.Tct0, ExampleModel.Wb0);
            for (int i = 0; i <= 8000; i++)
            {
                double t = 0.001 * i;
                var y = rk4.Integrate(t);
            }
        }


        private static Vector<double> Lorentz(double t, Vector<double> y, Vector<double> dy)
        {
            if (dy == null)
                dy = Vector.Create<double>(7);

            dy[0] = -CalcKt(y[4]) * y[0] * y[1];
            dy[1] = ExampleModel.Wbbx * ExampleModel.Cbbx / y[3] - CalcKt(y[4]) * y[0] * y[1];
            dy[2] = CalcKt(y[4]) * y[0] * y[1];
            dy[3] = y[6];
            dy[4] = y[6] / y[3] * (ExampleModel.Tbx - y[4]) - ExampleModel.Ktp * 4 / (ExampleModel.D * ExampleModel.r0 * ExampleModel.Cp) * (y[4] - y[5]) + ExampleModel.delH / (ExampleModel.r0 * ExampleModel.Cp) * CalcKt(y[4]) * y[0] * y[1];
            dy[5] = ExampleModel.Wxl / ExampleModel.Voxl * (ExampleModel.Txladbc - y[5]) + ExampleModel.Ktp / (ExampleModel.r0 * ExampleModel.Cpc * ExampleModel.D * ExampleModel.Voxl) * 4 * y[3] * (y[4] - y[5]);
            dy[6] = -ExampleModel.Kprop * (y[6] / y[3] * (ExampleModel.Tbx - y[4]) - ExampleModel.Ktp * 4 / (ExampleModel.D * ExampleModel.r0 * ExampleModel.Cp) * (y[4] - y[5]) + ExampleModel.delH / (ExampleModel.r0 * ExampleModel.Cp) * CalcKt(y[4]) * y[0] * y[1]) + ExampleModel.Kprop / ExampleModel.TimeIzod * (ExampleModel.Tzad - y[4]);
            return dy;
        }


        public static double CalcKt(double T)
        {
            return ExampleModel.K0 * Math.Exp(-ExampleModel.Eact / (1.985 * T));
        }

        public delegate double Function(double x, double y);


        public static double ODE_RungeKutta4(Function f, double x0, double y0, double h, double x)
        {
            double xnew, ynew, k1, k2, k3, k4, result = double.NaN;
            if (x == x0)
                result = y0;
            else if (x > x0)
            {
                do
                {
                    if (h > x - x0) h = x - x0;
                    k1 = h * f(x0, y0);
                    k2 = h * f(x0 + 0.5 * h, y0 + 0.5 * k1);
                    k3 = h * f(x0 + 0.5 * h, y0 + 0.5 * k2);
                    k4 = h * f(x0 + h, y0 + k3);
                    ynew = y0 + (k1 + 2 * k2 + 2 * k3 + k4) / 6;
                    xnew = x0 + h;
                    x0 = xnew;
                    y0 = ynew;
                } while (x0 < x);
                result = ynew;
            }
            return result;
        }
    }
}
