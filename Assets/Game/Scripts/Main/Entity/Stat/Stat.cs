#region

using DDDCore.Model;
using Main.Entity.Event;

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

        public void Create()
        {
            AddDomainEvent(new StatCreated(ActorId , Name , Amount));
        }

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