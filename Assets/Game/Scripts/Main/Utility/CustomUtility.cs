using UnityEngine;

namespace Main.Utility
{
    public static class CustomUtility
    {
    #region Public Methods

        public static Sprite CreateSprite()
        {
            var texture = new Texture2D(32 , 32);
            var sprite = Sprite.Create(texture , new Rect(0 , 0 , 32 , 32)
                , new Vector2(16 , 16));
            return sprite;
        }

    #endregion
    }
}