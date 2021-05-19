using DDDCore;
using Main.Actor.Events;
using Main.Entity.Model.Events;
using Main.Input;
using Main.Presenters;

namespace Main.EventHandler.View
{
    public class ViewEventHandlerActor : DDDCore.EventHandler
    {
    #region Constructor

        public ViewEventHandlerActor(EventStore eventStore , ActorPresenter actorPresenter) : base(eventStore)
        {
            var signalBus = eventStore.signalBus;
            Register<ActorCreated>(actorPresenter.OnActorCreated);
            Register<DirectionChanged>(actorPresenter.OnDirectionChanged);
            signalBus.Subscribe<Input_Horizontal>(actorPresenter.OnHorizontalChanged);
            signalBus.Subscribe<ButtonDownJump>(actorPresenter.OnButtonDownJump);
            signalBus.Subscribe<ButtonDownAttack>(actorPresenter.OnButtonDownAttack);
        }

    #endregion
    }
}