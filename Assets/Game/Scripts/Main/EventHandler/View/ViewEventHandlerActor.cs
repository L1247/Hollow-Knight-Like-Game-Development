using DDDCore;
using Main.Actor.Events;
using Main.Entity.Model.Events;
using Main.Presenters;

namespace Main.EventHandler.View
{
    public class ViewEventHandlerActor : DDDCore.EventHandler
    {
    #region Constructor

        public ViewEventHandlerActor(EventStore eventStore , ActorPresenter actorPresenter) : base(eventStore)
        {
            Register<ActorCreated>(actorPresenter.OnActorCreated);
            Register<DirectionChanged>(actorPresenter.OnDirectionChanged);
        }

    #endregion
    }
}