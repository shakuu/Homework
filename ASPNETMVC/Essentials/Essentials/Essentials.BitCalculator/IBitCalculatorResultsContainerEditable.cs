using System.Numerics;

namespace Essentials.BitCalculator
{
    public interface IBitCalculatorResultsContainerEditable : IBitCalculatorResultsContainer
    {
        new string Bytes { get; set; }

        new string KiloBytes { get; set; }

        new string MegaBytes { get; set; }

        new string GigaBytes { get; set; }

        new string TeraBytes { get; set; }

        new string PetaBytes { get; set; }

        new string ExaBytes { get; set; }

        new string ZettaBytes { get; set; }

        new string YottaBytes { get; set; }
    }
}
