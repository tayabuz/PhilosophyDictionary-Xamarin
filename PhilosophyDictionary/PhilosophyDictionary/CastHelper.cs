using System;
using System.Collections.Generic;

namespace Philosophy
{
    public static class CastHelper
    {
        public static KeyValuePair<object, object> CastToKeyValuePairFromObject(Object obj)
        {
            var type = obj.GetType();
            if (type.IsGenericType)
            {
                if (String.Compare(type.Name , "KeyValuePair`2") == 0)
                {
                    var key = type.GetProperty("Key");
                    var value = type.GetProperty("Value");
                    var keyObj = key.GetValue(obj, null);
                    var valueObj = value.GetValue(obj, null);
                    return new KeyValuePair<object, object>(keyObj, valueObj);
                }
            }
            throw new ArgumentException(" ### -> public static KeyValuePair<object, object> CastFrom(Object obj) : Error : obj argument must be KeyValuePair<,>");
        }
    }
}
