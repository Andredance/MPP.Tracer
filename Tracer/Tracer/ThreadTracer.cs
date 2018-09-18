using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace Tracer
{
    internal class ThreadTracer
    {
        private int threadId;
        private Stack<MethodTracer> methodsInThread;
        private List<MethodTracer> tracedMethods;

        internal int ThreadId { get; private set; }
        
        internal long Time
        {
            get
            {
                long t = 0;
                tracedMethods.ForEach((item) => t += item.Time);
                return t;                
            }
        }

        internal Stack<MethodTracer> MethodsInThread
        {
            get
            {
                if (methodsInThread == null)
                {
                    methodsInThread = new Stack<MethodTracer>();
                }
                return methodsInThread;
            }
        }

        internal List<MethodTracer> TracedMethods
        {
            get
            {
                if (tracedMethods == null)
                {
                    tracedMethods = new List<MethodTracer>();
                }
                return tracedMethods;
            }
        }

        private void AddMethod(MethodTracer method)
        {
            if (MethodsInThread.Count > 0)
            {
                MethodsInThread.Peek().AddInnerMethod(method);         
            } else
            {
                MethodsInThread.Push(method);
            }
        }

        internal void StartTrace(MethodTracer method)
        {
            AddMethod(method);
            method.StartTrace();
        }

        internal void StopTrace()
        {
            if (MethodsInThread.Count == 0)
            {
                throw new InvalidOperationException("Can't stop tracing method that doesn't exist");
            }
            MethodTracer popedMethod = MethodsInThread.Pop();
            popedMethod.StopTrace();
            TracedMethods.Add(popedMethod);
        }

        internal ThreadTracer(int id)
        {
            ThreadId = id;
        }


    }
}
