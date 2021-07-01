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
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
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
            // NetworkManager
            Container.InstantiateComponentOnNewGameObject<NetworkingManager>();
        }

    #endregion
    }

    public class NetworkingManager : MonoBehaviourPunCallbacks
    {
        public void Start()
        {
            var playerName = "Player " + Random.Range(1000 , 10000);
            PhotonNetwork.LocalPlayer.NickName = playerName;
            PhotonNetwork.ConnectUsingSettings();
            Debug.Log($"Connecting is Start");
        }

        public override void OnConnectedToMaster()
        {
            Debug.Log($"OnConnectedToMaster");
            JoinOrCreatePrivateRoom("TestRoom");
        }

        public void JoinOrCreatePrivateRoom(string nameEveryFriendKnows)
        {
            RoomOptions roomOptions = new RoomOptions();
            roomOptions.IsVisible  = false;
            roomOptions.MaxPlayers = 4;
            PhotonNetwork.JoinOrCreateRoom(nameEveryFriendKnows , roomOptions , TypedLobby.Default);
        }

        public override void OnJoinRoomFailed(short returnCode , string message)
        {
            Debug.LogErrorFormat("Room creation failed with error code {0} and error message {1}" , returnCode ,
                                 message);
        }

        public override void OnJoinedRoom()
        {
            // joined a room successfully, JoinOrCreateRoom leads here on success
            Debug.Log($"OnJoinedRoom");
        }
    }
}