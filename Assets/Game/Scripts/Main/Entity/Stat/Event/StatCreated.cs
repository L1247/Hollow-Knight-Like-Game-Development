#region

using DDDCore.Model;

#endregion

namespace Main.Entity.Event
{
    public class StatCreated : DomainEvent
    {
    #region Public Variables

        public int    Amount;
        public string ActorId;
        public string StatName;

    #endregion

    #region Constructor

        public StatCreated(string actorId , string statName , int amount)
        {
            ActorId  = actorId;
            StatName = statName;
            Amount   = amount;
        }

    #endregion
    }
}