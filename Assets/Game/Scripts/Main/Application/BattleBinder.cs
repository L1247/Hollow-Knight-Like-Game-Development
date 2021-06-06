using DDDCore;
using DDDCore.Model;
using Main.Controller;
using Main.EventHandler.View;
using Main.Input;
using Main.Input.Event;
using Main.Input.Events;
using Main.Presenters;
using Main.UseCases.Actor.Create;
using Main.UseCases.Actor.Edit;
using Main.UseCases.Repository;
using Main.ViewComponent.Events;
using Zenject;

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
            Container.Bind<EventStore>().AsSingle().NonLazy();
            Container.Bind<DomainEventBus>().AsSingle();
            // EventHandler
            Container.Bind<ViewEventHandler>().AsSingle().NonLazy();
            // Controller
            Container.Bind<ActorContoller>().AsSingle();
            // Repository
            Container.Bind<ActorRepository>().AsSingle();
            // UseCases
            Container.Bind<CreateActorUseCase>().AsSingle();
            Container.Bind<ChangeDirectionUseCase>().AsSingle();
            // View
            Container.Bind<ActorMapper>().AsSingle();
            // Input
            Container.BindInterfacesAndSelfTo<InputManager>().AsSingle();
        }

    #endregion
    }
}