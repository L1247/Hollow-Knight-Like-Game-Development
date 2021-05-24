using UnityEngine;
using UnityEngine.UI;

namespace Main.ViewComponent
{
    public class ActorComponent : MonoBehaviour
    {
    #region Public Variables

        public IUnityComponent UnityComponent;
        public bool            isAttacking;

        public bool isMoving;

        public bool isOnGround;

        public int currentDirectionValue;

        public int JumpForce;

        public Text text_IdAndDataId;

        public Transform Rednerer;

    #endregion

    #region Private Variables

        private readonly int moveSpeed = 5;

        private Transform _transform;

        [SerializeField]
        private Animator animator;

    #endregion

    #region Public Methods

        public void Attack()
        {
            isAttacking = true;
            UnityComponent.PlayAnimation("Attack");
        }

        public void Jump()
        {
            isOnGround = false;
            UnityComponent.PlayAnimation("Jump");
            UnityComponent.AddForce(Vector2.up * JumpForce);
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

    #endregion

    #region Private Methods

        private void Awake()
        {
            var rigi2d = GetComponent<Rigidbody2D>();
            _transform     = transform;
            isOnGround     = true;
            UnityComponent = new UnityComponent(animator , rigi2d);
        }

        private void MoveCharacter()
        {
            var directionValue = currentDirectionValue == 1 ? Vector3.right : Vector3.left;
            var movement       = directionValue * moveSpeed * Time.deltaTime;
            _transform.position += movement;
        }

        private void Update()
        {
            // 沒有攻擊時是可以移動的 , 空中可以左右移動
            if ((isAttacking == false || isOnGround == false) && isMoving)
                MoveCharacter();
        }

    #endregion
    }
}