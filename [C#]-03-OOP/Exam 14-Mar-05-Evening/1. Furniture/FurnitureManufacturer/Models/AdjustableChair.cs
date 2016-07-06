
namespace FurnitureManufacturer.Models
{
    using FurnitureManufacturer.Interfaces;

    /// <summary>
    /// TODO: ToString();
    /// </summary>
    internal class AdjustableChair : Chair, IAdjustableChair
    {
        public AdjustableChair(string model, MaterialType material, decimal price, decimal height, int numberOfLegs)
            : base(model, material, price, height, numberOfLegs)
        {
        }

        public void SetHeight(decimal height)
        {
            base.Height = height;
        }
    }
}
