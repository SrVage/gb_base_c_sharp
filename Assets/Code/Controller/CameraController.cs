using UnityEngine;

namespace Code.Controller
{
    public class CameraController:IExecute, IInitialization
    {
        private Camera _camera;
        private Transform _player;
        private Vector3 _offsetPos;
        private Vector3 _offsetRot;

        public CameraController(Camera camera)
        {
            _camera = camera;
        }
        
        public void Execute(float deltaTime)
        {
            if (_player==null) return;
            _camera.transform.parent.position = Vector3.Lerp(_camera.transform.parent.position, _player.position+_offsetPos, deltaTime);
            _camera.transform.parent.rotation = Quaternion.Euler(_player.rotation.eulerAngles + _offsetRot);
        }

        public void Initialization()
        {
            _player = GameObject.FindObjectOfType<Player>().transform;
            _offsetPos = _camera.transform.parent.position - _player.position;
            _offsetRot = _camera.transform.parent.rotation.eulerAngles - _player.rotation.eulerAngles;
        }
    }
}