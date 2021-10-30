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

        private readonly List<ActorViewData> actorViewDatas = new List<ActorViewData>();

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
            // todo : require Health
            // var health           = actorData.Health;
            actorComponent.SetText(text_IdAndDataId);
            actorComponent.SetDirection(direction);
            // actorComponent.SetHealthText(health);
            var actorViewData = new ActorViewData(actorId , actorDataId , actorComponent);
            actorViewDatas.Add(actorViewData);
        }

        public ActorComponent GetActorComponent(string actorId)
        {
            Contract.RequireString(actorId , "ActorId");
            var actorViewData = actorViewDatas.Find(data => data.ActorId == actorId);
            return actorViewData.ActorComponent;
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