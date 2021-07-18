namespace Main.ViewComponent
{
    public interface ICharacterCondition
    {
    #region Public Variables

        bool IsAttacking { get; set; }
        bool IsMoving    { get; set; }
        bool IsOnGround  { get; set; }
        bool IsDead      { get; set; }

    #endregion

    #region Public Methods

        bool CanMoving();

    #endregion
    }
}