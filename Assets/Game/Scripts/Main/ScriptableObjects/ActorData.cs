using Main.UseCases.Repository;
using UnityEngine;

namespace Main.GameDataStructure
{
    [CreateAssetMenu(fileName = "ActorData" , menuName = "HK/CreateActorData" , order = 0)]
    public class ActorData : ScriptableObject
    {
    #region Public Variables
        public string          ActorDataId;

        // view
        public GameObject ActorPrefab;
        // domain
        public ActorDomainData ActorDomainData;

    #endregion
    }
}