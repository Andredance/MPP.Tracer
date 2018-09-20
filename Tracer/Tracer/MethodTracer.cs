using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace Tracer
{
    [DataContract]
    internal class MethodTracer
    {
        private List<MethodTracer> innerMethods;
        private string name;
        private string className;
        private Stopwatch stopwatch = new Stopwatch();

        [DataMember(Name = "name", Order = 0)]
        internal string Name {
            get
            {
                return name;
            }
            private set { }
        }

        [DataMember(Name = "class", Order = 1)]
        internal string ClassName
        {
            get
            {
                return className;
            }
            private set { }
        }

        internal long Time
        {
            get
            {
                if (!stopwatch.IsRunning)
                {
                    return stopwatch.ElapsedMilliseconds;
                } else
                {
                    throw new Exception("Stopwatch is running");
                }
            }
        }

        [DataMember(Name = "time", Order = 2)]
        internal string TimeFormated
        {
            get
            {
                return Time.ToString() + "ms";
            }

            private set { }
        }
        
        [DataMember(Name= "methods", Order = 3)]
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
