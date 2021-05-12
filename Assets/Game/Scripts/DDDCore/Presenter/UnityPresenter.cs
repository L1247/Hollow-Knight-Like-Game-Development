using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
#if UniRx
using UniRx;
#endif

namespace DDDCore.Adapter.Presenter.Unity
{
    public class UnityPresenter : MonoBehaviour
    {
    #region Private Variables

        protected List<ButtonBinding> buttonBindings = new List<ButtonBinding>();

    #endregion

    #region Public Methods

        public virtual void SetUp() { }

    #endregion

    #region Protected Methods

        protected void ButtonBinding(Button button , Action action)
        {
        #if UniRx
            button.OnClickAsObservable().Subscribe(_ => action()).AddTo(button.gameObject);
        #else
            var buttonBinding = new ButtonBinding(button , action);

            buttonBindings.Add(buttonBinding);
            button.onClick.AddListener(() => action());
        #endif
        }

        protected virtual void OnDestroy()
        {
            buttonBindings.ForEach(binding => binding.RemoveOnClickListener());
        }

    #endregion
    }

    public class ButtonBinding
    {
    #region Private Variables

        private Action Action { get; }
        private Button Button { get; }

    #endregion

    #region Public Methods

        public void RemoveOnClickListener()
        {
            Button.onClick.RemoveListener(() => Action());
        }

    #endregion

        public ButtonBinding(Button button , Action action)
        {
            Button = button;
            Action = action;
        }
    }
}