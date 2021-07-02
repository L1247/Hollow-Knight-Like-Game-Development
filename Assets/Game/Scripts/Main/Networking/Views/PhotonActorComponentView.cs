using Main.ViewComponent;
using Photon.Pun;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Main.Networking.Views
{
    public class PhotonActorComponentView : MonoBehaviourPun , IPunObservable
    {
        private PhotonView photonView;

        [SerializeField]
        [Required]
        private ActorComponent actorComponent;

        void Awake()
        {
            photonView = GetComponent<PhotonView>();
        }

        public void OnPhotonSerializeView(PhotonStream stream , PhotonMessageInfo info)
        {
            if (stream.IsWriting)
            {
                stream.SendNext(actorComponent.currentDirectionValue);
                stream.SendNext(actorComponent.GetCurrentAnimation());
            }
            else
            {
                var directionValue = (int)stream.ReceiveNext();
                actorComponent.SetDirection(directionValue);

                var animationName = (string)stream.ReceiveNext();
                if (string.IsNullOrEmpty(animationName) == false)
                    actorComponent.PlayAnimation(animationName);
            }
        }
    }
}