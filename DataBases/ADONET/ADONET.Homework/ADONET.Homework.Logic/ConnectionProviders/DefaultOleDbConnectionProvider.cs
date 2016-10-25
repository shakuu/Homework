using System;
using System.Data;

using ADONET.Homework.Logic.ConnectionProviders.Contracts;

namespace ADONET.Homework.Logic.ConnectionProviders
{
    public class DefaultOleDbConnectionProvider : IDefaultConnectionProvider
    {
        //private const string ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + "../../../../scores.xlsx" + ";" + "Extended Properties='Excel 12.0 Xml;HDR=YES;IMEX=1;MAXSCANROWS=0;ReadOnly=False;'";

        private const string ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=../../../../scores.xlsx;Mode=ReadWrite;Extended Properties=""Excel 8.0;HDR=YES;MaxScanRows=0;IMEX=0"";";

        private readonly IConnectionProvider decoratedProvider;

        public DefaultOleDbConnectionProvider(IConnectionProvider decoratedProvider)
        {
            if (decoratedProvider == null)
            {
                throw new ArgumentNullException(nameof(decoratedProvider));
            }

            this.decoratedProvider = decoratedProvider;
        }

        public IDbConnection CreateConnection()
        {
            var connectionString = DefaultOleDbConnectionProvider.ConnectionString;
            var connection = this.decoratedProvider.CreateConnection(connectionString);

            return connection;
        }
    }
}
