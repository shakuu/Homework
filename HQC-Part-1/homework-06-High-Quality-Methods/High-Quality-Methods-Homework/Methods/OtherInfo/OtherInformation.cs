using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

using Methods.OtherInfo.Contracts;

namespace Methods.OtherInfo
{
    public class OtherInformation : IOtherInformation
    {
        private const string BirthplaceCommand = "from";
        private const string BirthDateCommand = "born";
        private const string DefaultCommand = "default";

        private IDictionary<string, Action<string>> infoCommandHandlers;

        private string birthPlace;
        private DateTime birthDate;
        private ICollection<string> characteristics;

        public OtherInformation(string info)
        {
            if (string.IsNullOrEmpty(info))
            {
                throw new ArgumentNullException("info");
            }

            this.infoCommandHandlers = this.BuildHandlersDictionary();
            this.characteristics = new HashSet<string>();
            this.ParseInputInfo(info);
        }

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

        public string Birthplace
        {
            get
            {
                return this.birthPlace;
            }

            private set
            {
                this.birthPlace = value;
            }
        }

        public string Characteristics
        {
            get
            {
                var characteristics = string.Join(", ", this.characteristics);
                return characteristics;
            }
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
        }

        private IEnumerable<string> SplitStringIntoWords(string info, char[] separators)
        {
            var infoWords = info
                .Trim()
                .Split(separators, StringSplitOptions.RemoveEmptyEntries)
                .Select(section => section.Trim());

            return infoWords;
        }

        private void ParseInfoSectionWords(IEnumerable<string> sectionWords)
        {
            Action<string> action;
            string actionParameters;

            var commandWord = sectionWords.FirstOrDefault().ToLower();
            if (this.infoCommandHandlers.ContainsKey(commandWord))
            {
                action = this.infoCommandHandlers[commandWord];
                actionParameters = sectionWords.LastOrDefault();
            }
            else
            {
                action = this.infoCommandHandlers[OtherInformation.DefaultCommand];
                actionParameters = string.Join(" ", sectionWords);
            }

            action.Invoke(actionParameters);
        }

        private void HandleBirthplaceCommand(string value)
        {
            if (this.CheckIfValueIsValid(value))
            {
                this.Birthplace = value;
            }
        }

        private void HandleBirthDateCommand(string value)
        {
            DateTime birthDate;
            var isParsed = DateTime.TryParseExact(value, "dd.MM.yyyy", null, DateTimeStyles.None, out birthDate);
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
                { OtherInformation.BirthplaceCommand, this.HandleBirthplaceCommand },
                { OtherInformation.BirthDateCommand, this.HandleBirthDateCommand   },
                { OtherInformation.DefaultCommand, this.HandleDefaultCommand       },
            };

            return dictionary;
        }
    }
}
