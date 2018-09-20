using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Runtime.Serialization;

namespace Tracer
{
    [DataContract]
    internal class ThreadTracer
    {
        private int threadId;
        private Stack<MethodTracer> methodsInThread;
        private List<MethodTracer> tracedMethods;

        [DataMember(Name = "id", Order = 0)]
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

        [DataMember(Name = "time", Order = 1)]
        internal string TimeFormated
        {
            get
            {
                return Time.ToString() + "ms";
            }

            private set { }
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

            private set { }
        }

        [DataMember(Name = "methods", Order = 2)]
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
                TracedMethods.Add(method);
            }
            MethodsInThread.Push(method);
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
        }

        internal ThreadTracer(int id)
        {
            threadId = id;
        }


    }
}
