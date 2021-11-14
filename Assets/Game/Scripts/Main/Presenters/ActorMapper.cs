#region

using System.Collections.Generic;
using Main.GameDataStructure;
using Main.ViewComponent;
using UnityEngine;
using Utilities.Contract;
using Zenject;

#endregion

namespace Main.Presenters
{
    public class ActorMapper
    {
    #region Private Variables

        [Inject]
        private DiContainer container;

        [Inject]
        private IActorDataOverView actorDataOverView;

        private readonly Dictionary<string , ActorViewData> actorViewDatas = new Dictionary<string , ActorViewData>();

    #endregion

    #region Public Methods

        public void CreateActorViewData(string actorId , string actorDataId , int direction)
        {
            var actorData   = actorDataOverView.FindActorData(actorDataId) as ActorData;
            var actorPrefab = actorData.ActorPrefab;
            var actorInstance =
                container.InstantiatePrefab(actorPrefab , Random.insideUnitCircle * 5 , Quaternion.identity , null);
            var actorComponent   = actorInstance.GetComponent<ActorComponent>();
            var text_IdAndDataId = $"{actorDataId} - {actorId.Substring(actorId.Length - 2 , 2)}";
            actorComponent.SetText(text_IdAndDataId);
            actorComponent.SetDirection(direction);
            var actorViewData = new ActorViewData(actorId , actorDataId , actorComponent);
            actorViewDatas.Add(actorId , actorViewData);
        }

        public ActorComponent GetActorComponent(string actorId)
        {
            Contract.RequireString(actorId , "ActorId");
            ActorComponent actorComponent = null;
            if (actorViewDatas.ContainsKey(actorId))
                actorComponent = actorViewDatas[actorId].ActorComponent;

            return actorComponent;
        }

    #endregion
    }

    public class ActorViewData
    {
    #region Public Variables

        public ActorComponent ActorComponent { get; }
        public string         ActorDataId    { get; }
        public string         ActorId        { get; }

    #endregion

    #region Constructor

        public ActorViewData(string actorId , string actorDataId , ActorComponent actorComponent)
        {
            ActorId        = actorId;
            ActorDataId    = actorDataId;
            ActorComponent = actorComponent;
        }

    #endregion
    }
}