using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy 
    {

        public string StealFieldInfo(string name,params string[] arr)
        {
            Type classType = Type.GetType(name);
            FieldInfo[] classField = classType.GetFields((BindingFlags)60);
            StringBuilder sb = new StringBuilder();
           
            Object classInstance = Activator.CreateInstance(classType, new object[] {});
            sb.AppendLine($"Class under investigation: {name}");
            foreach (FieldInfo field in classField.Where(x=> arr.Contains(x.Name)))
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }
            return sb.ToString().TrimEnd();

        }
    }
}
