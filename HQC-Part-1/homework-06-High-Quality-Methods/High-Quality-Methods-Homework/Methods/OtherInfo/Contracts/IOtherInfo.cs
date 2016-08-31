using System;

namespace Methods.OtherInfo.Contracts
{
    public interface IOtherInformation
    {
        string Birthplace { get; }

        DateTime BirthDate { get; }

        string Characteristics { get; }
    }
}
