using System;
using Code.Controller;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

namespace Code
{
    public sealed class RadarObj:MonoBehaviour
    {
        [SerializeField] private Image _ico;
        private GameController _gameController;

        private void Awake()
        {
            _gameController = Object.FindObjectOfType<GameController>();
        }

        private void OnValidate()
        {
            _ico = Resources.Load<Image>("MiniMap/RadarObject");
        }

        private void OnDisable()
        {
            _gameController.DisableObj(gameObject);
        }

        private void OnEnable()
        {
            Invoke(nameof(Enable), 0.5f);
        }

        private void Enable()
        {
            _gameController.EnableObj(gameObject, _ico);
        }

    }
}