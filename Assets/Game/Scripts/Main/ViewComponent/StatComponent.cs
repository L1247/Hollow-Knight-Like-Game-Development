#region

using UnityEngine;
using UnityEngine.UI;

#endregion

namespace Main.ViewComponent
{
    public class StatComponent : MonoBehaviour
    {
    #region Private Variables

        [SerializeField]
        private Text text;

    #endregion

    #region Public Methods

        public void SetText(string statName , int amount)
        {
            text.text = $"{statName}:{amount}";
        }

    #endregion
    }
}