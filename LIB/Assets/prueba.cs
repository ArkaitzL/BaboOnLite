
using UnityEngine;
using System.Collections.Generic;

using BaboOnLite;

public class prueba : MonoBehaviour
{
    //[SerializeField] Dictionary<string, int> Diccionario = new Dictionary<string, int>();
    //[SerializeField] string[,] Array2d = new string[0,0];

    void Start()
    {
        //ArrayList1D();
        //ArrayList2D();

        //Objetos();
        //String();
        //Data();
        //Audio();
    }

    private void Update()
    {
        //Unity();
    }

    void ArrayList1D() {
        int[] numerosA = { 1, 2, 3, 4, 5, 0, -1, -2, 6 };
        //List<int> numerosL = new List<int>() { 1, 2, 3, 4, 5, 0, -1, -2 };

        // String---------------------------------
        //Debug.Log(numerosA.inString());
        //Debug.Log(numerosL.inString());
        // ForEach--------------------------------

        //numerosA.ForEach(num => Debug.Log($"{num}"));
        //numerosL.ForEach((num, index) => Debug.Log($"{num} y esta en la pos {index}"));

        // Every----------------------------------

        //Debug.Log(numerosA.Every(num => num % 2 == 0));
        //Debug.Log(numerosL.Every(num => num % 2 == 0));

        // Some------------------------------------

        //Debug.Log(numerosA.Some(num => num % 2 == 0));
        //Debug.Log(numerosL.Some(num => num % 2 == 0));

        // Filter----------------------------------

        //List<int> nuevoArrayL = numerosL.Filter(num => num <= 3);
        //Debug.Log(nuevoArrayL.String());

        //int[] nuevoArrayA = numerosA.Filter(num => num <= 3);
        //Debug.Log(nuevoArrayA.String());

        // Map-------------------------------------

        //int[] nuevoArrayA = numerosA.Map(num => num * 2);
        //string[] nuevoArrayA = numerosA.Map(num => num + "Hola");
        //Debug.Log(nuevoArrayA.String());

        //List<int> nuevoArrayL = numerosL.Map(num => num + 1);
        //List<string> nuevoArrayL = numerosL.Map(num => num + "Hola");
        //Debug.Log(nuevoArrayL.String());

        // Sort-------------------------------------

        //List<int> nuevoArrayL = numerosL.Order();
        //List<int> nuevoArrayL = numerosL.Order((n1, n2) => n1.CompareTo(n2));
        //Debug.Log(nuevoArrayL.String());

        //int[] nuevoArrayA = numerosA.Order();
        //int[] nuevoArrayA = numerosA.Order((n1, n2) => n1.CompareTo(n2));
        //Debug.Log(nuevoArrayA.String());

        // inArray y inList---------------------------
        //"[1,2,3,4,5]"
        //"[hola, adios]"
        //"[false, true, 1, 23]".inArray<bool>().ForEach(e => {
        //    Debug.Log(e);
        //});
    }

    void ArrayList2D() {
        //int[,] numerosA = {
        //    { 1, 2, 3, 4, 5 },
        //    { 5, 4, 3, 2, 1 }
        //};
        //List<List<int>> numerosL = new List<List<int>>(){
        //    new List<int>{ 1, 2, 3, 4, 5 },
        //    new List<int>{ 5, 4, 3, 2, 1 }
        //};

        // Flat----------------------------------       //()->Normal
        // String--------------------------------       //()->Normal
        // ForEach-------------------------------       //(func(item, y, x))*
        //Con flat puedes usar some y every
        // Filter-------------------------------        //()->Normal
        // Map----------------------------------        //()->Normal

        //*IDEA*->Añadir a todos una opcion para elegir el Y
    }

    void Objetos() {
        //var objeto1 = (
        //    nombre: "Manolo",
        //    numeros: new[] { 
        //        0, 1, 2
        //    }
        //);

        //Debug.Log($"{objeto.nombre} su primer numero es: {objeto.numeros[0]}");

    }

    void String() {
        // Log();
        //"Este es mi mensaje".Log();
        //string miMens = "Este es mi mensaje".Log();
        //Bug.Log(Color.red);
        //Bug.Log();
        //int y = 9;
        //int x = 1 + y.Log();
        //x.Log();

    }

    void Data() {
        //Save.Data;
    }

    void Unity() {
        //Debug.Log(transform.MoveISO2D(10, 10));
        //transform.MoveISO2D();
        //transform.MoveForward2D(10, 10);
        //transform.MoveForward2D();

        //Debug.Log(transform.MoveISO3D(10, 10));
        //transform.MoveISO3D();
        //transform.MoveForward3D(10, 10);
        //transform.MoveForward3D();
    }

    void Audio() {
        //Bug.Log();
        //Sound.Create.Audio(0);
        //Sound.Create.Audio(new int[] { 0, 1 });
        //Sound.Create.Audio(new int[] { 0, 1 }, new Vector3(0, 10, 0), true);
        //Sound.Create.Audio(new int[] { 0 }, new Vector3(0, 10, 0), true);

        //Sound.Create.Vibration(3);
    }

    public void Logs() {
        Debug.Log("Mensaje de prueba para el funcionamieto de la consola no se que mas poner :)");
        Debug.LogError("Mensaje de prueba para el funcionamieto de la consola no se que mas poner :)");
        Debug.LogWarning("Mensaje de prueba para el funcionamieto de la consola no se que mas poner :)");
    }
}
