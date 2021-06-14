using System;
using System.Collections;
using System.Collections.Generic;
using Code;
using Code.Controller;
using UnityEngine;
using UnityEngine.UI;
using Object = UnityEngine.Object;

public class StartScreen : MonoBehaviour
{
    public event Action Load;
    [SerializeField] private GameObject gameController;
    [SerializeField] private InputField _name;

    public void NewGame()
    {
        PlayerName.Name = _name.text;
        Instantiate(gameController);
        FindObjectOfType<UI>().ChangePlayerName();
        gameObject.SetActive(false);
    }

    public void LoadGame()
    {
        var gameControl = Instantiate(gameController);
        Invoke(nameof(LoadEvent), 1.0f);
        
    }

    private void LoadEvent()
    {
        Load();
        FindObjectOfType<UI>().ChangePlayerName();
        gameObject.SetActive(false);
    }
    
    

}
