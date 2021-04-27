using System;
using System.Collections;
using System.Collections.Generic;
using Code;
using UnityEngine;
using static UnityEngine.Debug;

namespace Code
{
    
    public class SceneObjects : MonoBehaviour
    {
        private WinBonus[] _winBonus;
        private SceneObjects[] _sceneObjects;
        private Player _player;
        private int _countWinBonus;
        private PlayerController _playerController;
        private Camera _camera;

        void Start()
        {
            _winBonus = FindObjectsOfType<WinBonus>();
            _camera = Camera.main;
            _countWinBonus = _winBonus.Length;
            _sceneObjects = GameObject.FindObjectsOfType<SceneObjects>();
            _player = GameObject.FindObjectOfType<Player>();
            _playerController = new PlayerController(_player);
            _player.DestroyPlayer += ChangeCameraParent;
        }

        private void ChangeCameraParent()
        {
            _camera.transform.parent = null;
        }

        void Update()
        {
            for (var i = 0; i < _sceneObjects.Length; i++)
            {
                var sceneObject = _sceneObjects[i];
                if (sceneObject == null) continue;
                if (sceneObject is IPingPong pingPong) pingPong.PingPong();
            }

            if (_player == null) return;
            _playerController.Execute();
        }

        public void GetWinBonus()
        {
            _countWinBonus--;
            if (_countWinBonus <= 0)
            {
                Log("Win");
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<Player>()) return;
            print(other.GetType());
            if (other.gameObject.GetComponent<ISetDamage>() != null)
            {
                print("Damage");
                other.GetComponent<ISetDamage>().Damage();
            }
            if (other.gameObject.GetComponent<INeedGetForWin>() != null)
            {
                print("Win");
                other.GetComponent<INeedGetForWin>().GetWinBonus();
            }

            Destroy(other.gameObject);
        }
    }
}