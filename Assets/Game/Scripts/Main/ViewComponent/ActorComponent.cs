using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;
using Utilities.Contract;

namespace Main.ViewComponent
{
    public class ActorComponent : MonoBehaviour
    {
    #region Public Variables

        [ShowInInspector]
        public ICharacterCondition characterCondition;

        public IUnityComponent unityComponent;
        public int             currentDirectionValue;
        public int             JumpForce;
        public Text            text_IdAndDataId;
        public Transform       Rednerer;

    #endregion

    #region Private Variables

        private readonly int moveSpeed = 5;

        [SerializeField]
        private Animator animator;

    #endregion

    #region Events

        public void OnAttackEnd()
        {
            characterCondition.IsAttacking = false;
        }

    #endregion

    #region Public Methods

        public void Attack()
        {
            characterCondition.IsAttacking = true;
            unityComponent.PlayAnimation("Attack" , OnAttackEnd);
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

        public void MoveCharacter()
        {
            var movement = GetMovement();
            unityComponent.MoveCharacter(movement);
            unityComponent.PlayAnimation("Run");
        }

        public void SetDirection(int directionValue)
        {
            currentDirectionValue = directionValue;
            var x = 0;

            if (directionValue == 0) x = 1;
            if (directionValue == 1) x = -1;
            Rednerer.transform.localScale = new Vector3(x , 1 , 1);
        }

        public void SetIsMoving(bool isMoving)
        {
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

        public void Update()
        {
            Contract.RequireNotNull(characterCondition , "characterCondition");
            characterCondition.IsOnGround = unityComponent.IsGrounding();
            if (characterCondition.CanMoving()) MoveCharacter();
        }

    #endregion

    #region Private Methods

        private void Awake()
        {
            var rigi2d = GetComponent<Rigidbody2D>();
            unityComponent                = new UnityComponent(animator , rigi2d , transform);
            characterCondition            = new CharacterCondition();
            characterCondition.IsOnGround = true;
        }

    #endregion
    }
}