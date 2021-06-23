using DDDCore.Model;
using Entity.Events;

namespace Entity
{
    public class Actor : AggregateRoot
    {
    #region Public Variables

        public bool IsDead { get; private set; }

        public int    Direction   { get; private set; }
        public int    Health      { get; private set; }
        public string ActorDataId { get; }

    #endregion

    #region Constructor

        public Actor(string actorId , string actorDataId , int health) : base(actorId)
        {
            ActorDataId = actorDataId;
            Health      = health;
            Direction   = 1;
            AddDomainEvent(new ActorCreated(GetId() , ActorDataId , Direction));
        }

    #endregion

    #region Public Methods

        public void ChangeDirection(int direction)
        {
            Direction = direction;
            AddDomainEvent(new DirectionChanged(GetId() , Direction));
        }

        public void DealDamage(int damage)
        {
            Health -= damage;
            AddDomainEvent(new DamageDealt(GetId() , Health));
        }

        public void MakeDie()
        {
            IsDead = true;
        }

    #endregion
    }
}