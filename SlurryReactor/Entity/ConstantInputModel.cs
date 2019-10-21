using System;

namespace SlurryReactor.Entity
{
    public class ConstantInputModel
    {
        /// <summary>
        /// Gas constant
        /// </summary>
        public double R { get; } = 8.314;

        /// <summary>
        /// Hydrogen molar mass
        /// </summary>
        public double HydrogenMass { get; } = 2;

        /// <summary>
        /// Synthesis gas molar mass
        /// </summary>
        public double SynthesisGasMass { get; } = 28;

        /// <summary>
        /// Carbon dioxide molar mass
        /// </summary>
        public double CarbonDioxideMass { get; } = 44;

        /// <summary>
        /// Water molar mass
        /// </summary>
        public double WaterMass { get; } = 18;

        /// <summary>
        /// Methan molar mass
        /// </summary>
        public double MethanMass { get; } = 16;

        /// <summary>
        /// CH2 molar mass
        /// </summary>
        public double MethyleneGroupMass { get; } = 14;

        public double GetMolarMass(int index)
        {
            switch (index)
            {
                case 1:
                    return HydrogenMass;
                case 2:
                    return SynthesisGasMass;
                case 3:
                    return CarbonDioxideMass;
                case 4:
                    return WaterMass;
                case 5:
                    return MethanMass;
                default:
                    throw new NotSupportedException("Molar mass for component > 5 should calculated");
            }
        }

        /// <summary>
        /// Activation energy for shift reaction
        /// </summary>
        public double Esh { get; set; }

        /// <summary>
        /// Reaction rate constant for shift reaction
        /// </summary>
        public double Ksh { get; set; }

        /// <summary>
        /// Activation energy for Fisher-Tropch reaction
        /// </summary>
        public double Eft { get; set; }

        /// <summary>
        /// Reaction rate constant for Fisher-Tropch reaction
        /// </summary>
        public double Kft { get; set; }

        /// <summary>
        /// Hydrogen rate constant
        /// </summary>
        public double K1 { get; set; }

        /// <summary>
        /// Synthesis gas rate constant
        /// </summary>
        public double K2 { get; set; }

        /// <summary>
        /// Carbon dioxide rate constant
        /// </summary>
        public double K3 { get; set; }

        /// <summary>
        /// Water rate constant
        /// </summary>
        public double K4 { get; set; }

        /// <summary>
        /// Methan rate constant
        /// </summary>
        public double K5 { get; set; }

        /// <summary>
        /// Specific rate constant
        /// </summary>
        public double K { get; set; }

        public double GetK(int index)
        {
            switch (index)
            {
                case 1:
                    return K1;
                case 2:
                    return K2;
                case 3:
                    return K3;
                case 4:
                    return K4;
                case 5:
                    return K5;
                default:
                    return K;
            }
        }

        /// <summary>
        /// Hydrogen parameter
        /// </summary>
        public double B1 { get; set; }

        /// <summary>
        /// Synthesis gas parameter
        /// </summary>
        public double B2 { get; set; }

        /// <summary>
        /// Carbon dioxide parameter
        /// </summary>
        public double B3 { get; set; }

        /// <summary>
        /// Water parameter
        /// </summary>
        public double B4 { get; set; }

        /// <summary>
        /// Methan parameter
        /// </summary>
        public double B5 { get; set; }

        /// <summary>
        /// Specific parameter
        /// </summary>
        public double B { get; set; }

        /// <summary>
        /// Zero specific parameter
        /// </summary>
        public double B0 { get; set; }

        public double GetB(int index)
        {
            switch (index)
            {
                case 0:
                    return B0;
                case 1:
                    return B1;
                case 2:
                    return B2;
                case 3:
                    return B3;
                case 4:
                    return B4;
                case 5:
                    return B5;
                default:
                    return B;
            }
        }
    }
}
