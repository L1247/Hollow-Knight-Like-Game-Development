using UnityEngine;

namespace Game.ScriptableObjects
{
    [CreateAssetMenu(fileName = "ActorData" , menuName = "HK/CreateActorData" , order = 0)]
    public class ActorData : ScriptableObject
    {
    #region Public Variables

        public GameObject ActorPrefab;

        public string ActorDataId;

    #endregion
    }
}