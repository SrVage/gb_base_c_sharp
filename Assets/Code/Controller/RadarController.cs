using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Controller
{
    public class RadarController:IInitialization, IExecute
    {
        private Transform _playerPos; // Позиция главного героя
        private readonly float _mapScale = 2f;
        public static List<RadarObject> RadObjects = new List<RadarObject>();
        private float _time;
        private RadarView _radarView;
        private PhotoController _photoController;

        public void Initialization()
        {
            _radarView = Object.FindObjectOfType<RadarView>();
            Object.FindObjectOfType<GameController>().Register += RegisterRadarObject;
            Object.FindObjectOfType<GameController>().Remove += RemoveRadarObject;
        }

        public RadarController(GameObject player, PhotoController photoController)
        {
            _playerPos = player.transform;
            _photoController = photoController;
        }
        
        public static void RegisterRadarObject(GameObject o, Image i)
        {
            Image image = GameObject.Instantiate(i);
            RadObjects.Add(new RadarObject { Owner = o, Icon = image });
        }
        
        public static void RemoveRadarObject(GameObject o)
        {
            List<RadarObject> newList = new List<RadarObject>();
            foreach (RadarObject t in RadObjects)
            {
                if (t.Owner == o)
                {
                    GameObject.Destroy(t.Icon);
                    continue;
                }
                newList.Add(t);
            }
            RadObjects.RemoveRange(0, RadObjects.Count);
            RadObjects.AddRange(newList);
        }
        
        private void DrawRadarDots() // Синхронизирует значки на миникарте с реальными объектами
        {
            _photoController.TakeMap();
            foreach (RadarObject radObject in RadObjects)
            {
                Vector3 radarPos = (radObject.Owner.transform.position -
                                    _playerPos.position);
                float distToObject = Vector3.Distance(_playerPos.position,
                    radObject.Owner.transform.position) * _mapScale;
                float deltay = Mathf.Atan2(radarPos.x, radarPos.z) * Mathf.Rad2Deg -
                               270 - _playerPos.eulerAngles.y;
                radarPos.x = distToObject* Mathf.Cos(deltay* Mathf.Deg2Rad) * -1;
                radarPos.z = distToObject* Mathf.Sin(deltay* Mathf.Deg2Rad);
                _radarView.Draw(radObject, radarPos);
            }
        }



        public void Execute(float deltaTime)
        {
            _time += deltaTime;
            if (_time < 1f) return;
            DrawRadarDots();
            _time = 0;

        }
    }
    
    public sealed class RadarObject
    {
        public Image Icon;
        public GameObject Owner;
    }

}