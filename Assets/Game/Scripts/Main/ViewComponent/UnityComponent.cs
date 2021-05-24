using UnityEngine;
using Utilities.Contract;

namespace Main.ViewComponent
{
    public interface IUnityComponent
    {
    #region Public Methods

        void AddForce(Vector2 force);

        void PlayAnimation(string animationName);

    #endregion
    }

    public class UnityComponent : IUnityComponent
    {
    #region Private Variables

        private readonly Animator    animator;
        private readonly Rigidbody2D rigi2d;

    #endregion

    #region Constructor

        public UnityComponent(Animator animator , Rigidbody2D rigi2d)
        {
            this.animator = animator;
            this.rigi2d   = rigi2d;
        }

    #endregion

    #region Public Methods

        public void AddForce(Vector2 force)
        {
            Contract.RequireNotNull(rigi2d , "Rigidbody2d");
            rigi2d.AddForce(force , ForceMode2D.Impulse);
        }

        public void PlayAnimation(string animationName)
        {
            Contract.RequireNotNull(animator , "Animator");
            animator.Play(animationName);
        }

    #endregion
    }
}