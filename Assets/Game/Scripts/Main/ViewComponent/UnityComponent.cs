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

        Vector3 GetGroundCheckPosition();
        bool    IsGrounding();

        void MoveCharacter(Vector3 movement);

        void PlayAnimation(string animationName , Action animationEndCallBack = null);

    #endregion
    }

    [Serializable]
    public class UnityComponent : IUnityComponent
    {
    #region Private Variables

        private readonly Animator    animator;
        private          float       radius;
        private          int         groundLayer;
        private readonly Rigidbody2D rigi2d;
        private          Transform   groundTransform;
        private readonly Transform   transform;

    #endregion

    #region Constructor

        public UnityComponent(Animator animator , Rigidbody2D rigi2d , Transform transform , float radius)
        {
            this.radius    = radius;
            groundLayer    = 1 << LayerMask.NameToLayer("Ground");
            this.animator  = animator;
            this.rigi2d    = rigi2d;
            this.transform = transform;
            var boxCollider2D = this.transform.GetComponent<BoxCollider2D>();
            var height        = boxCollider2D.size.y / 2;
            var offsetY       = boxCollider2D.offset.y;
            var groundY       = 0 - height - offsetY;
            var groundObject  = new GameObject("Actor Ground");
            groundTransform                      = groundObject.transform;
            groundObject.transform.parent        = transform;
            groundObject.transform.localPosition = Vector3.up * groundY;
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

        public Vector3 GetGroundCheckPosition()
        {
            return groundTransform.position;
        }

        public bool IsGrounding()
        {
            return Physics2D.OverlapCircle(groundTransform.position , radius , groundLayer);
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