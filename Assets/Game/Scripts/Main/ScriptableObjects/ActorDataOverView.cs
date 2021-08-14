#region

using System.Collections.Generic;
using UnityEngine;
using Utilities.Contract;

#endregion

namespace Main.GameDataStructure
{
    [CreateAssetMenu(fileName = "ActorDataOverView" , menuName = "HK/CreateActorDataOverView" , order = 0)]
    public class ActorDataOverView : ScriptableObject
    {
    #region Private Variables

        [SerializeField]
        private List<ActorData> actorDatas = new List<ActorData>();

    #endregion

    #region Public Methods

        public ActorData FindActorData(string actorDataId)
        {
            Contract.RequireString(actorDataId , "actorDataId");
            var actorData = actorDatas.Find(data => data.ActorDataId == actorDataId);
            Contract.EnsureNotNull(actorData , $"actorDataId is {actorDataId} , actorData");
            return actorData;
        }

        public List<ActorData> FindAll()
        {
            return actorDatas;
        }

    #endregion
    }
}