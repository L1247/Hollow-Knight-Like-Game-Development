using DDDCore;
using DDDCore.Model;
using Main.Systems;
using Main.Controller;
using Main.EventHandler.View;
using Main.Input;
using Main.Input.Event;
using Main.Input.Events;
using Main.Presenters;
using Main.System;
using Main.UseCases.Actor.Create;
using Main.UseCases.Actor.Edit;
using Main.UseCases.Repository;
using Main.ViewComponent.Events;
using UnityEngine;
using Zenject;

namespace Main.Application
{
    public class BattleBinder : MonoInstaller
    {
        [SerializeField]
        private bool isNetworking;

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
            Container.Bind<DomainEventBus>().AsSingle();
            // EventHandler
            Container.Bind<ViewEventHandler>().AsSingle().NonLazy();
            // Controller
            Container.Bind<ActorContoller>().AsSingle();
            // Repository
            Container.Bind<ActorRepository>().AsSingle();
            Container.Bind<iSoRepository>().To<SoRepository>().AsSingle();
            // UseCases
            Container.Bind<CreateActorUseCase>().AsSingle();
            Container.Bind<ChangeDirectionUseCase>().AsSingle();
            Container.Bind<DealDamageUseCase>().AsSingle();
            Container.Bind<MakeActorDieUseCase>().AsSingle();
            // View
            Container.Bind<ActorMapper>().AsSingle();
            // Input
            Container.BindInterfacesAndSelfTo<InputManager>().AsSingle();
            if (isNetworking)
            {
                // NetworkManager
                Container.InstantiateComponentOnNewGameObject<NetworkingManager>();
                Container.Bind<IActorSpawner>().To<NetworkingActorSpawner>().AsSingle();
            }
            else
            {
                Container.Bind<IActorSpawner>().To<ActorSpawner>().AsSingle();
            }
        }

    #endregion
    }
}