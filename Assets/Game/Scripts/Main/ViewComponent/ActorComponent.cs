using UnityEngine;
using UnityEngine.UI;

namespace Main.ViewComponent
{
    public class ActorComponent : MonoBehaviour
    {
    #region Public Variables

        public bool isAttacking;

        public bool isMoving;

        public bool isOnGround;

        public int currentDirectionValue;

        public Text text_IdAndDataId;

        public Transform Rednerer;

    #endregion

    #region Private Variables

        private readonly int moveSpeed = 5;

        private Rigidbody2D rigi2d;

        private Transform _transform;

        [SerializeField]
        private Animator animator;

        [SerializeField]
        private int JumpForce;

    #endregion

    #region Public Methods

        public void Attack()
        {
            isAttacking = true;
            PlayAnimation("Attack");
        }

        public void Jump()
        {
            isOnGround = false;
            PlayAnimation("Jump");
            rigi2d?.AddForce(Vector2.up * JumpForce , ForceMode2D.Impulse);
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
            PlayAnimation(animationName);
        }

        public void SetText(string displayText)
        {
            text_IdAndDataId.text = displayText;
        }

    #endregion

    #region Private Methods

        private void Awake()
        {
            _transform = transform;
            rigi2d     = GetComponent<Rigidbody2D>();
            isOnGround = true;
        }

        private void MoveCharacter()
        {
            var directionValue = currentDirectionValue == 1 ? Vector3.right : Vector3.left;
            var movement       = directionValue * moveSpeed * Time.deltaTime;
            _transform.position += movement;
        }

        private void PlayAnimation(string animationName)
        {
            animator?.Play(animationName);
        }

        private void Update()
        {
            if (isMoving) MoveCharacter();
        }

    #endregion
    }
}