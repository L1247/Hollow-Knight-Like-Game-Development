#region

using DDDCore.Model;

#endregion

namespace Main.Entity.Event
{
    public class AmountModified : DomainEvent
    {
    #region Public Variables

        public int    Amount   { get; set; }
        public string ActorId  { get; set; }
        public string StatName { get; set; }

    #endregion

    #region Public Methods

        public void Clear()
        {
            Amount   = -999;
            ActorId  = null;
            StatName = null;
        }

    #endregion
    }
}