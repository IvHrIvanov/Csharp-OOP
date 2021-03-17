using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string RevealPrivateMethods(string className)
        {
            Type fieldInfo = Type.GetType(className);
            MethodInfo[] method = fieldInfo.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"All Private Methods of Class: {className}");
            sb.AppendLine($"Base Class: {fieldInfo.BaseType.Name}");
            foreach (MethodInfo item in method)
            {
                sb.AppendLine(item.Name);
            }
            return sb.ToString().TrimEnd();
        }
        public string StealFieldInfo(string name, params string[] arr)
        {
            Type classType = Type.GetType(name);
            FieldInfo[] classField = classType.GetFields((BindingFlags)60);
            StringBuilder sb = new StringBuilder();

            Object classInstance = Activator.CreateInstance(classType, new object[] { });
            sb.AppendLine($"Class under investigation: {name}");
            foreach (FieldInfo field in classField.Where(x => arr.Contains(x.Name)))
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }
            return sb.ToString().TrimEnd();

        }
        public string AnalyzeAccessModifiers(string className)
        {
            Type classType = Type.GetType(className);
            FieldInfo[] classField = classType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
            MethodInfo[] classPublicMethod = classType.GetMethods(BindingFlags.Instance | BindingFlags.Public);
            MethodInfo[] classNonPublicMethod = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
            StringBuilder sb = new StringBuilder();

            foreach (FieldInfo fieldInfo in classField)
            {
                sb.AppendLine($"{fieldInfo.Name} must be private!");

            }
            foreach (MethodInfo method in classPublicMethod.Where(m => m.Name.StartsWith("get")))
            {
                sb.AppendLine($"{method.Name} have to be public");
            }
            foreach (MethodInfo method in classNonPublicMethod.Where(m => m.Name.StartsWith("set")))
            {
                sb.AppendLine($"{method.Name} have to be private!");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
