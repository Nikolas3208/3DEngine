using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3DEngine.Core.Serialize
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class SerializeField : Attribute { }

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class HideSerialize : Attribute { }
}
