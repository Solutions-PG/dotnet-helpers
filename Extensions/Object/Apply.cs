using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensions.Object
{
    public static partial class ObjectExtensions
    {
        public static T ApplyIf<T>(this T obj, Func<bool> condition, Action<T> action)
        {
            return obj.ApplyIf(condition?.Invoke() ?? false, action);
        }

        public static T ApplyIf<T>(this T obj, bool condition, Action<T> action)
        {
            if (condition)
                return obj.Apply(action);
            return obj;
        }

        public static T Apply<T>(this T obj, Action<T> action)
        {
            action?.Invoke(obj);
            return obj;
        }
    }
}
