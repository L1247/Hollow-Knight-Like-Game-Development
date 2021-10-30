#region

using Main.ViewComponent.Events;
using Sirenix.OdinInspector;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.UI;
using Utilities.Contract;
using Zenject;

#endregion

namespace Main.ViewComponent
{
    public class ActorComponent : MonoBehaviour
    {
    #region Public Variables

        [ShowInInspector]
        public ICharacterCondition characterCondition;

        public IUnityComponent unityComponent;

        [Required]
        public int currentDirectionValue;

        [Required]
        public int JumpForce;

        [Required]
        public Text text_IdAndDataId;

        [Required]
        public Transform Renderer;

    #endregion

    #region Private Variables

        private readonly int moveSpeed = 5;

        [Inject]
        private SignalBus signalBus;

        private int statIndex;

        [SerializeField]
        [Required]
        private Animator animator;

        [SerializeField]
        [Required]
        private BoxCollider2D boxCollider_Hitbox;

        [SerializeField]
        [Required]
        private float radius = 0.1f;

        [SerializeField]
        private Transform statParent;

        [SerializeField]
        private GameObject statTemplate;

    #endregion

    #region Unity events

        private void Awake()
        {
            var rigi2d = GetComponent<Rigidbody2D>();
            unityComponent                = new UnityComponent(animator , rigi2d , transform , radius);
            characterCondition            = new CharacterCondition();
            characterCondition.IsOnGround = true;
            // Listen hit box trigger event
            boxCollider_Hitbox.OnTriggerEnter2DAsObservable()
                              .Subscribe(collider2D => OnHitboxTriggered(collider2D))
                              .AddTo(gameObject);
            statTemplate?.gameObject.SetActive(false);
        }

        public void Update()
        {
            Contract.RequireNotNull(characterCondition , "characterCondition");
            characterCondition.IsOnGround = unityComponent.IsGrounding();
            if (characterCondition.CanMoving()) MoveCharacter();
        }

    #endregion

    #region Public Methods

        public void Attack()
        {
            if (characterCondition.IsDead) return;
            characterCondition.IsAttacking = true;
            unityComponent.PlayAnimation("Attack" , OnAttackEnd);
        }

        public void CreateStat(string statName , int amount)
        {
            var statInstance = Instantiate(statTemplate , statParent , true);
            statInstance.transform.position += Vector3.up * 0.5f * statIndex;
            var statComponent = statInstance.GetComponent<StatComponent>();
            statComponent.SetText(statName , amount);
            statInstance.SetActive(true);
            statIndex++;
        }

        public Vector3 GetMovement()
        {
            var directionValue = currentDirectionValue == 1 ? Vector3.right : Vector3.left;
            var movement       = directionValue * moveSpeed * Time.deltaTime;
            return movement;
        }

        public void Jump()
        {
            characterCondition.IsOnGround = false;
            unityComponent.PlayAnimation("Jump");
            unityComponent.AddForce(Vector2.up * JumpForce);
        }

        public void MakeDie()
        {
            characterCondition.IsDead = true;
            unityComponent.PlayAnimation("Die");
            if (text_IdAndDataId != null) text_IdAndDataId.enabled = false;
        }

        public void MoveCharacter()
        {
            var movement = GetMovement();
            unityComponent.MoveCharacter(movement);
            unityComponent.PlayAnimation("Run");
        }

        public void OnAttackEnd()
        {
            characterCondition.IsAttacking = false;
        }

        public void SetDirection(int directionValue)
        {
            currentDirectionValue = directionValue;
            var x = 0;

            if (directionValue == 0) x = 1;
            if (directionValue == 1) x = -1;
            Renderer.transform.localScale = new Vector3(x , 1 , 1);
        }


        public void SetIsMoving(bool isMoving)
        {
            if (characterCondition.IsDead) return;
            characterCondition.IsMoving = isMoving;
            var animationName = isMoving ? "Run" : "Idle";
            // 攻擊中不可以切換移動動畫
            if (characterCondition.IsMoving == false)
                unityComponent.PlayAnimation(animationName);
        }

        public void SetText(string displayText)
        {
            text_IdAndDataId.text = displayText;
        }

    #endregion

    #region Private Methods

        private void OnDrawGizmos()
        {
            if (unityComponent == null) return;
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(unityComponent.GetGroundCheckPosition() , radius);
        }

        private void OnHitboxTriggered(Collider2D collider)
        {
            var colliderGameObject = collider.gameObject;
            if (colliderGameObject != gameObject)
            {
                var triggerActorComponent = colliderGameObject.GetComponent<ActorComponent>();
                signalBus.Fire(new HitboxTriggered(triggerActorComponent));
            }
        }

    #endregion
    }
}