using System;
using UniRx;
using UnityEngine;
using Utilities.Contract;

namespace Main.ViewComponent
{
    public interface IUnityComponent
    {
    #region Public Methods

        void AddForce(Vector2 force);
        bool IsGrounding();

        void MoveCharacter(Vector3 movement);

        void PlayAnimation(string animationName , Action animationEndCallBack = null);

    #endregion
    }

    [Serializable]
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

        public bool IsGrounding()
        {
            return true;
        }

        public void MoveCharacter(Vector3 movement)
        {
            transform.position += movement;
        }

        public void PlayAnimation(string animationName , Action animationEndCallBack = null)
        {
            Contract.RequireNotNull(animator , "Animator");
            var currentClip     = animator.GetCurrentAnimatorClipInfo(0)[0].clip;
            var currentClipName = currentClip.name;
            if (currentClipName == animationName)
                return;

            animator.Play(animationName);
            if (animationEndCallBack != null)
            {
                var attackClipLength = currentClip.length
                                       - Time.deltaTime * 2;
                Observable.Timer(TimeSpan.FromSeconds(attackClipLength))
                          .Subscribe(_ => animationEndCallBack.Invoke());
            }
        }

    #endregion
    }
}