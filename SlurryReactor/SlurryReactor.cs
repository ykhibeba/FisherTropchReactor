using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlurryReactor
{
    public class SlurryReactor
    {
        #region Property

        public const double R = 8.314;

        //public const double Esh = 1181;
        //public const double Eft = 1181;
        //public const double Ksh = 10;
        //public const double Kft = 10;

        public const double Esh = 595.5;
        public const double Eft = 136.1;
        public const double Ksh = 0.000002;
        public const double Kft = 0.002;



        private double[] cH2;
        private double[] cCO;
        private double[] cCO2;
        private double[] cH2O;

        #endregion


        private readonly double endTime;
        private readonly double G1;
        private readonly double G2;
        //private readonly double P0;
        private readonly double T;
        private readonly double beta;
        private readonly double alfa; //grow chain
        private readonly double gama; //parafins 
        private readonly double ro; //густина 

        public SlurryReactor(int endTime, double G1, double G2, double T, double alfa, double gama, double ro)
        {
            this.endTime = endTime;
            this.G1 = G1;
            this.G2 = G2;
            this.T = T;
            this.alfa = alfa;
            this.beta = CalcBeta();
            this.gama = gama;
            this.ro = ro;

            cH2 = new double[endTime];
            cCO = new double[endTime];
            cCO2 = new double[endTime];
            cH2O = new double[endTime];
        }


        #region Calculation

        private double CalcBeta()
        {
            var coef = 427.218 * (1 / T - 1.0298 * Math.Pow(10.0, -3.0));
            return alfa * Math.Exp(coef);
        }

        public void StartCalc()
        {
            cH2[0] = CalcVoden(0, 0, 0, 0, 0);
            cCO[0] = CalcSynthesGas(0, 0, 0, 0, 0);
            cCO2[0] = CalcVyglGas(0, 0, 0, 0, 0);
            cH2O[0] = CalcWater(0, 0, 0, 0, 0);
            for (var i = 1; i < endTime; i++)
            {
                //double j = i / 10.0;
                cH2[i] = CalcVoden(i, cH2[i - 1], cCO[i - 1], cCO2[i - 1], cH2O[i - 1]);
                cCO[i] = CalcSynthesGas(i, cH2[i - 1], cCO[i - 1], cCO2[i - 1], cH2O[i - 1]);
                cCO2[i] = CalcVyglGas(i, cH2[i - 1], cCO[i - 1], cCO2[i - 1], cH2O[i - 1]);
                cH2O[i] = CalcWater(i, cH2[i - 1], cCO[i - 1], cCO2[i - 1], cH2O[i - 1]);
            }
        }

        private double CalcVoden(double i, double cH2, double cCO, double cCO2, double cH2O)
        {
            if (i == 0)
            {
                var S11 = CalcS11();
                var P10 = CalcPress(1, GetKi(1), GetBi(1));
                return ro * G1 / (S11 * P10 * 2.0);
            }
            {
                var P10 = CalcPress(1, GetKi(1), GetBi(1));
                var Wsh = CalcWsh(cH2, cCO, cCO2, cH2O);
                var v1 = GetVi(1);
                var Wft = CalcWft(cH2);
                var S1 = CalcS1(i, cH2, cCO, cCO2, cH2O);

                var Cl1S1 = ro / P10 * (G1 / 2.0 + i * (Wsh + v1 * Wft));
                return Cl1S1 / S1;
            }
        }

        private double CalcSynthesGas(double i, double cH2, double cCO, double cCO2, double cH2O)
        {
            if (i == 0)
            {
                var S11 = CalcS11();
                var P20 = CalcPress(2, GetKi(2), GetBi(2));
                return ro * G2 / (S11 * P20 * 28.0);
            }
            {
                var P20 = CalcPress(2, GetKi(2), GetBi(2));
                var Wsh = CalcWsh(cH2, cCO, cCO2, cH2O);
                var v2 = GetVi(2);
                var Wft = CalcWft(cH2);
                var S1 = CalcS1(i, cH2, cCO, cCO2, cH2O);

                var Cl2S1 = ro / P20 * (G2 / 28.0 - i * (Wsh - v2 * Wft));
                return Cl2S1 / S1;
            }
        }

        private double CalcVyglGas(double i, double cH2, double cCO, double cCO2, double cH2O)
        {
            if (i == 0)
            {
                return 0;
            }
            {
                var P30 = CalcPress(3, GetKi(3), GetBi(3));
                var Wsh = CalcWsh(cH2, cCO, cCO2, cH2O);
                var S1 = CalcS1(i, cH2, cCO, cCO2, cH2O);

                var Cl3S1 = i * ro / P30 * Wsh;
                return Cl3S1 / S1;
            }
        }

        private double CalcWater(double i, double cH2, double cCO, double cCO2, double cH2O)
        {
            if (i == 0)
            {
                return 0;
            }
            {
                var P40 = CalcPress(4, GetKi(4), GetBi(4));
                var Wsh = CalcWsh(cH2, cCO, cCO2, cH2O);
                var v4 = GetVi(4);
                var Wft = CalcWft(cH2);
                var S1 = CalcS1(i, cH2, cCO, cCO2, cH2O);

                var Cl4S1 = i * ro / P40 * (-Wsh + v4 * Wft);
                return Cl4S1 / S1;
            }
        }

        private double CalcPress(double i, double ki, double bi, double b0 = 0)
        {
            if (i <= 5)
            {
                return ki * Math.Exp(-bi / T);
            }
            else
            {
                double n = i - 4;
                return ki * Math.Exp(-bi * (1 / T - b0) * n);
            }
        }

        private double CalcS11()
        {
            var P10 = CalcPress(1, 8.8073 * Math.Pow(10, 6), -769.491);
            var P20 = CalcPress(2, 13.66 * Math.Pow(10, 6), -424.565);
            return G1 / P10 + G2 / P20;
        }

        private double CalcS12()
        {
            var P10 = CalcPress(1, 8.8073 * Math.Pow(10, 6), -769.491);
            var P20 = CalcPress(2, 13.66 * Math.Pow(10, 6), -424.565);
            var P30 = CalcPress(3, 48.502 * Math.Pow(10, 6), 636.999);
            var P40 = CalcPress(4, 68.763 * Math.Pow(10, 6), 746.846);
            return 2.0 / P10 - 28.0 / P20 + 44.0 / P30 - 18.0 / P40;
        }

        private double CalcS13()
        {
            double sum = 0;
            for (double i = 1; i <= 5; i++)
            {
                var vi = GetVi(i);
                var mi = GetMi(i);
                var Pi = CalcPress(i, GetKi(i), GetBi(i));
                sum += (vi * mi) / Pi;
            }
            return sum + ((Math.Pow(beta, 2) * (1.0 - alfa)) / (alfa * (1.0 - beta) * 17.838 * Math.Pow(10, 6))) * (2.0 + 14.0 * (2.0 - beta) / (1.0 - beta));
        }

        private double CalcS1(double q, double cH2, double cCO, double cCO2, double cH2O)
        {
            var S11 = CalcS11();
            var S12 = CalcS12();
            var S13 = CalcS13();
            var Wsh = CalcWsh(cH2, cCO, cCO2, cH2O);
            var Wft = CalcWft(cH2);

            return S11 + q * (S12 * Wsh + S13 * Wft);
        }

        private double GetVi(double i)
        {
            var n = i - 4;
            switch (i)
            {
                case 1:
                    return -2.0 / (1.0 - alfa) - 1.0 + (1.0 - gama) * alfa;
                case 2:
                    return -1.0 / (1.0 - alfa);
                case 3:
                    return 0;
                case 4:
                    return 1.0 / (1.0 - alfa);
                default:
                    return (1.0 - alfa) * Math.Pow(alfa, n - 1.0);
            }
        }

        private double GetMi(double i)
        {
            switch (i)
            {
                case 1:
                    return 2;
                case 2:
                    return 28;
                case 3:
                    return 44;
                case 4:
                    return 18;
                case 5:
                    return 16;
                default:
                    return 1;
            }
        }

        private double GetKi(double i)
        {
            switch (i)
            {
                case 1:
                    return 8.8073 * Math.Pow(10, 6);
                case 2:
                    return 13.66 * Math.Pow(10, 6);
                case 3:
                    return 48.502 * Math.Pow(10, 6);
                case 4:
                    return 68.763 * Math.Pow(10, 6);
                case 5:
                    return 25.097 * Math.Pow(10, 6);
                default:
                    throw new NotSupportedException("GetKi");
            }
        }

        private double GetBi(double i)
        {
            switch (i)
            {
                case 1:
                    return -769.491;
                case 2:
                    return -424.565;
                case 3:
                    return 636.999;
                case 4:
                    return 746.846;
                case 5:
                    return 95.8691;
                default:
                    throw new NotSupportedException("GetBi");
            }
        }

        private double CalcWsh(double cH2, double cCO, double cCO2, double cH2O)
        {
            var Kl = CalcKl();
            var ert = -Esh / (R * T);
            return Ksh * (cCO * cH2O - cH2 * cCO2 / Kl) * Math.Exp(ert);
        }

        private double CalcWft(double cH2)
        {
            var ert = -Eft / (R * T);
            return Kft * cH2 * Math.Exp(ert);
        }

        private double CalcKl()
        {
            var Kg = CalcKg();
            var P10 = CalcPress(1, GetKi(1), GetBi(1));
            var P20 = CalcPress(2, GetKi(2), GetBi(2));
            var P30 = CalcPress(3, GetKi(3), GetBi(3));
            var P40 = CalcPress(4, GetKi(4), GetBi(4));
            return Kg * (P20 * P40) / (P10 * P30);
        }

        private double CalcKg()
        {
            var coef = 2486.0 / T - 1.565 * Math.Log(T) - 0.066 * Math.Pow(10, -3) * T - (0.21 * Math.Pow(10, 5)) / Math.Pow(T, 2) - 6.93;
            return Math.Exp(coef);
        }
        #endregion
    }
}
