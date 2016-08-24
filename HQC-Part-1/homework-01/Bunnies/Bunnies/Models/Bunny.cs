namespace Bunnies.Models
{
    using System;
    using System.Text;

    using Bunnies.Contracts;
    using Bunnies.Enums;
    using Bunnies.Utils;

    [Serializable]
    public class Bunny : IBunny
    {
        public int Age { get; set; }

        public string Name { get; set; }

        public FurType FurType { get; set; }

        public void Introduce(IWriter writer)
        {
            var furTypeStringWithSpaces = this.GetFurTypeStringWithSpaces();

            writer.WriteLine($@"{this.Name} - ""I am {this.Age} years old!""");
            writer.WriteLine($@"{this.Name} - ""And I am {furTypeStringWithSpaces}""");
        }

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
