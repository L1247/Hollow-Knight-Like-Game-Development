using DDDCore;
using Main.Actor.Events;
using Main.Presenters;
using UnityEngine;

namespace Main.EventHandler.View
{
    public class ViewEventHandlerActor : DDDCore.EventHandler
    {
        public ViewEventHandlerActor(EventStore eventStore , ActorPresenter actorPresenter) : base(eventStore)
        {
            Register<ActorCreated>(actorPresenter.OnActorCreated);
        }
    }
}