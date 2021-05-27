using System;
using Sirenix.OdinInspector;

namespace Main.ViewComponent
{
    public interface ICharacterCondition
    {
    #region Public Variables

        bool        IsAttacking { get; set; }
        public bool IsMoving    { get; set; }
        public bool IsOnGround  { get; set; }

    #endregion

    #region Public Methods

        bool CanMoving();

    #endregion
    }

    [Serializable]
    public class CharacterCondition : ICharacterCondition
    {
    #region Public Variables

        [ShowInInspector]
        public bool IsAttacking { get; set; }

        [ShowInInspector]
        public bool IsMoving { get; set; }

        [ShowInInspector]
        public bool IsOnGround { get; set; }

    #endregion

    #region Public Methods

        public bool CanMoving()
        {
            // 在地面，且攻擊時，不可移動 , 空中可以左右移動
            if (IsMoving)
            {
                if (IsAttacking)
                {
                    // Ground
                    if (IsOnGround) return false;
                    // Air
                    return true;
                }

                // Not attacking
                return true;
            }

            return false;
        }

    #endregion
    }
}