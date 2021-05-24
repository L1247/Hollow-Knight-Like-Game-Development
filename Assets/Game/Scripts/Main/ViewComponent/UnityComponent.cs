using UnityEngine;
using Utilities.Contract;

namespace Main.ViewComponent
{
    public interface IUnityComponent
    {
    #region Public Methods

        void AddForce(Vector2 force);

        void MoveCharacter(Vector3 movement);

        void PlayAnimation(string animationName);

    #endregion
    }

    public class UnityComponent : IUnityComponent
    {
    #region Private Variables

        private readonly Animator    animator;
        private readonly Rigidbody2D rigi2d;
        private readonly Transform   transform;

    #endregion

    #region Constructor

        public UnityComponent(Animator animator , Rigidbody2D rigi2d , Transform transform)
        {
            this.animator  = animator;
            this.rigi2d    = rigi2d;
            this.transform = transform;
        }

        public UnityComponent(Animator animator)
        {
            this.animator = animator;
        }

        public UnityComponent(Rigidbody2D rigidbody2D)
        {
            rigi2d = rigidbody2D;
        }

        public UnityComponent(Transform transform)
        {
            this.transform = transform;
        }

    #endregion

    #region Public Methods

        public void AddForce(Vector2 force)
        {
            Contract.RequireNotNull(rigi2d , "Rigidbody2d");
            rigi2d.AddForce(force , ForceMode2D.Impulse);
        }

        public void MoveCharacter(Vector3 movement)
        {
            transform.position += movement;
        }

        public void PlayAnimation(string animationName)
        {
            Contract.RequireNotNull(animator , "Animator");
            animator.Play(animationName);
        }

    #endregion
    }
}