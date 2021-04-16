using UnityEngine;

namespace Code
{
    public abstract class Trap: SceneObjects
    {
        private bool _isActive;

        protected virtual void Damage()
        {
            if (!_isActive) return;
            //передаем урон для игрока
            _isActive = false;
        }
    }
}