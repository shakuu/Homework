using System.Collections.Generic;

namespace Data.CodeFirst.ConsoleClient.QueryFromXml.XmlQueryContainers.Contracts
{
    public interface IQueryContainer
    {
        string outputFileName { get; set; }

        string orderByElement { get; set; }

        ICollection<IWhereClause> WhereClauses { get; }

        void AddWhereClause(IWhereClause whereClause);
    }
}
