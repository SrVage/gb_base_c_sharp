using UnityEngine;

namespace Code
{
    public class HealthBonus:Bonus
    {
        private bool _isActive = true;
        private Vector3 _position;
        private float _hp = 1.5f;
        private Player _player;
        
        public HealthBonus(Vector3 position)
        {
            _position = position;
            _hp = Random.Range(0.2f, 2f);
            _isActive = true;
        }

        protected override void SetBonus()
        {
            base.SetBonus();
            _player.RestoreHealth(_hp);
        }
    }
}