using System.Collections.Generic;
using DDDCore.Adapter.Presenter.Unity;
using Game.ScriptableObjects;
using Main.Controller;
using Main.Entity.Model.Events;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Main.Presenters
{
    public class ActorPresenter : UnityPresenter
    {
    #region Private Variables

        [Inject]
        private ActorContoller actorContoller;

        [Inject]
        private ActorMapper actorMapper;

        [Inject]
        private List<ActorData> actorDatas;

        [SerializeField]
        private Button button_CreateActor_Enemy1;

        [SerializeField]
        private Button button_CreateActor_Player1;

        [SerializeField]
        private Button button_CreateActor_Player2;

    #endregion

    #region Unity events

        private void Start()
        {
            ButtonBinding(button_CreateActor_Player1 , () => actorContoller.CreateActor(actorDatas[0].ActorDataId));
            ButtonBinding(button_CreateActor_Player2 , () => actorContoller.CreateActor(actorDatas[1].ActorDataId));
            ButtonBinding(button_CreateActor_Enemy1 ,  () => actorContoller.CreateActor(actorDatas[2].ActorDataId));
        }

    #endregion

    #region Events

        public void OnActorCreated(ActorCreated actorCreated)
        {
            var actorId     = actorCreated.ActorId;
            var actorDataId = actorCreated.ActorDataId;
            var direction   = actorCreated.Direction;
            Debug.Log($"OnActorCreated {actorId} , {actorDataId}");
            actorMapper.CreateActorViewData(actorId , actorDataId , direction);
        }

    #endregion
    }
}