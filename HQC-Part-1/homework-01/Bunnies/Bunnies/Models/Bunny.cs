namespace Bunnies.Models
{
    using System;
    using System.Text;

    using Bunnies.Contracts;
    using Bunnies.Enums;
    using Bunnies.Utils;

    /// <summary>
    /// Implements base IBunny.
    /// </summary>
    [Serializable]
    public class Bunny : IBunny
    {
        /// <summary>
        /// Age of the IBunny.
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// Name of the IBunny.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The amount of fur the IBunny has.
        /// </summary>
        public FurType FurType { get; set; }

        /// <summary>
        /// Writes a string to the provided IWriter.
        /// </summary>
        /// <param name="writer"> Invokes IWriter.WriteLine(). </param>
        public void Introduce(IWriter writer)
        {
            var furTypeStringWithSpaces = this.GetFurTypeStringWithSpaces();

            writer.WriteLine($@"{this.Name} - ""I am {this.Age} years old!""");
            writer.WriteLine($@"{this.Name} - ""And I am {furTypeStringWithSpaces}""");
        }

        /// <summary>
        /// Generates a string containing Bunny properties
        /// "Bunny name: {name}"
        /// "Bunny age: {age}"
        /// "Bunny fur: {furType}"
        /// </summary>
        /// <returns> Returns a string with Bunny properties' values. </returns>
        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            var furTypeStringWithSpaces = this.GetFurTypeStringWithSpaces();

            stringBuilder.AppendLine($"Bunny name: {this.Name}");
            stringBuilder.AppendLine($"Bunny age: {this.Age}");
            stringBuilder.AppendLine($"Bunny fur: {furTypeStringWithSpaces}");

            return stringBuilder.ToString();
        }

        private string GetFurTypeStringWithSpaces()
        {
            var furTypeAsString = this.FurType.ToString();
            var furTypeAsStringWithSpaces = furTypeAsString.SplitToSeparateWordsByUppercaseLetter();

            return furTypeAsStringWithSpaces;
        }
    }
}
