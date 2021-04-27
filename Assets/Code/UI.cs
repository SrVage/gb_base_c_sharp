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
        private Player _player;
        private int _score;

        // Start is called before the first frame update
        void Start()
        {
            _player = FindObjectOfType<Player>();
            _player.DestroyPlayer += EndGame;
            WinBonus [] comp = FindObjectsOfType<WinBonus>();
            foreach (var a in comp)
            {
                a.GetBonus += ChangeScores;
            }
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