using System;
using Code.Controller;
using UnityEngine;

namespace Code
{
    public class RadarView:MonoBehaviour
    {
        public int _size;
        public bool _map;
        public GameObject _mapObject;

        private void Awake()
        {
            GetComponent<RectTransform>().sizeDelta = new Vector2(_size, _size);
            _mapObject.SetActive(_map);
        }

        public void Draw(RadarObject radarObject, Vector3 radarPos)
        {
            radarObject.Icon.transform.SetParent(transform);
            radarObject.Icon.transform.position = new Vector3(radarPos.x,
                radarPos.z, 0) + transform.position;
        }
    }
}