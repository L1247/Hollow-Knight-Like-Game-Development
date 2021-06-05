using DDDCore;
using Entity.Events;
using Main.Input;
using Main.Presenters;
using Main.ViewComponent;

namespace Main.EventHandler.View
{
    public class ViewEventHandler : DDDCore.EventHandler
    {
    #region Constructor

        public ViewEventHandler(EventStore eventStore , ActorPresenter actorPresenter) : base(eventStore)
        {
            var signalBus = eventStore.signalBus;
            Register<ActorCreated>(actorPresenter.OnActorCreated);
            Register<DirectionChanged>(actorPresenter.OnDirectionChanged);
            signalBus.Subscribe<Input_Horizontal>(actorPresenter.OnHorizontalChanged);
            signalBus.Subscribe<ButtonDownJump>(actorPresenter.OnButtonDownJump);
            signalBus.Subscribe<ButtonDownAttack>(actorPresenter.OnButtonDownAttack);
            signalBus.Subscribe<rAnimationEvent>(actorPresenter.OnAnimationTriggered);
        }

    #endregion
    }
}