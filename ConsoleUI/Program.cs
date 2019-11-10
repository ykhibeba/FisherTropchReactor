using Extreme.Mathematics;
using Extreme.Mathematics.Calculus.OrdinaryDifferentialEquations;
using FisherTropchTemperatureControl;
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
            ClassicRungeKuttaIntegrator rk4 = new ClassicRungeKuttaIntegrator();

            // The differential equation is expressed in terms of a 
            // DifferentialFunction delegate. This is a function that
            // takes a double (time value) and two Vectors (y value and
            // return value)  as arguments.
            //
            // The Lorentz function below defines the differential function
            // for the Lorentz attractor.
            rk4.DifferentialFunction = Lorentz;

            // To perform the computations, we need to set the initial time...
            rk4.InitialTime = 0.0;
            // and the initial value.
            rk4.InitialValue = Vector.Create(1.0, 0.0, 0.0);
            // The Runge-Kutta integrator also requires a step size:
            rk4.InitialStepsize = 0.1;
            //rk4.

            Console.WriteLine("Classic 4th order Runge-Kutta");
            for (int i = 0; i <= 5; i++)
            {
                double t = 0.2 * i;
                // The Integrate method performs the integration.
                // It takes as many steps as necessary up to
                // the specified time and returns the result:
                var y = rk4.IntegrateSingleStep(t);
                // The IterationsNeeded always shows the number of steps
                // needed to arrive at the final time.
                Console.WriteLine("{0:F2}: {1,20:F14} ({2} steps)", t, y, rk4.IterationsNeeded);
            }
            //ExampleModel.V0 = 6;
            //ExampleModel.Wbbx = 1;
            //ExampleModel.CA0 = 10;
            //ExampleModel.CB0 = 0;
            //ExampleModel.CC0 = 0;
            //ExampleModel.Cbbx = 10;
            //ExampleModel.Tbx = 15 + 273;
            //ExampleModel.T0 = 293;
            //ExampleModel.Tct0 = 18 + 273;
            //ExampleModel.Tzad = 293;
            //ExampleModel.Kprop = 0.02;
            //ExampleModel.TimeIzod = 100;
            //ExampleModel.Wb0 = 1;
            //ExampleModel.Cpc = 4.18;
            //ExampleModel.Cp = 4.14;
            //ExampleModel.r0 = 1000;
            //ExampleModel.Wxl = 10;
            //ExampleModel.Voxl = 0.5;
            //ExampleModel.Ktp = 10000;
            //ExampleModel.D = 2;
            //ExampleModel.K0 = 8 * Math.Pow(10, 17);
            //ExampleModel.delH = 30000;
            //ExampleModel.Eact = 22000;
            //var ex = new Example();
            //ex.Calc();

            //public const double Esh = 1181;
            //public const double Eft = 118.1;
            //public const double Ksh = 0.0000000001;
            //public const double Kft = 0.001;
            //var constants = new ConstantInputModel
            //{
            //    K1 = 8.8073 * Math.Pow(10, 6),
            //    K2 = 13.66 * Math.Pow(10, 6),
            //    K3 = 48.502 * Math.Pow(10, 6),
            //    K4 = 68.763 * Math.Pow(10, 6),
            //    K5 = 22.097 * Math.Pow(10, 6),
            //    K = 17.838 * Math.Pow(10, 6),
            //    B1 = -769.491,
            //    B2 = -424.565,
            //    B3 = 636.999,
            //    B4 = 746.846,
            //    B5 = 95.8691,
            //    B = 427.218,
            //    B0 = 1.0298 * Math.Pow(10, -3),
            //    Eft = 136.1,
            //    Esh = 1181,
            //    Kft = 0.001,
            //    Ksh = 0.000000001
            //};
            //var component = new FiniteComponentInputModel
            //{
            //    Alfa = 0.4,
            //    Density = 600,
            //    EndTime = 100,
            //    G1 = 4,
            //    G2 = 28,
            //    Gama = 0,
            //    M = 50,
            //    T = 400
            //};

            //var reactor = new FiniteComponentReactor(constants, component);
            //reactor.StartCalc();
        }
        private static Vector<double> Lorentz(double t, Vector<double> y, Vector<double> dy)
        {
            if (dy == null)
                dy = Vector.Create<double>(3);

            double sigma = 10.0;
            double beta = 8.0 / 3.0;
            double rho = 28.0;

            dy[0] = sigma * (y[1] - y[0]);
            dy[1] = y[0] * (rho - y[2]) - y[1];
            dy[2] = y[0] * y[1] - beta * y[2];

            return dy;
        }
    }
}
