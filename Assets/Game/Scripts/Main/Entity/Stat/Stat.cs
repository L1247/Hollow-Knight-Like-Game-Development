#region

using DDDCore.Model;
using Main.Entity.Event;

#endregion

namespace Main.Entity
{
    public class Stat : AggregateRoot , IStat
    {
    #region Public Variables

        public int    Amount  { get; private set; }
        public string ActorId { get; private set; }

        public string Name { get; private set; }

    #endregion

    #region Private Variables

        private AmountModified amountModified;

    #endregion

    #region Constructor

        public Stat(string statId , string actorId , string statName , int amount) : base(statId)
        {
            ActorId = actorId;
            Name    = statName;
            Amount  = amount;
        }

    #endregion

    #region Public Methods

        public void Create()
        {
            AddDomainEvent(new StatCreated(ActorId , Name , Amount));
            amountModified = new AmountModified();
        }

        public void SetActorId(string actorId)
        {
            ActorId = actorId;
        }

        public void SetAmount(int amount)
        {
            Amount = amount;
            amountModified.Clear();
            amountModified.ActorId  = ActorId;
            amountModified.Amount   = amount;
            amountModified.StatName = Name;
            AddDomainEvent(amountModified);
        }

        public void SetName(string statName)
        {
            Name = statName;
        }

    #endregion
    }
}