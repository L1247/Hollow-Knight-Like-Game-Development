using DDDCore.Model;
using Main.Entity.Model.Events;

namespace Main.Entity.Model
{
    public class Actor : AggregateRoot
    {
    #region Public Variables

        public int Direction { get; }

        public string ActorDataId { get; }

    #endregion

    #region Constructor

        public Actor(string actorId , string actorDataId) : base(actorId)
        {
            ActorDataId = actorDataId;
            Direction   = 1;
            AddDomainEvent(new ActorCreated(GetId() , ActorDataId , Direction));
        }

    #endregion
    }
}