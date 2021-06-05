using DDDCore.Model;

namespace Entity.Events
{
    public class DirectionChanged : DomainEvent
    {
    #region Public Variables

        public int    Direction;
        public string ActorId;

    #endregion

    #region Constructor

        public DirectionChanged(string actorId , int direction)
        {
            ActorId   = actorId;
            Direction = direction;
        }

    #endregion
    }
}