using UnityEngine;

namespace Code
{
    public class SpeedTrap:Trap, ISetDamage
    {
        private bool _isActive = true;
        private Vector3 _position;
        private float _changeSpeed = 1.5f;
        private Player _player;
        
        public SpeedTrap(Vector3 position)
        {
            _position = position;
            _changeSpeed = Random.Range(0.5f, 1f);
            _isActive = true;
        }
        
        public void Damage()
        {
            _player = GameObject.FindObjectOfType<Player>().GetComponent<Player>();
            _player.GetComponent<IChangeSpeed>().ChangeSpeed(_changeSpeed);
        }
    }
}