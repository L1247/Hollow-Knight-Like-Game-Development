using System.Collections.Generic;
using DDDCore.Adapter.Presenter.Unity;
using Game.ScriptableObjects;
using Main.Actor.Events;
using Main.Controller;
using Main.Entity.Model.Events;
using Main.Input;
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

        private int direction;

        [Inject]
        private List<ActorData> actorDatas;

        private string CacheActorId;

        [SerializeField]
        private Button button_ChangeDirection;

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
            ButtonBinding(button_ChangeDirection , () =>
            {
                direction = direction == 0 ? 1 : 0;
                actorContoller.ChangeDirection(CacheActorId , direction);
            });
        }

    #endregion

    #region Events

        public void OnActorCreated(ActorCreated actorCreated)
        {
            var actorId     = actorCreated.ActorId;
            var actorDataId = actorCreated.ActorDataId;
            var direction   = actorCreated.Direction;
            // Debug.Log($"OnActorCreated {actorId} , {actorDataId}");
            CacheActorId = actorId;
            actorMapper.CreateActorViewData(actorId , actorDataId , direction);
        }

        public void OnButtonDownJump(ButtonDownJump buttonDownJump)
        {
            var actorComponent = actorMapper.GetActorComponent(CacheActorId);
            actorComponent.Jump();
        }

        public void OnDirectionChanged(DirectionChanged directionChanged)
        {
            var actorId        = directionChanged.ActorId;
            var direction      = directionChanged.Direction;
            var actorComponent = actorMapper.GetActorComponent(actorId);
            actorComponent.SetDirection(direction);
        }

        public void OnHorizontalChanged(Input_Horizontal inputHorizontal)
        {
            // detect actor is exist
            if (string.IsNullOrEmpty(CacheActorId) == false)
            {
                // -1 : left , 0 : no press , 1 : right
                var horizontalValue = inputHorizontal.HorizontalValue;
                var isMoving        = horizontalValue != 0;
                var actorComponent  = actorMapper.GetActorComponent(CacheActorId);
                actorComponent.SetIsMoving(isMoving);
                if (isMoving)
                {
                    // mapping input value to domain direction value
                    var dir = horizontalValue == 1 ? 1 : 0;
                    actorContoller.ChangeDirection(CacheActorId , dir);
                }
            }
        }

    #endregion
    }
}