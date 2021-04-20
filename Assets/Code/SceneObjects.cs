using System;
using System.Collections;
using System.Collections.Generic;
using Code;
using UnityEngine;
using static UnityEngine.Debug;

public class SceneObjects : MonoBehaviour
{
    private WinBonus[] _winBonus;
    private SceneObjects[] _sceneObjects;
    private Player _player;

    private int _countWinBonus;

    private PlayerController _playerController;
    // Start is called before the first frame update
    void Start()
    {
        _winBonus = FindObjectsOfType<WinBonus>();
        _countWinBonus = _winBonus.Length;
        _sceneObjects = GameObject.FindObjectsOfType<SceneObjects>();
        _player = GameObject.FindObjectOfType<Player>();
        _playerController = new PlayerController(_player);
    }

    // Update is called once per frame
    void Update()
    {
        for (var i = 0; i < _sceneObjects.Length; i++)
        {
            var sceneObject = _sceneObjects[i];
            if (sceneObject == null) continue;
            if (sceneObject is IPingPong pingPong) pingPong.PingPong();
        }
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
        Destroy(other.gameObject);
    }
}
