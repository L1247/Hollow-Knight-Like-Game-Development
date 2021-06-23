using DDDCore.Model;

namespace Entity.Events
{
    public class ActorDead : DomainEvent
    {
    #region Public Variables

        public string ActorId;

    #endregion

    #region Constructor

        public ActorDead(string actorId)
        {
            ActorId = actorId;
        }

    #endregion
    }
}