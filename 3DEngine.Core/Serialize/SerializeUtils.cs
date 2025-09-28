using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _3DEngine.Core.Serialize
{
    public class SerializeUtils
    {
        public static IEnumerable<MemberInfo> GetInspectableMembers(Type type)
        {
            var flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

            foreach (var field in type.GetFields(flags))
            {
                if (field.IsPublic || field.GetCustomAttribute<SerializeField>() != null)
                {
                    if (field.GetCustomAttribute<HideSerialize>() == null)
                        yield return field;
                }
            }

            foreach (var prop in type.GetProperties(flags))
            {
                if (prop.GetMethod != null && prop.GetMethod.IsPublic)
                {
                    if (prop.GetCustomAttribute<HideSerialize>() == null)
                        yield return prop;
                }
            }
        }

        public static void SetMemberValue(object target, MemberInfo member, object value)
        {
            switch (member)
            {
                case FieldInfo field: field.SetValue(target, value); break;
                case PropertyInfo prop when prop.CanWrite: prop.SetValue(target, value); break;
            }
        }

        public static Type GetMemberType(MemberInfo member)
        {
            return member switch
            {
                FieldInfo f => f.FieldType,
                PropertyInfo p => p.PropertyType,
                _ => throw new NotSupportedException($"Member {member.Name} of type {member.MemberType} is not supported")
            };
        }
    }
}
