using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensions.Object
{
    public static partial class ObjectExtensions
    {
        public static TReturn TransformIf<T, TReturn>(this T obj, Func<bool> condition, Func<T, TReturn> action)
        {
            return obj.TransformIf(condition?.Invoke() ?? false, action);
        }

        /// <summary>
        /// Take an object and transform it into something else.
        /// </summary>
        /// <typeparam name="T">Type of the object.</typeparam>
        /// <typeparam name="TReturn">Type of the returned objet.</typeparam>
        /// <param name="obj">Object to transform</param>
        /// <param name="condition"></param>
        /// <param name="action">Action transforming the object.</param>
        /// <returns>The object transformed.</returns>
        public static TReturn TransformIf<T, TReturn>(this T obj, bool condition, Func<T, TReturn> action)
        {
            if (condition)
                return obj.Transform(action);
            return default(TReturn);
        }

        /// <summary>
        /// Take an object and transform it into something else.
        /// </summary>
        /// <typeparam name="T">Type of the object.</typeparam>
        /// <typeparam name="TReturn">Type of the returned objet.</typeparam>
        /// <param name="obj">Object to transform</param>
        /// <param name="action">Action transforming the object.</param>
        /// <returns>The object transformed.</returns>
        public static TReturn Transform<T, TReturn>(this T obj, Func<T, TReturn> action)
        {
            if (action == null)
                throw new ArgumentNullException(nameof(action));
            return action(obj);
        }
    }
}
