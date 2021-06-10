using System;
using DDDCore.Model;

namespace Entity.Builder
{
    public class ActorBuilder : AbstractBuilder<ActorBuilder , Actor>
    {
    #region Private Variables

        private int health;

        private string actorDataId;
        private string actorId;

    #endregion

    #region Public Methods

        public override Actor Build()
        {
            actorId = actorId == null ? Guid.NewGuid().ToString() : actorId;
            var actor = new Actor(actorId , actorDataId , health);
            return actor;
        }

        public ActorBuilder SetActorDataId(string actorDataId)
        {
            this.actorDataId = actorDataId;
            return this;
        }

        public ActorBuilder SetActorId(string actorId)
        {
            this.actorId = actorId;
            return this;
        }

        public ActorBuilder SetHealth(int health)
        {
            this.health = health;
            return this;
        }

    #endregion
    }
}