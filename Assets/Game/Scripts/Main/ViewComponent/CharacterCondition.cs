using System;
using Sirenix.OdinInspector;

namespace Main.ViewComponent
{
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

        [ShowInInspector]
        public bool IsDead { get; set; }

    #endregion

    #region Public Methods

        public bool CanMoving()
        {
            if (IsDead) return false;
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