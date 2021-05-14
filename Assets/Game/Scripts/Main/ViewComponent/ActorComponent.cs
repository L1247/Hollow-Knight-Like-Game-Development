using UnityEngine;
using UnityEngine.UI;

namespace Main.ViewComponent
{
    public class ActorComponent : MonoBehaviour
    {
    #region Public Variables

        public SpriteRenderer spriteRenderer;
        public Text           text_IdAndDataId;

    #endregion

    #region Public Methods

        public void SetSprite(Sprite sprite)
        {
            spriteRenderer.sprite = sprite;
        }

        public void SetText(string displayText)
        {
            text_IdAndDataId.text = displayText;
        }

    #endregion
    }
}