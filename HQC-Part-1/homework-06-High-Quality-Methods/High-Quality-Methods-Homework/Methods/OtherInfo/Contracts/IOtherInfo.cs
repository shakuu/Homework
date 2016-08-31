using System;

namespace Methods.OtherInfo.Contracts
{
    internal interface IOtherInformation
    {
        string Birthplace { get; }

        DateTime BirthDate { get; }

        string Characteristics { get; }
    }
}
