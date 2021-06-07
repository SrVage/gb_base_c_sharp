using Code;
using UnityEditor;
using UnityEngine;

namespace DefaultNamespace
{
    [CustomEditor(typeof(RadarView))]
    public class RadarExtension: UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            //DrawDefaultInspector();
            RadarView radarView = (RadarView) target;
            radarView._map = EditorGUILayout.Toggle("Включение карты", radarView._map);
            radarView._size = EditorGUILayout.IntSlider("Размер радара", radarView._size, 50, 300);
            if (radarView._map)
            {
                radarView._mapObject =
                    EditorGUILayout.ObjectField("Картинка карты", radarView._mapObject, typeof(GameObject), false) as
                        GameObject;
            }
        }
    }
}