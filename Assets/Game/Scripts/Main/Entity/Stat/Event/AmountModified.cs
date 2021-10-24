#region

using DDDCore.Model;

#endregion

namespace Main.Entity.Event
{
    public class AmountModified : DomainEvent
    {
    #region Public Variables

        public int    Amount   { get; }
        public string ActorId  { get; }
        public string StatName { get; }

    #endregion

    #region Constructor

        public AmountModified(string actorId , string statName , int amount)
        {
            ActorId  = actorId;
            StatName = statName;
            Amount   = amount;
        }

    #endregion
    }
}