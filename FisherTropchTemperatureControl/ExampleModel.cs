namespace FisherTropchTemperatureControl
{
    public static class ExampleModel
    {
        public static double V0 { get; set; }

        public static double Wbbx { get; set; }

        public static double CA0 { get; set; }

        public static double CB0 { get; set; }

        public static double CC0 { get; set; }

        public static double Cbbx { get; set; }

        public static double Tbx { get; set; }

        public static double T0 { get; set; }

        public static double Tct0 { get; set; }
               
        public static double Tzad { get; set; }
               
        public static double Kprop { get; set; }
               
        public static int TimeIzod { get; set; }
               
        public static double Wb0 { get; set; }
               
        public static double Txladbc => Tct0 - 6;
               
        public static double Cpc { get; set; }
               
        public static double Cp { get; set; }
               
        public static int r0 { get; set; }
               
        public static double Wxl { get; set; }
               
        public static double Voxl { get; set; }
               
        public static double Ktp { get; set; }
               
        public static double D { get; set; }
               
        public static double K0 { get; set; }
               
        public static double delH { get; set; }
               
        public static double Eact { get; set; }
    }
}
