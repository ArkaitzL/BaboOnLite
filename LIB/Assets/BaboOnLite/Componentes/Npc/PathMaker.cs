using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace BaboOnLite
{
    [DefaultExecutionOrder(0)]
    [AddComponentMenu("BaboOnLite/ Npc/PathMaker (NPC)")]
    [DisallowMultipleComponent]
    //[HelpURL("")]
    public class PathMaker : MonoBehaviour
    {
        [SerializeField] List<Vector3> position = new List<Vector3>();
        [SerializeField] string pathName = "path";

        public void Add()
        {
            position.Add(transform.position);
        }

        public void Save()
        {
            Path path = ScriptableObject.CreateInstance<Path>();
            path.positions = position.ToArray();

            AssetDatabase.CreateAsset(path, $"Assets/{pathName}.asset");
        }
    }

}