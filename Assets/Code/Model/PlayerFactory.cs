using UnityEngine;

namespace Code
{
    public sealed class PlayerFactory
    {
        public PlayerFactory()
        {
            
        }
        public GameObject CreatePlayer()
        {
            GameObject player = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            player.name = "Player";
            player.AddComponent<Player>();
            player.AddComponent<PlayerInteraction>();
            player.AddComponent<Rigidbody>();
            player.GetComponent<Rigidbody>().constraints =
                RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
            return player;
        }
    }
}