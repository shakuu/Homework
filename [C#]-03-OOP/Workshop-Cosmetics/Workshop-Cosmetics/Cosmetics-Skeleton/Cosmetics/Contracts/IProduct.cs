namespace Cosmetics.Contracts
{
    using System;
    using System.Collections.Generic;
    using Cosmetics.Common;

    public interface IProduct
    {
        string Name { get; }

        string Brand { get; }

        decimal Price { get; }

        GenderType Gender { get; }

        string Print();
    }
}
