using UnityEngine;

namespace Code
{
    public class DamageTrap:Trap, ISetDamage
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

        public void Damage()
        {
            _damage = Random.Range(0.2f, 1.5f);
            print(_damage);
            _player = GameObject.FindObjectOfType<Player>().GetComponent<Player>();
            _player.GetComponent<IGetDamage>().GetDamage(_damage);
        }
    }
}