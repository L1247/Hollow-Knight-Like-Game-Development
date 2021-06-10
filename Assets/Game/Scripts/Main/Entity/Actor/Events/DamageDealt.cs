using DDDCore.Model;

namespace Entity.Events
{
    public class DamageDealt : DomainEvent
    {
    #region Public Variables

        public int    CurrentHealth;
        public string ActorId;

    #endregion

    #region Constructor

        public DamageDealt(string actorId , int currentHealth)
        {
            ActorId       = actorId;
            CurrentHealth = currentHealth;
        }

    #endregion
    }
}