#region

using DDDCore.Model;

#endregion

namespace Main.Entity
{
    public interface IStat : IAggregateRoot
    {
    #region Public Variables

        int    Amount  { get; }
        string ActorId { get; }
        string Name    { get; }

    #endregion

    #region Public Methods

        void SetActorId(string actorId);
        void SetAmount(int     amount);
        void SetName(string    statName);

    #endregion
    }
}