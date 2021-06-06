namespace Main.ViewComponent.Events
{
    public class rAnimationEvent
    {
    #region Public Variables

        public string EventId { get; }

    #endregion

    #region Constructor

        public rAnimationEvent(string eventId)
        {
            EventId = eventId;
        }

    #endregion
    }
}