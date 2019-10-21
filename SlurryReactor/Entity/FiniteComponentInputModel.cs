namespace SlurryReactor.Entity
{
    /// <summary>
    /// Input parameters for reactor model
    /// </summary>
    public class FiniteComponentInputModel
    {
        /// <summary>
        /// Value represent time of reaction in reactor
        /// </summary>
        public int EndTime { get; set; }

        /// <summary>
        /// Value represent flow rate Hydrogen
        /// </summary>
        public double G1 { get; set; }

        /// <summary>
        /// Value represent flow rate Synthesis-gas
        /// </summary>
        public double G2 { get; set; }

        /// <summary>
        /// Value represent temperature inside reactor
        /// </summary>
        public double T { get; set; }

        /// <summary>
        /// Chain growth probability
        /// </summary>
        public double Alfa { get; set; }

        /// <summary>
        /// Part of paraffins
        /// </summary>
        public double Gama { get; set; }

        /// <summary>
        /// Density of liquid phase 
        /// </summary>
        public double Density { get; set; }

        /// <summary>
        /// Count of component in reactor
        /// </summary>
        public int M { get; set; }
    }
}
