namespace Main.Actor
{
    public class Actor
    {
    #region Public Variables

        public string ActorDataId { get; }
        public string ActorId     { get; }

    #endregion

    #region Constructor

        public Actor(string actorId , string actorDataId)
        {
            ActorId          = actorId;
            ActorDataId = actorDataId;
        }

    #endregion
    }
}