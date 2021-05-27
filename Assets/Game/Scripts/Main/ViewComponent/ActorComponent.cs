using UnityEngine;
using UnityEngine.UI;
using Utilities.Contract;

namespace Main.ViewComponent
{
    public class ActorComponent : MonoBehaviour
    {
    #region Public Variables

        public ICharacterCondition characterCondition;

        public IUnityComponent unityComponent;

        public bool isAttacking;
        public bool isMoving;

        public bool isOnGround;

        public int currentDirectionValue;

        public int JumpForce;

        public Text text_IdAndDataId;

        public Transform Rednerer;

    #endregion

    #region Private Variables

        private readonly int moveSpeed = 5;

        [SerializeField]
        private Animator animator;

    #endregion

    #region Public Methods

        public void Attack()
        {
            isAttacking = true;
            unityComponent.PlayAnimation("Attack");
        }

        public bool CanMoving()
        {
            // 在地面，且攻擊時，不可移動 , 空中可以左右移動
            if (isMoving)
            {
                if (isAttacking)
                {
                    // Ground
                    if (isOnGround) return false;
                    // Air
                    return true;
                }

                // Not attacking
                return true;
            }

            return false;
        }

        public Vector3 GetMovement()
        {
            var directionValue = currentDirectionValue == 1 ? Vector3.right : Vector3.left;
            var movement       = directionValue * moveSpeed * Time.deltaTime;
            return movement;
        }

        public void Jump()
        {
            isOnGround = false;
            unityComponent.PlayAnimation("Jump");
            unityComponent.AddForce(Vector2.up * JumpForce);
        }

        public void MoveCharacter()
        {
            var movement = GetMovement();
            unityComponent.MoveCharacter(movement);
        }

        public void PlayAnimation(string animationName)
        {
            animator?.Play(animationName);
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
            this.isMoving = isMoving;
            var animationName = isMoving ? "Run" : "Idle";
            // 攻擊中不可以切換移動動畫
            if (isAttacking == false) PlayAnimation(animationName);
        }

        public void SetText(string displayText)
        {
            text_IdAndDataId.text = displayText;
        }

        public void Update()
        {
            Contract.RequireNotNull(characterCondition , "characterCondition");
            if (characterCondition.CanMoving()) MoveCharacter();
        }

    #endregion

    #region Private Methods

        private void Awake()
        {
            var rigi2d = GetComponent<Rigidbody2D>();
            isOnGround         = true;
            unityComponent     = new UnityComponent(animator , rigi2d , transform);
            characterCondition = new CharacterCondition();
        }

    #endregion
    }
}