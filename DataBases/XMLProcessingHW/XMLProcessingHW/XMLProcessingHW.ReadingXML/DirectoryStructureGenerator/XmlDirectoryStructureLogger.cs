using System;
using System.IO;
using System.Text;
using System.Xml;

using XMLProcessingHW.ReadingXML.DirectoryStructureGenerators.Contracts;

namespace XMLProcessingHW.ReadingXML.DirectoryStructureGenerators
{
    public class XmlDirectoryStructureLogger : IDirectoryStructureLogger, IDisposable
    {
        private readonly string fileName;
        private readonly Encoding encoding;

        private XmlWriter writer;

        public XmlDirectoryStructureLogger(string fileName, Encoding encoding)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentNullException(nameof(fileName));
            }

            if (!File.Exists(fileName))
            {
                throw new FileNotFoundException(fileName);
            }

            if (encoding == null)
            {
                throw new ArgumentNullException(nameof(encoding));
            }

            this.fileName = fileName;
            this.encoding = encoding;
        }

        private XmlWriter Writer
        {
            get
            {
                if (this.writer == null)
                {
                    this.writer = new XmlTextWriter(this.fileName, this.encoding);
                    this.writer.WriteStartDocument();
                }

                return this.writer;
            }

            set
            {
                this.writer = null;
            }
        }

        public void Dispose()
        {
            this.Writer.WriteEndDocument();
            this.Writer.Close();
            this.Writer = null;
        }

        public void LogElement(string elementName, string elementText, bool isNewScope = false)
        {
            this.Writer.WriteStartElement(elementName);
            this.Writer.WriteString(elementText);

            if (!isNewScope)
            {
                this.Writer.WriteEndElement();
            }
        }

        public void EndScope()
        {
            this.Writer.WriteEndElement();
        }
    }
}
