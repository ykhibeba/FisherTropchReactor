using SlurryReactor.Entity;
using System;
using Common.Extension;

namespace SlurryReactor
{
    public class FiniteComponentReactor
    {
        public readonly ConstantInputModel constants;
        public readonly FiniteComponentInputModel component;

        private double[] cH2;
        private double[] cCO;
        private double[] cCO2;
        private double[] cH2O;

        public double[,] x;
        public double[,] y;
        public double[] reactorPress;
        public double[,] cLiquidComponent;
        public double[,] cGasComponent;

        public readonly double beta;
        public readonly double N;
        public readonly double nparameter;
        public readonly double omega;

        public double liquidSigma;
        public double gasSigma;

        public FiniteComponentReactor(ConstantInputModel constants, FiniteComponentInputModel component)
        {
            this.component = component;
            this.constants = constants;

            this.omega = CalcOmega();
            this.beta = CalcBeta();
            this.N = component.M - 5;
            this.nparameter = CalcNParameter();

            cH2 = new double[component.EndTime];
            cCO = new double[component.EndTime];
            cCO2 = new double[component.EndTime];
            cH2O = new double[component.EndTime];

            x = new double[component.M, component.EndTime];
            y = new double[component.M, component.EndTime];

            reactorPress = new double[component.EndTime];
            cLiquidComponent = new double[component.M, component.EndTime];
            cGasComponent = new double[component.M, component.EndTime];
        }

        private double CalcBeta()
        {
            return component.Alfa / omega;
        }

        private double CalcOmega()
        {
            return Math.Exp(constants.B * (1 / component.T - constants.B0));
        }

        private double CalcNParameter()
        {
            return N + 1 / (1 - component.Alfa);
        }

        public void StartCalc()
        {
            cH2[0] = CalcVoden();
            cCO[0] = CalcSynthesGas(0, 0, 0, 0, 0);
            cCO2[0] = 0;
            cH2O[0] = 0;
            reactorPress[0] = CalcReactorPress(0, cH2[0], cCO[0], cCO2[0], cH2O[0]);
            for (var i = 1; i < component.EndTime; i++)
            {
                cH2[i] = CalcVoden(i, cH2[i - 1], cCO[i - 1], cCO2[i - 1], cH2O[i - 1]) < 0 ? 0 : CalcVoden(i, cH2[i - 1], cCO[i - 1], cCO2[i - 1], cH2O[i - 1]);
                cCO[i] = CalcSynthesGas(i, cH2[i - 1], cCO[i - 1], cCO2[i - 1], cH2O[i - 1]) < 0 ? 0 : CalcSynthesGas(i, cH2[i - 1], cCO[i - 1], cCO2[i - 1], cH2O[i - 1]);
                cCO2[i] = CalcVyglGas(i, cH2[i - 1], cCO[i - 1], cCO2[i - 1], cH2O[i - 1]) < 0 ? 0 : CalcVyglGas(i, cH2[i - 1], cCO[i - 1], cCO2[i - 1], cH2O[i - 1]);
                cH2O[i] = CalcWater(i, cH2[i - 1], cCO[i - 1], cCO2[i - 1], cH2O[i - 1]) < 0 ? 0 : CalcWater(i, cH2[i - 1], cCO[i - 1], cCO2[i - 1], cH2O[i - 1]);
                reactorPress[i] = CalcReactorPress(0, cH2[i], cCO[i], cCO2[i], cH2O[i]);
            }

            cLiquidComponent.AddArray(cH2, 0);
            cLiquidComponent.AddArray(cCO, 1);
            cLiquidComponent.AddArray(cCO2, 2);
            cLiquidComponent.AddArray(cH2O, 3);
            CalcComponentsLiquidPhase();
            CalcComponentsGasPhase();
        }

        public void CalcComponentsLiquidPhase()
        {
            liquidSigma = component.Density * CalcS1(1, cH2[1], cCO[1], cCO2[1], cH2O[1]) / CalcS2(1, cH2[1], cCO[1], cCO2[1], cH2O[1]);
            for (var i = 4; i < component.M; i++)
            {
                cLiquidComponent[i, 0] = 0;
                for (int j = 1; j < component.EndTime; j++)
                    cLiquidComponent[i, j] = cLiquidComponent[i, j - 1] + CalcLiquidComponent(i, j, cH2[j], cCO[j], cCO2[j], cH2O[j]);
            }

            for (int i = 0; i < component.M; i++)
                for (int j = 0; j < component.EndTime; j++)
                    x[i, j] = cLiquidComponent[i, j] / liquidSigma;

        }

        public void CalcComponentsGasPhase()
        {
            gasSigma = reactorPress[0] / (constants.R * component.T);
            for (var i = 0; i < component.M; i++)
            {
                var pi = CalcPress(i + 1, constants.GetK(i + 1), constants.GetB(i + 1));
                for (int j = 0; j < component.EndTime; j++)
                {
                    cGasComponent[i, j] = x[i, j] * pi / (constants.R * component.T);
                }
            }

            for (int i = 0; i < component.M; i++)
                for (int j = 0; j < component.EndTime; j++)
                    y[i, j] = cGasComponent[i, j] / gasSigma;

        }

