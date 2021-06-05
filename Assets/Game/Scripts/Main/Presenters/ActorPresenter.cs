using System.Collections.Generic;
using DDDCore.Adapter.Presenter.Unity;
using Entity.Events;
using Main.Controller;
using Main.Input;
using Main.ScriptableObjects;
using Main.ViewComponent;
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

        public void OnActorCreated(ActorCreated actorCreated)
        {
            var actorId     = actorCreated.ActorId;
            var actorDataId = actorCreated.ActorDataId;
            var direction   = actorCreated.Direction;
            // Debug.Log($"OnActorCreated {actorId} , {actorDataId}");
            CacheActorId = actorId;
            actorMapper.CreateActorViewData(actorId , actorDataId , direction);
        }

        public void OnAnimationTriggered(rAnimationEvent rAnimationEvent)
        {
            var     actorComponent = actorMapper.GetActorComponent(CacheActorId);
            var     direction      = actorComponent.currentDirectionValue == 0 ? Vector2.left : Vector2.right;
            Vector2 origin         = actorComponent.Renderer.position;
            var     raycastHit2Ds  = Physics2D.BoxCastAll(origin , new Vector2(2 , 1) , 0 , direction , 2);
            if (raycastHit2Ds.Length > 0)
                foreach (var raycastHit2D in raycastHit2Ds)
                    // exclude self
                    if (raycastHit2D.transform.gameObject != actorComponent.gameObject)
                    {
                        Debug.Log($"raycastHit2D {raycastHit2D.transform.gameObject.name}");
                        var hitActorComponent = raycastHit2D.transform.GetComponent<ActorComponent>();
                        hitActorComponent.unityComponent.PlayAnimation("Hit");
                    }
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