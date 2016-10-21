using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

using ADONET.Homework.Logic.DataMappers.Contracts;

namespace ADONET.Homework.Logic.DataMappers
{
    public class DataObjectMapper : IDataObjectMapper
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
                foreach (var property in propertiesInfo)
                {
                    var propertyName = property.Name;
                    var propertyValue = dataReader[propertyName];

                    property.SetValue(nextItem, propertyValue);
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
