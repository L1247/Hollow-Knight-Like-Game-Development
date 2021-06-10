using UnityEngine;

namespace Main.ScriptableObjects
{
    [CreateAssetMenu(fileName = "ActorData" , menuName = "HK/CreateActorData" , order = 0)]
    public class ActorData : ScriptableObject
    {
    #region Public Variables

        public GameObject ActorPrefab;
        public int        Health = 100;
        public string     ActorDataId;

    #endregion
    }
}