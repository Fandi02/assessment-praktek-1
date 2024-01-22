using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todos.Management.Application.Common.Extensions
{
    public static class ObjectExtension
    {
        public static bool IsNotA<T>(this object obj, bool ignoreNull = false)
        {
            return ignoreNull
                ? !(obj is T)
                : !(obj is T) & obj != null;
        }
    }
}
