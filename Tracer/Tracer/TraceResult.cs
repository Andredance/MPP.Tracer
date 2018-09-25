using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Tracer
{
    [DataContract]
    public class TraceResult
    {
        private ConcurrentDictionary<int, ThreadTracer> threadResults;

        internal ConcurrentDictionary<int, ThreadTracer> ThreadTracer
        {
            get
            {
                if (threadResults == null)
                {
                    threadResults = new ConcurrentDictionary<int, ThreadTracer>();
                }
                return threadResults;
            }
        }

        [DataMember(Name = "threads")]
        public List<ThreadTracer> ThreadsList
        {
            get
            {
                return new List<ThreadTracer>(ThreadTracer.Values).OrderBy(item=> item.ThreadId).ToList();
            }

            private set { }
        }

        internal TraceResult() { }

        internal ThreadTracer AddThreadTracer(int id, ThreadTracer value)
        {
            if (ThreadTracer.TryAdd(id, value)) 
            {
                return GetThreadTracer(id);
            }
            return null;     
        }

        internal ThreadTracer GetThreadTracer(int id)
        {
            ThreadTracer threadTracer;
            if (ThreadTracer.TryGetValue(id, out threadTracer))
            {
                return threadTracer;
            }
            return null;
        }


    }
}