using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracer
{
    public class JSONSerializer : ISerializer
    {
        private JsonSerializer jSerializer;

        private JsonSerializer JSerializer
        {
            get
            {
                if (jSerializer == null)
                {
                    jSerializer = new JsonSerializer();
                }
                return jSerializer;
            }
        }
        public void SerializeResult(TraceResult traceResult, Stream stream)
        {
            using (StreamWriter sw = new StreamWriter(stream))
            {
                using (JsonWriter writer = new JsonTextWriter(sw) { Formatting = Formatting.Indented})
                {
                    JSerializer.Serialize(writer, traceResult);
                }
            }

          
        }
    }
}
