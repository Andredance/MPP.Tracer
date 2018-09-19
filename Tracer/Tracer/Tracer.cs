using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tracer
{
    public class Tracer : ITracer
    {
        private TraceResult traceResult;
        public TraceResult GetTraceResult()
        {
            return traceResult;
        }

        public void StartTrace()
        {
            MethodBase methodBase = new StackTrace().GetFrame(1).GetMethod();
            string methodName = methodBase.Name;
            string className = methodBase.ReflectedType.Name;      
            MethodTracer methodTracer = new MethodTracer(methodName, className);
            int threadId = Thread.CurrentThread.ManagedThreadId;
            ThreadTracer currentThreadTracer = traceResult.GetThreadTracer(threadId);
            if (currentThreadTracer == null)
            {
                currentThreadTracer = new ThreadTracer(threadId);
                currentThreadTracer = traceResult.AddThreadTracer(threadId, currentThreadTracer);
            }
            currentThreadTracer.StartTrace(methodTracer);
        }

        public void StopTrace()
        {
            int threadId = Thread.CurrentThread.ManagedThreadId;
            ThreadTracer threadTracer = traceResult.GetThreadTracer(threadId);
            if (threadTracer != null)
            {
                threadTracer.StopTrace();
            } else
            {
                throw new InvalidOperationException("There are no one method to stop tracing");
            }
        }

        public Tracer()
        {
            traceResult = new TraceResult();
        }

    }
}
