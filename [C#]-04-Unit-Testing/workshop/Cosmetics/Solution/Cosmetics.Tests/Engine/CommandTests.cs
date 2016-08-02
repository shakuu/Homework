namespace Cosmetics.Tests.Engine
{
    using System;
    using System.Collections.Generic;

    using NUnit.Framework;

    using Cosmetics.Engine;

    [TestFixture]
    public class CommandTests
    {
        //- **Parse** should **return new Command**, when the "input" string is in the required valid format.
        [Test]
        public void Parse_ShouldReturnANewCommant_WhenTheInputParamenterIsInTheRequiredFormat()
        {
            // ShowCategory ForMale
            var input = "ShowCategory ForMale";
            var command = Command.Parse(input);

            var actual = command.GetType().GetInterface("ICommand");
            
            Assert.IsNotNull(actual);
        }

        //- **Parse** should set correct values to the newly returned Command object's Properties ("Name" & "Parameters"), when the "input" string is in the valid required format.  
        [Test]
        public void Parse_ShouldSetCorrectValues_ToNameAndParametersProperties_WhenInputIsValid()
        {
            // Name Param1 Param2 Param3
            var input = new List<string>()
            {
                "Name",
                "Param1",
                "Param2",
                "Param3"
            };

            var command = Command.Parse(string.Join(" ", input));
            var actual = new List<string>();
            actual.Add(command.Name);
            actual.AddRange(command.Parameters);

            CollectionAssert.AreEqual(input, actual);
            //Assert.AreEqual(command.Name, "Name");
            //Assert.AreEqual(command.Parameters[0], "Param1");
            //Assert.AreEqual(command.Parameters[1], "Param2");
            //Assert.AreEqual(command.Parameters[2], "Param3");
        }

        //- **Parse** should throw **ArgumentNullException** with a message that contains the string "Name", when the "input" string that represents the Command Name is Null Or Empty.
        [Test]
        public void Parse_ShouldThrow_WhenInputNameIsNull()
        {
            string input = string.Empty;

            var exception = Assert.Throws<ArgumentNullException>(() => Command.Parse(input));
            StringAssert.Contains("Name", exception.Message);
        }

        //- **Parse** should throw **ArgumentNullException** with a message that contains the string "List", when the "input" string that represents the Command Parameters is Null or Empty.
        [Test]
        public void Parse_ShouldThrow_WhenInputOnlyContainsAName()
        {
            var input = "Name ";

            var exception = Assert.Throws<ArgumentNullException>(() => Command.Parse(input));
            StringAssert.Contains("List", exception.Message);
        }
    }
}
