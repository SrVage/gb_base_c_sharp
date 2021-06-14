using System;
using UnityEngine;
using Object = System.Object;

namespace Code
{
    public sealed class Player:SceneObjects, IMove, IRotation
    {
        private Transform _position;
        private Transform _direction;
        private float _hp = 3;
        private float _speed = 5f;

        public float Speed
        {
            get => _speed;
            set => _speed = value;
        }

        public float HP => _hp;


        public void Move(float time) //перемещение игрока
        {
            try
            {
                if (Speed < 0)
                    throw new LessNullException("Скорость не может быть меньше 0", Speed);
                transform.localPosition += transform.forward*Speed*time;
            }
            catch (LessNullException e)
            {
               Debug.Log($"{e.Message}, текущая скорость {e.Value}");
            }
        }

        public void Rotation(float direct) //поворот игрока
        {
            transform.localRotation *= Quaternion.Euler(0,direct,0);
        }


    }
}