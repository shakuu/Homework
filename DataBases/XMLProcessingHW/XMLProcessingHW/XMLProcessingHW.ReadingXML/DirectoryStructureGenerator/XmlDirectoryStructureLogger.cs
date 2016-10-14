using System;
using System.Text;
using System.Xml;

using XMLProcessingHW.ReadingXML.DirectoryStructureGenerators.Contracts;

namespace XMLProcessingHW.ReadingXML.DirectoryStructureGenerators
{
    public class XmlDirectoryStructureLogger : IDirectoryStructureLogger, IDisposable
    {
        private XmlWriter writer;

        private string fileName;
        private Encoding encoding;

        public XmlDirectoryStructureLogger(string fileName, Encoding encoding)
        {
            // TODO: Validate fileName
            this.fileName = fileName;
            this.encoding = encoding;
        }

        public void Dispose()
        {
            this.writer.WriteEndDocument();
            this.writer.Close();
        }

        public void LogElement(string elementName, string elementText, bool isNewScope = false)
        {
            if (this.writer == null)
            {
                this.writer = new XmlTextWriter(this.fileName, this.encoding);
                this.writer.WriteStartDocument();
            }

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
