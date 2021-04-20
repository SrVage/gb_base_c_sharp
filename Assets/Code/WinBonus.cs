using UnityEngine;

namespace Code
{
    public class WinBonus:Bonus, INeedGetForWin
    {
        private bool _isActive = true;
        private Vector3 _position;
        private SceneObjects SceneObjects = new SceneObjects();
        
        public WinBonus (Vector3 position)
        {
            _position = position;
            _isActive = true;
            
        }

        public void GetWinBonus()
        {
            SceneObjects.GetWinBonus();
        }
    }
}