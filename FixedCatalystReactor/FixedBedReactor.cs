using FixedCatalystReactor.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FixedCatalystReactor
{
    public class FixedBedReactor
    {
        public readonly FixedBedComponentModel model;

        public double[] cCO;
        public double[] cH2;
        public double[] cCO2;
        public double[] cH2O;
        public double[,] cAlkan;
        public double[,] cAlken;

        public FixedBedReactor(FixedBedComponentModel model)
        {
            this.model = model;
            this.cCO = new double[model.Time];
            this.cCO[0] = model.cCO0;

            this.cH2 = new double[model.Time];
            this.cH2[0] = model.cH20;

            this.cH2O = new double[model.Time];
            this.cH2O[0] = 0;

            this.cCO2 = new double[model.Time];
            this.cCO2[0] = 0;

            this.cAlkan = new double[20, ]
            for (int i = 0; i < 20; i++)
            {

            }
        }


        private double CalcCO(int j)
        {
            double sum = 0;
            for (int i = 0; i < model.AlkenE.Length; i++)
            {
                var n = i + 1;
                sum += -n * CalcW1(i, cH2[j], cCO[j], cH2O[j]);
            }
            for (int i = 0; i < model.AlkanE.Length; i++)
            {
                var n = i + 1;
                sum += -n * CalcW2(i, cH2[j], cCO[j], cH2O[j]);
            }
            sum = sum - CalcW4(cH2[j], cCO[j], cH2O[j], cCO2[j]);
            return sum;
        }

        private double CalcH2(int j)
        {
            double sum = 0;
            for (int i = 0; i < model.AlkenE.Length; i++)
            {
                var n = i + 1;
                sum += (2 * n + 1) * CalcW1(i, cH2[j], cCO[j], cH2O[j]);
            }
            for (int i = 0; i < model.AlkanE.Length; i++)
            {
                var n = i + 1;
                sum += -2 * n * CalcW2(i, cH2[j], cCO[j], cH2O[j]);
            }
            for (int i = 0; i < model.AlkanE.Length; i++)
            {
                var n = i + 1;
                sum += -1 * CalcW2(i, cH2[j], cCO[j], cH2O[j]);
            }
            sum = sum + CalcW4(cH2[j], cCO[j], cH2O[j], cCO2[j]);
            return sum;
        }

        private double CalcH2O(int j)
        {
            double sum = 0;
            for (int i = 0; i < model.AlkenE.Length; i++)
            {
                var n = i + 1;
                sum += n * CalcW1(i, cH2[j], cCO[j], cH2O[j]);
            }
            for (int i = 0; i < model.AlkanE.Length; i++)
            {
                var n = i + 1;
                sum += n * CalcW2(i, cH2[j], cCO[j], cH2O[j]);
            }
            sum = sum - CalcW4(cH2[j], cCO[j], cH2O[j], cCO2[j]);
            return sum;
        }

        private double CalcAlken(int i, int j)
        {
            return CalcW2(i, cH2[j], cCO[j], cH2O[j]) - CalcW3(i, cH2[j], cCO[j], cH2O[j],);
        }

        private double CalcAlkan(int i, int j)
        {
            return CalcW2(i, cH2[j], cCO[j], cH2O[j]);
        }

        private double CalcCO2(int j)
        {
            return CalcW4(cH2[j], cCO[j], cH2O[j], cCO2[j]);
        }

        private double CalcW1(int i, double cH2, double cCO, double cH2O)
        {
            var k = CalcAlkenK(i);
            return k * cH2 * cCO / (cCO + model.B * cH2O);
        }

        private double CalcW2(int i, double cH2, double cCO, double cH2O)
        {
            var k = CalcAlkanK(i);
            return k * cH2 * cCO / (cCO + model.B * cH2O);
        }

        private double CalcW3(int i, double cH2, double cCO, double cH2O, double cAlken)
        {
            var k = CalcAlkinK(i);
            return k * cH2 * cAlken / (cCO + model.B * cH2O);
        }

        private double CalcW4(double cH2, double cCO, double cH2O, double cCO2)
        {
            return model.K4 * (cH2O * cCO - Math.Pow(model.Kp, -1) * cH2 * cCO2) / (model.A * cH2O - cCO2);
        }

        private double CalcAlkenK(int i)
        {
            return model.AlkenK0[i] * Math.Exp(-model.AlkenE[i] / (model.T * model.R));
        }

        private double CalcAlkanK(int i)
        {
            return model.AlkanK0[i] * Math.Exp(-model.AlkanE[i] / (model.T * model.R));
        }

        private double CalcAlkinK(int i)
        {
            return model.AlkinK0[i] * Math.Exp(-model.AlkinE[i] / (model.T * model.R));
        }
    }
}
