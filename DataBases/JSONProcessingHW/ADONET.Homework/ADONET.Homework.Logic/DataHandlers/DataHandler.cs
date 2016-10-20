using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

using ADONET.Homework.Logic.DataHandlers.Contracts;

namespace ADONET.Homework.Logic.DataHandlers
{
    public class DataHandler : IDataHandler
    {
        public IEnumerable<ModelType> ParseData<ModelType>(IDataReader dataReader)
            where ModelType : new()
        {
            if (dataReader == null)
            {
                throw new ArgumentNullException(nameof(dataReader));
            }


            var parsedData = new LinkedList<ModelType>();
            var propertiesInfo = this.GetModelTypeProperties(typeof(ModelType));

            while (dataReader.Read())
            {
                var nextItem = new ModelType();
                foreach (var prop in propertiesInfo)
                {
                    prop.SetValue(nextItem, dataReader[prop.Name]);
                }

                parsedData.AddLast(nextItem);
            }

            return parsedData;
        }

        private IEnumerable<PropertyInfo> GetModelTypeProperties(Type modelType)
        {
            var modelTypePropertiesInfo = modelType.GetProperties();

            return modelTypePropertiesInfo;
        }
    }
}
