using System;
using System.Collections.Generic;
using System.Linq;

using Methods.OtherInfo.Contracts;

namespace Methods.OtherInfo
{
    internal class OtherInfo : IOtherInfo
    {
        private const string BirthplaceCommand = "from";
        private const string BirthDateCommand = "born";
        private const string DefaultCommand = "default";

        private IDictionary<string, Action<string>> infoCommandHandlers;

        private string birthPlace;
        private DateTime birthDate;
        private ICollection<string> characteristics;

        public OtherInfo(string info)
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
                throw new NotImplementedException();
            }

            private set
            {

            }
        }

        public string Birthplace
        {
            get
            {
                throw new NotImplementedException();
            }

            private set
            {

            }
        }

        public ICollection<string> Characteristics
        {
            get
            {
                throw new NotImplementedException();
            }

            private set
            {

            }
        }

        private void ParseInputInfo(string info)
        {
            var infoSections = this.SplitStringIntoWords(info, new[] { ',' });
            foreach (var section in infoSections)
            {
                var infoSectionWords = this.SplitStringIntoWords(section, new[] { ' ' });
                this.ParseInfoSectionWords(infoSectionWords);
            }
        }

        private IEnumerable<string> SplitStringIntoWords(string info, char[] separators)
        {
            var infoSections = info
                .Trim()
                .Split(separators, StringSplitOptions.RemoveEmptyEntries)
                .Select(section => section.Trim())
                .ToList();

            return infoSections;
        }

        private void ParseInfoSectionWords(IEnumerable<String> sectionWords)
        {
            Action<string> action;

            var commandWord = sectionWords.First().ToLower();
            if (this.infoCommandHandlers.ContainsKey(commandWord))
            {
                action = this.infoCommandHandlers[commandWord];
            }
            else
            {
                action = this.infoCommandHandlers[OtherInfo.DefaultCommand];
            }

            action.Invoke(sectionWords.Last());
        }

        private void HandleBirthplaceCommand(string value)
        {
            this.Birthplace = value;
        }

        private void HandleBirthDateCommand(string value)
        {
            DateTime birthDate;
            var isParsed = DateTime.TryParse(value, out birthDate);
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
            this.characteristics.Add(value);
        }

        private IDictionary<string, Action<string>> BuildHandlersDictionary()
        {
            var dictionary = new Dictionary<string, Action<string>>()
            {
                { OtherInfo.BirthplaceCommand, this.HandleBirthplaceCommand },
                { OtherInfo.BirthDateCommand, this.HandleBirthDateCommand   },
                { OtherInfo.DefaultCommand, this.HandleDefaultCommand       },
            };

            return dictionary;
        }
    }
}
