using System;
using DDDCore.Model;

namespace Main.Entity.Model
{
    public class ActorBuilder : AbstractBuilder<ActorBuilder , Actor>
    {
    #region Private Variables

        private string actorDataId;
        private string actorId;

    #endregion

    #region Public Methods

        public override Actor Build()
        {
            actorId = actorId == null ? Guid.NewGuid().ToString() : actorId;
            var actor = new Actor(actorId , actorDataId);
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

    #endregion
    }
}