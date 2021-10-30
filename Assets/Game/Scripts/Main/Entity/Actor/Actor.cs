#region

using DDDCore.Model;
using Entity.Events;

#endregion

namespace Entity
{
    public class Actor : AggregateRoot
    {
    #region Public Variables

        public bool   IsDead      { get; private set; }
        public int    Direction   { get; private set; }
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

    #region Public Methods

        public void ChangeDirection(int direction)
        {
            if (IsDead) return;
            Direction = direction;
            AddDomainEvent(new DirectionChanged(GetId() , Direction));
        }

        public void DealDamage(int damage)
        {
            // AddDomainEvent(new DamageDealt(GetId() , Health));
        }

        public void MakeDie()
        {
            IsDead = true;
            AddDomainEvent(new ActorDead(GetId()));
        }

    #endregion
    }
}