        private double CalcVoden()
        {
            var P10 = CalcPress(constants.K1, constants.B1);
            var S11 = CalcS11();
            return component.Density * component.G1 / (S11 * P10 * constants.HydrogenMass);
        }

        private double CalcVoden(int i, double cH2, double cCO, double cCO2, double cH2O)
        {
            var P10 = CalcPress(constants.K1, constants.B1);
            var Wsh = CalcWsh(cH2, cCO, cCO2, cH2O);
            var v1 = CalculateV(1);
            var Wft = CalcWft(cH2);
            var S1 = CalcS1(i, cH2, cCO, cCO2, cH2O);

            var Cl1S1 = component.Density / P10 * (component.G1 / constants.HydrogenMass + i * (Wsh + v1 * Wft));
            return Cl1S1 / S1;
        }

        private double CalcSynthesGas()
        {
            var S11 = CalcS11();
            var P20 = CalcPress(constants.GetK(2), constants.GetB(2));
            return component.Density * component.G2 / (S11 * P20 * constants.SynthesisGasMass);
        }

        private double CalcSynthesGas(int i, double cH2, double cCO, double cCO2, double cH2O)
        {
            var P20 = CalcPress(constants.GetK(2), constants.GetB(2));
            var Wsh = CalcWsh(cH2, cCO, cCO2, cH2O);
            var v2 = CalculateV(2);
            var Wft = CalcWft(cH2);
            var S1 = CalcS1(i, cH2, cCO, cCO2, cH2O);
            var Cl2S1 = component.Density / P20 * (component.G2 / constants.SynthesisGasMass - i * (Wsh - v2 * Wft));
            return Cl2S1 / S1;
        }

        private double CalcVyglGas(int i, double cH2, double cCO, double cCO2, double cH2O)
        {
            var P30 = CalcPress(3, constants.GetK(3), constants.GetB(3));
            var Wsh = CalcWsh(cH2, cCO, cCO2, cH2O);
            var S1 = CalcS1(i, cH2, cCO, cCO2, cH2O);
            var Cl3S1 = i * component.Density / P30 * Wsh;
            return Cl3S1 / S1;
        }

        private double CalcWater(int i, double cH2, double cCO, double cCO2, double cH2O)
        {
            var P40 = CalcPress(4, constants.GetK(4), constants.GetB(4));
            var Wsh = CalcWsh(cH2, cCO, cCO2, cH2O);
            var v4 = CalculateV(4);
            var Wft = CalcWft(cH2) * cH2;
            var S1 = CalcS1(i, cH2, cCO, cCO2, cH2O);

            var Cl4S1 = i * component.Density / P40 * (-Wsh + v4* Wft);
            return Cl4S1 / S1;
        }

        private double CalcLiquidComponent(int componentIndex, int i, double cH2, double cCO, double cCO2, double cH2O)
        {
            var wft = CalcWft(cH2) * cH2 * Math.Pow(10, 6);
            return (1 - component.Alfa) * component.Density * wft / (constants.K * component.Alfa) * Math.Pow(beta, componentIndex - 4);
        }
        private double CalcPress(double ki, double bi)
        {
            return ki * Math.Exp(-bi / component.T);
        }

        private double CalcPress(int i, double ki, double bi)
        {
            if (i <= 4)
            {
                return ki * Math.Exp(-bi / component.T);
            }
            else if (i < component.M && i > 4)
            {
                double n = i - 4;
                return ki * Math.Pow(omega, i - 4);
            }
            else
            {
                return ki * Math.Pow(omega, nparameter);
            }
        }

        private double CalcReactorPress(int i, double cH2, double cCO, double cCO2, double cH2O)
        {
            var s2 = CalcS2(i, cH2, cCO, cCO2, cH2O);
            var wft = CalcWft(cH2);
            var a = wft * (2 / (1 - component.Alfa) + component.Gama * component.Alfa - component.Alfa);
            var b = 1 / s2;
            return 1 / s2 * (component.G1 / constants.HydrogenMass + component.G2 / constants.SynthesisGasMass - wft * (2 / (1 - component.Alfa) + component.Gama * component.Alfa - component.Alfa));
        }

        private double CalcS1(int i, double cH2, double cCO, double cCO2, double cH2O)
        {
            var S11 = CalcS11();
            var S12 = CalcS12();
            var S13 = CalcS13();
            var Wsh = CalcWsh(cH2, cCO, cCO2, cH2O);
            var Wft = CalcWft(cH2);

            return S11 + i * (S12 * Wsh + S13 * Wft);
        }

        private double CalcS11()
        {
            var P10 = CalcPress(constants.K1, constants.B1);
            var P20 = CalcPress(constants.K2, constants.B2);
            return component.G1 / P10 + component.G2 / P20;
        }

