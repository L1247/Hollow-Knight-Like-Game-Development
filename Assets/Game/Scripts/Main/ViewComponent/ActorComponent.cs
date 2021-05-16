using UnityEngine;
using UnityEngine.UI;

namespace Main.ViewComponent
{
    public class ActorComponent : MonoBehaviour
    {
    #region Public Variables

        public Text text_IdAndDataId;

    #endregion

    #region Private Variables

        [SerializeField]
        private Animator animator;

    #endregion

    #region Public Methods

        public void SetText(string displayText)
        {
            text_IdAndDataId.text = displayText;
        }

    #endregion
    }
}