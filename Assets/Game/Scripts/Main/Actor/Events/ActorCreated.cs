using DDDCore.Model;

namespace Main.Actor.Events
{
    public class ActorCreated : DomainEvent
    {
    #region Public Variables

        public string ActorDataId { get; }

        public string ActorId { get; }

    #endregion

    #region Constructor

        public ActorCreated(string actorId , string actorDataId)
        {
            ActorId          = actorId;
            ActorDataId = actorDataId;
        }

    #endregion
    }
}