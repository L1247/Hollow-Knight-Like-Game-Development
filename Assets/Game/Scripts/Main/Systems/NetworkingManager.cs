using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

namespace Main.Systems
{
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