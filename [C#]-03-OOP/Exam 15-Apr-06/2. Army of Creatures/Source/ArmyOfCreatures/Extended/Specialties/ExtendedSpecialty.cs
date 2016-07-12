namespace ArmyOfCreatures.Extended.Specialties
{
    using System;
    using System.Globalization;

    using ArmyOfCreatures.Logic.Specialties;
    using ArmyOfCreatures.Logic.Battles;
    /// <summary>
    /// Null Checks
    /// Input checks
    /// ToString
    /// </summary>
    public class ExtendedSpecialty : Specialty
    {
        private int specialty;

        public ExtendedSpecialty(int specialty, int minimumConstraint = 1, int maximumConstraint = int.MaxValue)
        {
            if (specialty < minimumConstraint || maximumConstraint < specialty)
            {
                // TODO: fix message.
                throw new ArgumentOutOfRangeException("rounds", "The number of rounds should be greater than 0");
            }

            this.Specialty = specialty;
        }

        /// <summary>
        /// Rounds/ StatToApply
        /// </summary>
        public int Specialty
        {
            get
            {
                return this.specialty;
            }

            protected set
            {
                this.specialty = value;
            }
        }

        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "{0}({1})", base.ToString(), this.specialty);
        }

        /// <summary>
        /// If Specialty is treated as a Rounds Counter, 
        /// check if it's larger than zero and decrement it if it is.
        /// </summary>
        /// <returns>Return whether the effect can be applied</returns>
        protected bool DecrementRoundsCounter()
        {
            if (this.Specialty > 0)
            {
                this.Specialty--;
                return true;
            }
            else
            {
                return false;
            }
        }

        protected void CheckInputCreatures(ICreaturesInBattle creature, string name)
        {
            if (creature == null)
            {
                throw new ArgumentNullException(name);
            }
        }
    }
}

