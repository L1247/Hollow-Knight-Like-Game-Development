using Photon.Pun;
using UnityEngine;
using Zenject;

namespace Main.System
{
    public interface IActorSpawner
    {
        GameObject Spawn(GameObject actorPrefab , Vector2 position , Quaternion rotation , Transform parent);
    }

    public class NetworkingActorSpawner : IActorSpawner
    {
        public GameObject Spawn(GameObject actorPrefab , Vector2 position , Quaternion rotation , Transform parent)
        {
            return PhotonNetwork.Instantiate("ActorPrefab" , Vector3.zero , Quaternion.identity);
        }
    }

    public class ActorSpawner : IActorSpawner
    {
        private DiContainer container;

        public GameObject Spawn(GameObject actorPrefab , Vector2 position , Quaternion rotation , Transform parent)
        {
            var actorInstance =
                container.InstantiatePrefab(actorPrefab , position , rotation , parent);
            return actorInstance;
        }
    }
}