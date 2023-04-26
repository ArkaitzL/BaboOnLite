using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace onFunc
{

    internal static class Otros 
    {
        internal static T Get<T>(this IEnumerable<T> array, int i) => array.ToArray()[i];
    }

    public static class Array1D
    {
        public static string String<T>(this IEnumerable<T> array)
        {
            string text = "[";
            for (int i = 0; i < array.Count(); i++)
            {
                text += (i != array.Count() - 1)
                    ? $"{array.Get(i)},"
                    : $"{array.Get(i)}";
            }
            return text + "]";
        }

        public static void ForEach<T>(this IEnumerable<T> array, Action<T> func)
        {
            for (int i = 0; i < array.Count(); i++)
            {
                func(array.Get(i));
            }
        }
        public static void ForEach<T>(this IEnumerable<T> array, Action<T, int> func)
        {
            for (int i = 0; i < array.Count(); i++)
            {
                func(array.Get(i), i);
            }
        }

        public static bool Every<T>(this IEnumerable<T> array, Func<T, bool> func)
        {
            foreach (T item in array)
            {
                if (!func(item)) return false;
            }
            return true;
        }

        public static bool Some<T>(this IEnumerable<T> array, Func<T, bool> func)
        {
            foreach (T item in array)
            {
                if (func(item)) return true;
            }
            return false;
        }

        private static IEnumerable<T> _Filter<T>(IEnumerable<T> array, Func<T, bool> func)
        {
            List<T> result = new List<T>();
            for (int i = 0; i < array.Count(); i++)
            {
                if (func(array.Get(i))) result.Add(array.Get(i));
            }
            return result;
        }
        public static T[] Filter<T>(this T[] array, Func<T, bool> func) => _Filter(array, func).ToArray();
        public static List<T> Filter<T>(this List<T> array, Func<T, bool> func) => _Filter(array, func).ToList();

        public static IEnumerable<T2> _Map<T1, T2>(IEnumerable<T1> array, Func<T1, T2> func)
        {
            List<T2> result = new List<T2>();
            for (int i = 0; i < array.Count(); i++)
            {
                result.Add(func(array.Get(i)));
            }
            return result;
        }
        public static T2[] Map<T1, T2>(this T1[] array, Func<T1, T2> func) => _Map(array, func).ToArray();
        public static List<T2> Map<T1, T2>(this List<T1> array, Func<T1, T2> func) => _Map(array, func).ToList();

        public static IEnumerable<T> _Sort<T>(this IEnumerable<T> array)
        {
            T[] result = array.ToArray();
            Array.Sort(result);
            return result;
        }

        public static T[] Order<T>(this T[] array) => _Sort(array).ToArray();
        public static List<T> Order<T>(this List<T> array) => _Sort(array).ToList();

        public static IEnumerable<T> _Sort<T>(this IEnumerable<T> array, Comparison<T> func) 
        {
            T[] result = array.ToArray();
            Array.Sort(result, func);
            return result;
        }

        public static T[] Order<T>(this T[] array, Comparison<T> func) => _Sort(array, func).ToArray();
        public static List<T> Order<T>(this List<T> array, Comparison<T> func) => _Sort(array, func).ToList();



    }

    public static class Array2D 
    { 
    
    }

    public static class String {
        public static string Log(this string text) {
            Debug.Log(text);
            return text;
        }
    }

}