#region

using System.Collections.Generic;
using Main.DomainData;
using UnityEngine;
using Utilities.Contract;

#endregion

namespace Main.GameDataStructure
{
    public interface IActorDataOverView
    {
    #region Public Methods

        IActorData      FindActorData(string actorDataId);
        List<ActorData> FindAll();

    #endregion
    }

    [CreateAssetMenu(fileName = "ActorDataOverView" , menuName = "HK/CreateActorDataOverView" , order = 0)]
    public class ActorDataOverView : ScriptableObject , IActorDataOverView
    {
    #region Private Variables

        [SerializeField]
        private List<ActorData> actorDatas = new List<ActorData>();

    #endregion

    #region Public Methods

        public IActorData FindActorData(string actorDataId)
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