using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensions.Object
{
    public static partial class ObjectExtensions
    {
        public static T EnsureNot<T>(this T obj, Func<T, bool> condition, Func<T> getReplacement)
        {
            if (condition == null)
                throw new ArgumentNullException(nameof(condition));
            return obj.EnsureNot(condition(obj), getReplacement);
        }

        public static T EnsureNot<T>(this T obj, Func<T, bool> condition, T replacement)
        {
            if (condition == null)
                throw new ArgumentNullException(nameof(condition));
            return obj.EnsureNot(condition(obj), replacement);
        }

        public static T EnsureNot<T>(this T obj, bool condition, Func<T> getReplacement)
        {
            if (getReplacement == null)
                throw new ArgumentNullException(nameof(getReplacement));

            if (condition)
                return getReplacement();
            return obj;
        }

        public static T EnsureNot<T>(this T obj, bool condition, T replacement) => (condition) ? replacement : obj;
    }
}
