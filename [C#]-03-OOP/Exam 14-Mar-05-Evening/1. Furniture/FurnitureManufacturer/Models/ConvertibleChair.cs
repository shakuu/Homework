
namespace FurnitureManufacturer.Models
{
    using FurnitureManufacturer.Interfaces;

    /// <summary>
    /// TODO: ToString()
    /// </summary>
    internal class ConvertibleChair : Chair, IConvertibleChair
    {
        private const decimal ConvertedStateHeightInMeters = 0.10m;

        private const string ToStringFormat = ", State: {0}";

        private decimal initialHeight;

        private bool isConverted;

        public ConvertibleChair(string model, MaterialType material, decimal price, decimal height, int numberOfLegs)
            : base(model, material, price, height, numberOfLegs)
        {
            // Defaults to NO
            this.IsConverted = false;
            this.initialHeight = height;
        }

        public bool IsConverted
        {
            get
            {
                return this.isConverted;
            }

            private set
            {
                this.isConverted = value;
            }
        }

        public void Convert()
        {
            if (IsConverted) this.SetNormalState();
            else this.SetConvertedState();
        }

        private void SetConvertedState()
        {
            this.initialHeight = base.Height;
            base.Height = ConvertibleChair.ConvertedStateHeightInMeters;
            this.IsConverted = true;
        }

        private void SetNormalState()
        {
            base.Height = this.initialHeight;
            this.IsConverted = false;
        }

        public override string ToString()
        {
            return base.ToString()
                + string.Format(
                    ConvertibleChair.ToStringFormat,
                    this.IsConverted ? "Converted" : "Normal");
        }
    }
}
