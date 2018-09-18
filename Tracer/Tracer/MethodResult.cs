using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracer
{
    internal class MethodResult
    {
        private List<MethodResult> innerMethods;
        private string name;
        private string className;
        private long time;

        internal string Name { get; private set;}

        internal string ClassName { get; private set; }

        internal long Time { get; set; }
        
        internal List<MethodResult> InnerMethods
        {
            get
            {
                if (innerMethods == null)
                {
                    innerMethods = new List<MethodResult>();
                }
                return innerMethods;
            }
        }

        internal void AddInnerMethod(MethodResult method)
        {
            innerMethods.Add(method);
        }

        internal MethodResult(string methodName , string methodClassName)
        {
            name = methodName;
            className = methodClassName;
        }
    }
}
