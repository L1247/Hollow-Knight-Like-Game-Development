using System.Collections.Generic;
using DDDCore.Adapter.Presenter.Unity;
using Main.Controller;
using Main.Input;
using Main.Input.Event;
using Main.ScriptableObjects;
using Sirenix.OdinInspector;
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
        [Required]
        private Button button_CreateActor_Player;

    #endregion

    #region Unity events

        private void Start()
        {
            ButtonBinding(button_CreateActor_Player , () => actorContoller.CreateActor(actorDatas[3].ActorDataId));
            ButtonBinding(button_ChangeDirection , () =>
            {
                direction = direction == 0 ? 1 : 0;
                actorContoller.ChangeDirection(CacheActorId , direction);
            });
        }

    #endregion

    #region Events

        public void OnActorCreated(string actorId , string actorDataId , int direction)
        {
            CacheActorId = actorId;
            actorMapper.CreateActorViewData(actorId , actorDataId , direction);
        }

        public void OnButtonDownAttack(ButtonDownAttack buttonDownAttack)
        {
            if (string.IsNullOrEmpty(CacheActorId) == false)
            {
                var actorComponent = actorMapper.GetActorComponent(CacheActorId);
                actorComponent.Attack();
            }
        }

        public void OnButtonDownJump(ButtonDownJump buttonDownJump)
        {
            if (string.IsNullOrEmpty(CacheActorId) == false)
            {
                var actorComponent = actorMapper.GetActorComponent(CacheActorId);
                actorComponent.Jump();
            }
        }

        public void OnDirectionChanged(string actorId , int direction)
        {
            var actorComponent = actorMapper.GetActorComponent(actorId);
            actorComponent.SetDirection(direction);
        }

        public void OnHorizontalChanged(InputHorizontal inputHorizontal)
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