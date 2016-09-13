namespace Bunnies.Contracts
{
    using Bunnies.Enums;

    /// <summary>
    /// Exposes base IBunny properties.
    /// </summary>
    public interface IBunny
    {
        /// <summary>
        /// Age of the IBunny.
        /// </summary>
        int Age { get; set; }
        
        /// <summary>
        /// Name of the IBunny.
        /// </summary>
        string Name { get; set; }
        
        /// <summary>
        /// The amount of fur the IBunny has.
        /// </summary>
        FurType FurType { get; set; }
                
        /// <summary>
        /// Writes a string to the provided IWriter.
        /// </summary>
        /// <param name="writer"> IWriter used to write a string. </param>
        void Introduce(IWriter writer);
    }
}
