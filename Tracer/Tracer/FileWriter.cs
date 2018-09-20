using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracer
{
    public class FileWriter : IWriter
    {
        private string fileName;
        public FileWriter(string fileN)
        {
            fileName = fileN;
        }
        public void Write(TraceResult traceResult, ISerializer serializer)
        {
            using (FileStream fileStream = new FileStream(fileName, FileMode.Append))
            {
                serializer.SerializeResult(traceResult, fileStream);
            }
        }
    }
}
