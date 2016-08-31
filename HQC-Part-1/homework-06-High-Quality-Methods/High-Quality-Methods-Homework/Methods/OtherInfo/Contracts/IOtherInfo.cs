using System;
using System.Collections.Generic;

namespace Methods.OtherInfo.Contracts
{
    internal interface IOtherInfo
    {
        string Birthplace { get; }

        DateTime BirthDate { get; }

        ICollection<string> Characteristics { get; }
    }
}
