namespace Data.CodeFirst.ConsoleClient.QueryFromXml.XmlQueryContainers.Contracts
{
    public interface IWhereClause
    {
        string PropertyName { get; }

        string VariableName { get; }

        string Type { get; }

        string Value { get; }
    }
}
