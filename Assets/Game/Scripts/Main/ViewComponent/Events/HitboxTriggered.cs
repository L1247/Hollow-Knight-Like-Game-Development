namespace Main.ViewComponent.Events
{
    public class HitboxTriggered
    {
    #region Public Variables

        public ActorComponent TriggerActorComponent { get; }

    #endregion

    #region Constructor

        public HitboxTriggered(ActorComponent triggerActorComponent)
        {
            TriggerActorComponent = triggerActorComponent;
        }

    #endregion
    }
}