using DDDCore.Model;

namespace Main.Entity.Model.Events
{
    public class ActorCreated : DomainEvent
    {
    #region Public Variables

        public int Direction { get; }

        public string ActorDataId { get; }

        public string ActorId { get; }

    #endregion

    #region Constructor

        public ActorCreated(string actorId , string actorDataId , int direction)
        {
            ActorId     = actorId;
            ActorDataId = actorDataId;
            Direction   = direction;
        }

    #endregion
    }
}