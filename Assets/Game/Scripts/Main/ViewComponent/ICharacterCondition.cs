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
}