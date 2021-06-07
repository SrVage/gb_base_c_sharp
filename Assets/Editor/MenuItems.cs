using UnityEditor;
using UnityEngine;

namespace DefaultNamespace
{
    public class MenuItems
    {
        [MenuItem("Для гейм дизайнера/Добавление-удаление компонентов &G")]
        private static void MenuItem()
        {
            EditorWindow.GetWindow(typeof(AddComponent), false);
        }
    }
}