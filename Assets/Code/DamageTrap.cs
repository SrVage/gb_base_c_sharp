using UnityEngine;

namespace Code
{
    public class DamageTrap:Trap
    {
        private bool _isActive;
        private Vector3 _position;
        private float _damage;
        private Player _player;

        public DamageTrap(Vector3 position)
        {
            _position = position;
            _damage = Random.Range(0.2f, 1.5f);
            _isActive = true;
        }

        protected override void Damage()
        {
            base.Damage();
            _player.Damage(_damage);
        }
    }
}