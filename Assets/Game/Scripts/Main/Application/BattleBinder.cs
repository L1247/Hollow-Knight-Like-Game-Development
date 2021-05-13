using DDDCore;
using DDDCore.Model;
using Main.EventHandler.View;
using Main.UseCases.Actor.Create;
using Main.UseCases.Repository;
using UnityEngine.UIElements;
using Zenject;

namespace Main.Application
{
    public class BattleBinder : MonoInstaller
    {
        public override void InstallBindings()
        {
            // Event
            SignalBusInstaller.Install(Container);
            Container.DeclareSignal<DomainEvent>();
            Container.Bind<EventStore>().AsSingle().NonLazy();
            Container.Bind<DomainEventBus>().AsSingle();
            // EventHandler
            Container.Bind<ViewEventHandlerActor>().AsSingle().NonLazy();
            // Repository
            Container.Bind<ActorRepository>().AsSingle();
            // UseCases
            Container.Bind<CreateActorUseCase>().AsSingle();
        }
    }
}