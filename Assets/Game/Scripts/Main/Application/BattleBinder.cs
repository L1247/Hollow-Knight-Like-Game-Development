#region

using DDDCore;
using DDDCore.Model;
using Main.Controller;
using Main.DomainEventHandler;
using Main.EventHandler.View;
using Main.GameDataStructure;
using Main.Input;
using Main.Input.Event;
using Main.Input.Events;
using Main.Presenters;
using Main.UseCases.Actor.Create;
using Main.UseCases.Actor.Edit;
using Main.UseCases.Repository;
using Main.ViewComponent.Events;
using Zenject;

#endregion

namespace Main.Application
{
    public class BattleBinder : MonoInstaller
    {
    #region Public Methods

        public override void InstallBindings()
        {
            // Event
            SignalBusInstaller.Install(Container);
            Container.DeclareSignal<DomainEvent>();
            Container.DeclareSignal<InputHorizontal>();
            Container.DeclareSignal<ButtonDownJump>();
            Container.DeclareSignal<ButtonDownAttack>();
            Container.DeclareSignal<rAnimationEvent>();
            Container.DeclareSignal<HitboxTriggered>();
            Container.Bind<EventStore>().AsSingle().NonLazy();
            Container.Bind<IDomainEventBus>().To<DomainEventBus>().AsSingle();
            // EventHandler
            Container.Bind<ViewEventHandler>().AsSingle().NonLazy();
            Container.Bind<NotifyStat>().AsSingle().NonLazy();
            // Controller
            Container.Bind<ActorController>().AsSingle();
            // Repository
            Container.Bind<ActorRepository>().AsSingle();
            Container.Bind<IDataRepository>().To<DataRepository>().AsSingle();
            // UseCases
            Container.Bind<CreateActorUseCase>().AsSingle();
            Container.Bind<ChangeDirectionUseCase>().AsSingle();
            Container.Bind<MakeActorDieUseCase>().AsSingle();
            // View
            Container.Bind<ActorMapper>().AsSingle();
            // Input
            Container.BindInterfacesAndSelfTo<InputManager>().AsSingle();
        }

    #endregion
    }
}