        private double CalcS12()
        {
            var P10 = CalcPress(constants.K1, constants.B1);
            var P20 = CalcPress(constants.K2, constants.B2);
            var P30 = CalcPress(constants.K3, constants.B3);
            var P40 = CalcPress(constants.K4, constants.B4);
            return constants.HydrogenMass / P10 - constants.SynthesisGasMass / P20 + constants.CarbonDioxideMass / P30 - constants.WaterMass / P40;
        }

        private double CalcS13()
        {
            double sum = 0;
            for (var i = 1; i <= 5; i++)
            {
                var vi = CalculateV(i);
                var mi = constants.GetMolarMass(i);
                var Pi = CalcPress(constants.GetK(i), constants.GetB(i));
                sum += (vi * mi) / Pi;
            }
            var coef1 = (constants.HydrogenMass + nparameter * constants.MethyleneGroupMass) / (constants.K * Math.Pow(omega, 1 / (1 - component.Alfa))) * Math.Pow(beta, N);
            var coef2 = (1 - component.Alfa) / (component.Alfa * constants.K) * Math.Pow(beta, 2) * (constants.HydrogenMass * GetFi() + constants.MethyleneGroupMass * GetPsi());
            return sum + coef1 + coef2;
        }


        private double CalcS2(int i, double cH2, double cCO, double cCO2, double cH2O)
        {
            var S21 = CalcS21();
            var S22 = CalcS22();
            var S23 = CalcS23();
            var Wsh = CalcWsh(cH2, cCO, cCO2, cH2O);
            var Wft = CalcWft(cH2);

            return S21 + S22 * Wsh + S23 * Wft;
        }

        private double CalcS21()
        {
            var P10 = CalcPress(constants.K1, constants.B1);
            var P20 = CalcPress(constants.K2, constants.B2);
            return component.G1 / (constants.HydrogenMass * P10) + component.G2 / (constants.SynthesisGasMass * P20);
        }

        private double CalcS22()
        {
            var P10 = CalcPress(constants.K1, constants.B1);
            var P20 = CalcPress(constants.K2, constants.B2);
            var P30 = CalcPress(constants.K3, constants.B3);
            var P40 = CalcPress(constants.K4, constants.B4);
            return 1 / P10 - 1 / P20 + 1 / P30 - 1 / P40;
        }

        private double CalcS23()
        {
            double sum = 0;
            for (var i = 1; i <= 5; i++)
            {
                var vi = CalculateV(i);
                var Pi = CalcPress(constants.GetK(i), constants.GetB(i));
                sum += vi / Pi;
            }
            var coef1 = (1 - component.Alfa) / (constants.K * component.Alfa) * Math.Pow(beta, 2) * GetPsi();
            var coef2 = Math.Pow(beta, N) / (constants.K * Math.Pow(omega, 1 / (1 - component.Alfa)));
            return sum + coef1 + coef2;
        }

        private double GetFi()
        {
            if (beta == 1)
            {
                return N - 1;
            }
            else
            {
                return (1 - Math.Pow(beta, N - 1)) / (1 - beta);
            }
        }

        private double GetPsi()
        {
            if (beta == 1)
            {
                return N * (N + 1) / 2 - 1;
            }
            else
            {
                return (2 - beta - (N + 1) * Math.Pow(beta, N - 1) + N * Math.Pow(beta, N)) / Math.Pow(1 - beta, 2);
            }
        }

        private double CalculateV(int i)
        {
            var n = i - 4;
            if (i == component.M)
            {
                return Math.Pow(component.Alfa, N);
            }
            switch (i)
            {
                case 1:
                    return -2 / (1 - component.Alfa) - 1 + (1 - component.Gama) * component.Alfa;
                case 2:
                    return -1 / (1 - component.Alfa);
                case 3:
                    return 0;
                case 4:
                    return 1 / (1 - component.Alfa);
                default:
                    return (1 - component.Alfa) * Math.Pow(component.Alfa, n - 1);
            }
        }

        private double CalcWsh(double cH2, double cCO, double cCO2, double cH2O)
        {
            var Kl = CalcKl();
            var ert = -constants.Esh / (constants.R * component.T);
            return constants.Ksh * Math.Exp(ert);
            //return constants.Ksh * (cCO * cH2O - cH2 * cCO2) * Math.Exp(ert);
        }

        private double CalcWft(double cH2)
        {
            var ert = -constants.Eft / (constants.R * component.T);
            return constants.Kft * Math.Exp(ert);
            //return constants.Kft * cH2 * Math.Exp(ert);
        }

        private double CalcKl()
        {
            var Kg = CalcKg();
            var P10 = CalcPress(constants.GetK(1), constants.GetB(1));
            var P20 = CalcPress(constants.GetK(2), constants.GetB(2));
            var P30 = CalcPress(constants.GetK(3), constants.GetB(3));
            var P40 = CalcPress(constants.GetK(4), constants.GetB(4));
            return Kg * (P20 * P40) / (P10 * P30);
        }

        private double CalcKg()
        {
            var coef = 2486.0 / component.T - 1.565 * Math.Log(component.T) - 0.066 * Math.Pow(10, -3) * component.T - (0.21 * Math.Pow(10, 5)) / Math.Pow(component.T, 2) - 6.93;
            return Math.Exp(coef);
        }
    }
}
