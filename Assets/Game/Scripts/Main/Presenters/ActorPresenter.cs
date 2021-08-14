#region

using DDDCore.Adapter.Presenter.Unity;
using Main.Controller;
using Main.GameDataStructure;
using Main.Input.Event;
using Main.Input.Events;
using Main.ViewComponent.Events;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

#endregion

namespace Main.Presenters
{
    public class ActorPresenter : UnityPresenter
    {
    #region Private Variables

        [Inject]
        private ActorContoller actorContoller;

        [Inject]
        private ActorDataOverView actorDataOverView;

        [Inject]
        private ActorMapper actorMapper;

        private int direction;

        private string CacheActorId;

        [SerializeField]
        [Required]
        private Button button_CreateActor_Player;

        [SerializeField]
        [Required]
        private Button button_DealDamage;

        [SerializeField]
        [Required]
        private Button button_MakeActorDie;

    #endregion

    #region Unity events

        private void Start()
        {
            ButtonBinding(button_CreateActor_Player , () =>
            {
                var actorDataId = actorDataOverView.FindAll()[3].ActorDataId;
                actorContoller.CreateActor(actorDataId);
            });
            ButtonBinding(button_DealDamage ,   () => actorContoller.DealDamage(CacheActorId , 10));
            ButtonBinding(button_MakeActorDie , () => actorContoller.MakeActorDie(CacheActorId));
        }

    #endregion

    #region Public Methods

        public void OnActorCreated(string actorId , string actorDataId , int direction)
        {
            CacheActorId = actorId;
            actorMapper.CreateActorViewData(actorId , actorDataId , direction);
        }

        public void OnActorDead(string actorId)
        {
            var actorComponent = actorMapper.GetActorComponent(actorId);
            actorComponent.MakeDie();
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

        public void OnDamageDealt(string actorId , int currentHealth)
        {
            var actorComponent = actorMapper.GetActorComponent(actorId);
            actorComponent.SetHealthText(currentHealth);
        }

        public void OnDirectionChanged(string actorId , int direction)
        {
            var actorComponent = actorMapper.GetActorComponent(actorId);
            actorComponent.SetDirection(direction);
        }

        public void OnHitboxTriggered(HitboxTriggered hitboxTriggered)
        {
            var triggerActorComponent = hitboxTriggered.TriggerActorComponent;
            triggerActorComponent.unityComponent.PlayAnimation("Hit");
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