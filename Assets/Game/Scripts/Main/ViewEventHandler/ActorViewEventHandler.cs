#region

using DDDCore;
using Entity.Events;
using Main.Input.Event;
using Main.Input.Events;
using Main.Presenters;
using Main.ViewComponent.Events;
using Zenject;

#endregion

namespace Main.EventHandler.View
{
    public class ActorViewEventHandler : DDDCore.EventHandler
    {
    #region Constructor

        public ActorViewEventHandler(SignalBus      signalBus , IDomainEventBus domainEventBus ,
                                     ActorPresenter actorPresenter) : base(
            domainEventBus)
        {
            handlerType = HandlerType.View;

            // domain event
            Register<ActorCreated>(created =>
            {
                actorPresenter.OnActorCreated(created.ActorId , created.ActorDataId ,
                                              created.Direction);
            });
            Register<DirectionChanged>(changed =>
            {
                actorPresenter.OnDirectionChanged(changed.ActorId , changed.Direction);
            });
            Register<ActorDead>(dead => { actorPresenter.OnActorDead(dead.ActorId); });

            // some view event
            signalBus.Subscribe<InputHorizontal>(actorPresenter.OnHorizontalChanged);
            signalBus.Subscribe<ButtonDownJump>(actorPresenter.OnButtonDownJump);
            signalBus.Subscribe<ButtonDownAttack>(actorPresenter.OnButtonDownAttack);
            signalBus.Subscribe<HitboxTriggered>(actorPresenter.OnHitboxTriggered);
        }

    #endregion
    }
}