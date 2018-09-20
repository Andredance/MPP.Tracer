using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracer
{
    public class ConsoleWriter : IWriter
    {
        public void Write(TraceResult traceResult, ISerializer serializer)
        {
            using (Stream consoleOutPutStream = Console.OpenStandardOutput())
            {
                serializer.SerializeResult(traceResult, consoleOutPutStream);
            }
        }
    }
}
