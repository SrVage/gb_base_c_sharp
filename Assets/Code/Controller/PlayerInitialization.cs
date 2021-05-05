using UnityEngine;

namespace Code.Controller
{
    public sealed class PlayerInitialization:IInitialization
    {
        private PlayerFactory _playerFactory;
        private GameObject _player;
        
        public PlayerInitialization(PlayerFactory playerFactory)
        {
            _playerFactory = playerFactory;
            _player = _playerFactory.CreatePlayer();
            _player.transform.position = new Vector3(-2, 0.5f, -51);
        }
        public void Initialization()
        {
            
        }

        public GameObject GetPlayer()
        {
            return _player;
        }
    }
}