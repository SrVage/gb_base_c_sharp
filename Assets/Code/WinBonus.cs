using System;
using UnityEngine;

namespace Code
{
    public class WinBonus:Bonus, INeedGetForWin
    {
        public event Action <string> GetBonus;
        
        private bool _isActive = true;
        private Vector3 _position;
        private SceneObjects SceneObjects;
        
        public WinBonus (Vector3 position)
        {
            _position = position;
            _isActive = true;
        }
        
        public void GetWinBonus()
        {
            GetBonus?.Invoke(gameObject.name);
        }
    }
}