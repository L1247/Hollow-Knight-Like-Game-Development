namespace Main.ViewComponent
{
    public interface ICharacterCondition
    {
    #region Public Methods

        bool CanMoving();

    #endregion
    }

    public class CharacterCondition : ICharacterCondition
    {
    #region Public Variables

        public bool isAttacking;
        public bool isMoving;
        public bool isOnGround;

    #endregion

    #region Public Methods

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

    #endregion
    }
}