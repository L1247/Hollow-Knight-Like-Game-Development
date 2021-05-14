using System;
using DDDCore.Model;
using Main.Actor.Events;

namespace Main.Actor
{
    public class Actor : AggregateRoot
    {
    #region Public Variables

        public string ActorDataId { get; }
        public string ActorId     { get; }

    #endregion

    #region Constructor

        public Actor(string actorId , string actorDataId) : base(actorId)
        {
            ActorId     = actorId == null ? Guid.NewGuid().ToString() : actorId;
            ActorDataId = actorDataId;
            AddDomainEvent(new ActorCreated(ActorId , ActorDataId));
        }

    #endregion
    }
}