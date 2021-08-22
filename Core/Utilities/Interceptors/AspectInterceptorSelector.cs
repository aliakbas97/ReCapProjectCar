using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Linq;

namespace Core.Utilities
{
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var ClassAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>(true).ToList();

            var methodAttributes = type.GetMethod(method.Name)
                .GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
            ClassAttributes.AddRange(methodAttributes);

            return ClassAttributes.OrderBy(x => x.priority).ToArray();
        }

       
    }
}
