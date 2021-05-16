using System.Collections.Generic;
using UnityEngine;

namespace Game.ScriptableObjects
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
            return ActorDatas.Find(data => data.ActorDataId == actorDataId);
        }

    #endregion
    }
}