#region

using DDDCore.Model;

#endregion

namespace Main.Entity
{
    public class Stat : AggregateRoot
    {
    #region Public Variables

        public int    Amount  { get; private set; }
        public string ActorId { get; private set; }

        public string Name { get; private set; }

    #endregion

    #region Constructor

        public Stat(string id) : base(id) { }

    #endregion

    #region Public Methods

        public void SetActorId(string actorId)
        {
            ActorId = actorId;
        }

        public void SetAmount(int amount)
        {
            Amount = amount;
        }

        public void SetName(string statName)
        {
            Name = statName;
        }

    #endregion
    }
}