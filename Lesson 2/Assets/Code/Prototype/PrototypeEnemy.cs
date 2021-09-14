using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor.Build.Player;
using UnityEngine;

public static class Prototype
    {
        public static T CopyObj<T>(this T self) where T : class
        {
            if (!typeof(T).IsSerializable)
            {
                throw new Exception("Obj non serializeble");
            }
            if (ReferenceEquals(self, null))
            {
                return default;
                
            }
            var formatter = new BinaryFormatter();
            using (var stream = new MemoryStream())
            {
                formatter.Serialize(stream,self);
                stream.Seek(0, SeekOrigin.Begin);
                return (T)formatter.Deserialize(stream);
            }
        }
    }

