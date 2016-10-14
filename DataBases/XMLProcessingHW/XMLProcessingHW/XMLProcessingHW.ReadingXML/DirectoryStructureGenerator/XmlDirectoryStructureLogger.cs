using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

using XMLProcessingHW.ReadingXML.DirectoryStructureGenerator.Contracts;

namespace XMLProcessingHW.ReadingXML.DirectoryStructureGenerator
{
    public class XmlDirectoryStructureLogger : IDirectoryStructureLogger, IDisposable
    {
        private XmlWriter writer;
        private Stack<string> scopeStack;

        public XmlDirectoryStructureLogger(string fileName, Encoding encoding)
        {
            // TODO: Validate fileName

            this.scopeStack = new Stack<string>();

            this.writer = new XmlTextWriter(fileName, encoding);
            this.writer.WriteStartDocument();
        }

        public void Dispose()
        {
            this.writer.WriteEndDocument();
            this.writer.Close();
        }

        public void LogElement(string elementName, string elementText, bool isNewScope = false)
        {
            this.writer.WriteStartElement(elementName);
            this.writer.WriteString(elementText);

            if (!isNewScope)
            {
                this.writer.WriteEndElement();
            }
        }

        public void EndScope()
        {
            this.writer.WriteEndElement();
        }
    }
}
