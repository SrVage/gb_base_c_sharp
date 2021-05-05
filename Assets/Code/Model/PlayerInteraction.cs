using System;
using UnityEngine;

namespace Code
{
    public sealed class PlayerInteraction:SceneObjects, IGetDamage, IChangeSpeed
    {
        public event Action DestroyPlayer;
        private float _hp = 3;
        private Player _player;

        public void GetDamage(float damage) //получение урона
        {
            _hp -= damage;
            print(_hp);
        }

        public void ChangeSpeed(float speed) //замедление (попали в ловушку) или ускорение (взяли бонус)
        {
            _player.Speed = _player.Speed + speed;
        }
  
        public void RestoreHealth(float hp)
        {
            _hp += hp;
        }

        /*private void EndOfGame() //завершение игры
        {
            DestroyPlayer?.Invoke();
            Destroy(gameObject);
        }*/

        public PlayerInteraction(Player player)
        {
            _player = player;
        }
    }
}