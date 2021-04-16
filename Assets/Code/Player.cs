using UnityEngine;

namespace Code
{
    public sealed class Player:SceneObjects
    {
        private Transform _position;
        private Transform _direction;
        private float _hp = 3;
        private float _speed = 2;

        private void Move() //перемещение игрока
        {
            _position.position += new Vector3(0, 0, _speed);
        }

        private void Rotate(int direct) //поворот игрока
        {
            _direction.rotation *= Quaternion.Euler(0,direct,0);
        }

       public void Damage(float damage) //получение урона
        {
            if (damage < _hp) _hp -= damage;
            else EndOfGame();
        }

        public void ChangeSpeed(float speed) //замедление (попали в ловушку) или ускорение (взяли бонус)
        {
            _speed += speed;
        }

        public void RestoreHealth(float hp)
        {
            _hp += hp;
        }

        private void EndOfGame() //завершение игры
        {
            
        }
    }
}