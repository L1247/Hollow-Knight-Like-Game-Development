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
    #region Public Methods

        public bool CanMoving()
        {
            return true;
        }

    #endregion
    }
}