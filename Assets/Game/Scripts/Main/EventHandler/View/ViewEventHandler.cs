using DDDCore;
using Entity.Events;
using Main.Input.Event;
using Main.Input.Events;
using Main.Presenters;
using Main.ViewComponent.Events;

namespace Main.EventHandler.View
{
    public class ViewEventHandler : DDDCore.EventHandler
    {
    #region Constructor

        public ViewEventHandler(EventStore eventStore , ActorPresenter actorPresenter) : base(eventStore)
        {
            var signalBus = eventStore.signalBus;
            // domain event
            Register<ActorCreated>(created => { actorPresenter.OnActorCreated(created.ActorId , created.ActorDataId , created.Direction); });
            Register<DirectionChanged>(changed => { actorPresenter.OnDirectionChanged(changed.ActorId , changed.Direction); });
            Register<DamageDealt>(damageDealt => { actorPresenter.OnDamageDealt(damageDealt.ActorId , damageDealt.CurrentHealth); });


            // some view event
            signalBus.Subscribe<InputHorizontal>(actorPresenter.OnHorizontalChanged);
            signalBus.Subscribe<ButtonDownJump>(actorPresenter.OnButtonDownJump);
            signalBus.Subscribe<ButtonDownAttack>(actorPresenter.OnButtonDownAttack);
            signalBus.Subscribe<HitboxTriggered>(actorPresenter.OnHitboxTriggered);
        }

    #endregion
    }
}