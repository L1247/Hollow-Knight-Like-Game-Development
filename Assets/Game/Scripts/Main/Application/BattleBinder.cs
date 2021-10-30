#region

using DDDCore;
using DDDCore.Model;
using DDDCore.Usecase;
using Main.Controller;
using Main.DomainEventHandler;
using Main.Entity;
using Main.EventHandler.View;
using Main.GameDataStructure;
using Main.Input;
using Main.Input.Event;
using Main.Input.Events;
using Main.Presenters;
using Main.UseCases.Actor.Create;
using Main.UseCases.Actor.Edit;
using Main.UseCases.Repository;
using Main.UseCases.Stat;
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
            BindEventHandlers();
            BindControllers();
            BindRepositories();
            BindUseCases();
            // View
            Container.Bind<ActorMapper>().AsSingle();
            // Input
            Container.BindInterfacesAndSelfTo<InputManager>().AsSingle();
        }

    #endregion

    #region Private Methods

        private void BindControllers()
        {
            Container.Bind<ActorController>().AsSingle();
            Container.Bind<StatController>().AsSingle();
        }

        private void BindEventHandlers()
        {
            Container.Bind<ActorViewEventHandler>().AsSingle().NonLazy();
            Container.Bind<StatViewEventHandler>().AsSingle().NonLazy();
            Container.Bind<NotifyStat>().AsSingle().NonLazy();
        }

        private void BindRepositories()
        {
            Container.Bind<ActorRepository>().AsSingle();
            var statRepository = new StatRepository();
            Container.Bind<IRepository<IStat>>().To<StatRepository>().FromInstance(statRepository).AsCached();
            Container.Bind<IStatRepository>().To<StatRepository>().FromInstance(statRepository).AsCached();
            Container.Bind<IDataRepository>().To<DataRepository>().AsSingle();
        }

        private void BindUseCases()
        {
            // actor
            Container.Bind<CreateActorUseCase>().AsSingle();
            Container.Bind<ChangeDirectionUseCase>().AsSingle();
            Container.Bind<MakeActorDieUseCase>().AsSingle();
            // stat
            Container.Bind<CreateStatUseCase>().AsSingle();
            Container.Bind<ModifyAmountUseCase>().AsSingle();
        }

    #endregion
    }
}