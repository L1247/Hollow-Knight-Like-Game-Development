using System.Collections.Generic;
using UnityEngine;
using Utilities.Contract;

namespace Main.ScriptableObjects
{
    [CreateAssetMenu(fileName = "ActorDataOverView" , menuName = "HK/CreateActorDataOverView" , order = 0)]
    public class ActorDataOverView : ScriptableObject
    {
    #region Public Variables

        public List<ActorData> ActorDatas = new List<ActorData>();

    #endregion

    #region Public Methods

        public ActorData FindActorData(string actorDataId)
        {
            var actorData = ActorDatas.Find(data => data.ActorDataId == actorDataId);
            Contract.RequireNotNull(actorData , $"actorDataId is {actorDataId} , actorData");

            return actorData;
        }

    #endregion
    }
}