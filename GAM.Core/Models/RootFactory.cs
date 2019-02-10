using System;
using System.Reflection;

namespace GAM.Core.Models
{
    public class RootFactory<T> where T: IAggregateRoot
    {
        public static T ClassInstance(Type t)
        {
            string className = t.FullName;
            var classInstance = Assembly.LoadFrom(Assembly.GetAssembly(t).FullName).CreateInstance(className);
            return (T)classInstance;
        }
    }
}
