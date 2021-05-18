using UnityEngine;
using UnityEngine.UI;

namespace Main.ViewComponent
{
    public class ActorComponent : MonoBehaviour
    {
    #region Public Variables

        public int currentDirectionValue;

        public Text text_IdAndDataId;

        public Transform Rednerer;

    #endregion

    #region Private Variables

        private readonly int moveSpeed = 5;

        private Transform _transform;

        [SerializeField]
        private Animator animator;

    #endregion

    #region Public Methods

        public void SetDirection(int directionValue)
        {
            currentDirectionValue = directionValue;
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

    #region Private Methods

        private void Awake()
        {
            _transform = transform;
        }

        private void MoveCharacter()
        {
            var directionValue = currentDirectionValue == 1 ? Vector3.right : Vector3.left;
            var movement       = directionValue * moveSpeed * Time.deltaTime;
            _transform.position += movement;
        }

        private void Update()
        {
            MoveCharacter();
        }

    #endregion
    }
}