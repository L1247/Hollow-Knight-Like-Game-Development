using DDDCore;
using DDDCore.Model;
using UnityEngine.UIElements;
using Zenject;

namespace Main.Application
{
    public class BattleBinder : MonoInstaller
    {
        public override void InstallBindings()
        {
            SignalBusInstaller.Install(Container);
            Container.DeclareSignal<DomainEvent>();
            Container.Bind<EventStore>().AsSingle().NonLazy();
            Container.Bind<DomainEventBus>().AsSingle();
        }
    }
}