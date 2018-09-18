using System.Collections.Generic;
using System.Diagnostics;

namespace Tracer
{
    internal class MethodTracer
    {
        private List<MethodTracer> innerMethods;
        private string name;
        private string className;
        private long time;
        private Stopwatch stopwatch = new Stopwatch();

        internal string Name { get; private set;}

        internal string ClassName { get; private set; }

        internal long Time
        {
            get
            {
                if (!stopwatch.IsRunning)
                {
                    return stopwatch.ElapsedMilliseconds;
                } else
                {
                    return -1;
                }
            }
        }
        
        internal List<MethodTracer> InnerMethods
        {
            get
            {
                if (innerMethods == null)
                {
                    innerMethods = new List<MethodTracer>();
                }
                return innerMethods;
            }
        }

        internal void AddInnerMethod(MethodTracer method)
        {
            InnerMethods.Add(method);
        }

        internal MethodTracer(string methodName , string methodClassName)
        {
            name = methodName;
            className = methodClassName;
            stopwatch = new Stopwatch();
        }

        internal void StartTrace()
        {
            stopwatch.Start();
        }

        internal void StopTrace()
        {
            stopwatch.Stop();
        }
    }
}
