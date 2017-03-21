using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using System.Runtime.CompilerServices;

namespace APMT.Areas.Company.Models
{
    public class ReflectionController
    {
        public List<Type> GetControllers(string namespaces)
        {
            List<Type> lstController = new List<Type>();
            Assembly assembly = Assembly.GetExecutingAssembly();
            IEnumerable<Type> types = assembly.GetTypes().Where(type => typeof(Controller).IsAssignableFrom(type) && type.Namespace.Contains(namespaces)).OrderBy(x => x.Name);
            return types.ToList();

        }
        public List<string> GetAction(Type controller)
        {
            List<string> lstAction = new List<string>();
            IEnumerable<MemberInfo> memberInfo = controller.GetMethods(BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public)
                .Where(m => !m.GetCustomAttributes(typeof(CompilerGeneratedAttribute), true).Any())
                .OrderBy(x => x.Name);
            foreach (MemberInfo method in memberInfo)
            {
                if (method.ReflectedType.IsPublic && !method.IsDefined(typeof(NonActionAttribute)))
                {
                    lstAction.Add("\t" + method.Name.ToString());
                }
            }
            return lstAction;
        }
    }
}
