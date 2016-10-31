﻿using System.Xml;

namespace Data.CodeFirst.ConsoleClient.QueryFromXml
{
    public static class XmlQuery
    {
        private static string BaseQuery =
            @"SELECT * FROM Cars ";

        public static string BuildQueryFromXml(string fileLocation)
        {
            fileLocation = "../../../Data.Json.Files/Queries.xml";

            var document = new XmlDocument();
            document.Load(fileLocation);

            var root = document.DocumentElement;

            var queryElement = root["Query"];
            var outputFileName = queryElement.GetAttribute("OutputFileName");

            var orderByElement = queryElement.GetElementsByTagName("OrderBy");
            var whereElements = queryElement.GetElementsByTagName("WhereClause");

            var query = XmlQuery.BaseQuery;
            if (whereElements.Count > 0)
            {
                query += "WHERE ";
                var propertyName = whereElements[0].Attributes["PropertyName"].Value;
                var type = whereElements[0].Attributes["Type"].Value;
                var value = whereElements[0].InnerText;

                query += "[" + propertyName + "]";
                query += XmlQuery.ConvertType(type);
                query += value;
            }

            for (int i = 1; i < whereElements.Count; i++)
            {
                query += " AND ";
                var propertyName = whereElements[i].Attributes["PropertyName"].Value;
                var type = whereElements[i].Attributes["Type"].Value;
                var value = whereElements[i].InnerText;

                query += "[" + propertyName + "]";
                query += XmlQuery.ConvertType(type);
                query += value;
            }

            if (orderByElement.Count > 0)
            {
                var element = orderByElement[0].InnerText;
                query += " ORDER BY " + "[" + element + "]";
            }

            System.Console.WriteLine(query);
            return query;
        }

        private static string ConvertType(string name)
        {
            if (name == "Equals")
            {
                return "= ";
            }
            else if (name == "GreaterThan")
            {
                return "> ";
            }
            else
            {
                return "< ";
            }
        }
    }
}
