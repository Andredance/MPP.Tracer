using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracer
{
    internal class MethodTracer
    {
        private List<MethodTracer> innerMethods;
        private string name;
        private string className;
        private long time;

        internal string Name { get; private set;}

        internal string ClassName { get; private set; }

        internal long Time { get; set; }
        
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
            innerMethods.Add(method);
        }

        internal MethodTracer(string methodName , string methodClassName)
        {
            name = methodName;
            className = methodClassName;
        }
    }
}
