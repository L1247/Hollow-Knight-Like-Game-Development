using System;
using UnityEngine;

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
}