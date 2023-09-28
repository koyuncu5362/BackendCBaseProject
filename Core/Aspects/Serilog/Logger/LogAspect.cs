using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Logger;
using Core.Utilities.Interceptors;
using System.Reflection;

namespace Core.Aspects.Serilog.Logger
{
    public class LogAspect:MethodInterception
    {
        public override void Intercept(IInvocation invocation)
        {
            string detail = "";
    
            
            string methodName = invocation.Method.Name;

            var argument = invocation.Arguments[0];
            Type type = argument.GetType();
            PropertyInfo[] properties = type.GetProperties();
            var kind = type.ToString().Split('.').Last();
            foreach (var property in properties)
            {
                string propertyName = property.ToString().Split(" ").Last();
                object value = property.GetValue(argument, null);
                detail += propertyName +  " " +  value + " ";
            }
            LoggerTool.LoggerService(detail,kind,methodName);
            invocation.Proceed();
        }
    }
}
