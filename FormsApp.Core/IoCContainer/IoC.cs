using FormsApp.Core.Exceptions;

using System;
using System.Collections.Generic;

namespace FormsApp.Core.IoCContainer
{
    public static class IoC
    {

        #region Private Members

        /// <summary>
        /// The dictionary of all the objects injected in here
        /// </summary>
        private static Dictionary<Type, dynamic> InjectedObjects { get; set; } = new Dictionary<Type, dynamic>();

        #endregion

        #region Public Properties



        #endregion

        #region Public Methods

        /// <summary>
        /// Registers a static type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public static void RegisterStatic<T>()
            where T : class, new()
        {

            if (InjectedObjects.ContainsKey(typeof(T)))
                throw new DuplicateKeyException("Object with same type has already been injected into the container.");

            T newInst = new T();
            InjectedObjects.Add(typeof(T), newInst);
        }

        /// <summary>
        /// Registers a specific instance for the specified type 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="inst"></param>
        public static void RegisterStatic<T>(T inst)
        {

            if (InjectedObjects.ContainsKey(typeof(T)))
                throw new DuplicateKeyException("Object with same type has already been injected into the container.");

            InjectedObjects.Add(typeof(T), inst);
        }

        /// <summary>
        /// Gets the registered object from the injected objects of the specified type
        /// </summary>
        /// <typeparam name="T"> The type of the object to retreive </typeparam>
        /// <returns>Returns object if the type has been injected else returns null</returns>
        public static T Get<T>()
            where T : class
        {
            dynamic value;
            InjectedObjects.TryGetValue(typeof(T), out value);
            return value;
        }

        #endregion

    }
}
