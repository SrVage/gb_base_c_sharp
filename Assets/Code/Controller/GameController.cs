using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Controller
{
    public sealed class GameController:MonoBehaviour
    {
        public event Action<GameObject> Remove;
        public event Action<GameObject, Image> Register;
        private Controllers _controllers;
        private float _deltaTime;

        private void Start()
        {
            _controllers = new Controllers();
            GameInitialization ga = new GameInitialization(_controllers);
            _controllers.Initialization();
        }

        private void Update()
        {
            _deltaTime = Time.deltaTime;
            _controllers.Execute(_deltaTime);
        }

        public void EnableObj(GameObject gameObject, Image ico)
        {
            Register.Invoke(gameObject, ico);
        }
        
        public void DisableObj(GameObject gameObject)
        {
            Remove.Invoke(gameObject);
        }
    }
}