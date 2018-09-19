using System.Collections.Concurrent;

namespace Tracer
{
    public class TraceResult
    {
        private ConcurrentDictionary<int, ThreadTracer> threadResults;

        internal ConcurrentDictionary<int, ThreadTracer> ThreadResults
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

        internal TraceResult() { }

        internal bool AddThreadResult(int id)
        {
            ThreadTracer threadTracer;
            if (ThreadResults.TryGetValue(id, out threadTracer)) 
            {
                return false;
            }
            threadTracer = new ThreadTracer(id);
            ThreadResults[id] = threadTracer;
            return true;       
        }

        internal ThreadTracer GetThreadResult(int id)
        {
            ThreadTracer threadTracer;
            if (ThreadResults.TryGetValue(id, out threadTracer))
            {
                return threadTracer;
            }
            return null;    
        }


    }
}