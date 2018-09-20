using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Tracer
{
    public class XmlSerializator: ISerializer
    {
        protected readonly XmlWriterSettings xmlWriterSettings;
        protected readonly DataContractSerializer xmlSerializer;

        public void SerializeResult(TraceResult traceResult, Stream stream)
        {
            using (XmlWriter xmlWriter = XmlWriter.Create(stream, xmlWriterSettings))
            {
                xmlSerializer.WriteObject(xmlWriter, traceResult);
            }
        }

        public XmlSerializator()
        {
            xmlWriterSettings = new XmlWriterSettings
            {
                Indent = true
            };
            xmlSerializer = new DataContractSerializer(typeof(TraceResult));
        }
    }
}
