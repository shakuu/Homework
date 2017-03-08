using System.Numerics;

namespace Essentials.BitCalculator
{
    public interface IBitCalculatorResultsContainer
    {
        string Bytes { get; }

        string KiloBytes { get; }

        string MegaBytes { get; }

        string GigaBytes { get; }

        string TeraBytes { get; }

        string PetaBytes { get; }

        string ExaBytes { get; }

        string ZettaBytes { get; }

        string YottaBytes { get; }
    }
}
