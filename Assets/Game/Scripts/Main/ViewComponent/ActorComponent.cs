using UnityEngine;
using UnityEngine.UI;

namespace Main.ViewComponent
{
    public class ActorComponent : MonoBehaviour
    {
    #region Public Variables

        public Text text_IdAndDataId;

        public Transform Rednerer;

    #endregion

    #region Private Variables

        [SerializeField]
        private Animator animator;

    #endregion

    #region Public Methods

        public void ChangeDirection(int directionValue)
        {
            var x = 0;

            if (directionValue == 0) x = 1;
            if (directionValue == 1) x = -1;
            Rednerer.transform.localScale = new Vector3(x , 1 , 1);
        }

        public void SetText(string displayText)
        {
            text_IdAndDataId.text = displayText;
        }

    #endregion
    }
}