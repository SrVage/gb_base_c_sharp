using System;
using UnityEditor;
using UnityEngine;

namespace DefaultNamespace
{
    public class AddComponent:EditorWindow
    {
        public static GameObject GameObject = null;
        public static GameObject OldGameObject=null;
        public static bool Physics = false;
        public static bool RendererMesh;
        public static float Scale;
        public static float OldScale;

        private void OnGUI()
        {
            GUILayout.Label("Компонентор", EditorStyles.boldLabel);
            GameObject = EditorGUILayout.ObjectField("Объект", GameObject, typeof(GameObject), true) as GameObject;
            if (GameObject != OldGameObject)
            {
                Physics = GameObject.GetComponent<Rigidbody>();
                RendererMesh = GameObject.GetComponent<MeshRenderer>();
                Scale = (GameObject.transform.localScale.x+GameObject.transform.localScale.y+GameObject.transform.localScale.z)/3;
                OldScale = Scale;
                OldGameObject = GameObject;
            }
            Physics = EditorGUILayout.Toggle("Физика", Physics);
            RendererMesh = EditorGUILayout.Toggle("Изображение объекта", RendererMesh);
            Scale = EditorGUILayout.Slider("Масштаб", Scale, 0.1f, 30);
            var button = GUILayout.Button("Изменить параметры");
            if (button)
            {
                if (Physics && !GameObject.GetComponent<Rigidbody>()) GameObject.AddComponent<Rigidbody>();
                if (!Physics)
                {
                    if (GameObject.GetComponent<Rigidbody>()) DestroyImmediate(GameObject.GetComponent<Rigidbody>());
                }
                if (RendererMesh && !GameObject.GetComponent<MeshRenderer>()) GameObject.AddComponent<MeshRenderer>();
                if (!RendererMesh)
                {
                    if (GameObject.GetComponent<MeshRenderer>()) DestroyImmediate(GameObject.GetComponent<MeshRenderer>());
                }

                var mnozhitel = Scale / OldScale;
                GameObject.transform.localScale = new Vector3(GameObject.transform.localScale.x*mnozhitel,
                    GameObject.transform.localScale.y*mnozhitel, GameObject.transform.localScale.z*mnozhitel);
                OldScale = Scale;
            }
        }
    }
}