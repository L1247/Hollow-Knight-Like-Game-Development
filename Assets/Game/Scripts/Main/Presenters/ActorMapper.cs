using System.Collections.Generic;
using Game.ScriptableObjects;
using Main.ViewComponent;
using UnityEngine;
using Zenject;

namespace Main.Presenters
{
    public class ActorMapper
    {
    #region Private Variables

        [Inject]
        private ActorDataOverView actorDataOverView;

        private readonly List<ActorViewData> actorViewDatas = new List<ActorViewData>();

    #endregion

    #region Public Methods

        public void CreateActorViewData(string actorId , string actorDataId , int direction)
        {
            var actorData      = actorDataOverView.FindActorData(actorDataId);
            var actorPrefab    = actorData.ActorPrefab;
            var actorInstance  = Object.Instantiate(actorPrefab , Random.insideUnitCircle * 5 , Quaternion.identity);
            var actorComponent = actorInstance.GetComponent<ActorComponent>();
            var text           = $"{actorDataId} - {actorId.Substring(actorId.Length - 2 , 2)}";
            actorComponent.SetText(text);
            actorComponent.SetDirection(direction);
            var actorViewData = new ActorViewData(actorId , actorDataId , actorComponent);
            actorViewDatas.Add(actorViewData);
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