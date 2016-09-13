using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

using Methods.PersonalInfo.Contracts;

namespace Methods.PersonalInfo
{
    /// <summary>
    /// Provides personal information extracted from a string.
    /// </summary>
    public class PersonalInformation : IPersonalInformation
    {
        private const string BirthplaceCommand = "from";
        private const string BirthDateCommand = "born";
        private const string DefaultCommand = "default";

        private IDictionary<string, Action<string>> infoCommandHandlers;

        private string birthPlace;
        private DateTime birthDate;
        private ICollection<string> characteristics;

        /// <summary>
        /// Parse a string containing information fields separated by comma.
        /// "from" field describes birth place.
        /// "born" field describes birth date.
        /// All other fields are treated as characteristics.
        /// </summary>
        /// <param name="info"> Information string to parse. </param>
        public PersonalInformation(string info)
        {
            if (string.IsNullOrEmpty(info))
            {
                throw new ArgumentNullException("info");
            }

            this.infoCommandHandlers = this.BuildHandlersDictionary();
            this.characteristics = new HashSet<string>();
            this.ParseInputInfo(info);
        }

        /// <summary>
        /// Date of birth.
        /// </summary>
        public DateTime BirthDate
        {
            get
            {
                return this.birthDate;
            }

            private set
            {
                this.birthDate = value;
            }
        }

        /// <summary>
        /// Place of birth.
        /// </summary>
        public string Birthplace
        {
            get
            {
                if (this.birthPlace == null)
                {
                    this.birthPlace = "not available";
                }

                return this.birthPlace;
            }

            private set
            {
                this.birthPlace = value;
            }
        }

        /// <summary>
        /// Comma separated list of a person's characteristics.
        /// </summary>
        public string Characteristics
        {
            get
            {
                var characteristics = this.BuildCharacteristicsString(this.characteristics);
                return characteristics;
            }
        }

        private string BuildCharacteristicsString(IEnumerable<string> characteristics)
        {
            string result;
            if (characteristics.Count() == 0)
            {
                result = "not available";
            }
            else
            {
                result = string.Join(", ", this.characteristics);
            }

            return result;
        }

        private void ParseInputInfo(string info)
        {
            var infoSeparators = new[] { ',' };
            var sectionSeparators = new[] { ' ' };

            var infoSections = this.SplitStringIntoWords(info, infoSeparators);
            foreach (var section in infoSections)
            {
                var infoSectionWords = this.SplitStringIntoWords(section, sectionSeparators);
                this.ParseInfoSectionWords(infoSectionWords);
            }

            if (this.birthDate == default(DateTime))
            {
                throw new ArgumentException("Personal Information string must contain a birth date.");
            }
        }

        private IEnumerable<string> SplitStringIntoWords(string value, char[] separators)
        {
            var infoWords = value
                .Trim()
                .Split(separators, StringSplitOptions.RemoveEmptyEntries)
                .Select(section => section.Trim());

            return infoWords;
        }

        private void ParseInfoSectionWords(IEnumerable<string> sectionWords)
        {
            Action<string> commandHandler;
            string commandHandlerParameters;

            var commandWord = sectionWords.FirstOrDefault().ToLower();
            if (this.infoCommandHandlers.ContainsKey(commandWord))
            {
                commandHandler = this.infoCommandHandlers[commandWord];
                commandHandlerParameters = sectionWords.LastOrDefault();
            }
            else
            {
                commandHandler = this.infoCommandHandlers[PersonalInformation.DefaultCommand];
                commandHandlerParameters = string.Join(" ", sectionWords);
            }

            commandHandler.Invoke(commandHandlerParameters);
        }

        private void HandleBirthplaceCommand(string birthplace)
        {
            if (this.CheckIfValueIsValid(birthplace))
            {
                this.Birthplace = birthplace;
            }
        }

        private void HandleBirthDateCommand(string date)
        {
            DateTime birthDate;
            var isParsed = DateTime.TryParseExact(date, "dd.MM.yyyy", null, DateTimeStyles.None, out birthDate);
            if (isParsed)
            {
                this.BirthDate = birthDate;
            }
            else
            {
                throw new ArgumentException("Invalid date");
            }
        }

        private void HandleDefaultCommand(string value)
        {
            if (this.CheckIfValueIsValid(value))
            {
                this.characteristics.Add(value);
            }
        }

        private bool CheckIfValueIsValid(object value)
        {
            var isNull = value == null;
            if (isNull)
            {
                throw new ArgumentNullException();
            }
            else
            {
                return true;
            }
        }

        private IDictionary<string, Action<string>> BuildHandlersDictionary()
        {
            var dictionary = new Dictionary<string, Action<string>>()
            {
                { PersonalInformation.BirthplaceCommand, this.HandleBirthplaceCommand },
                { PersonalInformation.BirthDateCommand, this.HandleBirthDateCommand },
                { PersonalInformation.DefaultCommand, this.HandleDefaultCommand }
            };

            return dictionary;
        }
    }
}
