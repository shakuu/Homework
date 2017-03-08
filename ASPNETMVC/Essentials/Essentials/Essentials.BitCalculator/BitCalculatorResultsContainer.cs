namespace Essentials.BitCalculator
{
    public class BitCalculatorResultsContainer : IBitCalculatorResultsContainer, IBitCalculatorResultsContainerEditable
    {
        public string Bytes { get; set; }

        public string KiloBytes { get; set; }

        public string MegaBytes { get; set; }

        public string GigaBytes { get; set; }

        public string TeraBytes { get; set; }

        public string PetaBytes { get; set; }

        public string ExaBytes { get; set; }

        public string ZettaBytes { get; set; }

        public string YottaBytes { get; set; }
    }
}
