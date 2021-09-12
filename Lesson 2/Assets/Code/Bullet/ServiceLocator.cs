using System;
using System.Collections.Generic;
using UnityEngine;

namespace Code.Bullet
{
    public static class ServiceLocator
    {
        private static Dictionary<Type, object> _serviceLocator = new Dictionary<Type, object>();

        public static T GetObject<T>()
        {
            if (_serviceLocator.ContainsKey(typeof(T)))
            {
                object obj = _serviceLocator[typeof(T)];
                if (obj is T result)
                {
                    return result;
                }
            }

            return default;
        }
    

    public static void AddObject<T>(T obj)
        {
            if (_serviceLocator.ContainsKey(typeof(T)))
            {
                Debug.Log("Error");
            }
            _serviceLocator.Add(typeof(T),obj);
        }
    }
}