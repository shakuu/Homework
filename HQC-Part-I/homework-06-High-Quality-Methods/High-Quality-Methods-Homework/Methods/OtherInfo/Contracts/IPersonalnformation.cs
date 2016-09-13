using System;

namespace Methods.PersonalInfo.Contracts
{
    /// <summary>
    /// Provides personal information extracted from a string.
    /// </summary>
    public interface IPersonalInformation
    {
        /// <summary>
        /// Date of birth.
        /// </summary>
        string Birthplace { get; }

        /// <summary>
        /// Place of birth.
        /// </summary>
        DateTime BirthDate { get; }

        /// <summary>
        /// Comma separated list of a person's characteristics.
        /// </summary>
        string Characteristics { get; }
    }
}
