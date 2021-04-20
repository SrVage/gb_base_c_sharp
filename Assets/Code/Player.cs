﻿using UnityEngine;

namespace Code
{
    public sealed class Player:SceneObjects, IGetDamage, IMove, IRotation, IChangeSpeed
    {
        private Transform _position;
        private Transform _direction;
        private float _hp = 3;
        private float _speed = 0.05f;

        public void Move() //перемещение игрока
        {
            //_position.position += new Vector3(0, 0, _speed);
            transform.localPosition += transform.forward*_speed; //потом передам в другой класс
        }

        public void Rotation(float direct) //поворот игрока
        {
            //_direction.rotation *= Quaternion.Euler(0,direct,0);
            transform.localRotation *= Quaternion.Euler(0,direct/10,0); //потом передам в другой класс
        }

       public void GetDamage(float damage) //получение урона
        {
            if (damage < _hp) _hp -= damage;
            else EndOfGame();
            print(_hp);
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
            Destroy(gameObject);
        }
    }
}