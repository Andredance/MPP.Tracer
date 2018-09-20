using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracer
{
    public interface IWritter
    {
        void Write(TraceResult traceResult, ISerializer serializer);
    }
}
