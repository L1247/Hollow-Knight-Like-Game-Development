namespace Main.DomainData
{
    public interface IActorData
    {
    #region Public Variables

        int Atk    { get; }
        int Health { get; }

        string ActorDataId { get; }

    #endregion
    }
}