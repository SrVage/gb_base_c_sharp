namespace Code
{
    public abstract class Bonus:SceneObjects
    {
        
        
        private bool _isActive;
        
        protected virtual void SetBonus()
        {
            if (!_isActive) return;
            //передаем бонус для игрока
            _isActive = false;
        }
    }
}