using System;

using Data.CodeFirst.ConsoleClient.QueryFromXml.XmlQueryContainers.Contracts;

namespace Data.CodeFirst.ConsoleClient.QueryFromXml.XmlQueryContainers
{
    public class WhereClause : IWhereClause
    {
        public string PropertyName { get; set; }

        public string Type { get; set; }

        public string Value { get; set; }

        public string VariableName { get; set; }
    }
}
