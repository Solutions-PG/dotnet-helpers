using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensions.Object
{
    public static partial class ObjectExtensions
    {
        #region " Public methods "

        /// <summary>
        /// Execute an action if the condition is true and return the caller.
        /// </summary>
        /// <typeparam name="T">Type of the caller</typeparam>
        /// <param name="obj">Caller</param>
        /// <param name="condition">Condition to determine if the action must be called.</param>
        /// <param name="action">Action to be executed</param>
        /// <exception cref="ArgumentNullException">Thrown when the parameter "condition" is null</exception>
        /// <exception cref="ArgumentNullException">Thrown when the parameter "action" is null</exception>
        /// <returns>Caller</returns>
        public static T DoIf<T>(this T obj, Func<bool> condition, Action action)
        {
            if (condition == null)
                throw new ArgumentNullException(nameof(condition));
            if (action == null)
                throw new ArgumentNullException(nameof(action));

            return obj.DoIf_(condition(), action);
        }

        /// <summary>
        /// Execute an action if the condition is true and return the caller.
        /// </summary>
        /// <typeparam name="T">Type of the caller</typeparam>
        /// <param name="obj">Caller</param>
        /// <param name="condition">Condition to determine if the action must be called.</param>
        /// <param name="action">Action to be executed</param>
        /// <exception cref="ArgumentNullException">Thrown when the parameter "action" is null</exception>
        /// <returns>Caller</returns>
        public static T DoIf<T>(this T obj, bool condition, Action action)
        {
            if (action == null)
                throw new ArgumentNullException(nameof(action));

            return obj.DoIf_(condition, action);
        }

        /// <summary>
        /// Execute an action and return the caller.
        /// </summary>
        /// <typeparam name="T">Type of the caller</typeparam>
        /// <param name="obj">Caller</param>
        /// <param name="action">Action to be executed</param>
        /// <exception cref="ArgumentNullException">Thrown when the parameter "action" is null</exception>
        /// <returns>Caller</returns>
        public static T Do<T>(this T obj, Action action)
        {
            if (action == null)
                throw new ArgumentNullException(nameof(action));

            return obj.Do_(action);
        }

        #endregion //Public methods

        #region " Private methods "

        /// <summary>
        /// Execute an action and return the caller.
        /// </summary>
        /// <typeparam name="T">Type of the caller</typeparam>
        /// <param name="obj">Caller</param>
        /// <param name="action">Action to be executed</param>
        /// <exception cref="ArgumentNullException">Thrown when the parameter "action" is null</exception>
        /// <returns>Caller</returns>
        public static T DoIf_<T>(this T obj, bool condition, Action action)
        {
            if (condition) action();
            return obj;
        }

        /// <summary>
        /// Execute an action and return the caller.
        /// </summary>
        /// <typeparam name="T">Type of the caller</typeparam>
        /// <param name="obj">Caller</param>
        /// <param name="action">Action to be executed</param>
        /// <exception cref="ArgumentNullException">Thrown when the parameter "action" is null</exception>
        /// <returns>Caller</returns>
        private static T Do_<T>(this T obj, Action action)
        {
            action();
            return obj;
        }

        #endregion //Private methods
    }
}
