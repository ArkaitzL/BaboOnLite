using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace baboOn
{

    internal static class Otros 
    {
        internal static T Get<T>(this IEnumerable<T> array, int i) => array.ToArray()[i];
    }

    public static class Array1D
    {
        //Convierte de array a texto
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
        //Bucle de array
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
        //Devuelve true si todas las condiciones son correctas
        public static bool Every<T>(this IEnumerable<T> array, Func<T, bool> func)
        {
            foreach (T item in array)
            {
                if (!func(item)) return false;
            }
            return true;
        }
        //Devuelve true si alguna condicion es correcta
        public static bool Some<T>(this IEnumerable<T> array, Func<T, bool> func)
        {
            foreach (T item in array)
            {
                if (func(item)) return true;
            }
            return false;
        }
        //Devuelve los elementos que cumplan la condicion
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
        //Devuelve el array modificado
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
        //Devuelve el array ordenado
        public static IEnumerable<T> _Sort<T>(this IEnumerable<T> array)
        {
            T[] result = array.ToArray();
            Array.Sort(result);
            return result;
        }
        public static T[] Order<T>(this T[] array) => _Sort(array).ToArray();
        public static List<T> Order<T>(this List<T> array) => _Sort(array).ToList();
        //Devuelve el array ordenado segun la condicion
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

    public static class Bug {
        //Muestra un log del string y lo devuelve
        public static string Log(this string text) {
            Debug.Log(text);
            return text;
        }
        //Muestra un log con informacion basica
        public static void Log(Color color = default)
        {
            string message = "<b>**-------**</b>";
            string colorHex = ColorUtility.ToHtmlStringRGBA((color == default) ? Color.white : color);

            Debug.LogFormat("<color=#{0}>{1}</color>", colorHex, message);
        }
    }

    public static class Unity
    {
        //Movimiento basico de unity2D
        public static bool Move2D(this Transform transform, float velocity = 10, float rotation = 10)
        {

            float x = Input.GetAxisRaw("Horizontal");
            float y = Input.GetAxisRaw("Vertical");

            if (x != 0f || y != 0f)
            {
                Vector3 direction = new Vector2(
                    x,
                    y
                ).normalized;

                transform.position += direction * (velocity/2) * Time.deltaTime;
                float angle = Mathf.Atan2(
                    direction.y,
                    direction.x
                ) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Lerp(
                    transform.rotation,
                    Quaternion.Euler(0f, 0f, angle - 90f),
                    rotation * Time.deltaTime
                );

                return true;
            }

            return false;

        }
        //Moviemiento para adelante
        public static void MoveForward(this Transform transform, float velocity = 10, float rotation = 10)
        {
            transform.Translate(
                Vector3.up * (velocity / 5) * Time.deltaTime,
                Space.Self
            );

            float x = Input.GetAxisRaw("Horizontal");

            if (x != 0f)
            {
                float angleV = x * rotation * Time.deltaTime;
                transform.Rotate(0f, 0f, -(angleV*15));
            }

        }
    }

}