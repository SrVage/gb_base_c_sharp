using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Code
{
    public class UI : MonoBehaviour
    {
        [SerializeField] private Text _scores;
        [SerializeField] private Text _playerName;
        private PlayerController _playerController;
        private int _score;

        // Start is called before the first frame update
        void Start()
        {
            /*_playerController = new PlayerController(null);
            _playerController.DestroyPlayer += EndGame;*/
            WinBonus [] comp = FindObjectsOfType<WinBonus>();
            foreach (var a in comp)
            {
                a.GetBonus += ChangeScores;
            }
        }

        public void ChangePlayerName()
        {
            _playerName.text = PlayerName.Name;
        }

        private void EndGame()
        {
            _scores.text = "End of Game";
        }

        public void ChangeScores(string name)
        {
            _score++;
            _scores.text = _score.ToString();
        }
    }
}