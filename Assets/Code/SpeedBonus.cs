using UnityEngine;

namespace Code
{
    public class SpeedBonus:Bonus
    {
        private bool _isActive = true;
        private Vector3 _position;
        private float _changeSpeed = 1.5f;
        private Player _player;
        
        public SpeedBonus(Vector3 position)
        {
            _position = position;
            _changeSpeed = Random.Range(0.5f, 1f);
            _isActive = true;
        }

        protected override void SetBonus()
        {
            base.SetBonus();
            _player.ChangeSpeed(_changeSpeed);
        }
    }
}