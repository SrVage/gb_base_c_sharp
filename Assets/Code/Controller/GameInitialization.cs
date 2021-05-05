using UnityEngine;

namespace Code.Controller
{
    public sealed class GameInitialization
    {
        public GameInitialization(Controllers controllers)
        {
            PlayerFactory playerFactory = new PlayerFactory();
            PlayerInitialization playerInitialization = new PlayerInitialization(playerFactory);
            PlayerController playerController = new PlayerController(playerInitialization.GetPlayer());
            CameraController cameraController = new CameraController(Camera.main);
            controllers.Add(playerInitialization);
            controllers.Add(playerController);
            controllers.Add(cameraController);
        }
    }
}