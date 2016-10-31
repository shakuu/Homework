using System.Collections.Generic;

using Data.CodeFirst.ConsoleClient.QueryFromXml.XmlQueryContainers.Contracts;

namespace Data.CodeFirst.ConsoleClient.QueryFromXml.XmlQueryContainers
{
    public class XmlQueryContainer : IQueryContainer
    {
        private List<IWhereClause> whereClauses;

        public XmlQueryContainer()
        {
            this.whereClauses = new List<IWhereClause>();
        }

        public string orderByElement { get; set; }

        public string outputFileName { get; set; }

        public ICollection<IWhereClause> WhereClauses
        {
            get
            {
                return this.whereClauses;
            }
        }

        public void AddWhereClause(IWhereClause whereClause)
        {
            this.WhereClauses.Add(whereClause);
        }
    }
}
