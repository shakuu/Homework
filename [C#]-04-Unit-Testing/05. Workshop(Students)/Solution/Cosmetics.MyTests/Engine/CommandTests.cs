namespace Cosmetics.MyTests.Engine
{
    using System;
    using System.Collections.Generic;

    using NUnit.Framework;

    using Cosmetics.Engine;

    [TestFixture]
    public class CommandTests
    {
        //Parse should return new Command, when the "input" string is in the required valid format.
        [Test]
        public void Parse_ShoudReturnNewCommand_WhenInputParameterIsInTheRequiredFormat()
        {
            var inputString = "command param0 param1 param2";

            var actualResult = Command.Parse(inputString);

            Assert.IsInstanceOf(typeof(Command), actualResult);
        }

        //Parse should set correct values to the newly returned Command object's Properties ("Name" & "Parameters"), when the "input" string is in the valid required format.
        [Test]
        public void Parse_ShouldSetCorrectCommandNameValue_WhenInputParameterIsCorrect()
        {
            var inputString = "command param0 param1 param2";

            var actualResult = Command.Parse(inputString);

            Assert.AreEqual(actualResult.Name, "command");
        }

        [Test]
        public void Parse_ShouldSetCorrectCommandParametersValues_WhenInputParameterIsCorrect()
        {
            var expectedParameters = new List<string>()
            {
                "param0",
                "param1",
                "param2"
            };

            var inputString = "command param0 param1 param2";

            var actualResult = Command.Parse(inputString);

            CollectionAssert.AreEqual(actualResult.Parameters, expectedParameters);
        }

        //Parse should throw NullReferenceException when the "input" string is Null.
        [Test]
        public void Parse_ShouldThrowCorrectException_WhenInputParameterIsNull()
        {
            string inputString = null;

            Assert.Throws<NullReferenceException>(() => Command.Parse(inputString));
        }

        //Parse should throw ArgumentNullException with a message that contains the string "Name", when the "input" string that represents the Command Name is Null Or Empty.
        [Test]
        public void Parse_ShouldThrowWithMessageContainingName_WhenInputParamenterIsNullOrEmpty()
        {
            string input = string.Empty;

            var actualException = Assert.Throws<ArgumentNullException>(() => Command.Parse(input));
            StringAssert.Contains("Name", actualException.Message);
        }

        //Parse should throw ArgumentNullException with a message that contains the string "List", when the "input" string that represents the Command Parameters is Null or Empty.
        [Test]
        public void Parse_ShouldThrowWithMessageContainingList_WhenInputParameterOnlyContainsACommandName()
        {
            var inputString = "command ";

            var actualException = Assert.Throws<ArgumentNullException>(() => Command.Parse(inputString));
            StringAssert.Contains("List", actualException.Message);
        }
    }
}
