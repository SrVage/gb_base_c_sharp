using System;
using System.Collections.Generic;
using UnityEngine;

namespace Code.Controller
{
    public sealed class GameController:MonoBehaviour
    {
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
    }
}