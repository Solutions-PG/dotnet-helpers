using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensions.Object
{
    public static partial class ObjectExtensions
    {
        public static T EnsureNotNull<T>(this T obj) where T : new() => obj.EnsureNot(obj == null, () => new T());
        public static T EnsureNotNull<T>(this T obj, Func<T> getReplacement) => obj.EnsureNot(obj == null, getReplacement);
        public static T EnsureNotNull<T>(this T obj, T replacement) => obj.EnsureNot(obj == null, replacement);
    }
}
