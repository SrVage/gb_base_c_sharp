using UnityEngine;

namespace Code.Controller
{
    public class SceneObjectController:IExecute, IInitialization
    {
        private SceneObjects[] _sceneObjects;
        private SaveDataRepository _saveDataRepository;
        public void Execute(float deltaTime)
        {
            for (var i = 0; i < _sceneObjects.Length; i++)
            {
                var sceneObject = _sceneObjects[i];
                if (sceneObject == null) continue;
                if (sceneObject is IPingPong pingPong) pingPong.PingPong();
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                _saveDataRepository.Save(_sceneObjects);
            }

            if (Input.GetKeyDown(KeyCode.L))
            {
                _saveDataRepository.Load(_sceneObjects);
            }
        }

        public void LoadGame()
        {
            _saveDataRepository.Load(_sceneObjects);
        }

        public void Initialization()
        {
            _sceneObjects = Object.FindObjectsOfType<SceneObjects>();
            _saveDataRepository = new SaveDataRepository();
            Object.FindObjectOfType<StartScreen>().Load += LoadGame;
        }
    }
}